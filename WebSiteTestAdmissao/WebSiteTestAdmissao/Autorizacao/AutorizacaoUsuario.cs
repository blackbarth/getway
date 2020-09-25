using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebSiteTestAdmissao.Autorizacao
{
    public class AutorizacaoUsuario : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly LoginUser _loginUser;

        public AutorizacaoUsuario()
        {
            
        }

        public AutorizacaoUsuario(LoginUser login)
        {
            _loginUser = login;
        }
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //var usuario = filterContext.HttpContext.User;
            var usuario = _loginUser.GetUsuario();
            if (usuario == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
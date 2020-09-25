using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace WebSiteTestAdmissao.Autorizacao
{
    public class AutorizacaoUsuario : ActionFilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
          
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            LoginUser _loginUser =  new LoginUser();
            //var usuario = filterContext.HttpContext.User;
            var usuario = _loginUser.GetUsuario();

            if (usuario == null)
            {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "Login" },
                        { "controller", "Home" }
                    });
            }
        }
    }
}
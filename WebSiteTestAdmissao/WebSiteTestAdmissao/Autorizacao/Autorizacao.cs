using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebSiteTestAdmissao.Autorizacao
{
    public class Autorizacao : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var usuario = filterContext.HttpContext.User;
            if (usuario == null || !usuaruio.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
using System.Web.Mvc;
using WebSiteTestAdmissao.Autorizacao;
using WebSiteTestAdmissao.Model;

namespace WebSiteTestAdmissao.Controller
{
    public class HomeController : System.Web.Mvc.Controller
    {
        private UserRepository respository = new UserRepository();


        // GET: Home
        [AutorizacaoUsuario]
        public ActionResult Index()
        {
            return View(respository.GetAll());
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                var login = respository.LoginUser(usuario.Nome, usuario.Senha);

                if (login != null)
                {
                    LoginUser _loginUser = new LoginUser();
                    _loginUser.Salvar(login);
                    return RedirectToAction("Index");

                }

                else return View(usuario);
            }
            else
            {
                return View(usuario);
            }
        }


        public ActionResult Novo()
        {
            return View();
        }
        // POST: Home/Novo
        [HttpPost]
        public ActionResult Novo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                respository.Save(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        // GET: Home/Editar/5
        public ActionResult Editar(int codigo)
        {
            var user = respository.GetById(codigo);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Home/Editar/5
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                respository.Update(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        // POST: Home/Excluir/5
        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            respository.DeleteById(codigo);
            return Json(respository.GetAll());
        }
    }
}
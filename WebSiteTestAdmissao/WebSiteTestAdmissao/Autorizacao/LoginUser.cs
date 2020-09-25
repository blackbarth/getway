using Newtonsoft.Json;
using WebSiteTestAdmissao.Model;

namespace WebSiteTestAdmissao.Autorizacao
{
    public class LoginUser
    {
        private static string key = "Login.Usuario";
        public void Salvar(Usuario usuario)
        {
            //Serealizando
            string utilizadorString = JsonConvert.SerializeObject(usuario);
            Sessoes.Inserir(key, utilizadorString);
        }

        public Usuario GetUsuario()
        {
            if (Sessoes.Existe(key))
            {
                //Deserealizando
                string utilizadorString = Sessoes.Consultar(key);
                return JsonConvert.DeserializeObject<Usuario>(utilizadorString);
            }
            else
            {
                return null;
            }

        }

        public Usuario GetLogin()
        {
            if (Sessoes.Existe(key))
            {
                //Deserealizando
                string utilizadorString = Sessoes.Consultar(key);
                return JsonConvert.DeserializeObject<Usuario>(utilizadorString);
            }
            else
            {
                return null;
            }

        }

        public static void Loguot()
        {
            Sessoes.RemoverTodos();
        }
    }
}
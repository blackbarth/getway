namespace WebSiteTestAdmissao.Autorizacao
{
    public static class Sessoes
    {

        //CRUD - cadastrar|atualizar|consultar|removerTodos|Existe
        public static void Inserir(string key, string value)
        {
            System.Web.HttpContext.Current.Session[key] = value;
        }

        public static void Atualizar(string key, string value)
        {
            if (Existe(key))
            {
                System.Web.HttpContext.Current.Session.Remove(key);
            }

            System.Web.HttpContext.Current.Session[key] = value;

        }
        public static void Remover(string key)
        {
            System.Web.HttpContext.Current.Session.Remove(key);
        }

        public static string Consultar(string key)
        {
            return System.Web.HttpContext.Current.Session[key].ToString();

        }

        public static bool Existe(string key)
        {
#pragma warning disable CS0219 // The variable 'retorno' is assigned but its value is never used
            bool retorno = false;
#pragma warning restore CS0219 // The variable 'retorno' is assigned but its value is never used
            if (System.Web.HttpContext.Current.Session[key] != null)
            {
                return true;
            }

            return false;
        }

        public static void RemoverTodos()
        {
            System.Web.HttpContext.Current.Session.Clear();
        }

    }
}
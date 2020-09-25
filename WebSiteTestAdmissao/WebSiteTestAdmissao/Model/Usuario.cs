using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSiteTestAdmissao.Model
{
    public class Usuario
    {
        [DisplayName("Código")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Nome de usuário precisa ter no minimo 3 letras")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        [MinLength(6,ErrorMessage = "Senha precisa ter no minimo 6 caracteres")]
        [Required(ErrorMessage = "O Senha do usuário é obrigatório", AllowEmptyStrings = false)]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
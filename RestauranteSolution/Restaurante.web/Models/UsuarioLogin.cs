using Restaurante.modelos;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.web.Models
{
    public class UsuarioLogin
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Usuario ParaUsuario()
        {
            var usr = new Usuario();
            usr.UsuarioLogin = Login;
            usr.UsuarioSenha = Senha;

            return usr;
        }
    }
}
using Restaurante.modelos;
using System.Web;

namespace Restaurante.web.Sessao
{
    public class GerenciadorDeSessao
    {
        private HttpContextBase HttpContext { get; set; }
        
        
        private string KeySessionUser = "RestauranteSessionUser";

        public GerenciadorDeSessao(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }
        
        public void GuardaUsuario(Usuario usuario)
        {
            HttpContext.Session[KeySessionUser] = usuario;
        }

        public Usuario PegaUsuario()
        {
            return ((Usuario)HttpContext.Session[KeySessionUser]);
        }

        public bool ValidaSessao()
        {
            return true;
        }
    }
}
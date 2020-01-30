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
            return HttpContext.Session[KeySessionUser] as Usuario;
        }

        public bool ValidaSessao()
        {
            return true;
        }
    }
}
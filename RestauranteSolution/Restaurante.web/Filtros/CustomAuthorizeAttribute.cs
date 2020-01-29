using Restaurante.modelos;
using Restaurante.web.Sessao;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurante.web.Filtros
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(string[] perfis)
        {
            foreach (var perfil in perfis)
            {
                Roles += perfil.ToString().ToUpper() + ",";
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var gSessao = new GerenciadorDeSessao(httpContext);

            if (gSessao.ValidaSessao())
            {
                var usuario = gSessao.PegaUsuario();

                if (!string.IsNullOrEmpty(this.Roles))
                {
                    return UserIsInRoles(usuario);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                 new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Login" },
                        { "area", ""}
                    });
        }

        private bool UserIsInRoles(Usuario usuario)
        {
            //if (this.Roles.Contains(usuario.UsuarioPerfil))
            if (this.Roles.Contains("usuario"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
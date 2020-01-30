using Restaurante.modelos;
using Restaurante.utilidades;
using Restaurante.web.Sessao;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurante.web.Filtros
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params Perfis[] perfis)
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

                if (usuario == null)
                {
                    return false;
                }

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
            var perfil = (Perfis)usuario.UsuarioPerfil;
            if (this.Roles.Contains(perfil.ToString().ToUpper()))
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
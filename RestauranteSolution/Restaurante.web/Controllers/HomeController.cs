using Restaurante.utilidades;
using Restaurante.web.Filtros;
using System.Web.Mvc;

namespace Restaurante.web.Controllers
{
    [CustomAuthorize(Perfis.Administrador)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refeicoes()
        {
            return View();
        }

        public ActionResult Porcoes()
        {
            return View();
        }
    }
}
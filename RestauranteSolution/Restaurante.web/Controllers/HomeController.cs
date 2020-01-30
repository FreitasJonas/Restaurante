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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
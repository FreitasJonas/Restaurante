using Restaurante.access;
using Restaurante.modelos;
using Restaurante.utilidades;
using Restaurante.web.Filtros;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Restaurante.web.Controllers
{
    [CustomAuthorize(Perfis.Administrador)]
    public class HomeController : Controller
    {
        public IDao Db { get; }

        public HomeController(IDao db)
        {
            Db = db;
        }


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
            try
            {
                List<Porcao> porcores = Db.ListarPorcoes();


                return View();
            }
            catch (Exception e)
            {
                Log.GeraLog(e);
            }
        }
    }
}
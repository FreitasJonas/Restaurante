using Restaurante.access;
using Restaurante.modelos;
using Restaurante.utilidades;
using Restaurante.web.Filtros;
using Restaurante.web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Restaurante.web.Controllers
{
    [CustomAuthorize(Perfis.Administrador)]
    public class HomeController : Controller
    {
        private string MensagemDeErro = "Ocorreu um erro inesperado!";

        public IDao Db { get; }

        public HomeController(IDao db)
        {
            Db = db;
        }

        public ActionResult Index(string Erro = "", string Sucesso = "")
        {
            if (!string.IsNullOrEmpty(Erro))
            {
                ViewBag.Erro = Erro;
            }

            if (!string.IsNullOrEmpty(Sucesso))
            {
                ViewBag.Sucesso = Sucesso;
            }

            return View();
        }

        public ActionResult Refeicoes(string Erro = "", string Sucesso = "")
        {
            if (!string.IsNullOrEmpty(Erro))
            {
                ViewBag.Erro = Erro;
            }

            if (!string.IsNullOrEmpty(Sucesso))
            {
                ViewBag.Sucesso = Sucesso;
            }

            return View();
        }

        public ActionResult Porcoes(string Erro = "", string Sucesso = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(Erro))
                {
                    ViewBag.Erro = Erro;
                }

                if (!string.IsNullOrEmpty(Sucesso))
                {
                    ViewBag.Sucesso = Sucesso;
                }

                List<Porcao> porcoes = Db.ListarPorcoes();
                return View(porcoes);
            }
            catch (Exception e)
            {
                Log.GeraLog(e);
                return RedirectToAction("Index", new { Erro = MensagemDeErro });
            }
        }

        public ActionResult EditarPorcao(int PorcaoId)
        {
            try
            {
                Porcao porcao = Db.PegaPorcao(PorcaoId);
                PorcaoModel pModel = PorcaoModel.MapearParaModel(porcao);

                return View(pModel);
            }
            catch (Exception e)
            {
                Log.GeraLog(e);
                return RedirectToAction("Porcoes", new { Erro = MensagemDeErro });
            }
        }

        [HttpPost]
        public ActionResult EditarPorcao(PorcaoModel porcaoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Porcao porcao = porcaoModel.MapearParaObjeto(porcaoModel);
                    var resultado = Db.AtualizaPorcao(porcao);

                    return RedirectToAction("Porcoes", new { Sucesso = "Porção atualizada com sucesso!" });
                }
                else
                {
                    ModelState.AddModelError("Erro", "Preencha todos os campos corretamente!");
                    return View(porcaoModel);
                }
            }
            catch (Exception e)
            {
                Log.GeraLog(e);
                return RedirectToAction("Porcoes", new { Erro = MensagemDeErro });
            }
        }
    }
}
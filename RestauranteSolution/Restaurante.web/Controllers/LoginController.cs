using Restaurante.access;
using Restaurante.web.Models;
using Restaurante.web.Sessao;
using System;
using System.Web.Mvc;

namespace Restaurante.web.Controllers
{
    public class LoginController : Controller
    {
        public IDao Db { get; }

        public LoginController(IDao db)
        {
            Db = db;
        }

        public ActionResult Index(string erro = "")
        {
            if (!string.IsNullOrEmpty(erro))
            {
                ViewBag.LoginErro = erro;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioLogin usuario)
        {
            try
            {
                var usr = Db.ValidaUsuario(usuario.Login, usuario.Senha);

                if (usr != null)
                {
                    var sessao = new GerenciadorDeSessao(this.HttpContext);
                    sessao.GuardaUsuario(usr);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", new { erro = "Usuário ou senha inválido!" });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { erro = "Ocorreu um erro inesperado! " + e.Message });
            }            
        }
    }
}
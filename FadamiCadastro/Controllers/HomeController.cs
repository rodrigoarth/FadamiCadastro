using FadamiCadastro.Models;
using FadamiCadastro.ViewModels;
using FadamiCadastroInfra.Entities;
using FadamiCadastroInfra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FadamiCadastro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _service;
        private readonly IHttpContextAccessor _acesso;

        public HomeController(IHttpContextAccessor acesso,ILogger<HomeController> logger, IUsuarioService service)
        {
            _logger = logger;
            _service = service;
            _acesso = acesso;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin( LoginViewModel model)
        {
            try
            {
                Usuario? user = _service.VerificarLogin(model.Login, model.Senha);

                if (user == null)
                    throw new Exception("Dados Incorretos");

                _acesso.HttpContext.Session.SetString("UserName", user.Nome);
                _acesso.HttpContext.Session.SetString("UserMail", user.Login);
                return RedirectToAction("Index", "Listar");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Deslogar()
        {
            _acesso.HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using FadamiCadastro.ViewModels;
using FadamiCadastroInfra.Entities;
using FadamiCadastroInfra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FadamiCadastro.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _service;

        public CadastroController(ILogger<HomeController> logger, IUsuarioService service)
        {
            _logger = logger;
            _service = service;
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarUsuario(CadastroViewModel model)
        {
            try
            {
                Usuario? user = _service.Find(x => x.Login == model.Login);

                if (model.Senha != model.SenhaConfirmacao)
                    throw new Exception("A senhas não coincidem");

                if (user == null)
                {
                    Usuario novoUsuario = new()
                    {
                        Login = model.Login,
                        CPF = model.CPF,
                        Nome = model.Nome,
                        Senha = model.Senha,
                    };

                    _service.Insert(novoUsuario);
                    TempData["Success"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index", "Listar");
                }
                else
                {
                    TempData["Error"] = "Usuario já existente no sistema!";
                    return RedirectToAction("Index", "Cadastro");
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
               return RedirectToAction("Index", "Cadastro");
            }
        }
    }
}

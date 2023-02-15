using AutoMapper;
using FadamiCadastro.ViewModels;
using FadamiCadastroInfra.Entities;
using FadamiCadastroInfra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FadamiCadastro.Controllers
{
    public class ListarController : Controller
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        public ListarController(IMapper mapper, ILogger<HomeController> logger, IUsuarioService service)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            ListaUsuario usuarios = new()
            {
                Usuarios = _service.FindAll(x => true)
            };


            ListaUsuarioViewModel listaDeUsuarios = _mapper.Map<ListaUsuarioViewModel>(usuarios);

            return View(listaDeUsuarios);
        }
    }
}

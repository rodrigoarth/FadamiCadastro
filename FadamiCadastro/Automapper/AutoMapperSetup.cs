using AutoMapper;
using FadamiCadastro.ViewModels;
using FadamiCadastroInfra.Entities;

namespace Automapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<ListaUsuarioViewModel, ListaUsuario>();
            CreateMap<ListaUsuario, ListaUsuarioViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}

using FadamiCadastroInfra.Entities;
using Infra.Interfaces;

namespace FadamiCadastroInfra.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        public Usuario? VerificarLogin(string email, string senha);

    }
}

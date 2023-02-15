using FadamiCadastroInfra.Context;
using FadamiCadastroInfra.Entities;
using FadamiCadastroInfra.Interfaces;
using Infra.Repositories;

namespace FadamiCadastroInfra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PrincipalContext context) : base(context)
        {
        }
    }
}

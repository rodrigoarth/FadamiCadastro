using FadamiCadastroInfra.Entities;
using FadamiCadastroInfra.Interfaces;
using Infra.Interfaces;
using Infra.Services;

namespace FadamiCadastroInfra.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }

        public Usuario? VerificarLogin(string email, string senha)
        {
            Usuario? user = Find(x => x.Login == email);

            if (user == null)
            {
                return null;
            }

            if (user.BloqueioAtivo)
            {
                throw new Exception("Usuario Bloqueado");
            }

            if (user.Senha != senha)
            {
                if (user.QtdErros >= 3)
                {
                    user.BloqueioAtivo = true;
                    Update(user);
                }

                else
                {
                    user.QtdErros += 1;

                    Update(user);
                }
                return null;
            }

            if (user.QtdErros > 0)
            {
                user.QtdErros = 0;
                Update(user);
            }

            return user;
        }
    }
}

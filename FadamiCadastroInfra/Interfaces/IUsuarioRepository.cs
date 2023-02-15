using FadamiCadastroInfra.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FadamiCadastroInfra.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
    }
}

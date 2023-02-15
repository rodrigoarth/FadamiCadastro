using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FadamiCadastro.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Login { get; set; }

        public string? CPF { get; set; }

        public string? Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}

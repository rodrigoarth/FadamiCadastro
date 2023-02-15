using Microsoft.Build.Framework;

namespace FadamiCadastro.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}

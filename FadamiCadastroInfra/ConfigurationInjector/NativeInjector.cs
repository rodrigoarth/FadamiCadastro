using FadamiCadastroInfra.Interfaces;
using FadamiCadastroInfra.Repositories;
using FadamiCadastroInfra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Template.IoC
{
    public static class NativeInjector
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();

        }
    }
}
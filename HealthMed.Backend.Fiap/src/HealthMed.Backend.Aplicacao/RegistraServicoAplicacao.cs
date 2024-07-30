using HealthMed.Backend.Aplicacao.Contratos.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace HealthMed.Backend.Aplicacao
{
    public static class RegistraServicoAplicacao
    {
        public static IServiceCollection AddServicosAplicacao(this IServiceCollection services)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IHorarioService, HorarioService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();

            return services;
        }
    }
}


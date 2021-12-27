using LembreMeApi.Services;

namespace LembreMeApi.Infra
{
    public static class ServiceDi
    {
        public static void AddFactoryService(this IServiceCollection services)
        {
            // Serviços Disponíveis
            services.AddScoped<UsuarioService>();
            services.AddScoped<DespesaServices>();

            // Passagem do Provider para Construção da Fábrica de Serviços
            services.AddScoped(serviceProvider => new FactoryService(serviceProvider));                        
        }
    }
}

using LembreMeApi.Repository;

namespace LembreMeApi.Infra
{
    public static class RepositoryDi
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<UsuarioRepository>();
            services.AddTransient<DespesaRepository>();
        }
    }
}

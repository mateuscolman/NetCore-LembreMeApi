using Microsoft.EntityFrameworkCore;

namespace LembreMeApi.Models
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<InserirComSPModel> InserirComSP { get; set; }
        public DbSet<DespesaModel> Despesa { get; set; }

    }
}

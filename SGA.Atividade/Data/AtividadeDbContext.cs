using Microsoft.EntityFrameworkCore;

namespace SGA.Atividade.Data
{
    public class AtividadeDbContext : DbContext
    {
        public DbSet<Entities.Atividade> Atividades { get; set; }

        public AtividadeDbContext(DbContextOptions<AtividadeDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=SgaAtividade;Integrated Security=True;");

        }
    }
}

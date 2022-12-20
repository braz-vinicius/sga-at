using Microsoft.EntityFrameworkCore;

namespace SGA.Disciplina.Data
{
    public class DisciplinaDbContext : DbContext
    {
        public DbSet<Entities.Disciplina> Disciplinas { get; set; }

        public DisciplinaDbContext(DbContextOptions<DisciplinaDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=SgaDisciplina;Integrated Security=True;");

        }
    }
}

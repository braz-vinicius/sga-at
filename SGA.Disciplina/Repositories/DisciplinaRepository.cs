using Microsoft.EntityFrameworkCore;
using SGA.Common.Providers;

namespace SGA.Disciplina.Repositories
{
    public class DisciplinaRepository : SqlRepository<Entities.Disciplina, int>, IDisciplinaRepository
    {
        public DisciplinaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

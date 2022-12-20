using Microsoft.EntityFrameworkCore;
using SGA.Common.Providers;

namespace SGA.Atividade.Repositories
{
    public class AtividadeRepository : SqlRepository<Entities.Atividade, int>, IAtividadeRepository
    {
        public AtividadeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

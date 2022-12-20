using Microsoft.EntityFrameworkCore;
using SGA.Atividade.Data;
using SGA.Atividade.Repositories;

namespace SGA.Atividade.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepository repository;
        private readonly AtividadeDbContext dbContext;

        public AtividadeService(IAtividadeRepository repository, AtividadeDbContext dbContext)
        {
            this.repository = repository;
            this.dbContext = dbContext;
        }
        public IEnumerable<Entities.Atividade> RetrieveAllAtividades()
        {
            return repository.GetAll();
        }

        public Entities.Atividade GetAtividade(int id)
        {
            return repository.Get(x => x.Id == id);
        }

        public void CreateAtividade(Entities.Atividade value)
        {
            repository.CreateOrUpdate(value);
        }

        public void UpdateAtividade(int id, Entities.Atividade value)
        {
            repository.Update(value);
        }

        public void DeleteAtividade(int id)
        {
            repository.DeleteById(id);
        }

        public void UpdateAtividadesByDisciplinaNome(int disciplinaId, string newDisciplinaNome)
        {
           // var atividades = repository.FindWhere(x => x.DisciplinaId == disciplinaId);

            dbContext.Database.ExecuteSql($"UPDATE [Atividades] SET DisciplinaNome = {newDisciplinaNome} WHERE DisciplinaId = {disciplinaId}");
            //dbContext.SaveChanges();
            //foreach (var item in atividades)
            //{
            //    item.DisciplinaNome = newDisciplinaNome;
            //    repository.Update(item);
            //}

        }
    }
}

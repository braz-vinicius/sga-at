using SGA.Disciplina.Repositories;

namespace SGA.Disciplina.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository repository;

        public DisciplinaService(IDisciplinaRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteDisciplina(int id)
        {
            repository.DeleteById(id);
        }

        public void UpdateDisciplina(int id, Entities.Disciplina value)
        {
            repository.Update(value);
        }

        public void CreateDisciplina(Entities.Disciplina value)
        {
            repository.CreateOrUpdate(value);
        }

        public Entities.Disciplina GetDisciplina(int id)
        {
            return repository.Get(x => x.Id == id);
        }

        public IEnumerable<Entities.Disciplina> RetrieveAllDisciplinas()
        {
            return repository.GetAll();
        }
    }
}

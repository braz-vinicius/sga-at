namespace SGA.Disciplina.Services
{
    public interface IDisciplinaService
    {
        void CreateDisciplina(Entities.Disciplina value);
        void DeleteDisciplina(int id);
        Entities.Disciplina GetDisciplina(int id);
        IEnumerable<Entities.Disciplina> RetrieveAllDisciplinas();
        void UpdateDisciplina(int id, Entities.Disciplina value);
    }
}
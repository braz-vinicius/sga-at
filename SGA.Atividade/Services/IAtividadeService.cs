namespace SGA.Atividade.Services
{
    public interface IAtividadeService
    {
        void CreateAtividade(Entities.Atividade value);
        void DeleteAtividade(int id);
        Entities.Atividade GetAtividade(int id);
        IEnumerable<Entities.Atividade> RetrieveAllAtividades();
        void UpdateAtividade(int id, Entities.Atividade value);
        void UpdateAtividadesByDisciplinaNome(int disciplinaId, string newNome);
    }
}
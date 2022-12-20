using SGA.Common.Interfaces;

namespace SGA.Atividade.Entities
{
    public class Atividade : IEntity<int>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DisciplinaNome { get; set; }

        public int DisciplinaId { get; set; }


    }
}

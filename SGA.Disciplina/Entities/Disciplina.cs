using SGA.Common.Interfaces;

namespace SGA.Disciplina.Entities
{
    public class Disciplina : IEntity<int>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

    }
}

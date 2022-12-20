using SGA.Common.EventBus;

namespace SGA.Disciplina.IntegrationEvents.Events
{
    public record DisciplinaNomeChanged : IntegrationEvent
    {
        public int DisciplinaId { get; set; }

        public string NewNome { get; set; }


        public DisciplinaNomeChanged(int disciplinaId, string newNome)
        {
            DisciplinaId = disciplinaId;
            NewNome = newNome;
        }
    }
}

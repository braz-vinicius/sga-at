using SGA.Common.EventBus;

namespace SGA.Atividade.IntegrationEvents.Events
{
    public record DisciplinaNomeChanged : IntegrationEvent
    {
        public int DisciplinaId { get; set; }

        public string NewNome { get; set; }

        public string OldNome { get; set; }

        public DisciplinaNomeChanged(int disciplinaId, string newNome, string oldNome)
        {
            DisciplinaId = disciplinaId;
            NewNome = newNome;
            OldNome = oldNome;
        }
    }
}

using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using SGA.Disciplina.IntegrationEvents.Events;
using SGA.Disciplina.Services;
using System.Text;
using System.Text.Json;

namespace SGA.Disciplina.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService service;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            this.service = disciplinaService;
        }

        [HttpGet]
        public IEnumerable<Entities.Disciplina> Get()
        {
            return service.RetrieveAllDisciplinas();
        }

        [HttpGet("{id}")]
        public Entities.Disciplina Get(int id)
        {
            return service.GetDisciplina(id);
        }

        [HttpPost]
        public void Post([FromBody] Entities.Disciplina value)
        {
            service.CreateDisciplina(value);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Entities.Disciplina value)
        {
            try
            {
                service.UpdateDisciplina(id, value);
            }
            catch (Exception)
            {
                throw;
            }

            var messageEvent = new DisciplinaNomeChanged(id, value.Nome);
            var messageJson = JsonSerializer.Serialize(messageEvent, typeof(DisciplinaNomeChanged));
            var messageBody = Encoding.UTF8.GetBytes(messageJson);

            var client = new ServiceBusClient("Endpoint=sb://sgadornas.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gxI8TIBMZFf3fD9lT0hVO0oFb63kuzxPtzTR2htkc1w=;EntityPath=disciplina-nome-changed");
            var sender = client.CreateSender("disciplina-nome-changed");           

            var message = new ServiceBusMessage
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = new BinaryData(messageBody),
                Subject = "disciplina-nome-changed",
            };

            sender.SendMessageAsync(message)
                .GetAwaiter()
                .GetResult();

          

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteDisciplina(id);
        }
    }
}
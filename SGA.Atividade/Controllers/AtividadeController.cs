using Microsoft.AspNetCore.Mvc;
using SGA.Atividade.Services;

namespace SGA.Atividade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService service;

        public AtividadeController(IAtividadeService atividadeService)
        {
            this.service = atividadeService;
        }

        [HttpGet]
        public IEnumerable<Entities.Atividade> Get()
        {
            return service.RetrieveAllAtividades();
        }

        [HttpGet("{id}")]
        public Entities.Atividade Get(int id)
        {
            return service.GetAtividade(id);
        }

        [HttpPost]
        public void Post([FromBody] Entities.Atividade value)
        {
            service.CreateAtividade(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Atividade value)
        {
            service.UpdateAtividade(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteAtividade(id);
        }
    }
}
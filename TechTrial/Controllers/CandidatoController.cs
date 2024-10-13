using Microsoft.AspNetCore.Mvc;

namespace TechTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        public CandidatoController()
        {
        }

        [HttpGet(Name = "Candidatos")]
        public IEnumerable<object> Get()
        {
            return new object[] { new { Nome = "Candidato 1", Idade = 20 }, new { Nome = "Candidato 2", Idade = 30 } };
        }
    }
}

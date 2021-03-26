using Desafio.Business.Interfaces;
using Desafio.Dto;
using Microsoft.AspNetCore.Mvc;



namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        private readonly IQuestaoBusiness questaoBusiness;

        public QuestaoController(IQuestaoBusiness questaoBusiness)
        {
            this.questaoBusiness = questaoBusiness;
        }

        
        [HttpPost("1")]
        public IActionResult QuestaoUm(PrimeiraQuestaoDto request)
        {
            var response = questaoBusiness.PrimeiraQuestao(request);

            return Ok(response);
        }

        
        [HttpPost("2")]
        public IActionResult QuestaoDois(SegundaQuestaoDto request)
        {
            var response = questaoBusiness.SegundaQuestao(request);

            return Ok(response);
        }

        [HttpPost("3")]
        public IActionResult QuestaoTres(TerceiraQuestaoDto request)
        {
            var response = questaoBusiness.TerceiraQuestao(request);

            return Ok(response);
        }

        [HttpPost("4")]
        public IActionResult QuestaoQuatro(QuartaQuestaoDto request)
        {
            var response = questaoBusiness.QuartaQuestao(request);

            return Ok(response);
        }
    }
}

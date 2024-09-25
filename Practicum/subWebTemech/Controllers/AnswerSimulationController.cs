using Microsoft.AspNetCore.Mvc;
using subWebTemech.DTOs;
using subWebTemech.Services;
using System.Threading.Tasks;
using subWebTemech.Services.Interfaces;
using subWebTemech.Services;
namespace subWebTemech.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AnswerSimulationController : ControllerBase
    {
        
        private readonly IAnswerSimulationService answerService;

        public AnswerSimulationController(IAnswerSimulationService answerSimulationService)
        {
            answerService = answerSimulationService;
        }

        [HttpPost("ReceiveAnswer")]
        public async Task<IActionResult> ReceiveAnswer(int questionId, string? answerText)
        {
            await answerService.ReceiveAnswerAsync(questionId, answerText);
            return Ok();
        }

    }
}




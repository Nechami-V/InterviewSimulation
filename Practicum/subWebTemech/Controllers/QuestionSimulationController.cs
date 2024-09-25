using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;
using subWebTemech.Services.Interfaces;
using System.Threading.Tasks;

namespace subWebTemech.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QuestionSimulationController : ControllerBase
    {
        private readonly IQuestionSimulationService questionService;

        public QuestionSimulationController(IQuestionSimulationService questionSimulationService)
        {
            questionService = questionSimulationService;
        }

        [HttpGet("RetrievingQuestion")]
        public async Task<IActionResult> RetrievingQuestion()
        {
            var question = await questionService.RetrievingQuestionAsync();
            return Ok(question);
        }
    }

}

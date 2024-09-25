using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using subWebTemech.Services;
using subWebTemech.Services.Interfaces;
using subWebTemech.DTOs;

namespace subWebTemech.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InterviewSimulationController : ControllerBase
    {
        private readonly IInterviewSimulationService interviewService;

        public InterviewSimulationController(IInterviewSimulationService interviewSimulationService)
        {
            interviewService = interviewSimulationService;
        }

        [HttpGet("CreateNewInterview/{Id}")]
        public async Task<IActionResult> CreateNewInterview(int Id)
        {
            await interviewService.CreateNewInterviewAsync(Id);
            return Ok();
        }

        [HttpPut("GivingHint")]
        public async Task<IActionResult> GivingHint(int questionId)
        {
            var hint = await interviewService.GivingHintAsync(questionId);
            return Ok(hint);
        }

        [HttpGet("FeedbackAndScore")]
        public async Task<IActionResult> FeedbackAndScore()
        {
            var feedbackAndScore = await interviewService.FeedbackAndScoreAsync();
            return Ok(feedbackAndScore);
        }

        [HttpGet("userId")]
        public async Task<ActionResult<List<InterviewSimulationDTO>>> GetInterviewsByUserId(int userId)
        {
            var interviews = await interviewService.GetInterviewsByUserIdAsync(userId);
            if (interviews == null || !interviews.Any())
            {
                return NotFound();
            }

            return Ok(interviews);
        }
        [HttpGet("SaveToDatabase/{userId}")]
        public async Task<IActionResult> SaveToDatabase(int userId)
        {
            await interviewService.SaveToDatabaseAsync(userId);
            return Ok();
        }
    }
}

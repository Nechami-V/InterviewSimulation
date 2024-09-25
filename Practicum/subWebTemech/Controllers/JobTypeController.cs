using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;

namespace subWebTemech.Controllers
{
    [Route("api/JobType")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        IJobTypeService jobTypeService;
        public JobTypeController(IJobTypeService jobTypeService)
        {
            this.jobTypeService = jobTypeService;
        }
        // קבלת כל joptype
        [HttpGet("GetAllJobType")]
        public ActionResult GetAllJobType()
        {
            return Ok(jobTypeService.GetAllJobType());
        }
    }
}

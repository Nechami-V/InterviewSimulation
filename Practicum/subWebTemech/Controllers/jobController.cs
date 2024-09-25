using Microsoft.AspNetCore.Mvc;
using subWebTemech.Models;
using subWebTemech.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace subWebTemech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/Jobs/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllSubmittedJobs(int userId)
        {
            var jobs = await _jobService.GetAllSubmittedJobsAsync(userId);
            if (jobs == null)
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        // GET: api/Jobs/{jobId}
        [HttpGet("{jobId}")]
        public async Task<ActionResult<Job>> GetJobDetailsById(int jobId)
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaa"+jobId);
            var job = await _jobService.GetJobDetailsByIdAsync(jobId);
            Console.WriteLine(job);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }
    }
}



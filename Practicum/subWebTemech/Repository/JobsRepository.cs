using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using subWebTemech.Models;
using Microsoft.EntityFrameworkCore;

namespace subWebTemech.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private readonly subWebTemechDbContext _context;

        public JobsRepository(subWebTemechDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllSubmittedJobsAsync(int userId)
        {
            return await _context.Job
                .Where(job => job.UserProfileID == userId)
                .Include(job => job.JobSubCategorys)
                .Include(job => job.ExperienceLevel)
                .Include(job => job.Location)
                .Include(job => job.JobType)
                .ToListAsync();
        }

        public async Task<Job> GetJobDetailsByIdAsync(int jobId)
        {
            Console.WriteLine("hiiiiiiiiiiiiii");
            return await _context.Job
                .Include(job => job.JobSubCategorys)
                .Include(job => job.ExperienceLevel)
                .Include(job => job.Location)
                .Include(job => job.JobType)
                .FirstOrDefaultAsync(job => job.Id == jobId);
        }
    }
}

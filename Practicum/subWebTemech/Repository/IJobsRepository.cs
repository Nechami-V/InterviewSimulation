using System.Collections.Generic;
using System.Threading.Tasks;
using subWebTemech.Models;

namespace subWebTemech.Repository
{
    public interface IJobsRepository
    {
        Task<IEnumerable<Job>> GetAllSubmittedJobsAsync(int userId);
        Task<Job> GetJobDetailsByIdAsync(int jobId);
    }
}

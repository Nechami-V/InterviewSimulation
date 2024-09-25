using subWebTemech.DTOs;

namespace subWebTemech.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobDTO>> GetAllSubmittedJobsAsync(int userId);
        Task<JobDTO> GetJobDetailsByIdAsync(int jobId);
    }
}

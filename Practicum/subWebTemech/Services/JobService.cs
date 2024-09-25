using subWebTemech.Models;
using subWebTemech.Repository;
using subWebTemech.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace subWebTemech.Services
{
    public class JobService : IJobService
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly IMapper _mapper;

        public JobService(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper.Mapper>();
            });
            _mapper = config.CreateMapper();
        
        }

        public async Task<IEnumerable<JobDTO>> GetAllSubmittedJobsAsync(int userId)
        {
            var jobs = await _jobsRepository.GetAllSubmittedJobsAsync(userId);
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<JobDTO> GetJobDetailsByIdAsync(int jobId)
        {
            var job = await _jobsRepository.GetJobDetailsByIdAsync(jobId);
            return _mapper.Map<JobDTO>(job);
        }
    }
}

using subWebTemech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace subWebTemech.Repository
{
    public class JobTypeRepository : IJobTypeRepository
    {
        subWebTemechDbContext subWebTemechDb;

        public JobTypeRepository(subWebTemechDbContext subWebTemechDb)
        {
            this.subWebTemechDb = subWebTemechDb;
        }

        ILogger<string> logger;
        public JobTypeRepository(subWebTemechDbContext subWebTemechDb, ILogger<string> logger)
        {
            this.subWebTemechDb = subWebTemechDb;
            this.logger = logger;
        }
        public List<JobType> GetAllJobType()
        {
            return subWebTemechDb.JobType.ToList();
        }
    }
}

using subWebTemech.Models;
using subWebTemech.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace subWebTemech.Repository
{
    public class LocationRepository : ILocationRepository
    {

        subWebTemechDbContext subWebTemechDb;
        ILogger<string> logger;
        public LocationRepository(subWebTemechDbContext subWebTemechDb, ILogger<string> logger)
        {
            this.subWebTemechDb = subWebTemechDb;
            this.logger = logger;
        }
        public List<Location> GetAllLocation()
        {
            return subWebTemechDb.locations.ToList();

        }
    }
}

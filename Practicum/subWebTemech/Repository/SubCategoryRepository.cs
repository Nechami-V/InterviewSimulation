using subWebTemech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace subWebTemech.Repository
{
    public class SubCategoryRepository: ISubCategoryRepository
    {

        subWebTemechDbContext subWebTemechDb;
        ILogger<string> logger;
        public SubCategoryRepository(subWebTemechDbContext subWebTemechDb, ILogger<string> logger)
        {
            this.subWebTemechDb = subWebTemechDb;
            this.logger = logger;
        }

        public List<SubCategory> GetAllSubCategory()
        {
            return subWebTemechDb.SubCategory.ToList();
        }
    }
}

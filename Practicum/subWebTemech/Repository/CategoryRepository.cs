using subWebTemech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace subWebTemech.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        subWebTemechDbContext subWebTemechDb;
        ILogger<string> logger;
        public CategoryRepository(subWebTemechDbContext subWebTemechDb, ILogger<string> logger)
        {
            this.subWebTemechDb = subWebTemechDb;
            this.logger = logger;
        }

        public List<Category>  GetAllCategory()
        {
            return subWebTemechDb.Category.ToList();
        }
    }
}

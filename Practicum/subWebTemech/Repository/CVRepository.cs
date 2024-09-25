using Microsoft.EntityFrameworkCore;
using subWebTemech.Models;

namespace subWebTemech.Repository
{
    public class CVRepository : ICVRepository
    {
      private readonly subWebTemechDbContext subWebTemechDbContext;
        public CVRepository(subWebTemechDbContext subWebTemechDbContext)
        {
            this.subWebTemechDbContext = subWebTemechDbContext;
        }

        public async Task<List<CV>> GetAllResumesById(int id)
        {
            try
            {
                var usercvs = await subWebTemechDbContext.cVs.Where(p => p.CVId == id).ToListAsync();
                if (usercvs == null)
                {
                    return new List<CV>();
                }
                return usercvs;
            }
            catch (Exception ex)
            {
                return new List<CV>();
            }
        }
        //GetFavoriteResume: שליפת קובץ קורות החיים המסומן כמועדף.
        public async Task<CV> GetFavoriteResume(int id)
        {
            try
            {
                var favoriteCV = await subWebTemechDbContext.cVs.FirstOrDefaultAsync(x => x.CVId == id && x.Favorite);
                return favoriteCV;
            }
            catch (Exception ex)
            {
                return new CV();
            }
        }
        //SetFavoriteResume: סימון קובץ קורות חיים כמועדף.
        public async Task SetFavoriteResume(CV v, bool favorite)
        {
            try
            {
                v.Favorite = favorite;
                subWebTemechDbContext.cVs.Update(v);
                await subWebTemechDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
   




        public async Task<List<CV>> GetAllCV()
        {
            return await subWebTemechDbContext.cVs.ToListAsync();
        }

        public async Task<CV> GetCVById(int id)
        {
            return await subWebTemechDbContext.cVs.FindAsync(id);
        }

        public async Task<CV> GetRecentCV()
        {
            return await subWebTemechDbContext.cVs.OrderByDescending(cv => cv.UploadDate).FirstOrDefaultAsync();
        }

        public async Task<List<CV>> GetRecentCVs()
        {
            return await subWebTemechDbContext.cVs.OrderByDescending(cv => cv.UploadDate).ToListAsync();
        }

        public async Task AddCV(CV cv)
        {
            subWebTemechDbContext.cVs.Add(cv);
            await subWebTemechDbContext.SaveChangesAsync();
        }

        public async Task UpdateCV(CV cv)
        {
            subWebTemechDbContext.Entry(cv).State = EntityState.Modified;
            await subWebTemechDbContext.SaveChangesAsync();
        }

        public async Task DeleteCV(int id)
        {
            var cv = await subWebTemechDbContext.cVs.FindAsync(id);
            if (cv != null)
            {
                subWebTemechDbContext.cVs.Remove(cv);
                await subWebTemechDbContext.SaveChangesAsync();
            }
        }
    }
}

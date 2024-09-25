using Microsoft.EntityFrameworkCore;
using subWebTemech.DTOs;
using subWebTemech.Models;
using subWebTemech.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subWebTemech.Repository
{
    public class InterviewSimulationRepository : IInterviewSimulationRepository
    {
        private readonly subWebTemechDbContext context;

        public InterviewSimulationRepository(subWebTemechDbContext context)
        {
            this.context = context;
        }

        public async Task<List<InterviewSimulation>> GetAllInterviewsAsync()
        {
            return await context.InterviewSimulations
                .Include(i => i.User)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.QuestionSimulation)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.AnswerSimulation)
                .ToListAsync();
        }
        public async Task<List<InterviewSimulation>> GetInterviewsByUserIdAsync(int userId)
        {
            return await context.InterviewSimulations
                .Where(i => i.UserID == userId)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.QuestionSimulation)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.AnswerSimulation)
                .ToListAsync();
        }
        public async Task<UserProfile> GetProfileByUserIdAsync(int userId)
        {
            return await context.UserProfile
                .Include(up => up.CategoryProfiles)
                    .ThenInclude(cp => cp.CategorySubCategory)
                        .ThenInclude(csc => csc.Category)
                .Include(up => up.CategoryProfiles)
                    .ThenInclude(cp => cp.CategorySubCategory)
                        .ThenInclude(csc => csc.SubCategory)
                .Include(up => up.Jobs) // אם יש צורך גם בפרטי העבודה
                .FirstOrDefaultAsync(up => up.UserProfileID == userId);

        }

        public async Task<(List<string> CategoryNames, List<string> SubCategoryNames)> GetCategoryAndSubCategoryNamesByUserIdAsync(int userId)
        {
            var userProfile = await GetProfileByUserIdAsync(userId);
            var categoryNames = new List<string>();
            var subCategoryNames = new List<string>();
            if (userProfile != null)
            {
                foreach (var categoryProfile in userProfile.CategoryProfiles)
                {
                    var categoryName = categoryProfile.CategorySubCategory.Category.name;
                    var subCategoryName = categoryProfile.CategorySubCategory.SubCategory.Name;
                    categoryNames.Add(categoryName);
                    subCategoryNames.Add(subCategoryName);
                }
            }
            return (categoryNames, subCategoryNames);
        }


        public async Task<InterviewSimulation> GetInterviewByIdAsync(int id)
        {
            return await context.InterviewSimulations
                .Include(i => i.User)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.QuestionSimulation)
                .Include(i => i.QuestionAnswers)
                    .ThenInclude(qa => qa.AnswerSimulation)
                .FirstOrDefaultAsync(i => i.InterviewSimulationID == id);
        }

        public async Task UpdateInterviewAsync(InterviewSimulation interview)
        {
            context.InterviewSimulations.Update(interview);
            await context.SaveChangesAsync();
        }

        public async Task DeleteInterviewAsync(int id)
        {
            var interview = await context.InterviewSimulations.FindAsync(id);
            if (interview != null)
            {
                context.InterviewSimulations.Remove(interview);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddInterviewAsync(InterviewSimulation interview)
        {
            await context.InterviewSimulations.AddAsync(interview);
            await context.SaveChangesAsync();
        }
        public async Task<int> GetLastId()
        {
            var lastInterview = context.InterviewSimulations
                                        .OrderByDescending(i => i.InterviewSimulationID)
                                        .FirstOrDefault();
            return lastInterview?.InterviewSimulationID ?? 0;
        }
        
    }
}

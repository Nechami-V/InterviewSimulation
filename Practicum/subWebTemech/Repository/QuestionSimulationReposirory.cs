using Microsoft.EntityFrameworkCore;
using subWebTemech.Models;
using subWebTemech.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subWebTemech.Repository
{
    public class QuestionSimulationRepository : IQuestionSimulationRepository
    {
        private readonly subWebTemechDbContext context;

        public QuestionSimulationRepository(subWebTemechDbContext context)
        {
            this.context = context;
        }

        public async Task<List<QuestionSimulation>> GetAllQuestionsAsync()
        {
            return await context.QuestionAnswer
                .Include(qa => qa.QuestionSimulation)
                .Select(qa => qa.QuestionSimulation)
                .ToListAsync();
        }

        public async Task<QuestionSimulation> GetQuestionByIdAsync(int id)
        {
            return await context.QuestionAnswer
                .Include(qa => qa.QuestionSimulation)
                .Where(qa => qa.QuestionSimulationID == id)
                .Select(qa => qa.QuestionSimulation)
                .FirstOrDefaultAsync();
        }

        public async Task AddQuestionAsync(QuestionSimulation question)
        {
            await context.QuestionSimulations.AddAsync(question);
            await context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(QuestionSimulation question)
        {
            context.QuestionSimulations.Update(question);
            await context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var questionAnswer = await context.QuestionAnswer
                .Include(qa => qa.QuestionSimulation)
                .FirstOrDefaultAsync(qa => qa.QuestionSimulationID == id);

            if (questionAnswer != null)
            {
                context.QuestionAnswer.Remove(questionAnswer);
                await context.SaveChangesAsync();
            }
        }
        public async Task<int> GetLastId()
        {
            var lastQuestion = await context.QuestionSimulations
                .OrderByDescending(q => q.QuestionSimulationID)
                .FirstOrDefaultAsync();

            return lastQuestion?.QuestionSimulationID ?? 0;
        }

    }
}

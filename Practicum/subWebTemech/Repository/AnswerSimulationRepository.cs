using Microsoft.EntityFrameworkCore;
using subWebTemech.Models;
using subWebTemech.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subWebTemech.Repository
{
    public class AnswerSimulationRepository : IAnswerSimulationRepository
    {
        private readonly subWebTemechDbContext context;

        public AnswerSimulationRepository(subWebTemechDbContext context)
        {
            this.context = context;
        }

        public async Task<List<AnswerSimulation>> GetAllAnswersAsync()
        {
            return await context.QuestionAnswer
                .Include(qa => qa.AnswerSimulation)
                .Select(qa => qa.AnswerSimulation)
                .ToListAsync();
        }

        public async Task<AnswerSimulation> GetAnswerByIdAsync(int id)
        {
            return await context.QuestionAnswer
                .Include(qa => qa.AnswerSimulation)
                .Where(qa => qa.AnswerSimulationID == id)
                .Select(qa => qa.AnswerSimulation)
                .FirstOrDefaultAsync();
        }

        public async Task AddAnswerAsync(AnswerSimulation answer)
        {
            await context.AnswerSimulations.AddAsync(answer);
            await context.SaveChangesAsync();
        }


        public async Task UpdateAnswerAsync(AnswerSimulation answer)
        {
            context.AnswerSimulations.Update(answer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAnswerAsync(int id)
        {
            var questionAnswer = await context.QuestionAnswer
                .Include(qa => qa.AnswerSimulation)
                .FirstOrDefaultAsync(qa => qa.AnswerSimulationID == id);

            if (questionAnswer != null)
            {
                context.QuestionAnswer.Remove(questionAnswer);
                await context.SaveChangesAsync();
            }
        }
        public async Task<int> GetLastId()
        {
            var lastAnswer = await context.AnswerSimulations
                .OrderByDescending(q => q.AnswerSimulationID)
                .FirstOrDefaultAsync();

            return lastAnswer?.AnswerSimulationID ?? 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using subWebTemech.Models;
using subWebTemech.Repository.Interfaces;

namespace subWebTemech.Repository
{
         public class QuestionAnswerRepository : IQuestionAnswerRepository
        {
            private readonly subWebTemechDbContext _context;

            public QuestionAnswerRepository(subWebTemechDbContext context)
            {
                _context = context;
            }


            public async Task<IEnumerable<QuestionAnswer>> GetByInterviewIdAsync(int interviewId)
            {
                return await _context.QuestionAnswer
                    .Where(q => q.InterviewSimulationID == interviewId)
                    .ToListAsync();
            }

            public async Task<QuestionAnswer> GetByIdAsync(int id)
            {
                return await _context.QuestionAnswer.FindAsync(id);
            }

            public async Task UpdateAsync(QuestionAnswer questionAnswer)
            {
                _context.QuestionAnswer.Update(questionAnswer);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var questionAnswer = await _context.QuestionAnswer.FindAsync(id);
                if (questionAnswer != null)
                {
                    _context.QuestionAnswer.Remove(questionAnswer);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task SaveToDBAsync(QuestionAnswer questionAnswer)
            {
                _context.QuestionAnswer.Add(questionAnswer);
                await _context.SaveChangesAsync();
            }
    }

    
}

using subWebTemech.Models;

namespace subWebTemech.Repository.Interfaces
{
        public interface IQuestionAnswerRepository
        {
            Task<IEnumerable<QuestionAnswer>> GetByInterviewIdAsync(int interviewId);
            Task<QuestionAnswer> GetByIdAsync(int id);
            Task UpdateAsync(QuestionAnswer questionAnswer);
            Task DeleteAsync(int id);
            Task SaveToDBAsync(QuestionAnswer questionAnswer);

        }

    
}

using subWebTemech.DTOs;
using subWebTemech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace subWebTemech.Repository
{
    public interface IQuestionSimulationRepository
    {
        Task<List<QuestionSimulation>> GetAllQuestionsAsync();
        Task<QuestionSimulation> GetQuestionByIdAsync(int id);
        Task AddQuestionAsync(QuestionSimulation question);
        Task UpdateQuestionAsync(QuestionSimulation question);
        Task DeleteQuestionAsync(int id);
        Task<int> GetLastId();

    }
}

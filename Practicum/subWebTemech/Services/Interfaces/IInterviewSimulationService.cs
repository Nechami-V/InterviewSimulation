using subWebTemech.DTOs;
using subWebTemech.Models;

namespace subWebTemech.Services.Interfaces
{
    public interface IInterviewSimulationService
    {
        Task CreateNewInterviewAsync(int Id);
        Task<string> GivingHintAsync(int questionId);
        Task<List<AnswerSimulationDTO>> FeedbackAndScoreAsync();
        Task<List<InterviewSimulationDTO>> GetInterviewsByUserIdAsync(int userId);
        Task SaveToDatabaseAsync(int userId);
    }
}

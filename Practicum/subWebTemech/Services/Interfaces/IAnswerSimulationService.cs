using subWebTemech.DTOs;

namespace subWebTemech.Services.Interfaces
{
    public interface IAnswerSimulationService
    {
        Task<bool> ReceiveAnswerAsync(int questionId, string userAnswer);
    }
}



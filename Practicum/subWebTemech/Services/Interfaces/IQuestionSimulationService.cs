using subWebTemech.DTOs;

namespace subWebTemech.Services.Interfaces
{
    public interface IQuestionSimulationService
    {
        Task<QuestionSimulationDTO> RetrievingQuestionAsync();
    }
}


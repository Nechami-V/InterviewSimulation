using subWebTemech.Models;

namespace subWebTemech.Services.Interfaces
{
    public interface IGptService
    {
        Task<string[]> GetInterviewQuestionsAsync(UserProfile profile, (List<string> CategoryNames, List<string> SubCategoryNames) nameOfCategory);
        Task<bool> CheckIsCorrect(int questionId, string userAnswer);
        Task<string> GetLinks(int questionId);
        Task<string> GetHint(int questionId);
    }
}

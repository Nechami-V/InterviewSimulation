using subWebTemech.DTOs;
using subWebTemech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace subWebTemech.Repository.Interfaces
{
        public interface IInterviewSimulationRepository
        {
            Task<List<InterviewSimulation>> GetAllInterviewsAsync();
            Task<List<InterviewSimulation>> GetInterviewsByUserIdAsync(int userId);
            Task<InterviewSimulation> GetInterviewByIdAsync(int id);
            Task AddInterviewAsync(InterviewSimulation interview);
            Task UpdateInterviewAsync(InterviewSimulation interview);
            Task DeleteInterviewAsync(int id);
            Task<int> GetLastId();
            Task<UserProfile> GetProfileByUserIdAsync(int userId);
            Task<(List<string> CategoryNames, List<string> SubCategoryNames)> GetCategoryAndSubCategoryNamesByUserIdAsync(int userId);
        }
}


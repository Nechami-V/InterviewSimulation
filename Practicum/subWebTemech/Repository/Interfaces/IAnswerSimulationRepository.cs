using subWebTemech.Models;

namespace subWebTemech.Repository.Interfaces
{
        public interface IAnswerSimulationRepository
        {
            Task<List<AnswerSimulation>> GetAllAnswersAsync();
            Task<AnswerSimulation> GetAnswerByIdAsync(int id);
            Task AddAnswerAsync(AnswerSimulation answer);
            Task UpdateAnswerAsync(AnswerSimulation answer);
            Task DeleteAnswerAsync(int id);
            Task<int> GetLastId();

    }
}




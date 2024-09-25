using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using subWebTemech.DTOs;
using subWebTemech.Repository.Interfaces;
using subWebTemech.Services.Interfaces;
using AutoMapper;
using subWebTemech.Models;

namespace subWebTemech.Services.Interfaces
{
    public class AnswerSimulationService : IAnswerSimulationService
    {
        private readonly IDistributedCache _cache;
        private readonly IGptService _gptService;
        private readonly IAnswerSimulationRepository _answerRepository;


        public AnswerSimulationService(IDistributedCache cache, IGptService gptService, IAnswerSimulationRepository answerRepository, IMapper mapper)
        {
            _cache = cache;
            _gptService = gptService;
            _answerRepository = answerRepository;
        }

        public async Task<bool> ReceiveAnswerAsync(int questionId, string userAnswer)
        {
            
            if (questionId <= 0)
            {
                throw new ArgumentException("Invalid question ID.");
            }
            if (userAnswer == null)
            {
                userAnswer = "";
            }
            bool isCorrect = await _gptService.CheckIsCorrect(questionId, userAnswer);
            string cacheKey = $"Answer_{questionId}";

            var answerData = new AnswerSimulationDTO
            {
                AnswerText = userAnswer,
                IsCorrect = isCorrect,
                Links = ""
            };

            if (!isCorrect)
            {
                string links = await _gptService.GetLinks(questionId);
                answerData.Links = links;
            }
            SaveAnswerAsync(questionId, answerData.AnswerText, answerData.IsCorrect, answerData.Links);
            return isCorrect;
        }

            private async Task SaveAnswerAsync(int questionId, string answerText, bool isCorrect, string links)
            {
                await _cache.SetStringAsync($"Answer_{questionId}", answerText);
                await _cache.SetStringAsync($"IsCorrect_{questionId}", isCorrect.ToString());
                await _cache.SetStringAsync($"Links_{questionId}", links);
            }

    }
}



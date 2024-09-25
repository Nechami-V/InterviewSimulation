using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using subWebTemech.DTOs;
using subWebTemech.Repository;
using subWebTemech.Services.Interfaces;

namespace subWebTemech.Services
{
        public class QuestionSimulationService : IQuestionSimulationService
        {
            private readonly IDistributedCache _cache;
            private readonly IQuestionSimulationRepository _questionRepository;

            public QuestionSimulationService(IDistributedCache cache, IQuestionSimulationRepository questionRepository)
            {
                 _cache = cache;
                _questionRepository = questionRepository;
            }

            public async Task<QuestionSimulationDTO> RetrievingQuestionAsync()
            {
                var cachedQuestions = await _cache.GetStringAsync("Questions");
                if (string.IsNullOrEmpty(cachedQuestions))
                {
                    throw new Exception("No questions found in cache.");
                }

                var questions = JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions);

                var cachedIndex = await _cache.GetStringAsync("QuestionIndex");
                int currentIndex = string.IsNullOrEmpty(cachedIndex) ? 0 : int.Parse(cachedIndex);

                if (currentIndex >= questions.Count)
                {
                    throw new Exception("No more questions available.");
                }

                var question = questions[currentIndex];
                currentIndex++;

                await _cache.SetStringAsync("QuestionIndex", currentIndex.ToString(), new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });

                return question;
            }

        }    
}


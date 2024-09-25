using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using subWebTemech.DTOs;
using subWebTemech.Models;
using subWebTemech.Repository;
using subWebTemech.Repository.Interfaces;
using subWebTemech.Services;
using subWebTemech.Services.Interfaces;

using System.Text.Json;

public class InterviewSimulationService : IInterviewSimulationService
{
    private readonly IDistributedCache _cache;
    private readonly IGptService _gptService;
    private readonly IInterviewSimulationRepository _interviewSimulationRepository;
    private readonly IAnswerSimulationRepository _answerSimulationRepository;
    private readonly IQuestionSimulationRepository _questionSimulationRepository;
    private readonly IQuestionAnswerRepository _questionAnswerRepository;
    private readonly IUserService _userService;
    private HashSet<string> _cacheKeys;
    List<QuestionSimulationDTO> Interview = new List<QuestionSimulationDTO>();



    public InterviewSimulationService(IDistributedCache cache, IGptService gptService, IUserService userService, IQuestionSimulationRepository questionSimulationRepository, IAnswerSimulationRepository answerSimulationRepository, IInterviewSimulationRepository interviewSimulationRepository, IQuestionAnswerRepository questionAnswerRepository)
    {
        _userService = userService;
        _cache = cache;
        _gptService = gptService;
        _interviewSimulationRepository = interviewSimulationRepository;
        _answerSimulationRepository = answerSimulationRepository;
        _questionSimulationRepository = questionSimulationRepository;
        _questionAnswerRepository = questionAnswerRepository;
        _cacheKeys = new HashSet<string>(); 

    }

    public async Task CreateNewInterviewAsync(int Id)
    {
        var QuestionId = 1;
        int intrviewId = 0;

        UserProfile userProfile = await _interviewSimulationRepository.GetProfileByUserIdAsync(1);
        var nameOfCategory = await _interviewSimulationRepository.GetCategoryAndSubCategoryNamesByUserIdAsync(Id);
        string[] Questions = await _gptService.GetInterviewQuestionsAsync(userProfile, nameOfCategory);

        if (userProfile == null)
        {
            throw new Exception("User profile not found.");
        }

        if (userProfile.CategoryProfiles == null || userProfile.ExperienceLevel == null)
        {
            throw new Exception("Related entities are not loaded properly.");
        }
        Interview.Clear();
        await _cache.RemoveAsync("QuestionIndex");
        for(var i=1;i<=10;i++)
        {
            _cache.RemoveAsync($"Answer_{i}");
            _cache.RemoveAsync($"IsCorrect_{i}");
            _cache.RemoveAsync($"Hint_{i}");
            _cache.RemoveAsync($"Links_{i}");

        }

        foreach (var item in Questions)
        {
            Interview.Add(new QuestionSimulationDTO
            {
                QuestionText = item,
                QuestionSimulationID = QuestionId++,
            });
        }

        var cacheOptions = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(offset: TimeSpan.FromHours(1));
        await _cache.SetStringAsync("Questions", JsonSerializer.Serialize(Interview), cacheOptions);
        _cacheKeys.Add("Questions");
    }

    public async Task<string> GivingHintAsync(int questionId)
    {
        string hint = await _gptService.GetHint(questionId);

        await _cache.SetStringAsync($"Hint_{questionId}", hint);
        _cacheKeys.Add($"Hint_{ questionId}");

        return hint;
    }


    public async Task<List<AnswerSimulationDTO>> FeedbackAndScoreAsync()
    {
        var cachedQuestions = await _cache.GetStringAsync("Questions");
        if (string.IsNullOrEmpty(cachedQuestions))
        {
            throw new Exception("No questions found in cache.");
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        List<QuestionSimulationDTO>? questions;
        try
        {
            questions = JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions, options);
        }
        catch (JsonException ex)
        {
            throw new Exception("Failed to deserialize questions from cache.", ex);
        }

        var feedbackList = new List<AnswerSimulationDTO>();

        foreach (var question in questions)
        {
            string answerText = await _cache.GetStringAsync($"Answer_{question.QuestionSimulationID}");
            string links = await _cache.GetStringAsync($"Links_{question.QuestionSimulationID}");
            string hint = await _cache.GetStringAsync($"Hint_{question.QuestionSimulationID}");
            string stringisCorrect = await _cache.GetStringAsync($"IsCorrect_{question.QuestionSimulationID}");
            bool isCorrect = true;
            bool CheckCorrect = bool.TryParse(stringisCorrect, out isCorrect);
            if (!CheckCorrect)
            {
                isCorrect = false;
            }

            var answerSimulation = new AnswerSimulationDTO
            {
                AnswerSimulationID = question.QuestionSimulationID,
                AnswerText = answerText,
                IsCorrect = isCorrect,
                Links = links,
                Question = new QuestionSimulationDTO
                {
                    QuestionSimulationID = question.QuestionSimulationID,
                    QuestionText = question.QuestionText,
                    Hint = hint
                }
            };

            feedbackList.Add(answerSimulation);
        }
        var orderedFeedbackList = feedbackList.OrderBy(a => a.AnswerSimulationID).ToList();

        return orderedFeedbackList;
    }

    public async Task SaveToDatabaseAsync(int userId)
    {
        var user = await _interviewSimulationRepository.GetProfileByUserIdAsync(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} does not exist.");
        }

        var interview = new InterviewSimulation
        {
            InterviewSimulationDate = DateTime.Now,
            UserID = userId
        };

        try
        {
            await _interviewSimulationRepository.AddInterviewAsync(interview);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add interview to database.", ex);
        }

        var lastInterviewId = interview.InterviewSimulationID;
        if (lastInterviewId <= 0)
        {
            throw new Exception("Failed to retrieve the last interview ID.");
        }

        var cachedQuestions = await _cache.GetStringAsync("Questions");
        if (string.IsNullOrEmpty(cachedQuestions))
        {
            throw new Exception("No questions found in cache.");
        }

        List<QuestionSimulationDTO> questions = JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions);
        if (questions == null)
        {
            throw new Exception("Failed to deserialize questions from cache.");
        }

        foreach (var question in questions)
        {
            if (question == null)
            {
                throw new Exception("Question is null.");
            }

            string answerText = await _cache.GetStringAsync($"Answer_{question.QuestionSimulationID}");
            string links = await _cache.GetStringAsync($"Links_{question.QuestionSimulationID}");
            string hint = await _cache.GetStringAsync($"Hint_{question.QuestionSimulationID}");
            bool isCorrect = await _cache.GetStringAsync($"IsCorrect_{question.QuestionSimulationID}") == "true";

            var questionEntity = new QuestionSimulation
            {
                QuestionText = question.QuestionText,
                Hint = hint
            };

            try
            {
                await _questionSimulationRepository.AddQuestionAsync(questionEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add question {question.QuestionSimulationID} to database.", ex);
            }

            var lastQuestionId = questionEntity.QuestionSimulationID;
            if (lastQuestionId <= 0)
            {
                throw new Exception("Failed to retrieve the last question ID.");
            }

            var answerSimulation = new AnswerSimulation
            {
                AnswerText = answerText,
                IsCorrect = isCorrect,
                Links = links
            };

            try
            {
                await _answerSimulationRepository.AddAnswerAsync(answerSimulation);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add answer to database.", ex);
            }

            var lastAnswerId = answerSimulation.AnswerSimulationID;
            if (lastAnswerId <= 0)
            {
                throw new Exception("Failed to retrieve the last answer ID.");
            }

            var questionAnswer = new QuestionAnswer
            {
                QuestionSimulationID = lastQuestionId,
                AnswerSimulationID = lastAnswerId,
                InterviewSimulationID = lastInterviewId
            };

            try
            {
                await _questionAnswerRepository.SaveToDBAsync(questionAnswer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add question-answer relation to database.", ex);
            }
        }
    }
    public async Task<List<InterviewSimulationDTO>> GetInterviewsByUserIdAsync(int userId)
    {
        var interviews = await _interviewSimulationRepository.GetInterviewsByUserIdAsync(userId);

        if (!interviews.Any())
        {
            Console.WriteLine("No interviews found for user: " + userId);
            return new List<InterviewSimulationDTO>();
        }
        var interviewDTOs = interviews.Select(interview => new InterviewSimulationDTO
        {
            InterviewSimulationID = interview.InterviewSimulationID,
            InterviewSimulationDate = interview.InterviewSimulationDate,
            UserID = interview.UserID,
            Questions = interview.QuestionAnswers
         .GroupBy(qa => qa.QuestionSimulationID)
         .Select(group => new QuestionSimulationDTO
         {
             QuestionSimulationID = group.Key,
             QuestionText = group.First().QuestionSimulation.QuestionText,
             Hint = group.First().QuestionSimulation.Hint,
             Answer = group.Select(qa => new AnswerSimulationDTO
             {
                 AnswerSimulationID = qa.AnswerSimulation.AnswerSimulationID,
                 AnswerText = qa.AnswerSimulation.AnswerText,
                 IsCorrect = qa.AnswerSimulation.IsCorrect,
                 Links = qa.AnswerSimulation.Links
             }).FirstOrDefault()
         }).ToList()
        }).ToList();

        if (!interviewDTOs.Any())
        {
            Console.WriteLine("No interviewDTOs found for user: " + userId);
        }

        return interviewDTOs;
    }


}

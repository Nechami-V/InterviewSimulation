using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using DotNetEnv;
using subWebTemech.Models;
using System.Text.RegularExpressions;
using System.Net;
using subWebTemech.Services.Interfaces;
using System.Text.Json;
using subWebTemech.DTOs;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;
using subWebTemech.Repository;
using subWebTemech.Repository.Interfaces;

namespace subWebTemech.Services
{
    public class GptService : IGptService
    {
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _cache;
        private readonly string _apiKey;
        private readonly UserRepository _userRepository;
        public GptService(IDistributedCache cache, subWebTemechDbContext dbContext,IUserRepository Repository)
        {
            Env.Load();
            _httpClient = new HttpClient();
            _cache = cache;
            _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }
        public async Task<string[]> GetInterviewQuestionsAsync(UserProfile profile, (List<string> CategoryNames, List<string> SubCategoryNames) nameOfCategory)
        {
            if(profile == null)
            {
                throw new Exception("User profile not found");
            }
            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = $"You are an interviewer conducting a job interview in the field of {nameOfCategory.CategoryNames.First()}. Specialize mainly in {nameOfCategory.SubCategoryNames[0]}. Provide a list of 10 high-level interview questions on C# for a candidate with {profile.ExperienceLevel} years of experience. The questions should be in Hebrew. Return only the list of questions, with each question on a new line and no additional text or formatting." },
                    new { role = "user", content = $"Please provide 10 interview questions on {nameOfCategory.SubCategoryNames[1]} for a candidate with {profile.ExperienceLevel} experience. The questions should be in Hebrew , listed sequentially with each question on a new line. Do not include any numbering or additional text." }
                }
            };
            if (nameOfCategory.CategoryNames.Any() && nameOfCategory.SubCategoryNames.Count > 1)
            {

            }
            else
            {
                // Handle the case where the lists don't have the required elements
                Console.WriteLine("CategoryNames or SubCategoryNames don't have enough elements.");
            }

            var jsonContent = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            string questionsText = result.choices[0].message.content.ToString();
            string[] questionsArray = questionsText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            await _cache.SetStringAsync("Questions", questionsText);
            return questionsArray;
        }
        public async Task<bool> CheckIsCorrect(int questionId, string userAnswer)
        {
            string cachedQuestions = await _cache.GetStringAsync("Questions");
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
                questions = System.Text.Json.JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions, options);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception("Failed to deserialize questions from cache.", ex);
            }

            var question = questions.FirstOrDefault(q => q.QuestionSimulationID == questionId);
            if (question == null)
            {
                throw new Exception($"Question with ID {questionId} not found.");
            }

            string questionText = question.QuestionText;
            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You will receive a question and an answer. Check if the answer is correct. Return 'true' if the answer is more than 90% correct, otherwise return 'false'. The answers may be in Hebrew." },
                    new { role = "user", content = $"Question: {questionText}" },
                    new { role = "user", content = $"User's Answer: {userAnswer}" },
                    new { role = "user", content = "Is the user's answer correct? Return 'true' or 'false' only." }
                },
                max_tokens = 1
            };

            var jsonContent = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            string gptResponse = result.choices[0].message.content.ToString().Trim().ToLower();

            return gptResponse == "true";
        }
        public async Task<string> GetLinks(int questionId)
        {
            string cachedQuestions = await _cache.GetStringAsync("Questions");
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
                questions = System.Text.Json.JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions, options);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"Error deserializing  JSON: {ex.Message}");
                throw new Exception("Failed to deserialize questions from cache.", ex);
            }
            var question = questions.FirstOrDefault(q => q.QuestionSimulationID == questionId);
            if (question == null)
            {
                throw new Exception($"Question with ID {questionId} not found.");
            }
            string questionText = question.QuestionText;
            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are an assistant. You provide educational resources." },
                    new { role = "user", content = $"Question: {questionText}" },
                    new { role = "user", content = "Provide only one link to learn more about this topic." }
                },
                max_tokens = 150
            };
            var jsonContent = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            string linksText =  result.choices[0].message.content.ToString();

            List<string> links = ValidateLinks(linksText);
            string formattedLinks = string.Join(Environment.NewLine, links);

            return formattedLinks;
        }
        public async Task<string> GetHint(int questionId)
        {
            string cachedQuestions = await _cache.GetStringAsync("Questions");
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
                questions = System.Text.Json.JsonSerializer.Deserialize<List<QuestionSimulationDTO>>(cachedQuestions, options);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception("Failed to deserialize questions from cache.", ex);
            }

            var question = questions.FirstOrDefault(q => q.QuestionSimulationID == questionId);
            if (question == null)
            {
                throw new Exception($"Question with ID {questionId} not found.");
            }
            string questionText = question.QuestionText;

            var requestContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "You are an assistant. You provide hints for difficult questions. Provide hints in the same language as the question." },
                new { role = "user", content = $"Question: {questionText}" },
                new { role = "user", content= "Please provide a hint for the following question. Do not give the full answer. If the question is in Hebrew, provide the hint in Hebrew. If the question is in English, provide the hint in English. Return only the hint, with no additional text or explanation."}
    },
                max_tokens = 150
            };

            var jsonContent = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            return result.choices[0].message.content.ToString();
        }
        private List<string> ValidateLinks(string responseText)
        {
            var regex = new Regex(@"(http|https)://[^\s]+");
            var matches = regex.Matches(responseText);
            List<string> validLinks = new List<string>();
            foreach (Match match in matches)
            {
                string url = match.Value;
                if (IsValidUrl(url))
                {
                    validLinks.Add(url);
                }
            }
            return validLinks;
        }
        private bool IsValidUrl(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}


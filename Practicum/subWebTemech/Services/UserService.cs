using AutoMapper;
using subWebTemech.DTOs;
using subWebTemech.Models;
using subWebTemech.Repository;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using subWebTemech.Mapper;
using System.Security.Cryptography;
using subWebTemech.Repository.Interfaces;
using subWebTemech.Services.Interfaces;

namespace subWebTemech.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        IMapper mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            var config =
            new MapperConfiguration(cnf => cnf.AddProfile<subWebTemech.Mapper.Mapper>());
            mapper = config.CreateMapper();
            _configuration = configuration;

        }
        public async Task<bool> ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Match match = Regex.Match(email, pattern);
            return match.Success;
        }
        public async Task<string> HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public async Task<bool> AddNewUserByEmailAndPassword(string email, string password)
        {
            try
            {
                if (!await ValidateEmail(email) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }
                else
                {
                    var user = new UserDto
                    {
                        Email = email,
                        Password = await HashPassword(password)
                    };
                    var mapUser = mapper.Map<User>(user);
                    var answer = await userRepository.AddUserByEmailAndPasswordAsync(mapUser);
                    return answer;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ChangePassword(string email, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    return false;
                }
                var answer = await userRepository.UpdatePasswordToUser(email, await HashPassword(newPassword));
                return answer;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> ResetPassword(string email)
        {
            try
            {
                if (!await userRepository.IsUserExist(email))
                {
                    return false;
                }
                else
                {
                    var resetLink = GenerateResetLink(email);
                    SendResetEmail(email, resetLink);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string GenerateResetLink(string email)
        {
            return $" http://localhost:4200/forgetPassword";
        }

        private void SendResetEmail(string email, string resetLink)
        {
            var fromAddress = new MailAddress(_configuration["Smtp:FromAddress"], " Temech ");
            var toAddress = new MailAddress(email);
            string fromPassword = _configuration["Smtp:FromPassword"];
            const string subject = "קישור לאיפוס הסיסמא שלך";
            string body = $"Please reset your password by clicking the following link: {resetLink}";
            var smtp = new SmtpClient
            {
                Host = _configuration["Smtp:Host"],
                Port = int.Parse(_configuration["Smtp:Port"]),
                EnableSsl = bool.Parse(_configuration["Smtp:EnableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        public async Task<List<UserDto>> getAllUser()
        {
            try
            {
                var answer = await userRepository.GetAllUserAsync();
                return mapper.Map<List<UserDto>>(answer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var answer = await userRepository.GetUserByIdAsync(userId);

                return mapper.Map<UserDto>(answer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserDto> AddUserByEmailAndPassword(string email, string password)
        {
            try
            {
                if (!await ValidateEmail(email) || string.IsNullOrWhiteSpace(password))
                {
                    return null;
                }

                var userDto = new UserDto
                {
                    Email = email,
                    Password = await HashPassword(password)
                };

                var mapUser = mapper.Map<User>(userDto);

                User newUser = await userRepository.addNewUser(mapUser);
                UserDto mappedUserDto = mapper.Map<UserDto>(newUser);

                return mappedUserDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
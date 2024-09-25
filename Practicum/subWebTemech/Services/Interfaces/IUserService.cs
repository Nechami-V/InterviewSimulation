using subWebTemech.DTOs;

namespace subWebTemech.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ResetPassword(string email);
        Task<bool> AddNewUserByEmailAndPassword(string email, string password);
        Task<List<UserDto>> getAllUser();
        Task<bool> ChangePassword(string email, string password);
        Task<bool> ValidateEmail(string email);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<string> HashPassword(string password);
        Task<UserDto> AddUserByEmailAndPassword(string email, string password);


    }
}

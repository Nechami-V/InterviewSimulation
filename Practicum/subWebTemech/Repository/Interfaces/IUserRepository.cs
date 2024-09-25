using subWebTemech.Models;

namespace subWebTemech.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<bool> AddUserByEmailAndPasswordAsync(User entity);
        Task<bool> IsUserExist(string email);
        Task<bool> UpdatePasswordToUser(string email, string password);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> addNewUser(User entity);

    }
}

using Microsoft.EntityFrameworkCore;
using subWebTemech.Models;
using subWebTemech.Repository.Interfaces;

namespace subWebTemech.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly subWebTemechDbContext _context;
        public UserRepository(subWebTemechDbContext _context)
        {
            this._context = _context;
        }
        public async Task<bool> AddUserByEmailAndPasswordAsync(User entity)
        {
            try
            {
                if (!_context.users.Any(u => u.Email == entity.Email && u.Password == entity.Password))
                {
                    await _context.users.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<User>> GetAllUserAsync()
        {
            try
            {
                return await _context.users.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.users.FindAsync(userId);

        }
        public async Task<bool> IsUserExist(string email)
        {
            try
            {
                if (!_context.users.Any(u => u.Email == email)
                    && !string.IsNullOrEmpty(email))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdatePasswordToUser(string email, string password)
        {
            try
            {
                var user = _context.users.SingleOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    user.Password = password;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<User> addNewUser(User entity)
        {
            try
            {
                if (!_context.users.Any(u => u.Email == entity.Email && u.Password == entity.Password))
                {
                    await _context.users.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


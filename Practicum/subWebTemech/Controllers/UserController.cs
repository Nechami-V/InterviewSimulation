using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using subWebTemech.DTOs;
using subWebTemech.Services;
using subWebTemech.Services.Interfaces;

namespace subWebTemech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService user;
        public UserController(IUserService userService)
        {
            user = userService;
        }
        [HttpPost]
        [Route("/addUserByEmailAndPassword")]
        public async Task<bool> AddNewUser(string email, string password)
        {
            return await user.AddNewUserByEmailAndPassword(email, password);
        }
        [HttpPut]
        [Route("/UpdatePasswordToUser")]
        public async Task<bool> updatePassword(string email, string password)
        {
            return await user.ChangePassword(email, password);
        }
        [HttpGet]
        [Route("/GetAllUser")]
        public async Task<List<UserDto>> getAll()
        {
            return await user.getAllUser();
        }
        [HttpGet]
        [Route("/GetUserById")]
        public async Task<UserDto> getUserById(int IdUser)
        {
            return await user.GetUserByIdAsync(IdUser);
        }
        [HttpPost]
        [Route("/addUserByEmailAndPasswordReturnUser")]
        public async Task<UserDto> AddUser(string email, string password)
        {
            return await user.AddUserByEmailAndPassword(email, password);
        }
    }
}

      

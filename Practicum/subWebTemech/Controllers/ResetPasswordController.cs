using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;
using subWebTemech.Services.Interfaces;

namespace subWebTemech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        readonly IUserService user;
        public ResetPasswordController(IUserService userService)
        {
            user = userService;
        }
        [HttpPost]
        [Route("/SendEmailToResetPassword")]
        public async Task<bool> SendingEmailToResetPassword(string email)
        {
            return await user.ResetPassword(email);
        }
    }
}

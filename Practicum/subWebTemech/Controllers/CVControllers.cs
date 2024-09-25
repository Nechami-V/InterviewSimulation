using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using subWebTemech.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace subWebTemech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVControllers : ControllerBase
    {
        private readonly ICVDTO _cvDto;
        private readonly IConfiguration _configuration;
        private readonly subWebTemechDbContext _context;

        public CVControllers(IConfiguration configuration, subWebTemechDbContext context, ICVDTO cvDto)
        {
            _configuration = configuration;
            _context = context;
            _cvDto = cvDto;
        }

        public class CVRequest
        {
            public string Email { get; set; }
            public IFormFile CVFile { get; set; }
            public int CVId { get; set; }
        }

        [HttpPost]
        public IActionResult SendCV([FromForm] CVRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || request.CVFile == null)
            {
                return BadRequest("Email and CV file are required");
            }

            try
            {
                var senderName = GetSenderName(request.CVId);
                SendCVEmail(request.Email, request.CVFile, senderName);
                UpdateAmountOfCV(request.CVId);

                return Ok("CV sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private void SendCVEmail(string email, IFormFile cvFile, string senderName)
        {
            var fromAddress = new MailAddress(_configuration["Smtp:FromAddress"], senderName);
            string fromPassword = _configuration["Smtp:FromPassword"];
            const string subject = "Your CV";
            string body = "Attached is your CV";

            var smtp = new SmtpClient
            {
                Host = _configuration["Smtp:Host"],
                Port = int.Parse(_configuration["Smtp:Port"]),
                EnableSsl = bool.Parse(_configuration["Smtp:EnableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage()
            {
                From = fromAddress,
                Subject = subject,
                Body = body
            })
            {
                message.To.Add(email);

                using (var memoryStream = new MemoryStream())
                {
                    cvFile.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    var attachment = new Attachment(memoryStream, cvFile.FileName, cvFile.ContentType);
                    message.Attachments.Add(attachment);

                    smtp.Send(message);
                }
            }
        }

        private void UpdateAmountOfCV(int cvId)
        {
            var cv = _context.cVs.FirstOrDefault(c => c.CVId == cvId);
            if (cv != null)
            {
                cv.AmountOfCV++;
                _context.SaveChanges();
            }
        }

        private string GetSenderName(int cvId)
        {
            var cvInfo = (from cv in _context.cVs
                          join user in _context.users on cv.UserId equals user.Id
                          join userProfile in _context.UserProfile on user.Id equals userProfile.UserID
                          where cv.CVId == cvId
                          select new { user.Name, user.Email }).FirstOrDefault();

            return cvInfo?.Email ?? "Unknown Sender";
        }

        [HttpGet("GetAllResumesById")]
        public async Task<ActionResult> GetAllResumesById(int id)
        {
            var result = await _cvDto.GetAllResumesById(id);
            return Ok(result);
        }

        [HttpGet("GetFavoriteResume")]
        public async Task<ActionResult> GetFavoriteResume(int id)
        {
            var result = await _cvDto.GetFavoriteResume(id);
            return Ok(result);
        }

        [HttpPost("SetFavoriteResume")]
        public async Task<ActionResult> SetFavoriteResume(CVDTO cvDto, bool favorite)
        {
            await _cvDto.SetFavoriteResume(cvDto, favorite);
            return Ok();
        }
    }
}
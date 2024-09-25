using Microsoft.AspNetCore.Mvc;
using subWebTemech.DTOs;
using subWebTemech.Models;
using subWebTemech.Services;

namespace subWebTemech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CVController : ControllerBase
    {
        private ICVService cvService;

        public CVController(ICVService cvService)
        {
            this.cvService = cvService;
        }

        [HttpGet("GetRecentCV")]
        public async Task<cvDto> GetRecentCV() {
            return await cvService.GetRecentCV();
        }
        [HttpGet]
        [Route("GetAllCV")]
        public async Task<List<cvDto>> GetAllCV()
        {
            return await cvService.GetAllCV();  
        }
        [HttpGet]
        [Route("GetCVById")]
        public async Task<cvDto> GetCVById(int id)
        {
            return await cvService.GetCVById(id);
        }
        [HttpPost]
        [Route("AddCV")]//לא גמור עדיין - לא להשתמש
        public async Task<bool> AddCV(cvDto cv)
        {
            return  await cvService.AddCV(cv);
        }
        [HttpGet("GetRecentCVs")]
        public async Task<List<cvDto>> GetRecentCVs()
        {
            return await cvService.GetRecentCVs();
        }
        [HttpPut]
        [Route("UpdateCV")]//לא גמור עדיין - לא להשתמש
        public async Task<bool> UpdateCV(cvDto cv)
        {
            return await cvService.UpdateCV(cv);
        }
        [HttpDelete]
        [Route("DeleteCV")]
        public async Task<bool> DeleteCV(int id)
        {
            return await cvService.DeleteCV(id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;

namespace subWebTemech.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController :ControllerBase
    {
        ILocationService locationService;
        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        // קבלת כל הערים
        [HttpGet("GetAllLocation")]
        public ActionResult GetAllLocation()
        {
            return Ok(locationService.GetAllLocation());
        }
    }
}

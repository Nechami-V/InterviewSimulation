using Microsoft.AspNetCore.Mvc;
using subWebTemech.Services;

namespace subWebTemech.Controllers
{
    [Route("api/SubCategory")]
    [ApiController]
    public class SubCategoryController :ControllerBase
    {
        ISubCategoryService subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }
        // קבלת כל subcategory
        [HttpGet("GetAllSubCategory")]
        public ActionResult GetAllSubCategory()
        {
            return Ok(subCategoryService.GetAllSubCategory());
        }
    }
}

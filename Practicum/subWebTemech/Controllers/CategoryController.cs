using Microsoft.AspNetCore.Mvc;
using subWebTemech.DTOs;
using subWebTemech.Services;

namespace subWebTemech.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController :ControllerBase
    {
            ICategoryService categoryService;
            public CategoryController(ICategoryService categoryService)
            {
                this.categoryService = categoryService;
            }
            // קבלת כל הקטגוריות
            [HttpGet("GetAllCategory")]
            public ActionResult GetAllCategory()
            {
                return Ok(categoryService.GetAllCategory());
            }
    }
}

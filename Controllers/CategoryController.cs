using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var response = _service.GetAllCategories();

            if (response == null)
                return BadRequest("bad request");

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeDB.Models.DTO.Rating;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpPost("/rate-recipe")]
        public IActionResult CreateRating(NewRatingRequest request)
        {
            RatingResponse? response = _service.CreateRating(request);
            if (response == null) return BadRequest("Felaktiga information");
            return Ok(response);
        }
    }
}

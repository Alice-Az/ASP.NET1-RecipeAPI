using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeDB.Models.DTO.Recipe;
using RecipeDB.Models.DTO.User;
using RecipeDB.Models.Entities;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }

        [HttpPost("post-recipe")]
        public IActionResult CreateRecipe(NewRecipeRequest request)
        {
            RecipeResponse? recipe = _service.CreateRecipe(request);

            if (recipe == null)
                return BadRequest("Felaktiga information");

            return Ok(recipe);
        }

        [HttpPut("update-recipe")]
        public IActionResult UpdateRecipe(RecipeUpdateRequest request)
        {
            RecipeResponse? recipe = _service.UpdateRecipe(request);

            if (recipe == null) return BadRequest("Felaktiga information");
            return Ok(recipe);
        }

        [HttpDelete("delete-recipe/{userId}/{recipeId}")]
        public IActionResult DeleteRecipe(int userId, int recipeId)
        {
            if (_service.DeleteRecipe(userId, recipeId)) return NoContent();
            return BadRequest("Felaktiga information");
        }

        [HttpPost("search/{search}")]
        public IActionResult GetRecipes(string search)
        {
            List<RecipeResponse>? recipes = _service.GetRecipes(search);
            if (recipes != null)
                return recipes.Count > 0 ? Ok(recipes) : NoContent();
            return BadRequest();
        }

    }
}

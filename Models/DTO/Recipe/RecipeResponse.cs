using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.DTO.Recipe
{
    public class RecipeResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public int CategoryId { get; set; }

        public string? Title { get; set; }

        public List<string>? IngredientsList { get; set; }

        public string? Description { get; set; }
        public string? Rating { get; set; }
    }
}

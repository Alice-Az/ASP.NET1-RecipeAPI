using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.DTO.Recipe
{
    public class RecipeUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        public List<string> IngredientsList { get; set; } = [];

        [Required]
        [StringLength(int.MaxValue)]
        public string? Description { get; set; }
    }
}

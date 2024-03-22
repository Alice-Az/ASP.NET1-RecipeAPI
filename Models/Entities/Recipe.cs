using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }

    }
}

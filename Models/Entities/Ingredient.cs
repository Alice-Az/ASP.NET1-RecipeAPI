using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = default!;

        [Required]
        public int RecipeId { get; set; }

        public virtual Recipe? Recipe { get; set; }
    }
}

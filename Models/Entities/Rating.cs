using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int Note {  get; set; }

        public virtual Recipe? Recipe { get; set; }
    }
}

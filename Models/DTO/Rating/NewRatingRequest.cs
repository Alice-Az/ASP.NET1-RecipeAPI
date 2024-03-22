using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.DTO.Rating
{
    public class NewRatingRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        [Range(1,5)]
        public int Note { get; set; }
    }
}

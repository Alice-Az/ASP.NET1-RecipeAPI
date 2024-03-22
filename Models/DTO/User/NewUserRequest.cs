using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.DTO.User
{
    public class NewUserRequest
    {
        [Required]
        [MinLength(1)]
        public string Username { get; set; } = default!;

        [Required]
        [MinLength(1)]
        public string Password { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
    }
}

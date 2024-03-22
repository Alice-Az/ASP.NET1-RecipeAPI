using System.ComponentModel.DataAnnotations;

namespace RecipeDB.Models.DTO.User
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}

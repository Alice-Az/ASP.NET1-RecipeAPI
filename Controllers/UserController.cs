using Microsoft.AspNetCore.Mvc;
using RecipeDB.Models.DTO.User;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            LoginResponse? user = _service.Login(request);

            if (user == null)
                return BadRequest("Felaktig inloggning");

            return Ok(user);
        }

        [HttpPost("sign-up")]
        public IActionResult CreateUser(NewUserRequest request)
        {
            UserResponse? user = _service.CreateUser(request);

            if (user == null)
                return BadRequest("En användare med samma email eller samma användarnamn redan finns");

            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id) 
        {
            if (_service.DeleteUser(id)) return NoContent();
            return BadRequest("Felaktig userId");
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(UserUpdateRequest request)
        {
            UserResponse? user = _service.UpdateUser(request);

            if (user == null) return BadRequest("Felaktiga information");
            return Ok(user);
        }
    }
}

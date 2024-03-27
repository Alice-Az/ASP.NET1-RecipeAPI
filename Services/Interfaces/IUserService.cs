using RecipeDB.Models.DTO.User;

namespace RecipeDB.Services.Interfaces
{
    public interface IUserService
    {
        LoginResponse? Login(LoginRequest request);
        UserResponse? CreateUser(NewUserRequest request);
        UserResponse? UpdateUser(UserUpdateRequest request);
        bool DeleteUser(int userId);
    }
}

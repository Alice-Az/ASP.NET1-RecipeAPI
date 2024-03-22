using RecipeDB.Models.Entities;

namespace RecipeDB.Repository.Interfaces
{
    public interface IUserRepo
    {
        User? Login(string username, string password);
        User? CreateUser(User user);
        User? UpdateUser(User user);
        bool DeleteUser(int userId);
    }
}

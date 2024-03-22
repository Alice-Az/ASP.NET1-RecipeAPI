using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;

namespace RecipeDB.Repository.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly RecipeDBContext _context;

        public UserRepo(RecipeDBContext context)
        {
            _context = context;
        }

        public User? CreateUser(User user)
        {
            try
            {
                bool userExists = _context.Users.Any(u => u.Email == user.Email);

                if (!userExists)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user;
                }
                else return null;
            }
            catch { return null; }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                User? user = _context.Users.SingleOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    User deletedUser = new() { Username = user.Username, Email = user.Email };
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public User? Login(string username, string password)
        {
            try
            {
                return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            }
            catch { return null; }
        }

        public User? UpdateUser(User updatedUser)
        {
            try
            {
                User? user = _context.Users.SingleOrDefault(u => u.Id == updatedUser.Id);
                if (user != null)
                {
                    user.Username = updatedUser.Username;
                    user.Password = updatedUser.Password;

                    bool emailExists = _context.Users.Any(u => u.Email == updatedUser.Email && u.Id != updatedUser.Id);
                    if (emailExists)
                        return null;

                    user.Email = updatedUser.Email;
                    _context.SaveChanges();
                    return user;
                }
                else return null;
            }
            catch { return null; }
        }
    }
}

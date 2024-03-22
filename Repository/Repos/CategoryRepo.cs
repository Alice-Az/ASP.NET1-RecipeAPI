using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;

namespace RecipeDB.Repository.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly RecipeDBContext _context;

        public CategoryRepo(RecipeDBContext context)
        {
            _context = context;
        }

        public List<Category>? GetAllCategories()
        {
            try
            {
                return _context.Categories.ToList();
            }                
            catch
            {
                return null;
            }
        }
    }
}

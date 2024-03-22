using RecipeDB.Models.Entities;

namespace RecipeDB.Repository.Interfaces
{
    public interface ICategoryRepo
    {
        List<Category>? GetAllCategories();
    }
}

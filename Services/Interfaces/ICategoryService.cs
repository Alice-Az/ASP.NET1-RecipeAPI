using RecipeDB.Models.DTO.Category;

namespace RecipeDB.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetAllCategories();
    }
}

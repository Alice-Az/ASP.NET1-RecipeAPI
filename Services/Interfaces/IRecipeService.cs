using RecipeDB.Models.DTO.Recipe;

namespace RecipeDB.Services.Interfaces
{
    public interface IRecipeService
    {
        RecipeResponse? CreateRecipe(NewRecipeRequest request);

        List<RecipeResponse>? GetRecipes(string search);
        RecipeResponse? UpdateRecipe(RecipeUpdateRequest request);
        bool DeleteRecipe(int userId, int recipeId);
    }
}

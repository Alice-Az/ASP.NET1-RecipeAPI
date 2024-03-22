using RecipeDB.Models.Entities;
using System.Reflection.Metadata.Ecma335;

namespace RecipeDB.Repository.Interfaces
{
    public interface IRecipeRepo
    {
        Recipe? CreateRecipe(Recipe recipe);
        List<Recipe>? GetRecipes(string search);
        Recipe? GetRecipeById(int recipeId);
        Recipe? UpdateRecipe(Recipe recipe);
        bool DeleteRecipe(int userId, int recipeId);
    }
}

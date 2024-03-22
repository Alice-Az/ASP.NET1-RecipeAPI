using RecipeDB.Models.Entities;

namespace RecipeDB.Repository.Interfaces
{
    public interface IRatingRepo
    {
        Rating? CreateRating(Rating rating);
        List<Rating>? GetRatingsByRecipe(int recipeId);
    }
}

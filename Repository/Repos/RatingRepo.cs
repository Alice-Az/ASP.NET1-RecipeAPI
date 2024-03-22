using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;

namespace RecipeDB.Repository.Repos
{
    public class RatingRepo : IRatingRepo
    {
        private readonly RecipeDBContext _context;

        public RatingRepo(RecipeDBContext context)
        {
            _context = context;
        }

        public Rating? CreateRating(Rating rating)
        {
            try
            {
                bool invalidRequest = _context.Recipes.Any(r => r.Id == rating.RecipeId && r.UserId == rating.UserId);
                bool alreadyRated = _context.Ratings.Any(r => r.UserId == rating.UserId && r.RecipeId == rating.RecipeId);
                if (invalidRequest || alreadyRated) { return null; }
                _context.Ratings.Add(rating);
                _context.SaveChanges();
                return rating;
            }
            catch { return null; }
        }

        public List<Rating>? GetRatingsByRecipe(int recipeId)
        {
            try
            {
                return _context.Ratings.Where(r => r.RecipeId == recipeId).ToList();
            }
            catch { return null; }
        }
    }
}

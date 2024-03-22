using Microsoft.EntityFrameworkCore;
using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;

namespace RecipeDB.Repository.Repos
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly RecipeDBContext _context;

        public RecipeRepo(RecipeDBContext context)
        {
            _context = context;
        }
        public Recipe? CreateRecipe(Recipe recipe)
        {
            try
            {
                bool userExists = _context.Users.Any(u => u.Id == recipe.UserId);
                if (userExists)
                {
                    _context.Recipes.Add(recipe);
                    _context.SaveChanges();
                    return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Ratings).SingleOrDefault(r => r.Id == recipe.Id);
                }
                else return null;
            }
            catch { return null; }
        }

        public bool DeleteRecipe(int userId, int recipeId)
        {
            try
            {
                Recipe? recipe = _context.Recipes.SingleOrDefault(r => r.Id == recipeId && r.UserId == userId);
                if (recipe != null)
                {
                    _context.Recipes.Remove(recipe);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public Recipe? UpdateRecipe(Recipe recipe)
        {
            try
            {
                bool validRequest = _context.Recipes.Any(r => r.Id == recipe.Id && r.UserId == recipe.UserId);

                if (validRequest)
                {
                    List<Ingredient> oldIngredients = _context.Ingredients.Where(i => i.RecipeId == recipe.Id).ToList();
                    _context.Ingredients.RemoveRange(oldIngredients);
                    _context.Recipes.Update(recipe);
                    _context.SaveChanges();
                    return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Ratings).SingleOrDefault(r => r.Id == recipe.Id);
                }
                else return null;
            }
            catch { return null; }
        }

        public List<Recipe>? GetRecipes(string search)
        {
            try
            {
                return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Ratings).Where(r => r.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            catch { return null; }
        }

        public Recipe? GetRecipeById(int recipeId)
        {
            try
            {
                return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Ratings).SingleOrDefault(r => r.Id == recipeId);
            }
            catch { return null; }
        }
    }
}

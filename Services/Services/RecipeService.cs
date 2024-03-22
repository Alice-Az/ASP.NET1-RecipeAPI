using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using RecipeDB.Models.DTO.Recipe;
using RecipeDB.Models.DTO.User;
using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepo _recipeRepo;
        private readonly IRatingRepo _ratingRepo;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepo recipeRepo, IRatingRepo ratingRepo, IMapper mapper)
        {
            _recipeRepo = recipeRepo;
            _ratingRepo = ratingRepo;
            _mapper = mapper;
        }

        public RecipeResponse? CreateRecipe(NewRecipeRequest request)
        {
            Recipe? recipe = _mapper.Map<Recipe>(request);
            recipe.Ingredients = request.IngredientsList.Select(i => new Ingredient() { Name = i }).ToList();

            Recipe? createdRecipe = _recipeRepo.CreateRecipe(recipe);

            RecipeResponse? response = _mapper.Map<RecipeResponse>(createdRecipe);
            response.IngredientsList = createdRecipe.Ingredients.Select(i => i.Name).ToList();
            response.Rating = createdRecipe.Ratings.Count > 0
                                  ? (createdRecipe.Ratings.Select(r => r.Note).ToList().Average()).ToString()
                                  : "No ratings yet";
            return response;
        }

        public bool DeleteRecipe(int userId, int recipeId)
        {
            return _recipeRepo.DeleteRecipe(userId, recipeId);
        }

        public RecipeResponse? UpdateRecipe(RecipeUpdateRequest request)
        {
            Recipe? recipe = _mapper.Map<Recipe>(request);
            recipe.Ingredients = request.IngredientsList.Select(i => new Ingredient() { Name = i }).ToList();

            Recipe? updatedRecipe = _recipeRepo.UpdateRecipe(recipe);

            RecipeResponse? response = _mapper.Map<RecipeResponse>(updatedRecipe);
            response.IngredientsList = updatedRecipe.Ingredients.Select(i => i.Name).ToList();
            response.Rating = updatedRecipe.Ratings.Count > 0
                                  ? (updatedRecipe.Ratings.Select(r => r.Note).ToList().Average()).ToString()
                                  : "No ratings yet";
           
            return response;
        }

        public List<RecipeResponse>? GetRecipes(string search)
        {
            List<Recipe>? recipes = _recipeRepo.GetRecipes(search);
            List<RecipeResponse>? recipeResponses = [];

            if (recipes != null)
            {
                foreach (Recipe recipe in recipes)
                {
                    RecipeResponse recipeResponse = _mapper.Map<RecipeResponse>(recipe);
                    recipeResponse.IngredientsList = recipe.Ingredients.Select(i => i.Name).ToList();
                    recipeResponse.Rating = recipe.Ratings.Count > 0
                                          ? (recipe.Ratings.Select(r => r.Note).ToList().Average()).ToString()
                                          : "No ratings yet";
                    recipeResponses.Add(recipeResponse);
                }
            }
            return recipeResponses;
        }
    }
}

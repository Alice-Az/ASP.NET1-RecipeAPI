using AutoMapper;
using RecipeDB.Models.DTO.Recipe;
using RecipeDB.Models.Entities;

namespace RecipeDB.Mappers
{
    public class RecipeMapper : Profile
    {
        public RecipeMapper() 
        {
            CreateMap<NewRecipeRequest, Recipe>();
            CreateMap<RecipeUpdateRequest, Recipe>();
            CreateMap<Recipe, RecipeResponse>();
        }
    }
}

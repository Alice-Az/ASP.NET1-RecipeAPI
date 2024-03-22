using AutoMapper;
using RecipeDB.Models.DTO.Category;
using RecipeDB.Models.Entities;

namespace RecipeDB.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() 
        {
            CreateMap<Category, CategoryResponse>();
        }
    }
}

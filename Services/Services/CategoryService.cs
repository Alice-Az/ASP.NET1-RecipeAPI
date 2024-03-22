using AutoMapper;
using RecipeDB.Models.DTO.Category;
using RecipeDB.Repository.Interfaces;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CategoryResponse> GetAllCategories()
        {
            var categories = _repo.GetAllCategories();
            return _mapper.Map<List<CategoryResponse>>(categories);
        }
    }
}

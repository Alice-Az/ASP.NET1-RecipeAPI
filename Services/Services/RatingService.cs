using AutoMapper;
using RecipeDB.Models.DTO.Rating;
using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _repo;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public RatingResponse? CreateRating(NewRatingRequest request)
        {
            Rating? rating = _mapper.Map<Rating>(request);
            Rating? response = _repo.CreateRating(rating);

            return _mapper.Map<RatingResponse>(response);
        }
    }
}

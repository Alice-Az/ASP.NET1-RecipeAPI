using RecipeDB.Models.DTO.Rating;

namespace RecipeDB.Services.Interfaces
{
    public interface IRatingService
    {
        RatingResponse? CreateRating(NewRatingRequest request);
    }
}

using AutoMapper;
using Microsoft.Identity.Client;
using RecipeDB.Models.DTO.Rating;
using RecipeDB.Models.Entities;
using System.Runtime.InteropServices;

namespace RecipeDB.Mappers
{
    public class RatingMapper : Profile
    {
        public RatingMapper() 
        {
            CreateMap<NewRatingRequest, Rating>();
            CreateMap<Rating, RatingResponse>();
        }
    }
}

using AutoMapper;
using RecipeDB.Models.DTO.User;
using RecipeDB.Models.Entities;

namespace RecipeDB.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserResponse>();
            CreateMap<NewUserRequest, User>();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}

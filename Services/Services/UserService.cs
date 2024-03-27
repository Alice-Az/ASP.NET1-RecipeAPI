using AutoMapper;
using RecipeDB.Models.DTO.User;
using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;
using RecipeDB.Services.Interfaces;

namespace RecipeDB.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public UserResponse? CreateUser(NewUserRequest request)
        {
            User? user = _mapper.Map<User>(request);
            User? response = _repo.CreateUser(user);
            return _mapper.Map<UserResponse>(response);
        }

        public bool DeleteUser(int userId)
        {
            return _repo.DeleteUser(userId);
        }

        public LoginResponse? Login(LoginRequest request)
        {
            User? response = _repo.Login(request.Username, request.Password);
            return _mapper.Map<LoginResponse>(response);
        }

        public UserResponse? UpdateUser(UserUpdateRequest request)
        {
            User? user = _mapper.Map<User>(request);
            User? response = _repo.UpdateUser(user);
            return _mapper.Map<UserResponse>(response);
        }
    }
}

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DTOs.Users;
using RefuApi.Data.Intefaces;
using RefuApi.DTOs.Users;
using RefuApi.Models;
using RefuApi.Services.Interfaces;

namespace RefuApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(createUserDTO);

            if (!Validator.TryValidateObject(createUserDTO, validationContext, validationResults, true))
            {
                var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            var user = _mapper.Map<User>(createUserDTO);

            var existingUser = await _userRepository.GetAll(new UserQueryParameters { Email = user.Email });
            if (existingUser.Any())
            {
                throw new InvalidOperationException("A user with the same email already exists.");
            }

            await _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }
        public Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO?> GetUserDetails(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO?> LoginUser(LoginUserDTO loginUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutUser()
        {
            throw new NotImplementedException();
        }


        public Task<UserDTO> UpdateUserDetails(int userId, UpdateUserDTO updateUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}

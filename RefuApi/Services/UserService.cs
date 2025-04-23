using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RefuApi.Data.Interfaces;
using RefuApi.DTOs.Users;
using RefuApi.Models;
using RefuApi.Services.Interfaces;

namespace RefuApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            try
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

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                await _userRepository.Add(user);
                await _userRepository.SaveChangesAsync();

                return _mapper.Map<UserDTO>(user);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"User registration failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"User registration failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {userId} not found.");
                }
                await _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();
                return true;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"User deletion failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task<UserDTO?> GetUserDetails(int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {userId} not found.");
                }
                return _mapper.Map<UserDTO>(user);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"User retrieval failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers(UserQueryParametersDTO? userQueryParametersDTO)
        {
            try
            {
                var userQueryParameters = _mapper.Map<UserQueryParameters>(userQueryParametersDTO);
                var users = await _userRepository.GetAll(userQueryParameters);
                return _mapper.Map<IEnumerable<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task<UserDTO?> LoginUser(LoginUserDTO loginUserDTO)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(loginUserDTO);
                if (!Validator.TryValidateObject(loginUserDTO, validationContext, validationResults, true))
                {
                    var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                    throw new ArgumentException($"Validation failed: {errors}");
                }
                var users = await _userRepository.GetAll(new UserQueryParameters { Email = loginUserDTO.Email });
                var user = users.FirstOrDefault();

                if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password))
                {
                    throw new InvalidOperationException("Invalid email or password.");
                }

                return _mapper.Map<UserDTO>(user);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"User login failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public Task<bool> LogoutUser()
        {
            throw new NotImplementedException();
        }


        public async Task<UserDTO> UpdateUserDetails(int userId, UpdateUserDTO updateUserDTO)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(updateUserDTO);
                if (!Validator.TryValidateObject(updateUserDTO, validationContext, validationResults, true))
                {
                    var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                    throw new ArgumentException($"Validation failed: {errors}");
                }
                var user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {userId} not found.");
                }
                user.Name = updateUserDTO.Name ?? user.Name;
                user.Email = updateUserDTO.Email ?? user.Email;
                if(!string.IsNullOrEmpty(updateUserDTO.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserDTO.Password);
                }
                user.IsVeteran = updateUserDTO.IsVeteran ?? user.IsVeteran;

                await _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                return _mapper.Map<UserDTO>(user);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"User update failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"User update failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public string GenerateJWTToken(UserDTO user)
        {
            var jwtSecret = _configuration["JWT_SECRET"];
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new InvalidOperationException("JWT_SECRET is not configured.");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSecret));

            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, user.Name),
               new Claim("IsVeteran", user.IsVeteran.ToString())
           };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT_ISSUER"],
                audience: _configuration["JWT_AUDIENCE"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

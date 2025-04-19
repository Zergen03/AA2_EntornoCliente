using RefuApi.DTOs.Users;

namespace RefuApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(CreateUserDTO createUserDTO);
        Task<UserDTO?> LoginUser(LoginUserDTO loginUserDTO);
        Task<bool> LogoutUser();
        Task<UserDTO> UpdateUserDetails(int userId, UpdateUserDTO updateUserDTO);
        Task<bool> DeleteUser(int userId);
        Task<UserDTO?> GetUserDetails(int userId);
        Task<IEnumerable<UserDTO>> GetAllUsers(UserQueryParametersDTO? userQueryParametersDTO);
        string GenerateJWTToken(UserDTO user);
    }
}

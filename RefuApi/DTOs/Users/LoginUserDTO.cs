using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Users
{
    public class LoginUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}

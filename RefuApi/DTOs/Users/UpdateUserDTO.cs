using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Users
{
    public class UpdateUserDTO
    {
        [StringLength(100, ErrorMessage = "The User Name should be less than 100 chars")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string? Email { get; set; }

        [StringLength(100, ErrorMessage = "The Password should be less than 100 chars")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool? IsVeteran { get; set; }
    }
}

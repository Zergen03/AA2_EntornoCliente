using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs;

public class CreateUserDTO
{
    [Required]
    [StringLength(100, ErrorMessage = "The User Name should be less than 100 chars")]
    public string Name { get; set; } = default!;

    [Required]
    [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
    public string Email { get; set; } = default!;

    [Required]
    public bool IsVeteran { get; set; }

    public CreateUserDTO() { }
}
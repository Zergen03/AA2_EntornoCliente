using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool IsVeteran { get; set; }

    public User() { }

    public User(string name, string email, string password, bool isVeteran)
    {
        Name = name;
        Email = email;
        Password = password;
        IsVeteran = isVeteran;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Email: {Email}, IsVeteran: {IsVeteran}";
    }
}

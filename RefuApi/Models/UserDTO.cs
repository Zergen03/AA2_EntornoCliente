namespace RefuApi.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsVeteran { get; set; }

    public UserDTO() { }

    public UserDTO(int id, string name, string email, bool isVeteran)
    {
        Id = id;
        Name = name;
        Email = email;
        IsVeteran = isVeteran;
    }
}
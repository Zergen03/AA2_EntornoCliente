namespace RefuApi.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsVeteran { get; set; }

    public UserDTO() { }
}
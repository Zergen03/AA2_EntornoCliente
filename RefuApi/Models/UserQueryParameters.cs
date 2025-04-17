using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models;

public class UserQueryParameters
{
    public string? Name { get; set; }
    public bool? IsVeteran { get; set; }

}
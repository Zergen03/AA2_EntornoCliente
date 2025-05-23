﻿using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public bool IsVeteran { get; set; }

    public ICollection<ScheduleAssignment> ScheduleAssignments { get; set; } = new List<ScheduleAssignment>();

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

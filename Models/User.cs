using System.ComponentModel.DataAnnotations;

namespace StudentRegisteration.Models;

public class User
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Email is required.")]
    [EmailAddress(ErrorMessage ="Invalid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string Role { get; set; }  // Admin , Student

    // public Address? Address { get; set; }

    public StudentDetails? StudentDetails { get; set; }

}
using System.ComponentModel.DataAnnotations;

namespace StudentRegisteration.Models;

public class User
{
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string Role { get; set; }  // Admin , Student

    public Address Address { get; set; } 
    

}
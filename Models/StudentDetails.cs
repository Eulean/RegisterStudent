using System.ComponentModel.DataAnnotations;

namespace StudentRegisteration.Models;

public class StudentDetails 
{
    public string Id { get; set; }

    // can be not included in the model
    [Required(ErrorMessage ="Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Email is required.")]
    [EmailAddress(ErrorMessage ="Invalid email address.")]
    public string Email { get; set; }

   
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
   

    public string UserId { get; set; } //FK
    public User User { get; set; }

    
    public Address Address { get; set; }


    public List<Registeration> Registerations { get; set; }

    
} 
// public string FirstName { get; set; }
    // public string LastName { get; set; } 
    // public string PrifilePicturePath { get; set; }
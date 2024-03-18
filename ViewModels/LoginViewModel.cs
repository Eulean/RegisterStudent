namespace  StudentRegisteration.ViewModels;

using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }    

    public string RememberMe { get; set; }
}
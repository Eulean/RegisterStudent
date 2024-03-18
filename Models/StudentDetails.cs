namespace StudentRegisteration.Models;

public class StudentDetails 
{
    public int Id { get; set; }

    // can be not included in the model
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string PrifilePicturePath { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }


    public List<Registeration> Registerations { get; set; }
}
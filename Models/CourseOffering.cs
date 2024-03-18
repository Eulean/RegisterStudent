namespace StudentRegisteration.Models;

public class CourseOffering
{
    public int Id { get; set;}
    public string Course { get; set; }
    public string StudentYear { get; set; }
    public string Semester { get; set; }
    public double Cost { get; set; }


    public List<Registeration> Registerations { get; set; }
}
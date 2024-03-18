namespace StudentRegisteration.Models;

public class Registeration
{
    public int Id { get; set; }
    public string RegistrationId { get; set; }

    public int StudentDetailsId { get; set; }
    public StudentDetails studentDetails { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; }

    public string Status { get; set; } //= "Pending"; // Pending, Approved, Rejected
}
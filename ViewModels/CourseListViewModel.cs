using StudentRegisteration.Models;

namespace StudentRegisteration.ViewModels;

public class CourseListViewModel
{
    public IEnumerable<CourseOffering> CourseOffering { get; set; }
    public bool ShowFullList { get; set; }
}
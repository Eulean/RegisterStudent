using StudentRegisteration.Models;

namespace StudentRegisteration.Interfaces;

public interface ICourseService
{
    IEnumerable<CourseOffering> GetAllCourses();
    IEnumerable<CourseOffering> SearchCourses(string searchString);
    Task<CourseOffering> GetCourseById(int id);
    void CreateCourse(CourseOffering course);
    Task UpdateCourse(CourseOffering course);
    Task DeleteCourse(int id);
}
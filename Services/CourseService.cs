using StudentRegisteration.Data;
using StudentRegisteration.Interfaces;
using StudentRegisteration.Models;

namespace StudentRegisteration.Services;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;

    public CourseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CourseOffering> GetAllCourses()
    {
        return _context.CourseOfferings.ToList();
    }

    public IEnumerable<CourseOffering> SearchCourses(string searchString)   
    {
        if(string.IsNullOrEmpty(searchString))
        {
            return GetAllCourses();
        }

        return _context.CourseOfferings.Where( c =>
            c.Course.ToLower().Contains(searchString.ToLower()) ||
            c.StudentYear.ToLower().Contains(searchString.ToLower()) ||
            c.Semester.ToLower().Contains(searchString.ToLower()) ||
            c.Cost.ToString().Contains(searchString) 
        );
    }

    public async Task<CourseOffering> GetCourseById(int id)
    {
        return await _context.CourseOfferings.FindAsync(id);
    }

    public void CreateCourse(CourseOffering course)
    {
        _context.CourseOfferings.Add(course);
        _context.SaveChanges();
    }

    public async Task UpdateCourse(CourseOffering course)
    {
        _context.CourseOfferings.Update(course);
        _context.SaveChanges();
    }

    public async Task DeleteCourse(int id)
    {
        var course = _context.CourseOfferings.Find(id);
        if(course!= null)
        {
            _context.CourseOfferings.Remove(course);
            _context.SaveChanges();
        }
    }
}
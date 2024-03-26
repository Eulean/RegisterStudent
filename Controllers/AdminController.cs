using Microsoft.AspNetCore.Mvc;
using StudentRegisteration.Data;
using StudentRegisteration.Interfaces;
using StudentRegisteration.ViewModels;

namespace StudentRegisteration.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
 
    public AdminController(ApplicationDbContext context)
    {
        _context = context;
       
    }

    private bool IsUserLoggedIn()
    {
        var userId = HttpContext.Session.GetString("IsLoggedIn");
        return userId != null;
    }

    public IActionResult Index()
    {
       if(!IsUserLoggedIn())
       {
        return RedirectToAction("Login","User");
       }
        // var students = _context.StudentDetails.ToList();
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
       if(!IsUserLoggedIn())
       {
        return RedirectToAction("Login","User");
       }
        return View();
    }

    public  IActionResult AddressManagement()
    {
        if(!IsUserLoggedIn())
       {
        return RedirectToAction("Login","User");
       }

        return RedirectToAction("Index","AddressManagement");
    }


     public async Task<IActionResult> CoursesManagement()
    {
        if(!IsUserLoggedIn())
       {
        return RedirectToAction("Login","User");
       }
        return RedirectToAction("CourseList","CoursesManagement");
    }
    
    public async Task<IActionResult> StudentManagement()
    {
        if(!IsUserLoggedIn())
       {
        return RedirectToAction("Login","User");
       }
        return View();
    }

    
   
}
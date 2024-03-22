using Microsoft.AspNetCore.Mvc;
using StudentRegisteration.Data;
using StudentRegisteration.ViewModels;

namespace StudentRegisteration.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("IsLoggedIn") == null)
        {
            return RedirectToAction("Login", "User");
        }
        // var students = _context.StudentDetails.ToList();
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        return View();
    }
}
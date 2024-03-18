using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRegisteration.Data;
using StudentRegisteration.Models;

namespace StudentRegisteration.Controllers;


public class StudentController : Controller
{
    // private readonly ApplicationDbContext _context;
    // private readonly UserManager<User> _userManager;

    // public StudentController(UserManager<User> userManager,ApplicationDbContext context)
    // {
    //     _userManager = userManager;
    //     _context = context;
    // }

    public IActionResult Index()
    {
        return View();
    }
}
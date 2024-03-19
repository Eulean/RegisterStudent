using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using StudentRegisteration.Data;
using StudentRegisteration.Models;
using StudentRegisteration.ViewModels;


namespace StudentRegisteration.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

        if(user != null)
        {
            ModelState.AddModelError("","Email Already exists");
            return View(model);
        }

        var newUser = new User
        {
            Name = model.Name,
            Email = model.Email,
            Password = HashPassword(model.Password),
            Role = "Student"
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return RedirectToAction("Login", "User");
        
    }

    private string HashPassword(string password)
    {
        return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var loginUser = _context.Users
        .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        if (loginUser != null)
        {
            if(loginUser.Role == "Student")
            {
                return RedirectToAction("Index", "Student");
            }
            else if(loginUser.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("","Invalid username or password");
            return View(model);
            }
        }
            
        return View(model);
    }
}
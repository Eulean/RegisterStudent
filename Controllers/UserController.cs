
using System.Text;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // check email 
        var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
        if(user != null)
        {
            ModelState.AddModelError("Email","Email Already exists");
            return View(model);
        }

        var newUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = model.Name,
            Email = model.Email,
            Password = HashPassword(model.Password),
            Role = model.Role
          //  Role = "Student"
         // Role = "Admin"       // pls change it to Admin Role when you are add/register admin to database
        };

        _context.Users.Add(newUser);

        try
        {
             _context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            ModelState.AddModelError("e","An Error occurred.Please Try Again later.");
            return View (model);
        }
       

        return RedirectToAction("Login");
        
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
            return View(model); // login view with validation errors
        }

        var loginUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);

        if (loginUser == null)
        {
            ModelState.AddModelError("Email", "Email doesn't exist");
            return View(model);
        }
// check password
        if (!VerifyPassword( loginUser.Password, model.Password))
        {
            ModelState.AddModelError("Password", "Password is incorrect");
            return View(model);
        }

        HttpContext.Session.SetString("IsLoggedIn", loginUser.Id);

        HttpContext.Session.SetString("UserName", loginUser.Name);
        HttpContext.Session.SetString("UserEmail", loginUser.Email);

    // check Role
       if (loginUser.Role == "Admin")
       {
        
        return RedirectToAction("Index","Admin",model);
       }
       else if( loginUser.Role == "Student")
       {
        
        return RedirectToAction("Index","Student",model);
       }
       else{
        ModelState.AddModelError("","User has no assigned roles");
        return View(model);
       }
      
    }

    // for password hashing
      private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // for password verification
    private bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}
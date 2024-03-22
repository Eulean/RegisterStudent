using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRegisteration.Data;
using StudentRegisteration.Models;
using StudentRegisteration.ViewModels;
using System.Security.Claims;

namespace StudentRegisteration.Controllers;


public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;
    //private readonly UserManager<User> _userManager;

    public StudentController( ApplicationDbContext context)
    {
       
        _context = context;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetString("IsLoggedIn")== null)
        {
            return RedirectToAction("Login", "User");
        }

     /*   if(!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "User");
        }*/

        return RedirectToAction("Details");

        /*var student = _context.Users.Where(u => u.Role == "Student").Select(u => new StudentViewModel
        {
            Name = u.Name,
            Email = u.Email,
            Id = u.Id,
        }).ToList();
        return View(student);*/
    }

    public IActionResult Details()
    {

        var userId = HttpContext.Session.GetString("IsLoggedIn");
        var userName = HttpContext.Session.GetString("UserName");
        var userEmail = HttpContext.Session.GetString("UserEmail");

        if (userId == null)
        {
            return RedirectToAction("Login", "User");
        }

        var user = new User
        {
            Id = userId,
            Name = userName,
            Email = userEmail,
        };

        var studentDetails = _context.StudentDetails.FirstOrDefault(sd => sd.Id == userId);

        if(studentDetails == null)
        {
            studentDetails = new StudentDetails
            {
                Id = userId,
                
            };

        }

        var registrations = _context.Registerations
            .Where(r => r.StudentDetailsId == userId)
            .ToList();


        // combine studentdetails and registration into a view model

        var detailsViewModel = new DetailsViewModel
        {
            User = user,
            StudentDetails = studentDetails,
            Registerations = registrations,
        };

        HttpContext.Session.SetString("DetailsViewModel", JsonConvert.SerializeObject(detailsViewModel));

        /*   //try to store in tempdata
           TempData["DetailsViewModel"] = detailsViewModel;
           TempData["OriginalDetailsViewModel"] = detailsViewModel;*/


        return View(detailsViewModel);
    }

    [HttpPost]
    public IActionResult Details(DetailsViewModel detailsViewModel)
    {
        if(ModelState.IsValid)
        {
            _context.StudentDetails.Update(detailsViewModel.StudentDetails);
            _context.SaveChanges();
            return RedirectToAction("Details");
        }

        var serializedDetailsViewModel = HttpContext.Session.GetString("DetailsViewModel");

        if(serializedDetailsViewModel != null)
        {
            detailsViewModel = JsonConvert.DeserializeObject<DetailsViewModel>(serializedDetailsViewModel);

        }
       

        return View(detailsViewModel);
    }

    public IActionResult RegistrationCourse()
    {
        return View();
    }

}
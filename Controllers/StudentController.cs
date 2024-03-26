using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentRegisteration.Data;
using StudentRegisteration.Models;
using StudentRegisteration.ViewModels;
using System.Security.Claims;
using System.Text.Json;

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

        return RedirectToAction("Details");

      
    }

    
    // public async Task<IActionResult> Details()
    // {
    //     var userId = HttpContext.Session.GetString("IsLoggedIn");

    //     if (userId == null)
    //     {
    //         return RedirectToAction("Login", "User");
    //     }

    //     var studentDetails = await _context.StudentDetails
    //         .Include(sd => sd.Registerations)
    //         .FirstOrDefaultAsync(sd => sd.UserId == userId);

    //     var detailsViewModel = new DetailsViewModel(studentDetails); // Use constructor to exclude User

    //     if (studentDetails != null)
    //     {
    //         detailsViewModel.UserName = studentDetails.User?.Name;
    //         detailsViewModel.UserEmail = studentDetails.User?.Email;
    //     }

    //     HttpContext.Session.SetString("DetailsViewModel", JsonConvert.SerializeObject(detailsViewModel));

    //     return View(detailsViewModel);
    // }

    // [HttpPost]
    // public async Task<IActionResult> Details(DetailsViewModel detailsViewModel)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         // Update only the StudentDetails object from the view model
    //         _context.StudentDetails.Update(detailsViewModel.StudentDetails);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction("Details");
    //     }
    //     return View(detailsViewModel);
    // }

    public async Task<IActionResult> Details()
    {

        var userId = HttpContext.Session.GetString("IsLoggedIn");

        if (userId == null)
        {
            return RedirectToAction("Login", "User");
        }

        var studentDetails = await _context.StudentDetails
            // .Include(sd => sd.User)
            .Include(sd => sd.Address)
            .Include(sd => sd.Registerations)
            .FirstOrDefaultAsync(sd => sd.UserId == userId);
            
        if(studentDetails == null)
        {
            var user = await _context.Users.FindAsync(userId); 

            if(user == null )
            {
                ModelState.AddModelError("User", "No User Found!");
                return View(user);
            }

            var userName = user?.Name;
            var userEmail = user?.Email;
       
            studentDetails = new StudentDetails
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Name = userName,
                Email = userEmail,            
                Address = new Address
                {
                  
                    City = "Yangon",
                    Town = "Dagon",
                    State = "Yangon",
                    
                    
                }

                
            };

        }

        var detailsViewModel = new DetailsViewModel
        {
            UserName = studentDetails.Name,
            UserEmail = studentDetails.Email,
            StudentDetails = studentDetails,
            Address = studentDetails.Address,
            Registerations = studentDetails.Registerations != null && studentDetails.Registerations.Any()
                ? studentDetails.Registerations.ToList()
                : new List<Registeration>(),
        };

       

        // HttpContext.Session.SetString("DetailsViewModel", JsonConvert.SerializeObject(detailsViewModel));

        return View(detailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Details(DetailsViewModel detailsViewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
         }  
         else
         {
            // var serializedDetailsViewModel = HttpContext.Session.GetString("DetailsViewModel");

            var serializedDetailsViewModel = SerializeObjectIgnoreNull(detailsViewModel);
            
            HttpContext.Session.SetString("DetailsViewModel",serializedDetailsViewModel);

            var originalDetailsViewModel = JsonConvert.DeserializeObject<DetailsViewModel>(serializedDetailsViewModel);

    

            originalDetailsViewModel.StudentDetails.Name = detailsViewModel.StudentDetails.Name;
            originalDetailsViewModel.StudentDetails.Email = detailsViewModel.StudentDetails.Email;
            originalDetailsViewModel.StudentDetails.PhoneNumber = detailsViewModel.StudentDetails.PhoneNumber;
            originalDetailsViewModel.StudentDetails.Address.City = detailsViewModel.StudentDetails.Address.City;
            originalDetailsViewModel.StudentDetails.Address.Town = detailsViewModel.StudentDetails.Address.Town;
            originalDetailsViewModel.StudentDetails.Address.State = detailsViewModel.StudentDetails.Address.State;


            _context.StudentDetails.Update(detailsViewModel.StudentDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details");
         }
            
        
        return View(detailsViewModel);
    }

    private string SerializeObjectIgnoreNull(object obj)
    {
        var json = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
        return JsonConvert.SerializeObject(obj, json);
    }



    public IActionResult RegistrationCourse()
    {
        return View();
    }

}
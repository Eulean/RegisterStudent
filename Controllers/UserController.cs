using Microsoft.AspNetCore.Mvc;

namespace StudentRegisteration.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
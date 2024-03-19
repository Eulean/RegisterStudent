using Microsoft.AspNetCore.Mvc;

namespace StudentRegisteration.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
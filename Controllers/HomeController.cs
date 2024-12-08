using Microsoft.AspNetCore.Mvc;
using MvcWebAppProject.Helpers;

namespace MvcWebAppProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("aboutus")]
    public IActionResult AboutUs()
    {
        return View();
    }
}
using System.Diagnostics;
using MvcWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;

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
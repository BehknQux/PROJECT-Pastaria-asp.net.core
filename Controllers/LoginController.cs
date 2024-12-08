using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MvcWebAppProject.Helpers;
using MvcWebAppProject.Models;

namespace MvcWebAppProject.Controllers;

public class LoginController: Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<LoginController> _logger;
    
    public LoginController(ApplicationDbContext context, ILogger<LoginController> logger)
    { 
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterUser(string username, string passwordHash)
    {
        var user = new User();
        user.Username = username;
        user.PasswordHash = HashHelper.HashPassword(passwordHash);

        _context.Users.Add(user);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult LoginUser(User user)
    {
        var hashedPassword = HashHelper.HashPassword(user.PasswordHash);
        var foundUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.PasswordHash == hashedPassword);
        
        if (foundUser != null)
        {
            HttpContext.Session.SetString("username", foundUser.Username);
            HttpContext.Session.SetInt32("userID", foundUser.Id);
            Console.WriteLine(foundUser.Id + " Giriş Yaptı");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
    
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}

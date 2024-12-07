using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult RegisterUser(string username, string PasswordHash)
    {
        var user = new User();
        user.Username = username;
        user.PasswordHash = HashPassWord(PasswordHash);

        _context.Users.Add(user);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult LoginUser(User user)
    {
        var hashedPassword = HashPassWord(user.PasswordHash);
        var foundUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.PasswordHash == hashedPassword);
        
        if (foundUser != null)
        {
            HttpContext.Session.SetString("username", foundUser.Username);
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

    private string HashPassWord(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}

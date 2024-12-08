using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebAppProject.Models;

namespace MvcWebAppProject.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly ApplicationDbContext _context;
    
    public MenuController(ILogger<MenuController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    // GET
    public async Task<ActionResult> Index()
    {
        var items = await _context.MenuItems.ToListAsync();
        
        return View(items);
    }
 
    public IActionResult AddToMenu()
    {
        return View();
    }
 
    [HttpPost]
    public async Task<ActionResult> Create(MenuItem item)
    {
        _context.MenuItems.Add(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> Delete(int id)
    {
        var item = await _context.MenuItems.FindAsync(id);
        if (item != null) _context.MenuItems.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> AddToCart(int id)
    {
        int? userId = HttpContext.Session.GetInt32("userID");
        
        Cart cart = new Cart();
        cart.ItemId = id;
        cart.UserId = (int)userId!;
        
        _context.Cart.Add(cart);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
}
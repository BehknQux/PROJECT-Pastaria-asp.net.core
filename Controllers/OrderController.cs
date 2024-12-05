using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebAppProject.Models;

namespace MvcWebAppProject.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    public async Task<ActionResult> Index()
    {
        var items = await _context.Cart.Include(c => c.MenuItem).ToListAsync();
        
        return View(items);
    }
}
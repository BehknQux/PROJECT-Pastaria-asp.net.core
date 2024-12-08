using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebAppProject.Helpers;
using MvcWebAppProject.Models;

namespace MvcWebAppProject.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Index()
    {
        var items = await _context.Cart.Where(item => item.UserId == SessionHelper.GetUserId()).Include(c => c.MenuItem).ToListAsync();
        OrderViewModel orderViewModel = new OrderViewModel(items);
        return View(orderViewModel);
    }

    [HttpPost]
    public ActionResult CreateOrder()
    {
        var userId = SessionHelper.GetUserId();
        var items = _context.Cart.Where(item => item.UserId == userId).ToList();

        var mappedItems = items.Select(item => new
        {
            ItemId = item.ItemId,
            Quantity = (int?)null
        });

        string serializedItems = JsonSerializer.Serialize(mappedItems).ToString();

        Order order = new Order();
        order.UserId = (int)userId!;
        order.CartData = serializedItems;
        
        _context.Orders.Add(order);
        _context.Cart.RemoveRange(items);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}
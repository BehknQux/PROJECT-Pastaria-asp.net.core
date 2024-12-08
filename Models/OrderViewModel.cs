namespace MvcWebAppProject.Models;

public class OrderViewModel
{
    public Order Order { get; set; }
    public List<Cart> Cart { get; set; }
    
    public OrderViewModel(List<Cart> cart)
    {
        Order = new Order();
        Cart = cart;
    }
}
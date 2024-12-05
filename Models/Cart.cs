using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebAppProject.Models;

public class Cart
{
    public Cart(int id)
    {
        this.ItemId = id;
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("MenuItem")]
    public int ItemId { get; set; }
    
    public MenuItem MenuItem { get; set; }
}
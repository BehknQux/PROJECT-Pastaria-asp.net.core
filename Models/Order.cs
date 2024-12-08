using System.ComponentModel.DataAnnotations;
using static System.DateTime;

namespace MvcWebAppProject.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string CartData { get; set; } = string.Empty;
    
    [Required]
    public int UserId { get; set; }
    
    public DateTime OrderDate { get; set; } = Now;
}
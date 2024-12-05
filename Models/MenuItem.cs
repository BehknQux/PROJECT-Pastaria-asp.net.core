using System.ComponentModel.DataAnnotations;

namespace MvcWebAppProject.Models;

public class MenuItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public double Rating { get; set; }
}
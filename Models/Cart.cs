using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebAppProject.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("MenuItem")]
    public int ItemId { get; set; }
    
    public virtual MenuItem? MenuItem { get; set; }
    
    [Required]
    public int UserId { get; set; }
}
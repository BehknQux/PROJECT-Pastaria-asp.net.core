using System.ComponentModel.DataAnnotations;

namespace MvcWebAppProject.Models {

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string PasswordHash { get; set; } = string.Empty;
}
}
using Microsoft.EntityFrameworkCore;

namespace MvcWebAppProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
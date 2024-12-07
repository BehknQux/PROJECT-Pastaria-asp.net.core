using Microsoft.EntityFrameworkCore;

namespace MvcWebAppProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler burada tanımlanır
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
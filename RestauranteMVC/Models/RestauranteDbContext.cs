using Microsoft.EntityFrameworkCore;

namespace RestauranteMVC.Models
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rol> Rol { get; set; }
    }
}

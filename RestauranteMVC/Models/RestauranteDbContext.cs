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
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Menu_Items> Menu_Items { get; set; }
        public DbSet <Promociones> Promociones { get; set; }
        public DbSet<Promociones_Items> Promociones_Items { get; set; }
        public DbSet<PlatosCombos> PlatosCombos { get;set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<MetodosPago> MetodosPagos { get; set; }
        public DbSet<Combos> Combos {  get; set; }
        public DbSet <Categorias>Categorias { get; set; }

    }
}

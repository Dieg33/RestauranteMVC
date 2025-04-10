using Microsoft.EntityFrameworkCore;

namespace RestauranteMVC.Models
{
    public class RestauranteDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Menu_Items> Menu_Items { get; set; }
        public DbSet<Promociones> Promociones { get; set; }
        public DbSet<Promociones_Items> Promociones_Items { get; set; }
        public DbSet<PlatosCombos> PlatosCombos { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<MetodoPago> MetodoPagos { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatosCombos>()
                .HasKey(pc => new { pc.ComboID, pc.PlatoID });

            modelBuilder.Entity<PlatosCombos>()
                .HasOne(pc => pc.Combo)
                .WithMany(c => c.PlatosCombos)
                .HasForeignKey(pc => pc.ComboID);

            modelBuilder.Entity<PlatosCombos>()
                .HasOne(pc => pc.Plato)
                .WithMany(p => p.PlatosCombos)
                .HasForeignKey(pc => pc.PlatoID);
        }
    }
}

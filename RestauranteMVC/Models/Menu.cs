using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<Menu_Items> Menu_Items { get; set; } = [];
    }
}

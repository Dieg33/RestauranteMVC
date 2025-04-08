using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    public class Menu_Items
    {
        [Key]
        public int MenuItemId { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("Platos")]
        public int? PlatoID { get; set; }
        public Platos Platos { get; set; }

        [ForeignKey("Combos")]
        public int? ComboID { get; set; }
        public Combos Combos { get; set; }

        [ForeignKey("Promociones")]
        public int? PromocionID { get; set; }
        public Promociones Promociones { get; set; }
    }
}

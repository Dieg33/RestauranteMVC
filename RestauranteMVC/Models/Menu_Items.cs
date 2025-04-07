using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Menu_Items
    {
        [Key]

        public int MenuItemId { get; set; }
        public int MenuID { get; set; }
        public int PlatoID { get; set; }
        public int ComboID { get; set; }
        public int PromocionID { get; set; }
    }
}

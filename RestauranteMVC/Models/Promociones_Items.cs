using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Promociones_Items
    {
        [Key]
        public int PromocionID { get; set; }
        public int PlatoID { get; set; }
        public int ComboID { get; set; }
    }
}

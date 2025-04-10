using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    public class Promociones_Items
    {
        [Key]
        public int PromocionItemId { get; set; }//Id primaria agregada

        public int? PromocionID { get; set; }
        [ForeignKey("PromocionID")]
        public Promociones? Promocion { get; set; }

        public int? PlatoID { get; set; }
        [ForeignKey("PlatoID")]
        public Plato? Plato { get; set; }

        public int? ComboID { get; set; }
        [ForeignKey("ComboID")]
        public Combo? Combo { get; set; }
    }
}

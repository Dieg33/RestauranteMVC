using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    public class PlatosCombos
    {
        public int ComboID { get; set; }
        public int PlatoID { get; set; }

        [ForeignKey("ComboID")]
        public Combo? Combo { get; set; }

        [ForeignKey("PlatoID")]
        public Plato? Plato { get; set; }
    }
}

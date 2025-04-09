using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class PlatosCombos
    {
        public int ComboID { get; set; }
        public Combos Combo { get; set; }

        public int PlatoID { get; set; }
        public Platos Plato { get; set; }
    }
}

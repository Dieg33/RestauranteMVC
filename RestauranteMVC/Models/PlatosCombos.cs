using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class PlatosCombos
    {
        [Key]
        public int ComboID { get; set; }
        public int PlatoID {  get; set; }

    }
}

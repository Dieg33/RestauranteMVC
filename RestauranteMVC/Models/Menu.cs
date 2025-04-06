using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Menu
    {
        [Key]

        public int MenuID { get; set; }
        public string Nobre { get; set; }
        public string Descripcion {  get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}

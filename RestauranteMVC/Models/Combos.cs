using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Combos
    {
        [Key]

        public int ComboID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

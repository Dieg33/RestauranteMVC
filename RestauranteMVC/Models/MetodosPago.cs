using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class MetodosPago
    {
        [Key]
        public int MetodoID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion {  get; set; }
    }
}

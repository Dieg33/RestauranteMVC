using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Promociones
    {
        [Key] 
        public int PromocioneID { get; set; }
        public string Descripcion {  get; set; }
        public decimal Descuento { get; set; }
        public string ImagenURL { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin {  get; set; }

    }
}

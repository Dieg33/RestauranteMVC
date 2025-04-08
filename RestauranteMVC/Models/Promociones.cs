using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Promociones
    {
        [Key] 
        public int PromocionID { get; set; }
        public string Descripcion {  get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin {  get; set; }
        public ICollection<Promociones_Items> Promociones_Items { get; set; } = new List<Promociones_Items>();

    }
}

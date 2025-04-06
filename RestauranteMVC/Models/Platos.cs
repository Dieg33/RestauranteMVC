using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Platos
    {
        [Key]

        public int PlatoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenURL { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaID { get; set; }
    }
}

using RestauranteMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Platos
    {
        public int PlatoID { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string? ImagenURL { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? CategoriaID { get; set; }

        public required Categorias Categoria { get; set; }

        public ICollection<PlatosCombos> PlatosCombos { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Combo
    {
        [Key]
        public int ComboID { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? ImagenURL { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación muchos-a-muchos con Platos a través de la tabla intermedia
        public ICollection<PlatosCombos>? PlatosCombos { get; set; } = [];

        // Para la vista Create/Edit
        public List<int> PlatosSeleccionados { get; set; } = [];
    }
}

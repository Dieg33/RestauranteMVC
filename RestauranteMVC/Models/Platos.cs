using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    public class Plato
    {
        [Key]
        public int PlatoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }

        [Display(Name = "Imagen (URL)")]
        public string? ImagenURL { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Categoría")]
        public int? CategoriaID { get; set; }

        [ForeignKey("CategoriaID")]
        public Categoria? Categoria { get; set; }

        public ICollection<PlatosCombos>? PlatosCombos { get; set; }
    }
}

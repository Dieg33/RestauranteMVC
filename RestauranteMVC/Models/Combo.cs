using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Combo
    {
        [Key]
        public int ComboID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Descripcion { get; set; }

        [Display(Name = "Imagen (URL)")]
        public string? ImagenURL { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<PlatosCombos>? PlatosCombos { get; set; }
    }
}

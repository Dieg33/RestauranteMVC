using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class MetodoPago
    {
        [Key]
        public int MetodoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Descripcion { get; set; }
    }
}

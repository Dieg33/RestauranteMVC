using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}

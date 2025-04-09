using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Display(Name = "Foto del Empleado")]
        public string? UrlFotoEmpleado { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Telefono { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;

        public int? RolID { get; set; }

        [ForeignKey("RolID")]
        public Rol? Rol { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Mesa
    {
        [Key]
        public int MesaID { get; set; }

        [Required]
        [Display(Name = "Número de Mesa")]
        public int NumeroMesa { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Display(Name = "¿Ocupada?")]
        public bool Estado { get; set; } = false; // false = Disponible, true = Ocupada
    }
}

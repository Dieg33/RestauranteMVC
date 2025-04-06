using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Mesa
    {
        [Key]
        public int MesaID { get; set; }
        public int NumeroMesa { get; set; }
        public int Capacidad { get; set; }
        public bool Estado {  get; set; }

    }
}

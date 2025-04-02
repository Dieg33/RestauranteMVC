using System.Data;

namespace RestauranteMVC.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string urlFotoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public string contrasenia { get; set; }
    
        public int RolID { get; set; }
        public DateTime FechaIngreso {get; set;}

    }
}

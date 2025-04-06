using System.ComponentModel.DataAnnotations;

namespace RestauranteMVC.Models
{
    public class Categorias
    {
        [Key]

        public int CategoriaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion {  get; set; }
    }
}

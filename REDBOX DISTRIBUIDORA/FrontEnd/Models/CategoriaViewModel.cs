using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoriaViewModel
    {
        [Display(Name = "ID de la Categoría")]
        public int IdCategoria { get; set; }
        [Display(Name = "Categoría")]
        public string NombreCategoria { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoriaViewModel
    {
        [Display(Name = "ID de la Categoría")]
        public int IdCategoria { get; set; }


        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El nombre de la categoría es requerido."), MinLength(5, ErrorMessage = "El nombre es muy corto, mínimo 5 letras")]
        public string NombreCategoria { get; set; } = null!;
    }
}

using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "ID:")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre Completo:")]
        [Required(ErrorMessage = "El nombre de la persona es requerido.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Teléfono:")]
        [Required(ErrorMessage = "El número telefónico de la persona es requerido."), MinLength(8, ErrorMessage = "Formato de teléfono inválido, mínimo 8 dígitos son requeridos")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Cédula:")]
        [Required(ErrorMessage = "La cédula de la persona es requerida.")]
        public string Cedula { get; set; } = null!;

        [Display(Name = "Dirección:")]
        [Required(ErrorMessage = "Es requerido detallar la dirección de la persona.")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Usuario:")]
        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string NombreUsuario { get; set; } = null!;

        [Display(Name = "Contraseña:")]
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string ContraseniaUsuario { get; set; } = null!;

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Se debe definir el rol del usuario.")]
        public int IDRol { get; set; }
        public IEnumerable<Rol> Roles { get; set; }
        public Rol Rol { get; set; }


    }
}

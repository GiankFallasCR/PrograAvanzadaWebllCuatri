using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "ID:")]
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre Completo:")]
        public string Nombre { get; set; } = null!;
        [Display(Name = "Telefono:")]
        public string Telefono { get; set; } = null!;
        [Display(Name = "Cedula:")]
        public string Cedula { get; set; } = null!;
        [Display(Name = "Direccion:")]
        public string Direccion { get; set; } = null!;
        [Display(Name = "Usuario:")]
        public string NombreUsuario { get; set; } = null!;
        [Display(Name = "Contraseña:")]
        public string ContraseniaUsuario { get; set; } = null!;

        [Display(Name = "Rol")]
        public int IDRol { get; set; }
        public IEnumerable<Rol> Roles { get; set; }
        public Rol Rol { get; set; }


    }
}

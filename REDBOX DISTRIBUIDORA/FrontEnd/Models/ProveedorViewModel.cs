using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
	public class ProveedorViewModel
	{
        [Display(Name = "ID de Proveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public string NombreProveedor { get; set; } = null!;
        [Display(Name = "Telefono")]
        public string Telefono { get; set; } = null!;
        [Display(Name = "Cedula Juridica")]
        public string CedulaJuridica { get; set; } = null!;
        [Display(Name = "Direccion")]
        public string? Direccion { get; set; }
    }
}


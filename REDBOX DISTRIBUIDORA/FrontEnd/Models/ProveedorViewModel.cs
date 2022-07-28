using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
	public class ProveedorViewModel
	{
        [Display(Name = "ID del Proveedor")]
        public int IdProveedor { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public string NombreProveedor { get; set; } = null!;
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = null!;
        [Display(Name = "Cédula Jurídica")]
        public string CedulaJuridica { get; set; } = null!;
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }
    }
}


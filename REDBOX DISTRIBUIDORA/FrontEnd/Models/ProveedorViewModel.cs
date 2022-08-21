using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
	public class ProveedorViewModel
	{
        [Display(Name = "ID del Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Nombre del Proveedor")]
        [Required(ErrorMessage = "El nombre del proveedor es requerido.")]
        public string NombreProveedor { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El número telefónico del proveedor es requerido."), MinLength(8, ErrorMessage = "Formato de teléfono inválido, mínimo 8 dígitos son requeridos")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Cédula Jurídica")]
        [Required(ErrorMessage = "La cédula del proveedor es requerida.")]
        public string CedulaJuridica { get; set; } = null!;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Es requerido detallar la dirección del proveedor.")]
        public string? Direccion { get; set; }
    }
}


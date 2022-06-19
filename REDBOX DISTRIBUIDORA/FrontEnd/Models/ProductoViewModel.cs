using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Display(Name = "ID del Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string NombreProducto { get; set; } = null!;

        [Display(Name = "Precio del Producto")]
        public int PrecioProducto { get; set; }

        [Display(Name = "Stock del Producto")]
        public int CantidadDisponible { get; set; }

        [Display(Name = "Talla del Producto")]
        public string TallaProducto { get; set; } = null!;

        [Display(Name = "Fecha de Actualización")]
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Categoria del Producto")]
        public int IdCategoria { get; set; }
        public IEnumerable<Categorium> Categorias { get; set; }

        public Categorium Categorium { get; set; }



        [Display(Name = "Proveedor del Producto")]
        public int IdProveedor { get; set; }

        public IEnumerable<Proveedor> Proveedores { get; set; }

        public Proveedor Proveedor { get; set; }

        [Display(Name = "Imagen del Producto")]
        public byte[]? RutaImagen { get; set; }

    }
}

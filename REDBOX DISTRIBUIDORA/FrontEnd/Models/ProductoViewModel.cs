using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Display(Name = "ID del Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        public string NombreProducto { get; set; } = null!;

        [Display(Name = "Precio del Producto")]
        [Required(ErrorMessage = "El precio del producto es requerido.")]
        public int PrecioProducto { get; set; }

        [Display(Name = "Stock del Producto")]
        [Required(ErrorMessage = "El stock en inventario del producto es requerido.")]
        public int CantidadDisponible { get; set; }

        [Display(Name = "Talla del Producto")]
        [Required(ErrorMessage = "La talla del producto es requerido.")]
        public string TallaProducto { get; set; } = null!;

        [Display(Name = "Fecha de Actualización")]
        [Required(ErrorMessage = "Debe proporcionar la fecha de actualización del producto.")]
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Fecha de Registro")]
        [Required(ErrorMessage = "Es requerido que defina la fecha en la que se registró el producto.")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Categoria del Producto")]
        [Required(ErrorMessage = "La categoría del producto es requerida.")]
        public int IdCategoria { get; set; }
        public IEnumerable<Categorium> Categorias { get; set; }

        public Categorium Categorium { get; set; }



        [Display(Name = "Proveedor del Producto")]
        [Required(ErrorMessage = "El proveedor del producto es requerido.")]
        public int IdProveedor { get; set; }

        public IEnumerable<Proveedor> Proveedores { get; set; }

        public Proveedor Proveedor { get; set; }

        [Display(Name = "Imagen del Producto")]
        [Required(ErrorMessage = "Debe subir una imagen del producto.")]
        public byte[] RutaImagen { get; set; }

    }
}

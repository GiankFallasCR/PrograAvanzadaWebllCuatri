using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public int PrecioProducto { get; set; }
        public int CantidadDisponible { get; set; }
        public string TallaProducto { get; set; } = null!;
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public byte[]? RutaImagen { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}

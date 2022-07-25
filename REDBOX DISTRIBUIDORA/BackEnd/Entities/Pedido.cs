using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; } = null!;
        public DateTime FechaPedido { get; set; }
        public int CantidadProducto { get; set; }
        public int? IdProducto { get; set; }
        public int? IdEstado { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}

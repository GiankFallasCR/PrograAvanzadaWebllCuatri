using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PedidoViewModel
    {

        [Display(Name = "ID de Pedido")]
        public int IdPedido { get; set; }

        [Display(Name = "Número de Pedido")]
        public string NumeroPedido { get; set; } = null!;

        [Display(Name = "Fecha de Pedido")]
        public DateTime FechaPedido { get; set; }

        [Display(Name = "ID de Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Estado de Pedido")]
        public int IdEstado { get; set; }

        [Display(Name = "ID de Usuario")]

        public int IdUsuario { get; set; }

        //public virtual Estado IdEstadoNavigation { get; set; } = null!;
        //public virtual Producto IdProductoNavigation { get; set; } = null!;
        //public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}

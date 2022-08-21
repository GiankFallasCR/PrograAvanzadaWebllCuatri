using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PedidoViewModel
    {

        [Display(Name = "ID de Pedido")]
        public int IdPedido { get; set; }

        [Display(Name = "Número de Pedido")]
        [Required(ErrorMessage = "El código del pedido es requerido.")]
        public string NumeroPedido { get; set; } = null!;

        [Display(Name = "Fecha de Pedido")]
        [Required(ErrorMessage = "Es requerido que defina la fecha en la que se registró el pedido.")]
        public DateTime FechaPedido { get; set; }


        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El producto es requerido.")]
        public int IdProducto { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
        public Producto Producto { get; set; }


        [Display(Name = "Estado de Pedido")]
        public int IdEstado { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public Estado Estado { get; set; }



        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El usuario que realiza el pedido es requerido.")]
        public int IdUsuario { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public Usuario Usuario { get; set; }


        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad de compra es requerida.")]
        public int CantidadProducto { get; set; }
    }
}

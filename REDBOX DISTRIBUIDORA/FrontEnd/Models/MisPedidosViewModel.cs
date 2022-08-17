using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class MisPedidosViewModel
    {
        [Display(Name = "ID de Pedido")]
        public int IdPedido { get; set; }

        [Display(Name = "Número de Pedido")]
        public string NumeroPedido { get; set; } = null!;

        [Display(Name = "Fecha de Pedido")]
        public DateTime FechaPedido { get; set; }


        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
        public Producto Producto { get; set; }


        [Display(Name = "Estado de Pedido")]
        public string IdEstado { get; set; }
        //public IEnumerable<Estado> Estados { get; set; }
        //public Estado Estado { get; set; }



        [Display(Name = "Usuario")]

        public string IdUsuario { get; set; }
        //public IEnumerable<Usuario> Usuarios { get; set; }
        //public Usuario Usuario { get; set; }


        [Display(Name = "Cantidad")]

        public int CantidadProducto { get; set; }
    }
}

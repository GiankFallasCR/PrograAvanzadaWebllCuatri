using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface IDALPedido: IDALGenerico<Pedido>
    {
        bool setPedidoSP(int IdProducto, int Cantidad, int IdUsuario, string NumeroPedido /*DateTime FechaPedido*/ 
            /*int IdEstado*/);
    }
}

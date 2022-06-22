using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using BackEnd.DAL.Interfaces;
using BackEnd.DAL.Implementations;

namespace FrontEnd.Controllers
{
    public class PedidoController : Controller
    {

        IDALPedido pedidoDAL;
        IEstadoDAL estadoDAL;
        IProductoDAL productoDAL;
        //IUsuarioDAL usuarioDAL;

        private PedidoViewModel Convertir(Pedido pedido)
        {
            return new PedidoViewModel
            {
                IdPedido = pedido.IdPedido,
                NumeroPedido = pedido.NumeroPedido,
                FechaPedido = pedido.FechaPedido,
                IdEstado = pedido.IdPedido,
                IdProducto = (int)pedido.IdProducto,   
                IdUsuario = (int)pedido.IdUsuario
            };
        }


        #region Lista
        public IActionResult Index()
        {
            List<Pedido> pedidos;
            pedidoDAL = new DALPedidoIMP();


            pedidos = pedidoDAL.GetAll().ToList();
            List<PedidoViewModel> lista = new List<PedidoViewModel>();

            foreach (Pedido pedido in pedidos)
            {
                lista.Add(Convertir(pedido));
            }

            return View(lista);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {
            PedidoViewModel pedidos = new PedidoViewModel();
            estadoDAL = new EstadoDALImpl();
            productoDAL = new ProductoDALImpl();
            //usuarioDAL = new UsuarioDALImpl();

            pedidos.Estados = estadoDAL.GetAll();
            pedidos.Productos = productoDAL.GetAll();
            //pedidos.Usuarios = usuarioDAL.GetAll();

            return View(pedidos);

        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            pedidoDAL = new DALPedidoIMP();
            pedidoDAL.Add(pedido);

            return RedirectToAction("Index");
        }

        #endregion

        #region Editar

        public IActionResult Edit(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            PedidoViewModel pedidos = Convertir(pedidoDAL.Get(id));

            estadoDAL = new EstadoDALImpl();
            productoDAL = new ProductoDALImpl();
            //usuarioDAL = new UsuarioDALImpl();

            pedidos.Estados = estadoDAL.GetAll();
            pedidos.Productos = productoDAL.GetAll();
            //pedidos.Usuarios = usuarioDAL.GetAll();

            return View(pedidos);
        }

        [HttpPost]
        public IActionResult Edit(Pedido pedido)
        {

            pedidoDAL = new DALPedidoIMP();
            pedidoDAL.Update(pedido);
            return RedirectToAction("Index");
        }


        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            PedidoViewModel pedidos = Convertir(pedidoDAL.Get(id));

            estadoDAL = new EstadoDALImpl();
            productoDAL = new ProductoDALImpl();
            //usuarioDAL = new UsuarioDALImpl();

            pedidos.Estado = estadoDAL.Get(pedidos.IdEstado);
            pedidos.Producto = productoDAL.Get(pedidos.IdProducto);


           

            return View(pedidos);
        }


        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            PedidoViewModel pedido = Convertir(pedidoDAL.Get(id));




            return View(pedido);
        }

        [HttpPost]
        public IActionResult Delete(Pedido pedido)
        {

            pedidoDAL = new DALPedidoIMP();
            pedidoDAL.Remove(pedido);
            return RedirectToAction("Index");
        }


        #endregion

    }
}

using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class PedidoController : Controller
    {

        IDALPedido pedidoDAL;

        private PedidoViewModel Convertir(Pedido pedido)
        {
            return new PedidoViewModel
            {
                NumeroPedido = pedido.NumeroPedido,
                FechaPedido = pedido.FechaPedido,
                IdEstado = pedido.IdPedido,
                IdProducto = pedido.IdProducto,
                IdPedido = pedido.IdPedido,
                IdUsuario = pedido.IdUsuario
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

            return View();
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
            Pedido item = pedidoDAL.Get(id);




            return View(Convertir(item));
        }

        [HttpPost]
        public IActionResult Edit(Pedido category)
        {

            pedidoDAL = new DALPedidoIMP();
            pedidoDAL.Update(category);
            return RedirectToAction("Index");
        }


        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            Pedido item = pedidoDAL.Get(id);



            return View(Convertir(item));
        }


        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            Pedido item = pedidoDAL.Get(id);




            return View(Convertir(item));
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

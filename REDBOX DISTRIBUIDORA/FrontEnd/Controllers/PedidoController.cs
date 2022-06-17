using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
//test rob test
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
                IdEstado = pedido.IdPedido
            };
        }


        #region Lista
        public IActionResult Index()
        {
            pedidoDAL = new DALPedidoIMP();

            List<Pedido> lista;
            lista = pedidoDAL.GetAll().ToList();
            List<PedidoViewModel> pedidos = new List<PedidoViewModel>();

            foreach (Pedido item in lista)
            {

                pedidos.Add(Convertir(item));
            }

            return View(pedidos);
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

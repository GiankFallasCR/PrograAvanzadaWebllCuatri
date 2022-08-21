using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using BackEnd.DAL.Interfaces;
using BackEnd.DAL.Implementations;
using Microsoft.AspNetCore.Http;

namespace FrontEnd.Controllers
{
    public class PedidoController : Controller
    {

        IDALPedido pedidoDAL;
        IEstadoDAL estadoDAL;
        IProductoDAL productoDAL;
        IUsuarioDAL usuarioDAL;

        private PedidoViewModel Convertir(Pedido pedido)
        {
            return new PedidoViewModel
            {
                IdPedido = pedido.IdPedido,
                NumeroPedido = pedido.NumeroPedido,
                FechaPedido = pedido.FechaPedido,
                IdEstado = (int)pedido.IdEstado,
                IdProducto = (int)pedido.IdProducto,   
                IdUsuario = (int)pedido.IdUsuario,
                CantidadProducto = (int)pedido.CantidadProducto
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


        //Listado 2 para clientes, listado de 'mis pedidos'

        List<MisPedidosViewModel> mipedidoobj = new List<MisPedidosViewModel>();
        private BackEnd.Entities.BD_REDBOX_DISTRIBUIDORAContext _db = null;
        private bool _UsingExternalConnection;

        public IActionResult Index2()
        {

           int IDusuario = Int32.Parse(HttpContext.Session.GetString("idU"));

            this._db = new BackEnd.Entities.BD_REDBOX_DISTRIBUIDORAContext();
            this._UsingExternalConnection = false;

            try
            {
                using (var context = _db)
                {
                    try
                    {
                        var consultaMiPedido = (from u in context.Pedidos
                                                where u.IdUsuario == IDusuario
                                                select u);
                        foreach (var item in consultaMiPedido)
                        {
                            mipedidoobj.Add(new MisPedidosViewModel
                            {
                                IdPedido = item.IdPedido,
                                NumeroPedido = item.NumeroPedido,
                                FechaPedido = item.FechaPedido,
                                IdEstado = item.IdEstado.ToString()
                            });
                        }
                        _db.Dispose();
                        return View(mipedidoobj);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion

        #region Agregar
        public IActionResult Create()
        {
            PedidoViewModel pedidos = new PedidoViewModel();
            estadoDAL = new EstadoDALImpl();
            productoDAL = new ProductoDALImpl();
            usuarioDAL = new UsuarioDALImpl();

            pedidos.Estados = estadoDAL.GetAll();
            pedidos.Productos = productoDAL.GetAll();
            pedidos.Usuarios = usuarioDAL.GetAll();

            int min = 1;
            int max = 10000;

            Random rmd = new Random();

            ViewBag.NumPedidoVB = "ORDEN - "+ rmd.Next(min, max + 1).ToString();

            return View(pedidos);

        }

        //[HttpPost]
        //public IActionResult Create(Pedido pedido)
        //{
        //    pedidoDAL = new DALPedidoIMP();
        //    pedidoDAL.Add(pedido);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Create(PedidoViewModel pedido)
        {

            int usuario = Int32.Parse(HttpContext.Session.GetString("idU"));
            pedidoDAL = new DALPedidoIMP();
            pedidoDAL.setPedidoSP(pedido.IdProducto,pedido.CantidadProducto,usuario, pedido.NumeroPedido /*,pedido.FechaPedido,pedido.IdEstado*/);

            //return RedirectToAction("Details", new {pedido.IdPedido});
            return RedirectToAction("Index2");
        }

        

        #endregion

        #region Editar

        public IActionResult Edit(int id)
        {

            pedidoDAL = new DALPedidoIMP();
            PedidoViewModel pedidos = Convertir(pedidoDAL.Get(id));

            estadoDAL = new EstadoDALImpl();
            productoDAL = new ProductoDALImpl();
            usuarioDAL = new UsuarioDALImpl();

            pedidos.Estados = estadoDAL.GetAll();
            pedidos.Productos = productoDAL.GetAll();
            pedidos.Usuarios = usuarioDAL.GetAll();

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
            usuarioDAL = new UsuarioDALImpl();

            pedidos.Estado = estadoDAL.Get(pedidos.IdEstado);
            pedidos.Producto = productoDAL.Get(pedidos.IdProducto);
            pedidos.Usuario = usuarioDAL.Get(pedidos.IdUsuario);

           

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

using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {

        IProveedorDAL proveedorDAL;
        ICategoriaDAL categoriaDAL;
        IProductoDAL productoDAL;


        private ProductoViewModel Convertir(Producto producto)
        {
            return new ProductoViewModel
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.NombreProducto,
                PrecioProducto = producto.PrecioProducto,
                CantidadDisponible = producto.CantidadDisponible,
                TallaProducto = producto.TallaProducto,
                FechaActualizacion = producto.FechaActualizacion,
                FechaRegistro = producto.FechaRegistro,
                IdCategoria = producto.IdCategoria,
                IdProveedor = producto.IdProveedor,
                RutaImagen = producto.RutaImagen
            };
        }

        #region Lista
        public IActionResult Index()
        {
            List<Producto> productos;
            productoDAL = new ProductoDALImpl();

            productos = productoDAL.GetAll().ToList();
            List<ProductoViewModel> list = new List<ProductoViewModel>();
            foreach (Producto producto in productos)
            {
                list.Add(Convertir(producto));
            }

            return View(list);
        }
        #endregion

        #region Crear 
        public IActionResult Create()
        {
            ProductoViewModel productos = new ProductoViewModel();
            proveedorDAL = new ProveedorDALImpl();
            categoriaDAL = new CategoriaDALImpl();

            productos.Proveedores = proveedorDAL.GetAll();
            productos.Categorias = categoriaDAL.GetAll();

            return View(productos);
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            productoDAL = new ProductoDALImpl();
            productoDAL.Add(producto);

            return RedirectToAction("Details", new { id = producto.IdProducto });
            //return RedirectToAction("Index");
        }

        #endregion


        #region Detalles
        public IActionResult Details(int id)
        {
            productoDAL = new ProductoDALImpl();
            ProductoViewModel productos = Convertir(productoDAL.Get(id));

            proveedorDAL = new ProveedorDALImpl();
            categoriaDAL = new CategoriaDALImpl();

            productos.Proveedor = proveedorDAL.Get(productos.IdProveedor);
            productos.Categorium = categoriaDAL.Get(productos.IdCategoria);

            return View(productos);
        }
        #endregion

        #region Editar
        public IActionResult Edit(int id)
        {
            productoDAL = new ProductoDALImpl();
            ProductoViewModel productos = Convertir(productoDAL.Get(id));

            proveedorDAL = new ProveedorDALImpl();
            categoriaDAL = new CategoriaDALImpl();

            productos.Proveedores = proveedorDAL.GetAll();
            productos.Categorias = categoriaDAL.GetAll();

            return View(productos);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            productoDAL = new ProductoDALImpl();
            productoDAL.Update(producto);

            return RedirectToAction("Details", new { id = producto.IdProducto });
        }
        #endregion


        #region Eliminar 
        public IActionResult Delete(int id)
        {
            productoDAL = new ProductoDALImpl();
            ProductoViewModel producto = Convertir(productoDAL.Get(id));


            return View(producto);
        }

        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            productoDAL = new ProductoDALImpl();
            productoDAL.Remove(producto);

            return RedirectToAction("Index");
        }
        #endregion


    }
}

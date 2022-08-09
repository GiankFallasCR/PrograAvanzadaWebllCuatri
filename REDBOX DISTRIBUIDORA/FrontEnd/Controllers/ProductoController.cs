using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;
using FrontEnd.Permisos;
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
        private Producto Convertir2(ProductoViewModel producto)
        {
            return new Producto
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
        [ValidacionPermisoProducto]
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
        [ValidacionPermisoProducto]
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
        [ValidacionPermisoProducto]
        public IActionResult Create(Models.ProductoViewModel producto, List<IFormFile> upload)
        {
            try
            {
                if (upload.Count > 0)
                {
                    foreach (var file in upload)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            producto.RutaImagen = ms.ToArray();

                        }
                    }

                }
                productoDAL = new ProductoDALImpl();
                productoDAL.Add(Convertir2(producto));

                //return RedirectToAction("Details", new { id = producto.IdProducto });
                return RedirectToAction("Index");
                //

            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception)
            {

                throw;
            }


        }

        #endregion


        #region Detalles
        [ValidacionPermisoProducto]
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
        [ValidacionPermisoProducto]
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
        [ValidacionPermisoProducto]
        public IActionResult Edit(Producto producto)
        {
            productoDAL = new ProductoDALImpl();
            productoDAL.Update(producto);

            return RedirectToAction("Details", new { id = producto.IdProducto });
        }
        #endregion


        #region Eliminar
        [ValidacionPermisoProducto]
        public IActionResult Delete(int id)
        {
            productoDAL = new ProductoDALImpl();
            ProductoViewModel producto = Convertir(productoDAL.Get(id));


            return View(producto);
        }

        [HttpPost]
        [ValidacionPermisoProducto]
        public IActionResult Delete(Producto producto)
        {
            productoDAL = new ProductoDALImpl();
            productoDAL.Remove(producto);

            return RedirectToAction("Index");
        }
        #endregion


    }
}

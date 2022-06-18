using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using BackEnd.DAL.Interfaces;
using BackEnd.DAL.Implementations;

namespace FrontEnd.Controllers
{
    public class ProveedorController : Controller
    {

        IProveedorDAL proveedorDAL;

        private ProveedorViewModel Convertir(Proveedor proveedor)
        {
            return new ProveedorViewModel
            {
                IdProveedor=proveedor.IdProveedor,
                CedulaJuridica=proveedor.CedulaJuridica,
                Direccion=proveedor.Direccion,
                NombreProveedor=proveedor.NombreProveedor,
                Telefono=proveedor.Telefono
            };
        }


        #region Lista
        public IActionResult Index()
        {
            List<Proveedor> proveedores;
            proveedorDAL = new ProveedorDALImpl();
            proveedores = proveedorDAL.GetAll().ToList();
            List<ProveedorViewModel> lista = new List<ProveedorViewModel>();

            foreach (Proveedor proveedor in proveedores)
            {
                lista.Add(Convertir(proveedor));
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
        public IActionResult Create(Proveedor proveedor)
        {
            proveedorDAL = new ProveedorDALImpl();
            proveedorDAL.Add(proveedor);

            return RedirectToAction("Index");
        }

        #endregion

        #region Editar

        public IActionResult Edit(int id)
        {

            proveedorDAL = new ProveedorDALImpl();
            Proveedor item = proveedorDAL.Get(id);
            return View(Convertir(item));
        }

        [HttpPost]
        public IActionResult Edit(Proveedor proveedor)
        {

            proveedorDAL = new ProveedorDALImpl();
            proveedorDAL.Update(proveedor);
            return RedirectToAction("Index");
        }


        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {

            proveedorDAL = new ProveedorDALImpl();
            Proveedor item = proveedorDAL.Get(id);



            return View(Convertir(item));
        }


        #endregion

        #region Eliminar

        public IActionResult Delete(int id)
        {

            proveedorDAL = new ProveedorDALImpl();
            Proveedor item = proveedorDAL.Get(id);

            return View(Convertir(item));
        }

        [HttpPost]
        public IActionResult Delete(Proveedor proveedor)
        {

            proveedorDAL = new ProveedorDALImpl();
            proveedorDAL.Remove(proveedor);
            return RedirectToAction("Index");
        }


        #endregion

    }
}

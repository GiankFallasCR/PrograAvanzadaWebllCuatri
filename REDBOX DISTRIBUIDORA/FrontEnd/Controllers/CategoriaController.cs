using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;
using FrontEnd.Permisos;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoriaController : Controller
    {

        ICategoriaDAL categoriaDAL;

        private CategoriaViewModel Convertir(Categorium categorium)
        {
            return new CategoriaViewModel
            {
                IdCategoria = categorium.IdCategoria,
                NombreCategoria=categorium.NombreCategoria
                
            };
        }
        #region Lista
        [ValidacionPermisoCategoria]
        public IActionResult Index()
        {
            List<Categorium> categorias;
            categoriaDAL = new CategoriaDALImpl();
            categorias = categoriaDAL.GetAll().ToList();
            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();

            foreach (Categorium categorium in categorias)
            {
                lista.Add(Convertir(categorium));
            }

            return View(lista);
        }

        #endregion

        #region Agregar
        [ValidacionPermisoCategoria]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidacionPermisoCategoria]
        public IActionResult Create(Categorium categoria)
        {
            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Add(categoria);

            return RedirectToAction("Index");
        }

        #endregion

        #region Editar
        [ValidacionPermisoCategoria]
        public IActionResult Edit(int id)
        {

            categoriaDAL = new CategoriaDALImpl();
            Categorium item = categoriaDAL.Get(id);
            return View(Convertir(item));
        }

        [HttpPost]
        [ValidacionPermisoCategoria]
        public IActionResult Edit(Categorium categoria)
        {

            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Update(categoria);
            return RedirectToAction("Index");
        }


        #endregion



        #region Eliminar
        [ValidacionPermisoCategoria]
        public IActionResult Delete(int id)
        {


            categoriaDAL = new CategoriaDALImpl();
            Categorium item = categoriaDAL.Get(id);

            return View(Convertir(item));
        }

        [HttpPost]
        [ValidacionPermisoCategoria]
        public IActionResult Delete(Categorium categoria)
        {

            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Remove(categoria);
            return RedirectToAction("Index");
        }


        #endregion

    }
}

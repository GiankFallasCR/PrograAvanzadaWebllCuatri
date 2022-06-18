using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;
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
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorium categoria)
        {
            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Add(categoria);

            return RedirectToAction("Index");
        }

        #endregion

        #region Editar

        public IActionResult Edit(int id)
        {

            categoriaDAL = new CategoriaDALImpl();
            Categorium item = categoriaDAL.Get(id);
            return View(Convertir(item));
        }

        [HttpPost]
        public IActionResult Edit(Categorium categoria)
        {

            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Update(categoria);
            return RedirectToAction("Index");
        }


        #endregion

       

        #region Eliminar

        public IActionResult Delete(int id)
        {


            categoriaDAL = new CategoriaDALImpl();
            Categorium item = categoriaDAL.Get(id);

            return View(Convertir(item));
        }

        [HttpPost]
        public IActionResult Delete(Categorium categoria)
        {

            categoriaDAL = new CategoriaDALImpl();
            categoriaDAL.Remove(categoria);
            return RedirectToAction("Index");
        }


        #endregion

    }
}

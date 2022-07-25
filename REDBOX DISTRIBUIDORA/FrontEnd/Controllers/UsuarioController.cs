using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAL usuarioDAL;
        IRolDAL rolDAL;

        private UsuarioViewModel Convertir(Usuario usuario)
        {
            
            return new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Telefono = usuario.Telefono,
                Cedula = usuario.Cedula,
                Direccion = usuario.Direccion,
                NombreUsuario = usuario.NombreUsuario,
                ContraseniaUsuario = usuario.ContraseniaUsuario,
                IDRol = usuario.IdRol,
                             



            };
        }


        #region Lista
        public IActionResult Index()
        {
            List<Usuario> usuarios;
            usuarioDAL = new UsuarioDALImpl();
            usuarios = usuarioDAL.GetAll().ToList();
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            foreach (Usuario item in usuarios)
            {
                lista.Add(Convertir(item));
            }

            return View(lista);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            UsuarioViewModel usuarios = new UsuarioViewModel();
            rolDAL = new RolDALImpl();

            usuarios.Roles = rolDAL.GetAll();

            return View(usuarios);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Add(usuario);

            return RedirectToAction("Details", new { id = usuario.IdUsuario });
        }

        #endregion

        #region Detalles
        public IActionResult Details(int id)
        {
            
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuarios = Convertir(usuarioDAL.Get(id));

            rolDAL = new RolDALImpl();
            

            usuarios.Rol = rolDAL.Get(usuarios.IDRol);
            

            return View(usuarios);
        }
        #endregion

        #region Editar

        public IActionResult Edit(int id)
        {

            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuarios = Convertir(usuarioDAL.Get(id));

            rolDAL = new RolDALImpl();

            usuarios.Roles = rolDAL.GetAll();

            return View(usuarios);

        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {

            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Update(usuario);
            return RedirectToAction("Details", new { id = usuario.IdUsuario });
        }


        #endregion

        #region Eliminar 
        public IActionResult Delete(int id)
        {
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuario = Convertir(usuarioDAL.Get(id));


            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Remove(usuario);

            return RedirectToAction("Index");
        }
        #endregion

        #region Inicio Sesion
        public ActionResult InicioSesion()
        {
            return View();
        }
        #endregion
    }
}

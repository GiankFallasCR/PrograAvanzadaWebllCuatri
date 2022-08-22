using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL.Implementations;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using FrontEnd.Models;
using FrontEnd.Help;
using FrontEnd.Permisos;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAL usuarioDAL;
        IRolDAL rolDAL;
        UsuarioModel model = new UsuarioModel();


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
        [ValidacionPermisoUsuarios]
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
        [ValidacionPermisoUsuarios]
        public IActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                UsuarioViewModel usuarios = new UsuarioViewModel();
                rolDAL = new RolDALImpl();


                usuarios.Cedula = usuario.Cedula.ToString();
                usuarios.Nombre = usuario.Nombre.ToString();
                usuarios.Roles = rolDAL.GetAll();

                return View(usuarios);
            }
            catch (Exception ex)
            {
                return View("Error");
            }



        }

        [HttpPost]
        [ValidacionPermisoUsuarios]
        public IActionResult Create(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Add(usuario);

            return RedirectToAction("Details", new { id = usuario.IdUsuario });
        }

        #endregion

        #region Detalles
        [ValidacionPermisoUsuarios]
        public IActionResult Details(int id)
        {

            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuarios = Convertir(usuarioDAL.Get(id));

            rolDAL = new RolDALImpl();


            usuarios.Rol = rolDAL.Get(usuarios.IDRol);


            return View(usuarios);
        }
        #endregion

        [ValidacionPermisoUsuarios]
        public IActionResult BusquedaHacienda()
        {

            return View();

        }
        #region Hacienda
        [ValidacionPermisoUsuarios]
        public IActionResult Encontrado(UsuarioViewModel usuario)
        {
            var resultado = model.BuscarClientePorCedula(usuario.Cedula);

            if (resultado == null)
            {
                return View("Error");

            }
            else
            {
                return RedirectToAction("Create", resultado);
            }




        }
        #endregion

        #region Editar
        [ValidacionPermisoUsuarios]
        public IActionResult Edit(int id)
        {

            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuarios = Convertir(usuarioDAL.Get(id));

            rolDAL = new RolDALImpl();

            usuarios.Roles = rolDAL.GetAll();

            return View(usuarios);

        }

        [HttpPost]
        [ValidacionPermisoUsuarios]
        public IActionResult Edit(Usuario usuario)
        {

            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Update(usuario);
            return RedirectToAction("Details", new { id = usuario.IdUsuario });
        }


        #endregion

        #region Eliminar
        [ValidacionPermisoUsuarios]
        public IActionResult Delete(int id)
        {
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuario = Convertir(usuarioDAL.Get(id));


            return View(usuario);
        }

        [HttpPost]
        [ValidacionPermisoUsuarios]
        public IActionResult Delete(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Remove(usuario);

            return RedirectToAction("Index");
        }
        #endregion

        #region Inicio Sesion

        [validacionSesionError]
        public ActionResult InicioSesion()
        {
            return View();
        }

        
        [HttpPost]
        
        public ActionResult Acceder(string NombreUsuario, string ContraseniaUsuario)
        {

            UsuarioViewModel objvacio = new UsuarioViewModel();

            try
            {
                var resultado = model.BuscarLogin(NombreUsuario, ContraseniaUsuario);
                if (resultado != null)
                {
                    string nombre = resultado.Nombre;
                    string usuario = resultado.NombreUsuario;
                    string rol = resultado.IDRol.ToString();
                    string idU = resultado.IdUsuario.ToString();

                    HttpContext.Session.SetString("nombre",nombre);
                    HttpContext.Session.SetString("usuario", usuario);
                    HttpContext.Session.SetString("rol", rol);
                    HttpContext.Session.SetString("idU", idU);

                    //return Json(resultado, JsonRequestBehavior.AllowGet);
                    return RedirectToAction("Index", "Producto");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        public ActionResult Logout()
        {


            HttpContext.Session.Clear();

            return RedirectToAction("InicioSesion");


        }
    }
}

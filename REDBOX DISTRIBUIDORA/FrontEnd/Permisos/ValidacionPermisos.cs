using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrontEnd.Permisos
{
    public class validacionSesionError : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("usuario") != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
        }
    }


    public class ValidarSesionErrorNoLogueado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("usuario") == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }

    public class ValidacionPermisoUsuarios : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Session.GetString("usuario") != null &&
                filterContext.HttpContext.Session.GetString("rol") == "1")) // si es admin y hay sesion pasa
            {
                //ingresa
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }

    public class ValidacionPermisoCategoria : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Session.GetString("usuario") != null &&
                filterContext.HttpContext.Session.GetString("rol") == "1")) // si es admin y hay sesion pasa
            {
                //ingresa
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }

    public class ValidacionPermisoPedido : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Session.GetString("usuario") != null &&
                filterContext.HttpContext.Session.GetString("rol") == "1") || // si es admin y hay sesion pasa
                (filterContext.HttpContext.Session.GetString("usuario") != null && filterContext.HttpContext.Session.GetString("rol") == "3")|| // si es admin y hay sesion pasa
                (filterContext.HttpContext.Session.GetString("usuario") != null && filterContext.HttpContext.Session.GetString("rol") == "3")) // si es director entra
            {
                // la validaion de las funciones se hace en la interfaz limitando las funciones por rol
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }

    public class ValidacionPermisoProducto : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("usuario") != null &&
                filterContext.HttpContext.Session.GetString("rol") == "1")// si es admin y hay sesion pasa

            {
                // la validaion de las funciones se hace en la interfaz limitando las funciones por rol
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }
    public class ValidacionPermisoProveedor : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("usuario") != null &&
                filterContext.HttpContext.Session.GetString("rol") == "1")// si es admin y hay sesion pasa

            {
                // la validaion de las funciones se hace en la interfaz limitando las funciones por rol
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error",
                    Controller = "Home"
                }));
            }
        }

    }



}

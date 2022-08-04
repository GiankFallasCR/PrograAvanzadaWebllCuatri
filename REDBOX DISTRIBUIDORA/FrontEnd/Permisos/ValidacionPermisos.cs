namespace FrontEnd.Permisos
{
    public class validacionSesionError : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("Usuario") != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
        }
    }
}

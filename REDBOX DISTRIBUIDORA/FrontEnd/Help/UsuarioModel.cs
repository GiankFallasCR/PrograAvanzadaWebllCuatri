using System.Net;
using FrontEnd.Models;
using Newtonsoft.Json;


namespace FrontEnd.Help
{
    public class UsuarioModel
    {
        UsuarioViewModel usuarioobj = new UsuarioViewModel();
        private BackEnd.Entities.BD_REDBOX_DISTRIBUIDORAContext _db = null;
        private bool _UsingExternalConnection;

        public UsuarioViewModel BuscarLogin(string usuario, string contasennia)
        {

            this._db = new BackEnd.Entities.BD_REDBOX_DISTRIBUIDORAContext();
            this._UsingExternalConnection = false;

            try
            {
                using (var context = _db)
                {
                    try
                    {
                        var consultaUsuario = (from u in context.Usuarios
                                               where u.NombreUsuario == usuario && u.ContraseniaUsuario == contasennia
                                               select u);
                        foreach (var item in consultaUsuario)
                        {
                            usuarioobj.Nombre = item.Nombre.ToString();
                            usuarioobj.IDRol = item.IdRol;
                            usuarioobj.NombreUsuario = item.NombreUsuario.ToString();
                            usuarioobj.IdUsuario = item.IdUsuario;
                        }
                        _db.Dispose();
                        return usuarioobj;

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

        public UsuarioViewModel BuscarClientePorCedula(string identificacion)
        {



            string direccion = "https://api.hacienda.go.cr/fe/ae";
            string ruta = direccion + "?identificacion=" + identificacion;
            string respuesta = GetHttp(ruta);

            try
            {


                var Datos = JsonConvert.DeserializeObject<UsuarioViewModel>(respuesta);

                string nombreH = Datos?.Nombre;
                usuarioobj.Nombre = nombreH.ToString();
                usuarioobj.Cedula = identificacion.ToString();
                usuarioobj.NombreUsuario = identificacion.ToString();

                return usuarioobj;



            }
            catch (Exception ex)
            {

                return null;
            }



        }

        public static string GetHttp(string ruta)
        {

            try
            {
                WebRequest request = (WebRequest)WebRequest.Create(ruta);
                WebResponse response = (WebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }


}


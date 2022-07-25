using System.Net;
using FrontEnd.Models;
using Newtonsoft.Json;


namespace FrontEnd.Help
{
    public class UsuarioModel
    {


        public UsuarioViewModel BuscarClientePorCedula(string identificacion)
        {
            UsuarioViewModel usuarioobj = new UsuarioViewModel();


            string direccion = "https://api.hacienda.go.cr/fe/ae";
            string ruta = direccion + "?identificacion=" + identificacion;
            string respuesta = GetHttp(ruta);

            try
            {


                var Datos = JsonConvert.DeserializeObject<UsuarioViewModel>(respuesta);

                string nombreH = Datos?.Nombre;
                usuarioobj.Nombre = nombreH.ToString();
                usuarioobj.Cedula = identificacion.ToString();


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


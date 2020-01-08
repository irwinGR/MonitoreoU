using MonitoreoUniversal.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MonitoreoUniversal
{
    /// <summary>
    /// Descripción breve de ServicioSoap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioSoap : System.Web.Services.WebService
    {

        PruebasNegocio pruebasNegocio = new PruebasNegocio();

        [WebMethod]
        public Boolean Servicio(String cadena)
        {
            Boolean respuesta = false;
            String cadenas = cadena;
            if (cadenas != "" && cadenas.Contains("|"))
            {
                string[] cadenaDelimitada;
                cadenaDelimitada = cadenas.Split('*');
                string[] ParametrosEnCadena;
                ParametrosEnCadena = cadenaDelimitada[0].Split('|');
                int idDispositivo = Convert.ToInt32(ParametrosEnCadena[0]);
                string coordenadas = ParametrosEnCadena[1];
                string humedad = ParametrosEnCadena[2];
                string conductvidadElectrica = ParametrosEnCadena[3];

                try {
                    respuesta = pruebasNegocio.agregarPruebas(idDispositivo, coordenadas, humedad, conductvidadElectrica);
                }
                catch (Exception e) {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        //[WebMethod]
        //public Boolean ConsultaBitacora(String cadena)
        //{
        //    Boolean respuesta = false;
        //    String cadenas = cadena;
        //    if(cadenas != "" && cadenas.Contains("|"))
        //    {
        //        string[] cadenaDelimitada;
        //        cadenaDelimitada = cadenas.Split('*');
        //        string[] ParametrosEnCadena;
        //        ParametrosEnCadena = cadenaDelimitada[0].Split('|');
        //        int idDispositivo = Convert.ToInt32(ParametrosEnCadena[0]);

        //        try
        //        {
        //            respuesta = pruebasNegocio.getAllBitacora(idDispositivo);
        //        }
        //        catch (Exception e)
        //        {
        //            respuesta = false;
        //        }
        //    }
        //    return respuesta;
        //}
    }
}

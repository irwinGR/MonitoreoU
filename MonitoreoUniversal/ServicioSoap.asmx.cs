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
                int idDispositivo = 0;
                string coordenadas = "";
                int idVariable = 0;
                string valor = "";

                for (int i = 0; i < cadenaDelimitada.Length;i++) {

                    string[] ParametrosEnCadena;
                    ParametrosEnCadena = cadenaDelimitada[i].Split('|');
                    idDispositivo = Convert.ToInt32(ParametrosEnCadena[0]);
                    coordenadas = ParametrosEnCadena[1];
                    idVariable = Convert.ToInt32(ParametrosEnCadena[2]);
                    valor = ParametrosEnCadena[3];

                    try
                    {
                        respuesta = pruebasNegocio.agregarPruebas(idDispositivo, coordenadas, idVariable, valor);
                    }
                    catch (Exception e)
                    {
                        respuesta = false;
                    }
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

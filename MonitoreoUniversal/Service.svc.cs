using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.IO;
using System.Web.Services;
using MonitoreUniversal.Entidades;
using MonitoreoUniversal.Negocio;

namespace MonitoreoUniversal
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : System.Web.Services.WebService
    {

        UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
        PerfilesNegocio perfilesNegocio = new PerfilesNegocio();
        PuestosNegocio puestosNegocio = new PuestosNegocio();
        EstadosNegocio estadosNegocio = new EstadosNegocio();

        [OperationContract]
        [WebGet(UriTemplate = "/GetUsuarios", ResponseFormat = WebMessageFormat.Json)]
        public List<Usuarios> getAllUsuarios()
        {
            List<Usuarios> list = new List<Usuarios>();
            try
            {
                list = usuariosNegocio.getAllUsuarios();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/GetPerfil", ResponseFormat = WebMessageFormat.Json)]
        public List<Perfiles> getAllPerfiles()
        {
            List<Perfiles> list = new List<Perfiles>();
            try
            {
                list = perfilesNegocio.getAllPerfiles();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/GetPuestos", ResponseFormat = WebMessageFormat.Json)]
        public List<Puestos> getAllPuestos()
        {
            List<Puestos> list = new List<Puestos>();
            try
            {
                list = puestosNegocio.getAllPuestos();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return list;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/GetEstados", ResponseFormat = WebMessageFormat.Json)]
        public List<Estados> getAllEstados()
        {
            List<Estados> list = new List<Estados>();
            try
            {
                list = estadosNegocio.getAllEstados();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return list;
        }
    }
}

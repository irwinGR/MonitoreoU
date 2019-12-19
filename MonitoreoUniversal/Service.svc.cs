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
        IdiomasNegocio idiomasNegocio = new IdiomasNegocio();

        [OperationContract]
        [WebGet(UriTemplate = "/GetIdiomas", ResponseFormat = WebMessageFormat.Json)]
        public List<Idiomas> getAllIdiomas()
        {
            List<Idiomas> list = new List<Idiomas>();
            try
            {
                list = idiomasNegocio.getAllIdiomas();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertIdioma", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertIdiomas(Idiomas idiomas)
        {
            bool result = false;
            try
            {
                result = idiomasNegocio.registraIdiomas(idiomas);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarIdioma", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarIdiomas(Idiomas idiomas)
        {
            bool result = false;
            try
            {
                result = idiomasNegocio.editarIdiomas(idiomas);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarIdioma", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarIdiomas(Idiomas idiomas)
        {
            bool result = false;
            try
            {
                result = idiomasNegocio.eliminarIdiomas(idiomas);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

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
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertPerfil", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertPerfiles(Perfiles perfiles)
        {
            bool result = false;
            try
            {
                result = perfilesNegocio.registraPerfiles(perfiles);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarPerfil", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarPerfiles(Perfiles perfiles)
        {
            bool result = false;
            try
            {
                result = perfilesNegocio.editarPerfiles(perfiles);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarPerfil", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarPerfiles(Perfiles perfiles)
        {
            bool result = false;
            try
            {
                result = perfilesNegocio.eliminarPerfiles(perfiles);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
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

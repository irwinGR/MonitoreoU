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
        AccionesNegocio accionesNegocio = new AccionesNegocio();
        AccionesxPerfilNegocio accionesxPerfilNegocio = new AccionesxPerfilNegocio();
        AlertasNegocio alertasNegocio = new AlertasNegocio();
        CatalogosNegocio catalogosNegocio = new CatalogosNegocio();
        CentroMonitoreoNegocio centroMonitoreoNegocio = new CentroMonitoreoNegocio();
        CredencialesAccesoNegocio credencialesAccesoNegocio = new CredencialesAccesoNegocio();
        EmpresaNegocio empresaNegocio = new EmpresaNegocio();
        EstadosNegocio estadosNegocio = new EstadosNegocio();
        FallasDispositivosNegocio fallasDispositivosNegocio = new FallasDispositivosNegocio();
        IdiomasNegocio idiomasNegocio = new IdiomasNegocio();
        MagnitudNegocio magnitudNegocio = new MagnitudNegocio();
        MediosComunicacionNegocio mediosComunicacionNegocio = new MediosComunicacionNegocio();
        MunicipioDelegacionNegocio municipioDelegacionNegocio = new MunicipioDelegacionNegocio();
        PaisesNegocio paisesNegocio = new PaisesNegocio();
        PerfilesNegocio perfilesNegocio = new PerfilesNegocio();
        PersonalMantenimientoNegocio personalMantenimientoNegocio = new PersonalMantenimientoNegocio();
        PlacasNegocio placasNegocio = new PlacasNegocio();
        PruebasNegocio pruebasNegocio = new PruebasNegocio();
        PuestosNegocio puestosNegocio = new PuestosNegocio();
        ResponsablesNegocio responsablesNegocio = new ResponsablesNegocio();
        SectorNegocio sectorNegocio = new SectorNegocio();
        SensoresNegocio sensoresNegocio = new SensoresNegocio();
        ServicioNegocio servicioNegocio = new ServicioNegocio();
        SistemaMedicionNegocio sistemaMedicionNegocio = new SistemaMedicionNegocio();
        TemplateCorreoNegocio templateCorreoNegocio = new TemplateCorreoNegocio();
        TipoComunicacionNegocio tipoComunicacionNegocio = new TipoComunicacionNegocio();
        TipoDatoNegocio tipoDatoNegocio = new TipoDatoNegocio();
        UnidadLecturaNegocio unidadLecturaNegocio = new UnidadLecturaNegocio();
        UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
        VariablesNegocio variablesNegocio = new VariablesNegocio();

        #region Métodos - Acciones

        [OperationContract]
        [WebGet(UriTemplate = "/GetAcciones", ResponseFormat = WebMessageFormat.Json)]
        public List<Acciones> getAllAcciones()
        {
            List<Acciones> list = new List<Acciones>();
            try
            {
                list = accionesNegocio.getAllAcciones();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertAcciones", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertAcciones(Acciones acciones)
        {
            bool result = false;
            try
            {
                result = accionesNegocio.registrarAcciones(acciones);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarAcciones", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarAcciones(Acciones acciones)
        {
            bool result = false;
            try
            {
                result = accionesNegocio.editarAcciones(acciones);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarAcciones", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarAcciones(Acciones acciones)
        {
            bool result = false;
            try
            {
                result = accionesNegocio.eliminarAcciones(acciones);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Catalogos
        [OperationContract]
        [WebGet(UriTemplate = "/GetCatalogos", ResponseFormat = WebMessageFormat.Json)]
        public List<Catalogos> getAllCatalogos()
        {
            List<Catalogos> list = new List<Catalogos>();
            try
            {
                list = catalogosNegocio.getAllCatalogos();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertCatalogos", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertCatalogos(Catalogos catalogos)
        {
            bool result = false;
            try
            {
                result = catalogosNegocio.registrarCatalogos(catalogos);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarCatalogos", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarCatalogos(Catalogos catalogos)
        {
            bool result = false;
            try
            {
                result = catalogosNegocio.editarCatalogos(catalogos);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarCatalogos", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarCatalogos(Catalogos catalogos)
        {
            bool result = false;
            try
            {
                result = catalogosNegocio.eliminarCatalogos(catalogos);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Estados
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

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/getEstadosxPais", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<Estados> getEstadosxPais(int idPais)
        {
            List<Estados> list = new List<Estados>();
            try
            {
                list = estadosNegocio.getEstadosxPais(idPais);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertEstados", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertEstados(Estados estados)
        {
            bool result = false;
            try
            {
                result = estadosNegocio.registrarEstados(estados);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarEstados", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarEstados(Estados estados)
        {
            bool result = false;
            try
            {
                result = estadosNegocio.editarEstados(estados);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarEstados", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarEstados(Estados estados)
        {
            bool result = false;
            try
            {
                result = estadosNegocio.eliminarEstados(estados);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Idioma

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

        #endregion

        #region Métodos - Magnitud

        [OperationContract]
        [WebGet(UriTemplate = "/GetMagnitud", ResponseFormat = WebMessageFormat.Json)]
        public List<Magnitud> getAllMagnitud()
        {
            List<Magnitud> list = new List<Magnitud>();
            try
            {
                list = magnitudNegocio.getAllMagnitud();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertMagnitud", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertMagnitud(Magnitud magnitud)
        {
            bool result = false;
            try
            {
                result = magnitudNegocio.registrarMagnitud(magnitud);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarMagnitud", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarMagnitud(Magnitud magnitud)
        {
            bool result = false;
            try
            {
                result = magnitudNegocio.editarMagnitud(magnitud);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarMagnitud", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarMagnitud(Magnitud magnitud)
        {
            bool result = false;
            try
            {
                result = magnitudNegocio.eliminarMagnitud(magnitud);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - MediosComunicacion

        [OperationContract]
        [WebGet(UriTemplate = "/GetMediosComunicacion", ResponseFormat = WebMessageFormat.Json)]
        public List<MediosComunicacion> getAllMedioComunicacion()
        {
            List<MediosComunicacion> list = new List<MediosComunicacion>();
            try
            {
                list = mediosComunicacionNegocio.getAllMedioComunicacion();
            }
            catch
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertMediosComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertMediosComunicacion(MediosComunicacion mediosComunicacion)
        {
            bool result = false;
            try
            {
                result = mediosComunicacionNegocio.registrarMedioComunicacion(mediosComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarMediosComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarMediosComunicacion(MediosComunicacion mediosComunicacion)
        {
            bool result = false;
            try
            {
                result = mediosComunicacionNegocio.editarMedioComunicacion(mediosComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarMediosComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarMediosComunicacion(MediosComunicacion mediosComunicacion)
        {
            bool result = false;
            try
            {
                result = mediosComunicacionNegocio.eliminarMedioComunicacion(mediosComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - MunicipioDelegacion

        [OperationContract]
        [WebGet(UriTemplate = "/GetMunicipioDelegacion", ResponseFormat = WebMessageFormat.Json)]
        public List<MunicipioDelegacion> getAllMunicipioDelegacion()
        {
            List<MunicipioDelegacion> list = new List<MunicipioDelegacion>();
            try
            {
                list = municipioDelegacionNegocio.getAllMunicipioDelegacion();
            }
            catch
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertMunicipioDelegacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertMunicipioDelegacion(MunicipioDelegacion municipioDelegacion)
        {
            bool result = false;
            try
            {
                result = municipioDelegacionNegocio.registraMunicipioDelegacion(municipioDelegacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarMunicipioDelegacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarMunicipioDelegacion(MunicipioDelegacion municipioDelegacion)
        {
            bool result = false;
            try
            {
                result = municipioDelegacionNegocio.editarMunicipioDelegacion(municipioDelegacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarMunicipioDelegacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarMunicipioDelegacion(MunicipioDelegacion municipioDelegacion)
        {
            bool result = false;
            try
            {
                result = municipioDelegacionNegocio.eliminarMunicipioDelegacion(municipioDelegacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Paises

        [OperationContract]
        [WebGet(UriTemplate = "/GetPaises", ResponseFormat = WebMessageFormat.Json)]
        public List<Paises> getAllPaises()
        {
            List<Paises> list = new List<Paises>();
            try
            {
                list = paisesNegocio.getAllPaises();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertPaises", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertPaises(Paises paises)
        {
            bool result = false;
            try
            {
                result = paisesNegocio.registraPais(paises);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarPaises", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarPais(Paises paises)
        {
            bool result = false;
            try
            {
                result = paisesNegocio.editarPais(paises);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarPaises", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarPais(Paises paises)
        {
            bool result = false;
            try
            {
                result = paisesNegocio.eliminarPais(paises);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Perfil

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

        #endregion

        #region Métodos - PersonalMantenimiento

        [OperationContract]
        [WebGet(UriTemplate = "/GetPersonalMantenimiento", ResponseFormat = WebMessageFormat.Json)]
        public List<PersonalMantenimiento> getAllPersonalMantenimiento()
        {
            List<PersonalMantenimiento> list = new List<PersonalMantenimiento>();
            try
            {
                list = personalMantenimientoNegocio.getAllPersonalMantenimiento();
            }
            catch
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertPersonalMantenimiento", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            bool result = false;
            try
            {
                result = personalMantenimientoNegocio.registraPersonalMantenimiento(personalMantenimiento);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarPersonalMantenimiento", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            bool result = false;
            try
            {
                result = personalMantenimientoNegocio.editarPersonalMantenimiento(personalMantenimiento);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarPersonalMantenimiento", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            bool result = false;
            try
            {
                result = personalMantenimientoNegocio.eliminarPersonalMantenimiento(personalMantenimiento);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Bitacora

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/GetBitacora", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public List<Pruebas> getAllBitacora(int idDispostivo)
        {
            List<Pruebas> list = new List<Pruebas>();
            try
            {
                list = pruebasNegocio.getAllBitacora(idDispostivo);
            }
            catch (Exception e)
            {
            }
            return list;
        }

        #endregion

        #region Métodos - Prueba

        [OperationContract]
        [WebGet(UriTemplate = "/GetPrueba", ResponseFormat = WebMessageFormat.Json)]
        public List<Pruebas> getAllPrueba()
        {
            List<Pruebas> list = new List<Pruebas>();
            try
            {
                list = pruebasNegocio.getAllPruebas();
            }
            catch (Exception e)
            {

            }
            return list;
        }

        #endregion

        #region Métodos - Puestos

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

        #endregion

        #region Métodos - Responsables

        [OperationContract]
        [WebGet(UriTemplate = "/GetResponsables", ResponseFormat = WebMessageFormat.Json)]
        public List<Responsables> getAllResponsables()
        {
            List<Responsables> list = new List<Responsables>();
            try
            {
                list = responsablesNegocio.getAllResponsables();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertResponsables", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertResponsables(Responsables responsables)
        {
            bool result = false;
            try
            {
                result = responsablesNegocio.registraResponsables(responsables);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarResponsables", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarResponsables(Responsables responsables)
        {
            bool result = false;
            try
            {
                result = responsablesNegocio.editarResponsables(responsables);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarResponsables", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarResponsables(Responsables responsables)
        {
            bool result = false;
            try
            {
                result = responsablesNegocio.eliminarResponsables(responsables);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - Sector

        [OperationContract]
        [WebGet(UriTemplate = "/GetSector", ResponseFormat = WebMessageFormat.Json)]
        public List<Sector> getAllSector()
        {
            List<Sector> list = new List<Sector>();
            try
            {
                list = sectorNegocio.getAllSector();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertSector", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertSector(Sector sector)
        {
            bool result = false;
            try
            {   
                result = sectorNegocio.registrarSector(sector);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarSector", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarSector(Sector sector)
        {
            bool result = false;
            try
            {
                result = sectorNegocio.editarSector(sector);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarSector", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarSector(Sector sector)
        {
            bool result = false;
            try
            {
                result = sectorNegocio.eliminarSector(sector);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - SistemaMedicion

        [OperationContract]
        [WebGet(UriTemplate = "/GetSistemaMedicion", ResponseFormat = WebMessageFormat.Json)]
        public List<SistemaMedicion> getAllSistemaMedicion()
        {
            List<SistemaMedicion> list = new List<SistemaMedicion>();
            try
            {
                list = sistemaMedicionNegocio.getAllSistemaMedicion();
            }
            catch
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertSistemaMedicion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            bool result = false;
            try
            {
                result = sistemaMedicionNegocio.registrarSistemaMedicion(sistemaMedicion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarSistemaMedicion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            bool result = false;
            try
            {
                result = sistemaMedicionNegocio.editarSistemaMedicion(sistemaMedicion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarSistemaMedicion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            bool result = false;
            try
            {
                result = sistemaMedicionNegocio.eliminarSistemaMedicion(sistemaMedicion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - TipoComunicacion

        [OperationContract]
        [WebGet(UriTemplate = "/GetTipoComunicacion", ResponseFormat = WebMessageFormat.Json)]
        public List<TipoComunicacion> getAllTipoComunicacion()
        {
            List<TipoComunicacion> list = new List<TipoComunicacion>();
            try
            {
                list = tipoComunicacionNegocio.getAllTipoComunicacion();
            }
            catch
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertTipoComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            bool result = false;
            try
            {
                result = tipoComunicacionNegocio.registrarTipoComunicacion(tipoComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarTipoComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            bool result = false;
            try
            {
                result = tipoComunicacionNegocio.editarTipoComunicacion(tipoComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarTipoComunicacion", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            bool result = false;
            try
            {
                result = tipoComunicacionNegocio.eliminarTipoComunicacion(tipoComunicacion);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - TipoDato

        [OperationContract]
        [WebGet(UriTemplate = "/GetTipoDato", ResponseFormat = WebMessageFormat.Json)]
        public List<TipoDato> getAllTipoDato()
        {
            List<TipoDato> list = new List<TipoDato>();
            try
            {
                list = tipoDatoNegocio.getAllTipoDato();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertTipoDato", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertTipoDato(TipoDato tipoDato)
        {
            bool result = false;
            try
            {
                result = tipoDatoNegocio.registrarTipoDato(tipoDato);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EditarTipoDato", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarTipoDato(TipoDato tipoDato)
        {
            bool result = false;
            try
            {
                result = tipoDatoNegocio.editarTipoDato(tipoDato);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarTipoDato", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarTipoDato(TipoDato tipoDato)
        {
            bool result = false;
            try
            {
                result = tipoDatoNegocio.eliminarTipoDato(tipoDato);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region Métodos - UnidadLectura

        [OperationContract]
        [WebGet(UriTemplate = "/GetUnidadLectura", ResponseFormat = WebMessageFormat.Json)]
        public List<UnidadLectura> getAllUnidadLectura()
        {
            List<UnidadLectura> list = new List<UnidadLectura>();
            try
            {
                list = unidadLecturaNegocio.getAllUnidadLectura();
            }
            catch (Exception e)
            {
            }
            return list;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUnidadLectura", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean insertUnidadLectura(UnidadLectura unidadLectura)
        {
            bool result = false;
            try
            {
                result = unidadLecturaNegocio.registrarUnidadLectura(unidadLectura);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "EditarUnidadLectura", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean editarUnidadLectura(UnidadLectura unidadLectura)
        {
            bool result = false;
            try
            {
                result = unidadLecturaNegocio.editarUnidadLectura(unidadLectura);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        [OperationContract]
        [return: MessageParameter(Name = "result")]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarUnidadLectura", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public Boolean eliminarUnidadLectura(UnidadLectura unidadLectura)
        {
            bool result = false;
            try
            {
                result = unidadLecturaNegocio.eliminarUnidadLectura(unidadLectura);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        #endregion

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
    }
}

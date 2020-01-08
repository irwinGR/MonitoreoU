using MonitoreoUniversal.Framework.AccesoDatos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Datos
{
    public class EmpresaDatos
    { 
        public List<Empresa> getAllEmpresa()
        {
            List<Empresa> empresa = new List<Empresa>();
            SqlConnection connection;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaEmpresaSP");
                }
                foreach (DataRow row in dt.Rows)
                {
                    Empresa empre = new Empresa();
                    empre.idCliente = Convert.ToInt32(row["idCliente"].ToString());
                    empre.nombre = row["nombre"].ToString();
                    empre.comprobanteServicio = row["comprobanteServicio"].ToString();
                    empre.contraseña = row["contraseña"].ToString();
                    empre.correo = row["correo"].ToString();
                    empre.telefono = row["telefono"].ToString();
                    empre.tipoPersona = row["tipoPersona"].ToString();
                    empre.codigoPostal = row["codigoPostal"].ToString();
                    empre.numeroExterior = Convert.ToInt32(row["numeroExterior"].ToString());
                    empre.calle = row["calle"].ToString();
                    empre.numeroInterior = Convert.ToInt32(row["numeroInterior"].ToString());
                    empre.razonSocial = row["razonSocial"].ToString();
                    empre.RFC = row["RFC"].ToString();

                    MunicipioDelegacion municipioDelegacion = new MunicipioDelegacion();
                    empre.municipioDelegacion = municipioDelegacion;
                    empre.municipioDelegacion.idMunicipioDelegacion = Convert.ToInt32(row["idMunicipioDelegacion"].ToString());

                    Estados estados = new Estados();
                    empre.estados = estados;
                    empre.estados.idEstado = Convert.ToInt32(row["idEstado"].ToString());

                    Paises paises = new Paises();
                    empre.paises = paises;
                    empre.paises.idPais = Convert.ToInt32(row["idPais"].ToString());

                    Idiomas idiomas = new Idiomas();
                    empre.idiomas = idiomas;
                    empre.idiomas.idIdioma = Convert.ToInt32(row["idIdioma"].ToString());

                    Sector sector = new Sector();
                    empre.sector = sector;
                    empre.sector.idSector = Convert.ToInt32(row["idSector"].ToString());

                    Servicio servicio = new Servicio();
                    empre.servicio = servicio;
                    empre.servicio.idServicio = Convert.ToInt32(row["idServicio"].ToString());

                    empresa.Add(empre);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return empresa;
        }
        public Boolean registrarEmpresa(Empresa empresa)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,empresa.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@comprobanteServicio",SqlDbType.VarChar,empresa.comprobanteServicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,empresa.contraseña,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,empresa.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,empresa.telefono,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tipoPersona",SqlDbType.VarChar,empresa.tipoPersona,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@codigoPostal",SqlDbType.VarChar,empresa.codigoPostal,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroExterior",SqlDbType.VarChar,empresa.numeroExterior,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@calle",SqlDbType.VarChar,empresa.calle,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroInterior",SqlDbType.VarChar,empresa.numeroInterior,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@razonSocial",SqlDbType.VarChar,empresa.razonSocial,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@RFC",SqlDbType.VarChar,empresa.RFC,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion", SqlDbType.VarChar,empresa.municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.VarChar,empresa.estados.idEstado,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.VarChar,empresa.paises.idPais,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idIdioma",SqlDbType.VarChar, empresa.idiomas.idIdioma,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSector",SqlDbType.VarChar, empresa.sector.idSector,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idServicio",SqlDbType.VarChar, empresa.servicio.idServicio,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarEmpresaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch(Exception e)
            {
                respuesta = false;
                Console.WriteLine(e);
            }
            return respuesta;
        }
        public Boolean editarEmpresa(Empresa empresa)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,empresa.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@comprobanteServicio",SqlDbType.VarChar,empresa.comprobanteServicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,empresa.contraseña,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,empresa.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,empresa.telefono,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tipoPersona",SqlDbType.VarChar,empresa.tipoPersona,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@codigoPostal",SqlDbType.VarChar,empresa.codigoPostal,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroExterior",SqlDbType.VarChar,empresa.numeroExterior,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@calle",SqlDbType.VarChar,empresa.calle,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroInterior",SqlDbType.VarChar,empresa.numeroInterior,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@razonSocial",SqlDbType.VarChar,empresa.razonSocial,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@RFC",SqlDbType.VarChar,empresa.RFC,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion", SqlDbType.VarChar,empresa.municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.VarChar,empresa.estados.idEstado,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.VarChar,empresa.paises.idPais,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idIdioma",SqlDbType.VarChar, empresa.idiomas.idIdioma,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSector",SqlDbType.VarChar, empresa.sector.idSector,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idServicio",SqlDbType.VarChar, empresa.servicio.idServicio,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarEmpresaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch(Exception e)
            {
                respuesta = false;
                Console.WriteLine(e);
            }
            return respuesta;
        }
        public Boolean eliminarEmpresa(Empresa empresa)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@idCliente",SqlDbType.VarChar,empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarEmpresaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch(Exception e)
            {
                respuesta = false;
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}

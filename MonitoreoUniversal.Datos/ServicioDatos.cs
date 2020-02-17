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
    public class ServicioDatos
    {
        public List<Servicio> getAllServicio()
        {
            List<Servicio> servicio = new List<Servicio>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaServicioSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    Servicio serv = new Servicio();
                    serv.idServicio = row["idServicio"].ToString();
                    serv.nombre = row["nombre"].ToString();
                    serv.descripcion = row["descripcion"].ToString();
                    serv.objetivo = row["objetivo"].ToString();
                    serv.fechaInicio = row["fechaInicio"].ToString();
                    serv.fechaFin = row["fechaFin"].ToString();
                    serv.duracion = row["duracion"].ToString();
                    serv.contratoServicio = row["contratoServicio"].ToString();
                    serv.fechaFacturacion = row["fechaFacturacion"].ToString();
                    serv.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    MunicipioDelegacion municipioDelegacion = new MunicipioDelegacion();
                    serv.municipioDelegacion = municipioDelegacion;
                    serv.municipioDelegacion.idMunicipioDelegacion = row["idMunicipioDelegacion"].ToString();

                    Estados estados = new Estados();
                    serv.estados = estados;
                    serv.estados.idEstado = row["idEstado"].ToString();

                    Paises paises = new Paises();
                    serv.paises = paises;
                    serv.paises.idPais = row["idPais"].ToString();

                    Sector sector = new Sector();
                    serv.sector = sector;
                    serv.sector.idSector = row["idSector"].ToString();

                    Dispositivos dispositivo = new Dispositivos();
                    serv.dispositivo = dispositivo;
                    serv.dispositivo.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());

                    PersonalMantenimiento personalMantenimiento = new PersonalMantenimiento();
                    serv.personalMantenimiento = personalMantenimiento;
                    serv.personalMantenimiento.idPersonalMantenimiento = Convert.ToInt32(row["idPersonalMantenimiento"].ToString());

                    Responsables responsables = new Responsables();
                    serv.responsables = responsables;
                    serv.responsables.idReponsable = Convert.ToInt32(row["idReponsable"].ToString());

                    servicio.Add(serv);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return servicio;
        }
        public Boolean registrarServicio(Servicio servicio)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,servicio.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,servicio.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@objetivo",SqlDbType.VarChar,servicio.objetivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("fechaInicio",SqlDbType.VarChar,servicio.fechaInicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin",SqlDbType.VarChar,servicio.fechaFin,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@duracion",SqlDbType.VarChar,servicio.duracion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contratoServicio",SqlDbType.VarChar,servicio.contratoServicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFacturacion",SqlDbType.VarChar,servicio.fechaFacturacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion",SqlDbType.VarChar,servicio.municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.VarChar,servicio.estados.idEstado,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.VarChar,servicio.paises.idPais,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSector",SqlDbType.VarChar,servicio.sector.idSector,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,servicio.dispositivo.idDispositivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPersonalMantenimiento",SqlDbType.VarChar,servicio.personalMantenimiento.idPersonalMantenimiento,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idReponsable",SqlDbType.VarChar,servicio.responsables.idReponsable,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administración.AgregarServicioSP", parametros);
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
        public Boolean editarServicio(Servicio servicio)
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
                        ParametroAcceso.CrearParametro("@idServicio",SqlDbType.VarChar,servicio.idServicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,servicio.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,servicio.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@objetivo",SqlDbType.VarChar,servicio.objetivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("fechaInicio",SqlDbType.VarChar,servicio.fechaInicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin",SqlDbType.VarChar,servicio.fechaFin,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@duracion",SqlDbType.VarChar,servicio.duracion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contratoServicio",SqlDbType.VarChar,servicio.contratoServicio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFacturacion",SqlDbType.VarChar,servicio.fechaFacturacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion",SqlDbType.VarChar,servicio.municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.VarChar,servicio.estados.idEstado,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.VarChar,servicio.paises.idPais,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSector",SqlDbType.VarChar,servicio.sector.idSector,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,servicio.dispositivo.idDispositivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPersonalMantenimiento",SqlDbType.VarChar,servicio.personalMantenimiento.idPersonalMantenimiento,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idReponsable",SqlDbType.VarChar,servicio.responsables.idReponsable,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarServicioSP", parametros);
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
        public Boolean eliminarServicio(Servicio servicio)
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
                        ParametroAcceso.CrearParametro("@idServicio",SqlDbType.VarChar,servicio.idServicio,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarServicioSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                respuesta = false;
                Console.WriteLine(e);
            }
            return respuesta;
        }
    }
}

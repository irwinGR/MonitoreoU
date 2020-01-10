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
    public class SensoresDatos
    {
        public List<Sensores> getAllSensores()
        {
            List<Sensores> sensores = new List<Sensores>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaSensoresSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Sensores sens = new Sensores();
                    sens.idSensor = Convert.ToInt32(row["idSensor"].ToString());
                    sens.numeroSerie = row["numeroSerie"].ToString();
                    sens.tiempoLectura = row["tiempoLectura"].ToString();
                    sens.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    Placas placas = new Placas();
                    sens.placas = placas;
                    sens.placas.idPlaca = Convert.ToInt32(row["idPlaca"].ToString());

                    UnidadLectura unidadLectura = new UnidadLectura();
                    sens.unidadLectura = unidadLectura;
                    sens.unidadLectura.idUnidadLectura = Convert.ToInt32(row["idUnidadLectura"].ToString());

                    SistemaMedicion sistemaMedicion = new SistemaMedicion();
                    sens.sistemaMedicion = sistemaMedicion;
                    sens.sistemaMedicion.idSistemaMedicion = Convert.ToInt32(row["idSistemaMedicion"].ToString());

                    Magnitud magnitud = new Magnitud();
                    sens.magnitud = magnitud;
                    sens.magnitud.idMagnitud = Convert.ToInt32(row["idMagnitud"].ToString());

                    Empresa empresa = new Empresa();
                    sens.empresa = empresa;
                    sens.empresa.idCliente = Convert.ToInt32(row["idCliente"].ToString());

                    sensores.Add(sens);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return sensores;
        }
        public Boolean registrarSensores(Sensores sensores)
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
                        ParametroAcceso.CrearParametro("@numeroSerie",SqlDbType.VarChar,sensores.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tiempoLectura",SqlDbType.VarChar,sensores.tiempoLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,sensores.placas.idPlaca,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idUnidadLectura",SqlDbType.VarChar,sensores.unidadLectura.idUnidadLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSistemaMedicion",SqlDbType.VarChar,sensores.sistemaMedicion.idSistemaMedicion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMagnitud",SqlDbType.VarChar,sensores.magnitud.idMagnitud,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa",SqlDbType.VarChar,sensores.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarSensoresSP", parametros);
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
        public Boolean editarSensores(Sensores sensores)
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
                        ParametroAcceso.CrearParametro("@idSensor",SqlDbType.VarChar,sensores.idSensor,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroSerie",SqlDbType.VarChar,sensores.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tiempoLectura",SqlDbType.VarChar,sensores.tiempoLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,sensores.placas.idPlaca,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idUnidadLectura",SqlDbType.VarChar,sensores.unidadLectura.idUnidadLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSistemaMedicion",SqlDbType.VarChar,sensores.sistemaMedicion.idSistemaMedicion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMagnitud",SqlDbType.VarChar,sensores.magnitud.idMagnitud,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa",SqlDbType.VarChar,sensores.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizaSensoresSP", parametros);
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
        public Boolean eliminarSensores(Sensores sensores)
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
                        ParametroAcceso.CrearParametro("@idSensor",SqlDbType.VarChar,sensores.idSensor,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarSensoresSP", parametros);
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

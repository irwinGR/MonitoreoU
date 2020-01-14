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
    public class CentroMonitoreoDatos
    {
        public List<CentroMonitoreo> getAllCentroMonitoreo()
        {
            List<CentroMonitoreo> centroMonitoreo = new List<CentroMonitoreo>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaCentroMonitoreoSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    CentroMonitoreo centMoni = new CentroMonitoreo();

                    centMoni.idCentroMonitoreo = Convert.ToInt32(row["idCentroMonitoreo"].ToString());
                    centMoni.nombre = row["nombre"].ToString();


                    Empresa empresa = new Empresa();
                    centMoni.empresa = empresa;
                    centMoni.empresa.idCliente = Convert.ToInt32(row["idEmpresa"].ToString());

                    centroMonitoreo.Add(centMoni);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return centroMonitoreo;
        }
        public Boolean registrarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,centroMonitoreo.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idCliente",SqlDbType.VarChar,centroMonitoreo.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarCentroMonitoreoSP", parametros);
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
        public Boolean editarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,centroMonitoreo.nombre,ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("@idCliente",SqlDbType.VarChar,centroMonitoreo.empresa.idCliente,ParameterDirection.Input)

                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarCentroMonitoreoSP", parametros);
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
        public Boolean eliminarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
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
                        ParametroAcceso.CrearParametro("@idCentroMonitoreo",SqlDbType.VarChar,centroMonitoreo.idCentroMonitoreo,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarCentroMonitoreoSP", parametros);
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
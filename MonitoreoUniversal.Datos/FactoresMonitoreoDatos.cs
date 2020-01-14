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
    public class FactoresMonitoreoDatos
    {
        public List<FactoresMonitoreo> getAllFactoresMonitoreo()
        {
            List<FactoresMonitoreo> factoresMonitoreo = new List<FactoresMonitoreo>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaFactoresMonitoreoSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    FactoresMonitoreo facMoni = new FactoresMonitoreo();
                    facMoni.nombre = row["nombre"].ToString();
                    facMoni.formato = Convert.ToDecimal(row["formato"].ToString());
                    facMoni.valorMinimo = Convert.ToDecimal(row["valorMinimo"].ToString());
                    facMoni.valorMaximo = Convert.ToDecimal(row["valorMaximo"].ToString());
                    facMoni.escala = row["escala"].ToString();
                    facMoni.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    TipoDato tipoDato = new TipoDato();
                    facMoni.tipoDato = tipoDato;
                    facMoni.tipoDato.idTipoDato = Convert.ToInt32(row["idTipoDato"].ToString());

                    factoresMonitoreo.Add(facMoni);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return factoresMonitoreo;
        }
        public Boolean registrarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,factoresMonitoreo.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@formato",SqlDbType.VarChar,factoresMonitoreo.formato,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@valorMinimo",SqlDbType.VarChar,factoresMonitoreo.valorMinimo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@valor Maximo",SqlDbType.VarChar,factoresMonitoreo.valorMaximo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoDato",SqlDbType.VarChar,factoresMonitoreo.tipoDato.idTipoDato,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@escala",SqlDbType.VarChar,factoresMonitoreo.escala,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,factoresMonitoreo.nombre,ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarFactoresMonitoreoSP", parametros);
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
        public Boolean editarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
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
                        ParametroAcceso.CrearParametro("@idUnidadMedida",SqlDbType.VarChar,factoresMonitoreo.idUnidadMedida,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,factoresMonitoreo.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@formato",SqlDbType.VarChar,factoresMonitoreo.formato,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@valorMinimo",SqlDbType.VarChar,factoresMonitoreo.valorMinimo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@valor Maximo",SqlDbType.VarChar,factoresMonitoreo.valorMaximo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoDato",SqlDbType.VarChar,factoresMonitoreo.tipoDato.idTipoDato,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@escala",SqlDbType.VarChar,factoresMonitoreo.escala,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,factoresMonitoreo.nombre,ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarFactoresMonitoreoSP", parametros);
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
        public Boolean eliminarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
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
                        ParametroAcceso.CrearParametro("@idUnidadMedida",SqlDbType.VarChar,factoresMonitoreo.idUnidadMedida,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarFactoresMonitoreoSP", parametros);
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
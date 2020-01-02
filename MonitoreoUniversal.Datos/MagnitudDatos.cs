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
    public class MagnitudDatos
    {
        public List<Magnitud> getAllMagnitud()
        {
            List<Magnitud> magnitudes = new List<Magnitud>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaMagnitudSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Magnitud magni = new Magnitud();
                    magni.idMagnitud = Convert.ToInt32(row["idMagnitud"].ToString());
                    magni.descripcion = row["descripcion"].ToString();
                    magni.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    magnitudes.Add(magni);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return magnitudes;
        }
        public Boolean registrarMagnitud(Magnitud magnitudes)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,magnitudes.descripcion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarMagnitudSP", parametros);
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
        public Boolean editarMagnitud(Magnitud magnitudes)
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
                        ParametroAcceso.CrearParametro("@idMagnitud",SqlDbType.VarChar,magnitudes.idMagnitud,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,magnitudes.descripcion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarMagnitudSP", parametros);
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
        public Boolean eliminarMagnitud(Magnitud magnitudes)
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
                        ParametroAcceso.CrearParametro("@idMagnitud",SqlDbType.VarChar,magnitudes.idMagnitud,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarMagnitudSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = false;
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

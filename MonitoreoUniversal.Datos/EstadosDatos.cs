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
    public class EstadosDatos
    {
        public List<Estados> getAllEstados()
        {
            List<Estados> estados = new List<Estados>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaEstadoSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Estados estad = new Estados();

                    estad.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    estad.descripcion = row["descripcion"].ToString();
                    estad.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    Paises paises = new Paises();
                    estad.paises = paises;
                    estad.paises.idPais = Convert.ToInt32(row["idPais"].ToString());
                    estad.paises.descripcion = row["pais"].ToString();

                    estados.Add(estad);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return estados;
        }

        public List<Estados> getEstadosxPais(int idPais)
        {
            List<Estados> estados = new List<Estados>();
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
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.Int,idPais,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaEstadoxPaisSP", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Estados estad = new Estados();

                    estad.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    estad.descripcion = row["descripcion"].ToString();                   
                
                    estados.Add(estad);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return estados;
        }
        public Boolean registrarEstados(Estados estados)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,estados.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.Int,estados.paises.idPais,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarEstadoSP",parametros);
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
        public Boolean editarEstados(Estados estados)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,estados.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.VarChar,estados.idEstado,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPais",SqlDbType.VarChar,estados.paises.idPais,ParameterDirection.Input)

                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarEstadoSP", parametros);
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
        public Boolean eliminarEstados(Estados estados)
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
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.Int,estados.idEstado,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarEstadoSP", parametros);
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

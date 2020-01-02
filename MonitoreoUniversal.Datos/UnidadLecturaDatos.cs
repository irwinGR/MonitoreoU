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
    public class UnidadLecturaDatos
    {
        public List<UnidadLectura> getAllUnidadLectura()
        {
            List<UnidadLectura> unidadLectura = new List<UnidadLectura>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaUnidadLecturaSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    UnidadLectura uniLec = new UnidadLectura();
                    uniLec.idUnidadLectura = Convert.ToInt32(row["idUnidadLectura"].ToString());
                    uniLec.descripcion = row["descripcion"].ToString();
                    uniLec.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    unidadLectura.Add(uniLec);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return unidadLectura;
        }
        public Boolean registrarUnidadLectura(UnidadLectura unidadLectura)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,unidadLectura.descripcion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarUnidadLecturaSP", parametros);
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
        public Boolean editarUnidadLectura(UnidadLectura unidadLectura)
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
                        ParametroAcceso.CrearParametro("@idUnidadLectura",SqlDbType.VarChar,unidadLectura.idUnidadLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,unidadLectura.descripcion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarUnidadLecturaSP", parametros);
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
        public Boolean eliminarUnidadLectura (UnidadLectura unidadLectura)
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
                        ParametroAcceso.CrearParametro("@idUnidadLectura",SqlDbType.VarChar,unidadLectura.idUnidadLectura,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarUnidadLecturaSP", parametros);
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

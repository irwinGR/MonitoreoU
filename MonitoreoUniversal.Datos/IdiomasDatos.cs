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
    public class IdiomasDatos
    {
        public List <Idiomas> getAllIdiomas()
        {
            List<Idiomas> idiomas = new List<Idiomas>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("BDConexion"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaIdiomaSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach(DataRow row in dt.Rows)
                {
                    Idiomas idiom = new Idiomas();

                    idiom.idIdioma = Convert.ToInt32(row["idIdioma"].ToString());
                    idiom.descripcion = row["descripcion"].ToString();
                    idiom.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    idiomas.Add(idiom);

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return idiomas;
        }

        public Boolean registraIdiomas(Idiomas idiomas)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,idiomas.descripcion,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarIdiomaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex);
            }

            return respuesta;
        }

        public Boolean editarIdiomas(Idiomas idiomas)
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
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, idiomas.descripcion, ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Adminitracion.ActualizarIdiomaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch(Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex);
            }

            return respuesta;
        }

        public Boolean eliminarIdiomas(Idiomas idiomas)
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
                        ParametroAcceso.CrearParametro("@idIdioma",SqlDbType.Int, idiomas.idIdioma, ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarIdiomaSP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }
    }
}

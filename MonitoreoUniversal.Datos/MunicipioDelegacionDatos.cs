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
    public class MunicipioDelegacionDatos
    {
        public List<MunicipioDelegacion> getAllMunicipioDelegacion ()
        {
            List<MunicipioDelegacion> municipioDelegacion = new List<MunicipioDelegacion>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("BDConexion"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaMunicipioDelegacionSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach(DataRow row in dt.Rows)
                {
                    MunicipioDelegacion muni = new MunicipioDelegacion();

                    muni.idMunicipioDelegacion = Convert.ToInt32(row["idMunicipioDelegacion"].ToString());
                    muni.descripcion = row["descripcion"].ToString();
                    muni.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    municipioDelegacion.Add(muni);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return municipioDelegacion;
        }

        public Boolean registraMunicipioDelegacion(MunicipioDelegacion municipioDelegacion)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,municipioDelegacion.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEstado",SqlDbType.Int,municipioDelegacion.Estados.idEstado,ParameterDirection.Input)

                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarMunicipioDelegacionSP", parametros);
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

        public  Boolean editarMunicipioDelegacion (MunicipioDelegacion municipioDelegacion)
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
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar, municipioDelegacion.descripcion, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion",SqlDbType.Int,municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarMunicipioDelegacionSP", parametros);
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

        public Boolean eliminarMunicipioDelegacion (MunicipioDelegacion municipioDelegacion)
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
                        ParametroAcceso.CrearParametro("@idMunicipioDelegacion",SqlDbType.Int,municipioDelegacion.idMunicipioDelegacion,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarMenucipioDelegacionSP", parametros);
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

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
    public class PerfilDatos
    {
        public List<Perfiles> getAllPerfiles() {
            List<Perfiles> perfiles = new List<Perfiles>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.ConsultaPerfilesSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Perfiles perfi = new Perfiles();

                    perfi.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());
                    perfi.descripcion = row["descripcion"].ToString();
                    perfi.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    Empresa empresa = new Empresa();
                    perfi.empresa = empresa;
                    perfi.empresa.idCliente = Convert.ToInt32(row["idEmpresa"].ToString());

                    perfiles.Add(perfi);

                }

               
             }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return perfiles;
        }

        public Boolean registraPerfiles(Perfiles perfiles)
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

                    var parametros = new[] {
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, perfiles.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa", SqlDbType.Int, perfiles.empresa.idCliente , ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.AgregarPerfilesSP", parametros);
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

        public Boolean editarPerfiles(Perfiles perfiles)
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

                    var parametros = new[] {
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, perfiles.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPerfil", SqlDbType.Int, perfiles.idPerfil , ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.ActualizarPerfilesSP", parametros);
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

        public Boolean eliminarPerfiles(Perfiles perfiles)
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

                    var parametros = new[] {
                        ParametroAcceso.CrearParametro("@idPerfil", SqlDbType.Int, perfiles.idPerfil , ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.EliminarPerfilesSP", parametros);
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

using MonitoreoUniversal.Framework.AccesoDatos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

                    TextWriter text = null;

                    text = new StreamWriter(Perfiles.path, true);

                    text.WriteLine(DateTime.Now.ToString() + "Lectura de consulta");
                    text.WriteLine(DateTime.Now.ToString() + dt.ToString());

                    dt.Load(consulta);
                    connection.Close();
                    text.Close();
                }
                
                foreach (DataRow row in dt.Rows)
                {
                    Perfiles perfi = new Perfiles();
                    
                    perfi.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());
                    perfi.descripcion = row["descripcion"].ToString();
                    perfi.acciones = row["Acciones"].ToString();
                    perfi.estatus = Convert.ToBoolean(row["estatus"].ToString());
                   
               
                    perfiles.Add(perfi);

                }

               
             }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return perfiles;
        }

        public Boolean registraPerfiles(Perfiles perfiles, int[] arrayaccion)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();

            int accion0 = 0;
            int accion1 = 0;
            int accion2 = 0;
            int accion3 = 0;

            for (int j = 0; j < arrayaccion.Length; j++) {
                if (j == 0)
                {
                    accion0 = arrayaccion[0];
                }
                if (j == 1)
                {
                    accion1 = arrayaccion[1];
                }
                if (j == 2)
                {
                    accion2 = arrayaccion[2];
                }
                if (j == 3)
                {
                    accion3 = arrayaccion[3];
                }
            }
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[] {
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, perfiles.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa", SqlDbType.Int, perfiles.empresa.idCliente , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion0", SqlDbType.Int, accion0, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion1", SqlDbType.Int, accion1, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion2", SqlDbType.Int, accion2, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion3", SqlDbType.Int, accion3, ParameterDirection.Input),
                      
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.AgregarPerfilesAccionesSP", parametros);
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

        public Boolean editarPerfiles(Perfiles perfiles, int[] arrayaccion)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();

            int accion0 = 0;
            int accion1 = 0;
            int accion2 = 0;
            int accion3 = 0;

            for (int j = 0; j < arrayaccion.Length; j++)
            {
                if (j == 0)
                {
                    accion0 = arrayaccion[0];
                }
                if (j == 1)
                {
                    accion1 = arrayaccion[1];
                }
                if (j == 2)
                {
                    accion2 = arrayaccion[2];
                }
                if (j == 3)
                {
                    accion3 = arrayaccion[3];
                }
            }

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[] {
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, perfiles.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPerfil", SqlDbType.Int, perfiles.idPerfil , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion0", SqlDbType.Int, accion0, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion1", SqlDbType.Int, accion1, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion2", SqlDbType.Int, accion2, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Accion3", SqlDbType.Int, accion3, ParameterDirection.Input),
                      
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.ActualizarPerfilesAccionesSP", parametros);
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

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.EliminarPerfilesAccionesSP", parametros);
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

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
    public class ResponsablesDatos
    {
        public List<Responsables> getAllResponsables()
        {
            List<Responsables> responsables = new List<Responsables>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaResponsablesSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    Responsables respo = new Responsables();
                    respo.idReponsable = Convert.ToInt32(row["idReponsable"].ToString());
                    respo.nombre = row["nombre"].ToString();
                    respo.apellidoP = row["apellidoP"].ToString();
                    respo.apellidoM = row["apellidoM"].ToString();
                    respo.correo = row["correo"].ToString();
                    respo.telefono = row["telefono"].ToString();
                    respo.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    responsables.Add(respo);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return responsables;
        }
        public Boolean registraResponsables(Responsables responsables)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,responsables.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoP",SqlDbType.VarChar,responsables.apellidoP,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoM",SqlDbType.VarChar,responsables.apellidoM,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,responsables.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,responsables.telefono,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarResponsablesSP", parametros);
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
        public  Boolean editarResponsables(Responsables responsables)
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
                        ParametroAcceso.CrearParametro("@idReponsable",SqlDbType.VarChar,responsables.idReponsable,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,responsables.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoP",SqlDbType.VarChar,responsables.apellidoP,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoM",SqlDbType.VarChar,responsables.apellidoM,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,responsables.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,responsables.telefono,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarResponsablesSP", parametros);
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
        public Boolean eliminarResponsables(Responsables responsables)
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
                        ParametroAcceso.CrearParametro("@idReponsable",SqlDbType.Int,responsables.idReponsable,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarResponsablesSP", parametros);
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

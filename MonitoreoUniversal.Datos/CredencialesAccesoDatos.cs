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
    public class CredencialesAccesoDatos
    {
        public List<CredencialesAcceso> getAllCredencialesAcceso()
        {
            List<CredencialesAcceso> credencialesAcceso = new List<CredencialesAcceso>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaCrededencialesAccesoSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    CredencialesAcceso credeAcc = new CredencialesAcceso();
                    credeAcc.idCredencial = Convert.ToInt32(row["idCredencial"].ToString());
                    credeAcc.nombreUsuario = row["nombreUsuario"].ToString();
                    credeAcc.constraseña = row["contraseña"].ToString();
                    credeAcc.numeroIntentos = Convert.ToInt32(row["numeroIntentos"].ToString());
                    credeAcc.envioCorreo = row["envioCorreo"].ToString();

                    Usuarios usuarios = new Usuarios();
                    credeAcc.usuarios = usuarios;
                    credeAcc.usuarios.idUsuario = Convert.ToInt32(row["idUsuario"].ToString());

                    credencialesAcceso.Add(credeAcc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return credencialesAcceso;
        }
        public Boolean registraCredencialesAcceso(CredencialesAcceso credencialesAcceso)
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
                        ParametroAcceso.CrearParametro("@nombreUsuario",SqlDbType.VarChar,credencialesAcceso.nombreUsuario,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,credencialesAcceso.constraseña,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroIntentos",SqlDbType.VarChar,credencialesAcceso.numeroIntentos,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioCorreo",SqlDbType.VarChar,credencialesAcceso.envioCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idUsuario",SqlDbType.VarChar,credencialesAcceso.usuarios.idUsuario,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarCredencialesAccesoSP", parametros);
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
        public Boolean editarCredencialesAcceso(CredencialesAcceso credencialesAcceso)
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
                        ParametroAcceso.CrearParametro("@nombreUsuario",SqlDbType.VarChar,credencialesAcceso.nombreUsuario,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,credencialesAcceso.constraseña,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroIntentos",SqlDbType.VarChar,credencialesAcceso.numeroIntentos,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioCorreo",SqlDbType.VarChar,credencialesAcceso.envioCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idUsuario",SqlDbType.VarChar,credencialesAcceso.usuarios.idUsuario,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarCredencialesAccesoSP", parametros);
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
        public Boolean eliminarCredencialesAcceso(CredencialesAcceso credencialesAcceso)
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
                        ParametroAcceso.CrearParametro("@idCredencial",SqlDbType.VarChar,credencialesAcceso.idCredencial,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarCredencialesAccesoSP", parametros);
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

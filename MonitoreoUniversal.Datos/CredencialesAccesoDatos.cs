using MonitoreoUniversal.Framework.AccesoDatos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MonitoreoUniversal.Datos
{
    public class CredencialesAccesoDatos
    {
        public List<CredencialesAcceso> getAllCredencialesAcceso(string nombreUsuario)
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

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@nombreUsuario",SqlDbType.VarChar,nombreUsuario,ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaCredencialesAccesoSP", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    CredencialesAcceso credeAcc = new CredencialesAcceso();
                    credeAcc.idCredencial = Convert.ToInt32(row["idCredencial"].ToString());
                    credeAcc.nombreUsuario = row["nombreUsuario"].ToString();
                    credeAcc.constraseña = Sha256encrypt(row["contraseña"].ToString());
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
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,GetSHA256(credencialesAcceso.constraseña),ParameterDirection.Input),
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

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string Sha256encrypt(string contraseña) {
            UTF8Encoding encoder = new UTF8Encoding();

            SHA256Managed sha256hasher = new SHA256Managed();

            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(contraseña));

            return Convert.ToBase64String(hashedDataBytes);
        }

    }
}

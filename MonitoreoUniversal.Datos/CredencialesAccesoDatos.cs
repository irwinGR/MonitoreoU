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
using System.IO;

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
                    credeAcc.nombreUsuario = row["nombreUsuario"].ToString();
                    credeAcc.constraseña = Decrypt(row["contraseña"].ToString(),"ITE");

                    Usuarios usuarios = new Usuarios();
                    credeAcc.usuarios = usuarios;
                    credeAcc.usuarios.idUsuario = Convert.ToInt32(row["idUsuario"].ToString());
                    credeAcc.usuarios.nombre = row["nombre"].ToString();
                    credeAcc.usuarios.apellidoP = row["apellidoP"].ToString();
                    credeAcc.usuarios.apellidoM = row["apellidoM"].ToString();
                    credeAcc.usuarios.correo = row["correo"].ToString();

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
                        ParametroAcceso.CrearParametro("@contraseña",SqlDbType.VarChar,Encrypt(credencialesAcceso.constraseña,"ITE"),ParameterDirection.Input),
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

       
        public static string Encrypt(string plainText, string password)
        {
            if (plainText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        
        public static string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}

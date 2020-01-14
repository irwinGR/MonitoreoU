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
    public class FallasDispositivosDatos
    {
        public List<FallasDispositivos> getAllFallasDispositivos()
        {
            List<FallasDispositivos> fallasDispositivos = new List<FallasDispositivos>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaFallasDispositivosSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    FallasDispositivos fallDis = new FallasDispositivos();
                    fallDis.idFallas = Convert.ToInt32(row["idFallas"].ToString());
                    fallDis.nombre = row["nombre"].ToString();
                    fallDis.descripcion = row["descripcion"].ToString();
                    fallDis.estatusAtencion = row["estatusAtencion"].ToString();
                    fallDis.fechaFalla = row["fechaFalla"].ToString();
                    fallDis.horaFalla = row["horaFalla"].ToString();
                    fallDis.area = row["area"].ToString();
                    fallDis.adjuntoEvidencia = row["adjuntoEvidencia"].ToString();
                    fallDis.validarDispositivo = Convert.ToBoolean(row["validadDispositivos"].ToString());

                    Placas placas = new Placas();
                    fallDis.placas = placas;
                    fallDis.placas.idPlaca = Convert.ToInt32(row["idPlaca"].ToString());

                    fallasDispositivos.Add(fallDis);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return fallasDispositivos;
        }
        public Boolean registrarFallasDispositivos(FallasDispositivos fallasDispositivos)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,fallasDispositivos.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,fallasDispositivos.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@estatusAtencion",SqlDbType.VarChar,fallasDispositivos.estatusAtencion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFalla",SqlDbType.VarChar,fallasDispositivos.fechaFalla,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@horaFalla",SqlDbType.VarChar,fallasDispositivos.horaFalla,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@area",SqlDbType.VarChar,fallasDispositivos.area,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@adjuntoEvidencia",SqlDbType.VarChar,fallasDispositivos.adjuntoEvidencia,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,fallasDispositivos.placas.idPlaca,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarFallasDispositivosSP", parametros);
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
        public Boolean editarFallasDispositivos(FallasDispositivos fallasDispositivos)
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
                        ParametroAcceso.CrearParametro("@idFallas",SqlDbType.VarChar,fallasDispositivos.idFallas,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,fallasDispositivos.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,fallasDispositivos.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@estatusAtencion",SqlDbType.VarChar,fallasDispositivos.estatusAtencion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFalla",SqlDbType.VarChar,fallasDispositivos.fechaFalla,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@horaFalla",SqlDbType.VarChar,fallasDispositivos.horaFalla,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@area",SqlDbType.VarChar,fallasDispositivos.area,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@adjuntoEvidencia",SqlDbType.VarChar,fallasDispositivos.adjuntoEvidencia,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,fallasDispositivos.placas.idPlaca,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarFallasDispositivosSP", parametros);
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
        public Boolean eliminarFallasDispositivos(FallasDispositivos fallasDispositivos)
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
                        ParametroAcceso.CrearParametro("@idFallas",SqlDbType.VarChar,fallasDispositivos.idFallas,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarFallasDispositivosSP", parametros);
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

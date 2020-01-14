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
    public class AlertasDatos
    {
        public List<Alertas> getAllAlertas()
        {
            List<Alertas> alertas = new List<Alertas>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaAlertasSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Alertas alert = new Alertas();

                    alert.idAlerta = Convert.ToInt32(row["idAlerta"].ToString());
                    alert.nombre = row["nombre"].ToString();
                    alert.descripcion = Convert.ToInt32(row["descripcion"].ToString());
                    alert.tiempoEnvio = Convert.ToInt32(row["tiempoEnvio"].ToString());
                    alert.envioCorreo = Convert.ToBoolean(row["envioCorreo"].ToString());
                    alert.envioMensajeTexto = Convert.ToBoolean(row["envioMensajeTexto"].ToString());
                    alert.envioAplicacion = Convert.ToBoolean(row["envioAplicacion"].ToString());
                    alert.cantidadAlertas = Convert.ToInt32(row["cantidadAlertas"].ToString());

                    Empresa empresa = new Empresa();
                    alert.empresa = empresa;
                    alert.empresa.idCliente = Convert.ToInt32(row["idEmpresa"].ToString());

                    TemplateCorreo templateCorreo = new TemplateCorreo();
                    alert.templateCorreo = templateCorreo;
                    alert.templateCorreo.idTemplateCorreo = Convert.ToInt32(row["idTemplateCorreo"].ToString());

                    alertas.Add(alert);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return alertas;
        }
        public Boolean registrarAlertas(Alertas alertas)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,alertas.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,alertas.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tiempoEnvio",SqlDbType.VarChar,alertas.tiempoEnvio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioCorreo",SqlDbType.VarChar,alertas.envioCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioMensajeTexto",SqlDbType.VarChar,alertas.envioMensajeTexto,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioAplicacion",SqlDbType.VarChar,alertas.envioAplicacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@cantidadAlertas",SqlDbType.VarChar,alertas.cantidadAlertas,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTemplateCorreo",SqlDbType.VarChar,alertas.templateCorreo.idTemplateCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa",SqlDbType.VarChar,alertas.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarAlertasSP", parametros);
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
        public Boolean editarAlertas(Alertas alertas)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,alertas.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,alertas.descripcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tiempoEnvio",SqlDbType.VarChar,alertas.tiempoEnvio,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioCorreo",SqlDbType.VarChar,alertas.envioCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioMensajeTexto",SqlDbType.VarChar,alertas.envioMensajeTexto,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@envioAplicacion",SqlDbType.VarChar,alertas.envioAplicacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@cantidadAlertas",SqlDbType.VarChar,alertas.cantidadAlertas,ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("@idTemplateCorreo",SqlDbType.VarChar,alertas.templateCorreo.idTemplateCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idEmpresa",SqlDbType.VarChar,alertas.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarAlertasSP", parametros);
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
        public Boolean eliminarAlertas(Alertas alertas)
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
                        ParametroAcceso.CrearParametro("@idAlerta",SqlDbType.VarChar,alertas.idAlerta,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarAlertasSP", parametros);
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
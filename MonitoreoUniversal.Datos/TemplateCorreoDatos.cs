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
    public class TemplateCorreoDatos
    {
        TemplateCorreo templateCorreo = new TemplateCorreo();
        public List<TemplateCorreo> getAllTemplateCorreo()
        {
            List<TemplateCorreo> templateCorreo = new List<TemplateCorreo>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaTemplateCorreoSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    TemplateCorreo tempCor = new TemplateCorreo();
                    tempCor.idTemplateCorreo = Convert.ToInt32(row["idTemplateCorreo"].ToString());
                    tempCor.logo = row["logo"].ToString();
                    tempCor.cuerpoCorreo = row["cuerpoCorreo"].ToString();
                    tempCor.asunto = row["asunto"].ToString();
                    tempCor.prioridad = row["prioridad"].ToString();
                    tempCor.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    Empresa empresa = new Empresa();
                    tempCor.empresa = empresa;
                    tempCor.empresa.idCliente = Convert.ToInt32(row["idEmpresa"].ToString());

                    templateCorreo.Add(tempCor);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return templateCorreo;
        }
        public Boolean registrarTemplateCorreo(TemplateCorreo templateCorreo)
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
                        ParametroAcceso.CrearParametro("logo",SqlDbType.VarChar,templateCorreo.logo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("cuerpoCorreo",SqlDbType.VarChar,templateCorreo.cuerpoCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("asunto",SqlDbType.VarChar,templateCorreo.asunto,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("prioridad",SqlDbType.VarChar,templateCorreo.prioridad,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idEmpresa",SqlDbType.VarChar,templateCorreo.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarTemplateCorreoSP", parametros);
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
        public Boolean editarTemplateCorreo(TemplateCorreo templateCorreo)
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
                        ParametroAcceso.CrearParametro("idTemplateCorreo",SqlDbType.VarChar,templateCorreo.idTemplateCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("logo",SqlDbType.VarChar,templateCorreo.logo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("cuerpoCorreo",SqlDbType.VarChar,templateCorreo.cuerpoCorreo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("asunto",SqlDbType.VarChar,templateCorreo.asunto,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("prioridad",SqlDbType.VarChar,templateCorreo.prioridad,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idEmpresa",SqlDbType.VarChar,templateCorreo.empresa.idCliente,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarTemplateCorreoSP", parametros);
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
        public Boolean eliminarTemplateCorreo(TemplateCorreo templateCorreo)
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
                        ParametroAcceso.CrearParametro("idTemplateCorreo",SqlDbType.VarChar,templateCorreo.idTemplateCorreo,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarTemplateCorreoSP", parametros);
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

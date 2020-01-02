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
    public class TipoDatoDatos
    {
        public List<TipoDato> getAllTipoDato()
        {
            List<TipoDato> tipoDato = new List<TipoDato>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaTipoDatoSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    TipoDato tipDat = new TipoDato();
                    tipDat.idTipoDato = Convert.ToInt32(row["idTipoDato"].ToString());
                    tipDat.nombre = row["nombre"].ToString();
                    tipDat.tipo = row["tipo"].ToString();
                    tipDat.formato = Convert.ToDouble(row["formato"].ToString());
                    tipDat.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    tipoDato.Add(tipDat);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return tipoDato;
        }
        public Boolean registrarTipoDato(TipoDato tipoDato)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,tipoDato.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tipo",SqlDbType.VarChar,tipoDato.tipo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@formato",SqlDbType.VarChar,tipoDato.formato,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregaTipoDatoSP", parametros);
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
        public Boolean editarTipoDato(TipoDato tipoDato)
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
                        ParametroAcceso.CrearParametro("@idTipoDato",SqlDbType.VarChar,tipoDato.idTipoDato,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,tipoDato.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@tipo",SqlDbType.VarChar,tipoDato.tipo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@formato",SqlDbType.VarChar,tipoDato.formato,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarTipoDatoSP", parametros);
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
        public Boolean eliminarTipoDato(TipoDato tipoDato)
        {
            Boolean respuesta = false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Close();

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@idTipoDato",SqlDbType.VarChar,tipoDato.idTipoDato,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarTipoDatoSP", parametros);
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

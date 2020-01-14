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
    public class VariablesDatos
    {
        public List<Variables> getAllVariables()
        {
            List<Variables> variables = new List<Variables>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaVariablesSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Variables vari = new Variables();
                    vari.idVariable = Convert.ToInt32(row["idVariable"].ToString());
                    vari.nombre = row["nombre"].ToString();
                    vari.valor = row["valor"].ToString();
                    vari.valorMaximo = row["valorMaximo"].ToString();
                    vari.valorMinimo = row["valorMinimo"].ToString();
                    vari.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    UnidadLectura unidadLectura = new UnidadLectura();
                    vari.unidadLectura = unidadLectura;
                    vari.unidadLectura.idUnidadLectura = Convert.ToInt32(row["idUnidadLectura"].ToString());

                    SistemaMedicion sistemaMedicion = new SistemaMedicion();
                    vari.sistemaMedicion = sistemaMedicion;
                    vari.sistemaMedicion.idSistemaMedicion = Convert.ToInt32(row["idSistemaMedicion"].ToString());

                    Magnitud magnitud = new Magnitud();
                    vari.magnitud = magnitud;
                    vari.magnitud.idMagnitud = Convert.ToInt32(row["idMagnitud"].ToString());

                    variables.Add(vari);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return variables;
        }
        public Boolean registrarVariables(Variables variables)
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
                        ParametroAcceso.CrearParametro("nombre",SqlDbType.VarChar,variables.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valor",SqlDbType.VarChar,variables.valor,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valorMaximo",SqlDbType.VarChar,variables.valorMaximo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valorMinimo0",SqlDbType.VarChar,variables.valorMinimo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idUnidadLectura",SqlDbType.VarChar,variables.unidadLectura.idUnidadLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idSistemaMedicion",SqlDbType.VarChar,variables.sistemaMedicion.idSistemaMedicion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idMagnitud",SqlDbType.VarChar,variables.magnitud.idMagnitud,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarVariablesSP", parametros);
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
        public Boolean editarVariables(Variables variables)
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
                        ParametroAcceso.CrearParametro("idVariable",SqlDbType.VarChar,variables.idVariable,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("nombre",SqlDbType.VarChar,variables.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valor",SqlDbType.VarChar,variables.valor,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valorMaximo",SqlDbType.VarChar,variables.valorMaximo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("valorMinimo0",SqlDbType.VarChar,variables.valorMinimo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idUnidadLectura",SqlDbType.VarChar,variables.unidadLectura.idUnidadLectura,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idSistemaMedicion",SqlDbType.VarChar,variables.sistemaMedicion.idSistemaMedicion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idMagnitud",SqlDbType.VarChar,variables.magnitud.idMagnitud,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarVariablesSP", parametros);
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
        public Boolean eliminarVariables(Variables variables)
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
                        ParametroAcceso.CrearParametro("idVariable",SqlDbType.VarChar,variables.idVariable,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarVariablesSP", parametros);
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

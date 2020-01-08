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
    public class PruebasDatos
    {
        public List<Pruebas> getAllPruebas()
        {
            List<Pruebas> pruebas = new List<Pruebas>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.ConsultaVariablesSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Pruebas prue = new Pruebas();
                    prue.id = Convert.ToInt32(row["id"].ToString());
                    prue.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());
                    prue.coordenadas = row["cordenadas"].ToString();
                    prue.humedad = row["humedad"].ToString();
                    prue.conductividadElectrica = row["conductividad"].ToString();
                    pruebas.Add(prue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return pruebas;
        }

        public List<Pruebas> getAllBitacora(int idDispositivo)
        {
            List<Pruebas> pruebas = new List<Pruebas>();
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
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.Int, idDispositivo,ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.bitacoraVariablesSP", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Pruebas prue = new Pruebas();
                    prue.id = Convert.ToInt32(row["id"].ToString());
                    prue.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());
                    prue.humedad = row["humedad"].ToString();
                    prue.conductividadElectrica = row["conductividad"].ToString();
                    prue.fecha = row["fecha"].ToString();
                    pruebas.Add(prue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return pruebas;
        }

        public Boolean agregarPruebas(int idDispositivo, string coordenadas, string humedad, string conductividadElectrica )
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
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar, idDispositivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@cordenadas",SqlDbType.VarChar, coordenadas,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@humedad",SqlDbType.VarChar, humedad,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@conductividad",SqlDbType.VarChar, conductividadElectrica,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.CapturarVariablesSP", parametros);
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

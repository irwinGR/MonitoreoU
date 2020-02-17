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
        public List<Dispositivos> getDispositivos(int idCliente,int idSector)
        {
            List<Dispositivos> dispositivos = new List<Dispositivos>();
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
                        ParametroAcceso.CrearParametro("@idCliente",SqlDbType.Int, idCliente,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idSector",SqlDbType.Int, idSector,ParameterDirection.Input)

                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.ConsultaVariablesSP", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Dispositivos dispos = new Dispositivos();
                    dispos.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());
                    dispos.numeroSerie = Convert.ToInt32(row["numeroSerie"].ToString());
                    dispos.descripcion = row["descripcion"].ToString();
                    dispos.coordenadas = row["cordenadas"].ToString();
                    dispositivos.Add(dispos);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return dispositivos;
        }

        public List<Variables> getVariablesxDispositivos(int idDispositivo)
        {
            List<Variables> dispositivos = new List<Variables>();
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
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.Int, idDispositivo,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.ConsultaVariablesxDispositivoSP", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    Variables dispos = new Variables();
                    dispos.idVariable = Convert.ToInt32(row["idVariable"].ToString());
                    dispos.nombre = row["nombre"].ToString();
                    dispos.valor = row["valor"].ToString();
                    dispos.valorMaximo = row["valorMaximo"].ToString();
                    dispos.valorMinimo = row["valorMinimo"].ToString();

                    UnidadLectura unidadLectura = new UnidadLectura();
                    dispos.unidadLectura = unidadLectura;
                    dispos.unidadLectura.descripcion = row["descripcion"].ToString();

                    dispositivos.Add(dispos);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return dispositivos;
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

        public Boolean agregarPruebas(int idDispositivo, string coordenadas, int idVariable, string valor )
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
                        ParametroAcceso.CrearParametro("@idVariable",SqlDbType.VarChar, idVariable,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@valor",SqlDbType.VarChar, valor,ParameterDirection.Input)
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

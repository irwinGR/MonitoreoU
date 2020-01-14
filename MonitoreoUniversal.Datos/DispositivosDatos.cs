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
    public class DispositivosDatos
    {
        public List<Dispositivos> getAllDispositivos()
        {
            List<Dispositivos> dispositivos = new List<Dispositivos>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexiónBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.GetDispositivos");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Dispositivos dispo = new Dispositivos();

                    dispo.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());
                    dispo.numeroSerie = Convert.ToInt32(row["numeroSerie"].ToString());
                    dispo.descripcion = row["descripcion"].ToString();

                    CentroMonitoreo centroMonitoreo = new CentroMonitoreo();
                    dispo.centroMonitoreo = centroMonitoreo;
                    dispo.centroMonitoreo.idCentroMonitoreo = Convert.ToInt32(row["idCentroMonitoreo"].ToString());

                    dispositivos.Add(dispo);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return dispositivos;


        }

        public Boolean registrarDispositivos(Dispositivos dispositivos)
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
                        ParametroAcceso.CrearParametro("numeroSerie",SqlDbType.VarChar,dispositivos.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("descripcion", SqlDbType.VarChar, dispositivos.descripcion, ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("idDispositivo",SqlDbType.VarChar,dispositivos.centroMonitoreo.idCentroMonitoreo,ParameterDirection.Input),
                };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarDispositivosSP", parametros);
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

        public Boolean editarDispositivos(Dispositivos dispositivos)
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
                        ParametroAcceso.CrearParametro("@numeroSerie",SqlDbType.VarChar,dispositivos.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion",SqlDbType.VarChar,dispositivos.descripcion,ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,dispositivos.centroMonitoreo.idCentroMonitoreo,ParameterDirection.Input)

                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarDispositivosSP", parametros);
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

        public Boolean eliminarDispositivos(Dispositivos dispositivos)
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
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,dispositivos.idDispositivo,ParameterDirection.Input)

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


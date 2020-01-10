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
    public class PlacasDatos
    {
        public List<Placas> getAllPlacas()
        {
            List<Placas> placas = new List<Placas>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaPlacasSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    Placas plac = new Placas();
                    plac.idPlaca = Convert.ToInt32(row["idPlaca"].ToString());
                    plac.nombre = row["nombre"].ToString();
                    plac.numeroSerie = row["numeroSerie"].ToString();
                    plac.ubicacionGeografica = row["ubicacionGeografica"].ToString();
                    plac.estatus = Convert.ToBoolean(row["estatus"].ToString());
                    plac.ipAsignada = row["ipAsignada"].ToString();
                    plac.asignacionMaster = row["asignacionMaster"].ToString();

                    TipoComunicacion tipoComunicacion = new TipoComunicacion();
                    plac.tipoComunicacion = tipoComunicacion;
                    plac.tipoComunicacion.idTipoComunicacion = Convert.ToInt32(row["idTipoComunicacion"].ToString());

                    Dispositivos dispositivo = new Dispositivos();
                    plac.dispositivo = dispositivo;
                    plac.dispositivo.idDispositivo = Convert.ToInt32(row["idDispositivo"].ToString());

                    MediosComunicacion medioComunicacion = new MediosComunicacion();
                    plac.medioComunicacion = medioComunicacion;
                    plac.medioComunicacion.idMedioComunicacion = Convert.ToInt32(row["idMedioComunicacion"].ToString());

                    placas.Add(plac);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return placas;
        }
        public Boolean registrarPlacas (Placas placas)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar, placas.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroSerie",SqlDbType.VarChar, placas.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@ubicacionGeografica",SqlDbType.VarChar,placas.ubicacionGeografica,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@estatus",SqlDbType.VarChar,placas.estatus,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@ipAsignada",SqlDbType.VarChar,placas.estatus,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@asignacionMaster",SqlDbType.VarChar,placas.ipAsignada,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoComunicacion",SqlDbType.VarChar,placas.tipoComunicacion.idTipoComunicacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,placas.dispositivo.idDispositivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMedioComunicacion",SqlDbType.VarChar,placas.medioComunicacion.idMedioComunicacion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarPlacasSP", parametros);
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
        public Boolean editarPlacas(Placas placas)
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
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,placas.idPlaca,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar, placas.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numeroSerie",SqlDbType.VarChar, placas.numeroSerie,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@ubicacionGeografica",SqlDbType.VarChar,placas.ubicacionGeografica,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@estatus",SqlDbType.VarChar,placas.estatus,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@ipAsignada",SqlDbType.VarChar,placas.estatus,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@asignacionMaster",SqlDbType.VarChar,placas.ipAsignada,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoComunicacion",SqlDbType.VarChar,placas.tipoComunicacion.idTipoComunicacion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.VarChar,placas.dispositivo.idDispositivo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMedioComunicacion",SqlDbType.VarChar,placas.medioComunicacion.idMedioComunicacion,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarPlacasSP", parametros);
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
        public Boolean eliminarPlacas(Placas placas)
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
                        ParametroAcceso.CrearParametro("@idPlaca",SqlDbType.VarChar,placas.idPlaca,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarPlacasSP", parametros);
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

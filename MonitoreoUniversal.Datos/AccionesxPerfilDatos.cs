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
    public class AccionesxPerfilDatos
    {
        public List<AccionesxPerfil> getAllAccionesxPerfil()
        {
            List<AccionesxPerfil> accionesxPerfil = new List<AccionesxPerfil>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.ConsultaAccionesxPerfilSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    AccionesxPerfil accxper = new AccionesxPerfil();
                    accxper.idAccionxPerfil = Convert.ToInt32(row["idAccionxPerfil"].ToString());

                    Acciones acciones = new Acciones();
                    accxper.acciones = acciones;
                    accxper.acciones.idAccion = Convert.ToInt32(row["idAccion"].ToString());

                    Perfiles perfiles = new Perfiles();
                    accxper.perfiles = perfiles;
                    accxper.perfiles.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());

                    accionesxPerfil.Add(accxper);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return accionesxPerfil;
        }
        public Boolean registrarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
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
                        ParametroAcceso.CrearParametro("idAccion",SqlDbType.VarChar,accionesxPerfil.acciones.idAccion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idPerfil",SqlDbType.VarChar,accionesxPerfil.perfiles.idPerfil,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.AgregarAccionesxPerfilSP", parametros);
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
        public Boolean editarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
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
                        ParametroAcceso.CrearParametro("idAccionxPerfil",SqlDbType.VarChar,accionesxPerfil.idAccionxPerfil,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idAccion",SqlDbType.VarChar,accionesxPerfil.acciones.idAccion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("idPerfil",SqlDbType.VarChar,accionesxPerfil.perfiles.idPerfil,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.ActualizarAccionesxPerfilSP", parametros);
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
        public Boolean eliminarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
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
                        ParametroAcceso.CrearParametro("idAccionxPerfil",SqlDbType.VarChar,accionesxPerfil.idAccionxPerfil,ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Seguridad.EliminarAccionesxPerfilSP", parametros);
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

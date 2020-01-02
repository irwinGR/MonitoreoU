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
    public class CatalogosDatos
    {
        public List<Catalogos> getAllCatalogos()
        {
            List<Catalogos> catalogos = new List<Catalogos>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ConsultaCatalogosSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    Catalogos cata = new Catalogos();
                    cata.idCatalogo = Convert.ToInt32(row["idCatalogo"].ToString());
                    cata.nombre = row["nombre"].ToString();
                    cata.nombreAspx = row["nombreAspx"].ToString();
                    cata.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    catalogos.Add(cata);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return catalogos;
        }
        public Boolean registrarCatalogos(Catalogos catalogos)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,catalogos.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombreAspx",SqlDbType.VarChar,catalogos.nombreAspx,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.AgregarCatalogosSP", parametros);
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
        public Boolean editarCatalogos(Catalogos catalogos)
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
                        ParametroAcceso.CrearParametro("@idCatalogo",SqlDbType.VarChar,catalogos.idCatalogo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,catalogos.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombreAspx",SqlDbType.VarChar,catalogos.nombreAspx,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.ActualizarCatalogosSP", parametros);
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
        public Boolean eliminarCatalogos(Catalogos catalogos)
        {
            Boolean respuesta=false;
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            
            try
            {  using(connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();

                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@idCatalogo",SqlDbType.VarChar,catalogos.idCatalogo,ParameterDirection.Input)
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Aplicacion.EliminarCatalogosSP", parametros);
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

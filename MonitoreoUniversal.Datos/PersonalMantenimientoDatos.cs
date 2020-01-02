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
    public class PersonalMantenimientoDatos
    {
        public List <PersonalMantenimiento> getAllPersonalMantenimiento()
        {
            List<PersonalMantenimiento> personalMantenimiento = new List<PersonalMantenimiento>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultaPersonalMantenimientoSP");

                    dt.Load(consulta);
                    connection.Close();
                }
                foreach(DataRow row in dt.Rows)
                {
                    PersonalMantenimiento persoMan = new PersonalMantenimiento();
                    persoMan.idPersonalMantenimiento = Convert.ToInt32(row["idPersonalMantenimiento"].ToString());
                    persoMan.nombre = row["nombre"].ToString();
                    persoMan.apellidoP = row["apellidoP"].ToString();
                    persoMan.apellidoM = row["apellidoM"].ToString();
                    persoMan.correo = row["correo"].ToString();
                    persoMan.telefono = row["telefono"].ToString();
                    persoMan.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    personalMantenimiento.Add(persoMan);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return personalMantenimiento;
        }
        public Boolean registraPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
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
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,personalMantenimiento.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoP",SqlDbType.VarChar,personalMantenimiento.apellidoP,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoM",SqlDbType.VarChar,personalMantenimiento.apellidoM,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,personalMantenimiento.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,personalMantenimiento.telefono,ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.AgregarPersonalMantenimientoSP", parametros);
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
        
        public Boolean editarPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
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
                        ParametroAcceso.CrearParametro("@idPersonalMantenimiento", SqlDbType.VarChar, personalMantenimiento.idPersonalMantenimiento,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre",SqlDbType.VarChar,personalMantenimiento.nombre,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoP",SqlDbType.VarChar,personalMantenimiento.apellidoP,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@apellidoM",SqlDbType.VarChar,personalMantenimiento.apellidoM,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@correo",SqlDbType.VarChar,personalMantenimiento.correo,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@telefono",SqlDbType.VarChar,personalMantenimiento.telefono,ParameterDirection.Input),
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ActualizarPersonalMantenimientoSP", parametros);
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
        public Boolean eliminarPersonalMantenimiento (PersonalMantenimiento personalMantenimiento)
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
                        ParametroAcceso.CrearParametro("@idPersonalMantenimiento",SqlDbType.Int, personalMantenimiento.idPersonalMantenimiento,ParameterDirection.Input)
                    };

                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.EliminarPersonalMantenimientoSP", parametros);
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

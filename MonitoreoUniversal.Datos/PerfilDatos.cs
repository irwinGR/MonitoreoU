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
    public class PerfilDatos
    {
        public List<Perfiles> getAllPerfiles() {
            List<Perfiles> perfiles = new List<Perfiles>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "ComunesSP.GetPerfiles");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Perfiles perfi = new Perfiles();

                    perfi.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());

                    perfi.descripcion = row["descripcion"].ToString();

                    perfiles.Add(perfi);

                }

               
             }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return perfiles;
        }
    }
}

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
    public class PaisesDatos
    {
        public List<Paises> getAllPaises()
        {
            List<Paises> paises = new List<Paises>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Administracion.ConsultarPaisSP");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Paises pais = new Paises();

                    pais.idPais = Convert.ToInt32(row["idPais"].ToString());
                    pais.descripcion = row["descripcion"].ToString();
                    pais.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    paises.Add(pais);

                }
             
            }
            
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return paises;
        }
    }
}

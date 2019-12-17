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
    public class PuestoDatos
    {
        public List<Puestos> getAllPuestos()
        {
            List<Puestos> puestos = new List<Puestos>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "ComunesSP.GetPuestos");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Puestos puest = new Puestos();

                    puest.idPuesto = Convert.ToInt32(row["idPuesto"].ToString());

                    puest.descripcion = row["descripcion"].ToString();

                    puestos.Add(puest);

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return puestos;
        }
    }
}

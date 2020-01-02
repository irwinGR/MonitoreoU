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
    public class EstadosDatos
    {
        public List<Estados> getAllEstados()
        {
            List<Estados> estados = new List<Estados>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "ComunesSp.GetEstados");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Estados estad = new Estados();

                    estad.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    estad.descripcion = row["descripcion"].ToString();
                    estad.estatus = Convert.ToBoolean(row["estatus"].ToString());

                    Paises paises = new Paises();
                    estad.paises = paises;
                    estad.paises.idPais = Convert.ToInt32(row["idPais"].ToString());

                    estados.Add(estad);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return estados;
        }
    }
}

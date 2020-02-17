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
    public class GraficasDatos
    {
        public List<Graficas> getDatosGrafica(int idDispositivos, int idVariable, int opcion,string fechaIni,string fechaFin) {
            List<Graficas> graficas = new List<Graficas>();
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
                        ParametroAcceso.CrearParametro("@idDispositivo",SqlDbType.Int,idDispositivos,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idVariable",SqlDbType.Int,idVariable,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@ejeX",SqlDbType.Int,opcion,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaIni",SqlDbType.VarChar,fechaIni,ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin",SqlDbType.VarChar,fechaFin,ParameterDirection.Input)

                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "dbo.ConsultaValoresBitacoraGrafica", parametros);

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Graficas grafica = new Graficas();

                    grafica.label = row["label"].ToString();
                    grafica.valor = row["valor"].ToString();
                    
                    graficas.Add(grafica);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return graficas;
        }
    }
}

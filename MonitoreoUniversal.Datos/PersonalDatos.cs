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
    public class PersonalDatos
    {
        public List<Personal> getAllPersonal() {
            List<Personal> personal = new List<Personal>();
            SqlConnection connection = null;
            DataTable dt = new DataTable();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "SensoresSp.GetPersonal");

                    dt.Load(consulta);
                    connection.Close();
                }

                foreach (DataRow row in dt.Rows) {
                    Personal perso = new Personal();

                    perso.idPersonal = Convert.ToInt32(row["idPersonal"].ToString());
                    perso.nombre = row["nombre"].ToString();
                    perso.apPaterno = row["apPaterno"].ToString();
                    perso.apMaterno = row["apMaterno"].ToString();
                    perso.rfc = row["RFC"].ToString();

                    Perfiles perfiles = new Perfiles();
                    perso.perfiles = perfiles;
                    perso.perfiles.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());
                    perso.perfiles.descripcion = row["nombrePerfil"].ToString();

                    Puestos puestos = new Puestos();
                    perso.puestos = puestos;
                    perso.puestos.idPuesto = Convert.ToInt32(row["idPuesto"].ToString());
                    perso.puestos.descripcion = row["nombrePuesto"].ToString();


                    perso.cp = row["c_CP"].ToString();

                    Estados estados = new Estados();
                    perso.estados = estados;
                    perso.estados.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    perso.estados.descripcion = row["nombreEstado"].ToString();

                    perso.email = row["email"].ToString();
                    perso.fechaAlta = row["fecha_alta"].ToString();
                    perso.fechaMod = row["fecha_mod"].ToString();

                    Usuarios estatusPersonal = new Usuarios();
                    perso.estatusPersonal = estatusPersonal;
                    perso.estatusPersonal.idEstatus = Convert.ToInt32(row["idEstatus"].ToString());

                    perso.activo = row["activo"].ToString();

                    personal.Add(perso);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            return personal;

        }
    }
}

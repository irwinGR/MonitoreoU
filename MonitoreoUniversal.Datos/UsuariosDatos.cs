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
    public class UsuariosDatos
    {
        public List<Usuarios> getAllUsuarios() {
            List<Usuarios> usuarios = new List<Usuarios>();
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

                    Usuarios usuar = new Usuarios();

                    usuar.idUsuario = Convert.ToInt32(row["idUsuario"].ToString());
                    usuar.nombre = row["nombre"].ToString();
                    usuar.apellidoP = row["apellidoP"].ToString();
                    usuar.apellidoM = row["apellidopM"].ToString();
                    usuar.correo = row["correo"].ToString();
                    usuar.telefono = row["telefono"].ToString();
                    usuar.rfc = row["rfc"].ToString();
                    usuar.codigoPostal = row["codigoPostal"].ToString();
                    usuar.calle = row["calle"].ToString();
                    usuar.numeroInterior = Convert.ToInt32(row["numeroInterior"].ToString());
                    usuar.numeroExterior = Convert.ToInt32(row["numeroExterior"].ToString());
                    usuar.fechaAlta = row["fechaAlta"].ToString();
                    usuar.fechaModificacion = row["fechaModificacion"].ToString();
                    usuar.estatus = Convert.ToBoolean(row["estatus"].ToString());
                    
                    Perfiles perfiles = new Perfiles();
                    usuar.perfiles = perfiles;
                    usuar.perfiles.idPerfil = Convert.ToInt32(row["idPerfil"].ToString());
                    usuar.perfiles.descripcion = row["nombrePerfil"].ToString();

                    Empresa empresa = new Empresa();
                    usuar.empresa = empresa;
                    usuar.empresa.idCliente = Convert.ToInt32(row["idPuesto"].ToString());
                    usuar.empresa.nombre = row["nombrePuesto"].ToString();

                    usuarios.Add(usuar);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            return usuarios;

        }
    }
}

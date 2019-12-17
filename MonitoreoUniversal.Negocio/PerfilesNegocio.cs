using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PerfilesNegocio
    {
        PerfilDatos perfilesDatos = new PerfilDatos();

        public List<Perfiles> getAllPerfiles()
        {
            return perfilesDatos.getAllPerfiles();
        }
    }
}

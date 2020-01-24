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
        public Boolean registraPerfiles(Perfiles perfiles, int[] arrayaccion) {
            return perfilesDatos.registraPerfiles(perfiles, arrayaccion);
        }

        public Boolean editarPerfiles(Perfiles perfiles, int[] arrayaccion)
        {
            return perfilesDatos.editarPerfiles(perfiles, arrayaccion);
        }

        public Boolean eliminarPerfiles(Perfiles perfiles)
        {
            return perfilesDatos.eliminarPerfiles(perfiles);
        }
    }
}

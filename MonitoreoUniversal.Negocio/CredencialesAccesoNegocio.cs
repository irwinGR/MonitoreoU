using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class CredencialesAccesoNegocio
    {
        CredencialesAccesoDatos credecialesAccesoDatos = new CredencialesAccesoDatos();
        public List<CredencialesAcceso> getAllCredencialesAcceso()
        {
            return credecialesAccesoDatos.getAllCredencialesAcceso();
        }
        public Boolean registrarCredencialesAcceso(CredencialesAcceso credencialesAcceso)
        {
            return credecialesAccesoDatos.registraCredencialesAcceso(credencialesAcceso);
        }
        public Boolean editarCredencialesAcceso(CredencialesAcceso credencialesAcceso)
        {
            return credecialesAccesoDatos.editarCredencialesAcceso(credencialesAcceso);
        }
        public Boolean eliminarCredencialesAcceso(CredencialesAcceso credencialesAcceso)
        {
            return credecialesAccesoDatos.eliminarCredencialesAcceso(credencialesAcceso);
        }
    }
}

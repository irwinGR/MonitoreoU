using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class ServicioNegocio
    {
        ServicioDatos servicioDatos = new ServicioDatos();
        public List<Servicio> getAllServicio()
        {
            return servicioDatos.getAllServicio();
        }
        public Boolean registrarServicio(Servicio servicio)
        {
            return servicioDatos.registrarServicio(servicio);
        }
        public Boolean editarServicio(Servicio servicio)
        {
            return servicioDatos.editarServicio(servicio);
        }
        public Boolean eliminarServicio(Servicio servicio)
        {
            return servicioDatos.eliminarServicio(servicio);
        }
    }
}

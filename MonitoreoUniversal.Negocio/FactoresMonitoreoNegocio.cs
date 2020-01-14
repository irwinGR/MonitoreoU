using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class FactoresMonitoreo
    {
        FactoresMonitoreo factoresMonitoreo = new FactoresMonitoreo();

        public List<FactoresMonitoreo> gellAllFactoresMonitoreo()
        {
            return factoresMonitoreo.gellAllFactoresMonitoreo();
        }

        public Boolean registrarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
        {
            return factoresMonitoreo.registrarFactoresMonitoreo(factoresMonitoreo);

        }

        public Boolean editarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
        {
            return factoresMonitoreo.editarFactoresMonitoreo(factoresMonitoreo);
        }

        public Boolean eliminarFactoresMonitoreo(FactoresMonitoreo factoresMonitoreo)
        {
            return factoresMonitoreo.eliminarFactoresMonitoreo(factoresMonitoreo);
        }
    }
}
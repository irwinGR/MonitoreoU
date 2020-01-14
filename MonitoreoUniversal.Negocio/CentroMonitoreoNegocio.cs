using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class CentroMonitoreoNegocio
    {
        CentroMonitoreoDatos centroMonitoreoDatos = new CentroMonitoreoDatos();

        public List<CentroMonitoreo> getAllCentroMonitoreo()

        {
            return centroMonitoreoDatos.getAllCentroMonitoreo();
        }
        public Boolean registrarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
        {
            return centroMonitoreoDatos.registrarCentroMonitoreo(centroMonitoreo);
        }

        public Boolean editarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
        {
            return centroMonitoreoDatos.editarCentroMonitoreo(centroMonitoreo);
        }

        public Boolean eliminarCentroMonitoreo(CentroMonitoreo centroMonitoreo)
        {
            return centroMonitoreoDatos.editarCentroMonitoreo(centroMonitoreo);
        }

    }
}

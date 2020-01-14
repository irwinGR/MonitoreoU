using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class AlertasNegocio
    {
        AlertasDatos alertaDatos = new AlertasDatos();

        public List<Alertas> getAllAlertas()

        {
            return alertaDatos.getAllAlertas();
        }
        public Boolean registrarAlertas(Alertas alertas)
        {
            return alertaDatos.registrarAlertas(alertas);
        }

        public Boolean editarAlertas(Alertas alertas)
        {
            return alertaDatos.editarAlertas(alertas);
        }

        public Boolean eliminarAlertas(Alertas alertas)
        {
            return alertaDatos.editarAlertas(alertas);
        }

    }
}
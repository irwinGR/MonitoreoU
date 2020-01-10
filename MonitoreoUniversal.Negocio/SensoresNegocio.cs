using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class SensoresNegocio
    {
        SensoresDatos sensoresDatos = new SensoresDatos();
        public List<Sensores> getAllSensores()
        {
            return sensoresDatos.getAllSensores();
        }
        public Boolean registrarSensores(Sensores sensores)
        {
            return sensoresDatos.registrarSensores(sensores);
        }
        public Boolean editarSensores(Sensores sensores)
        {
            return sensoresDatos.editarSensores(sensores);
        }
        public Boolean eliminarSensores(Sensores sensores)
        {
            return sensoresDatos.eliminarSensores(sensores);
        }

    }
}

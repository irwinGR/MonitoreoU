using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Dispositivos
    {
        public int idDispositivo { set; get; }
        public int numeroSerie { set; get; }
        public string descripcion { set; get; }
        public CentroMonitoreo centroMonitoreo { set; get; }
        public string coordenadas { set; get; }
    }
}

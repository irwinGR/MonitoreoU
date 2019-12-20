using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class CentroMonitoreo
    {
        public int idCentroMonitoreo { set; get; }
        public string nombre { set; get; }
        public Empresa empresa { set; get; }
        public bool estatus { set; get; }

    }
}

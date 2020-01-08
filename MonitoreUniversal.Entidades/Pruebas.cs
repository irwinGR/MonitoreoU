using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Pruebas
    {
        public int id { set; get; }
        public int idDispositivo { set; get; }
        public string coordenadas { set; get; }
        public string humedad { set; get; }
        public string conductividadElectrica { set; get; }
        public string fecha { set; get; }
    }
}

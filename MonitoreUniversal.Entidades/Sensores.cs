using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Sensores
    {
        public int idSensor { set; get; }
        public string numeroSerie { set; get; }
        public Placas placas { set; get; }
        public string tiempoLectura { set; get; }
        public UnidadLectura unidadLectura { set; get; }
        public SistemaMedicion sistemaMedicion { set; get; }
        public Magnitud magnitud { set; get; }
        public bool estatus { set; get; }
        public Empresa empresa { set; get; }

    }
}

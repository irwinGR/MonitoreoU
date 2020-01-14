using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Variables
    {
        public int idVariable { set; get; }
        public string nombre { set; get; }
        public bool estatus { set; get; }
        public string valor { set; get; }
        public string valorMaximo { set; get; }
        public string valorMinimo { set; get; }
        public UnidadLectura unidadLectura { set; get; }
        public SistemaMedicion sistemaMedicion { set; get; }
        public Magnitud magnitud { set; get; }
    }
}

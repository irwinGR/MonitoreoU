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
        public float valor { set; get; }
        public UnidadLectura unidadLectura { set; get; }
        public SistemaMedicion sistemaMedicion { set; get; }
        public Magnitud magnitud { set; get; }
        

    }
}

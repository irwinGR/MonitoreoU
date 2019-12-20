using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class TipoDato
    {
        public int idTipoDato { set; get; }
        public string nombre { set; get; }
        public string tipo { set; get; }
        public double formato { set; get; }
        public bool estatus { set; get; }
    }
}

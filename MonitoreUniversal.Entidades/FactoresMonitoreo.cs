using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class FactoresMonitoreo
    {
        public int idUnidadMedida { set; get; }
        public string nombre { set; get; }
        public decimal  formato { set; get; }
        public double valorMinimo { set; get; }
        public double valorMaximo { set; get; }
        public TipoDato tipoDato { set; get; }
        public string escala { set; get; }
        public string activo { set; get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Placas
    {
        public int idPlaca { set; get; }
        public string nombre { set; get; }
        public string numeroSerie { set; get; }
        public string ubicacionGeografica { set; get; }
        public bool estatus { set; get; }
        public string ipAsignada { set; get; } 
        public string asignacionMaster { set; get; }
        public TipoComunicacion tipoComunicacion { set; get; }
        public MediosComunicacion medioComunicacion { set; get; }
        public Dispositivos dispositivo { set; get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class AccionesxPerfil
    {
        public int idAccionxPerfil { set; get; }
        public Acciones acciones { set; get; }
        public Perfiles perfiles { set; get; }
    }
}

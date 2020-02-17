using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Estados
    {
        public string idEstado { set; get; }
        public string descripcion { set; get; }
        public bool estatus { set; get; }
        public Paises paises { set; get; }


    }
}

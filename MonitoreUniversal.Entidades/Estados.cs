using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Estados
    {
        public int idEstado { set; get; }
        public Paises paises { set; get; }
        public String descripcion { set; get; }
        public int activo { set; get; }

    }
}

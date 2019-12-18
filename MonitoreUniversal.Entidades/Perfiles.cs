using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Perfiles
    {
        public int idPerfil { set; get; }
        public string descripcion { set; get; }
        public int activo { set; get; }
        public Empresa empresa { set; get; }

    }
}

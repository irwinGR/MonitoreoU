using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Responsables
    {
        public int idReponsable { set; get; }
        public string nombre { set; get; }
        public string apellidoP { set; get; }
        public string apellidoM { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public bool estatus { set; get; }
    }
}

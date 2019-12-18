using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Personal
    {
        public int idPersonal { set; get; }
        public string nombre { set; get; }
        public string apMaterno {set; get;}
        public string apPaterno { set; get; }

        public string rfc { set; get; }
        public Perfiles perfiles { set; get; }
        public Puestos puestos { set; get; }
        public string cp { set; get; }
        public Estados estados { set; get; }
        public string email { set; get; }
        public string fechaAlta { set; get; }
        public string fechaMod { set; get; }
        public string activo { set; get; }

    }
}

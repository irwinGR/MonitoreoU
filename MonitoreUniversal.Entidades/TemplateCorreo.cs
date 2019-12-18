using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class TemplateCorreo
    {
        public int idTemplateCorreo { set; get; }
        public string logo { set; get; }
        public string cuerpoCorreo { set; get; }
        public string asunto { set; get; }
        public string prioridad { set; get; }
        public bool estatus { set; get; }
        public Empresa empresa { set; get; }

    }
}

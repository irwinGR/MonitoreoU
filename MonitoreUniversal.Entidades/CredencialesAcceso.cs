using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class CredencialesAcceso
    {
        public int idCredencial { set; get; }
        public string nombreUsuario { set; get; }
        public string constraseña { set; get; }
        public int numeroIntentos { set; get; }
        public string envioCorreo { set; get; }
        public Usuarios usuarios { set; get; }
    }
}
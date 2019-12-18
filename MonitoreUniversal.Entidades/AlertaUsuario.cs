using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class AlertaUsuario
    {
        public int idAlertasUsuarios { set; get; }
        public Alertas alertas { set; get; }
        public Usuarios usuarios { set; get; }
    }
}

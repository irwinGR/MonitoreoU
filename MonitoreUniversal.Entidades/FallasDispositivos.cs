using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class FallasDispositivos
    {
        public int idFallas { set; get; }
        public string nombre { set; get; }
        public string descripcion { set; get; }
        public string estatusAtencion { set; get; }
        public Placas placas { set; get; }
        public string fechaFalla { set; get; }
        public string horaFalla { set; get; }
        public string area { set; get; }
        public string adjuntoEvidencia { set; get; }
        public bool validarDispositivo { set; get; }

    }
}

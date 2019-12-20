using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Alertas
    {
        public int idAlerta { set; get; }
        public string nombre { set; get; }
        public int descripcion { set; get; }
        public float tiempoEnvio { set; get; }
        public bool envioCorreo { set; get; }
        public bool envioMensajeTexto { set; get; }
        public bool envioAplicacion { set; get; }
        public int cantidadAlertas { set; get; }
        public TemplateCorreo templateCorreo { set; get; }
        public Empresa empresa { set; get; }
        public bool estatus { set; get; }
    }
}

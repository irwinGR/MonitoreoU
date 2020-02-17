using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Servicio
    {
        public string idServicio { set; get; }
        public string nombre { set; get; }
        public Estados estados { set; get; }
        public Paises paises { set; get; }
        public MunicipioDelegacion municipioDelegacion { set; get; }
        public string descripcion { set; get; }
        public string objetivo { set; get; }
        public Sector sector { set; get; }
        public Dispositivos dispositivo { set; get; }
        public string fechaInicio { set; get; }
        public string fechaFin { set; get; }
        public string duracion { set; get; }
        public PersonalMantenimiento personalMantenimiento { set; get; }
        public Responsables responsables { set; get; }
        public string contratoServicio { set; get; }
        public string fechaFacturacion { set; get; }
        public bool estatus { set; get; }
    }
}

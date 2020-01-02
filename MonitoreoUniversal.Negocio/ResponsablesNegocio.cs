using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class ResponsablesNegocio
    {
        ResponsablesDatos responsablesDatos = new ResponsablesDatos();
        public List<Responsables> getAllResponsables()
        {
            return responsablesDatos.getAllResponsables();
        }
        public Boolean registraResponsables(Responsables responsables)
        {
            return responsablesDatos.registraResponsables(responsables);
        }
        public Boolean editarResponsables(Responsables responsables)
        {
            return responsablesDatos.editarResponsables(responsables);
        }
        public Boolean eliminarResponsables(Responsables responsables)
        {
            return responsablesDatos.eliminarResponsables(responsables);
        }
    }
}

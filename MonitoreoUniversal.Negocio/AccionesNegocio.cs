using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class AccionesNegocio
    {
        AccionesDatos accionesDatos = new AccionesDatos();
        public List<Acciones> getAllAcciones()
        {
            return accionesDatos.getAllAcciones();
        }
        public Boolean registrarAcciones(Acciones acciones)
        {
            return accionesDatos.registrarAcciones(acciones);
        }
        public Boolean editarAcciones(Acciones acciones)
        {
            return accionesDatos.editarAcciones(acciones);
        }
        public Boolean eliminarAcciones(Acciones acciones)
        {
            return accionesDatos.eliminarAcciones(acciones);
        }
    }
}

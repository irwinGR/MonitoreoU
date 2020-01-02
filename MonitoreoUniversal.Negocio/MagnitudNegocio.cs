using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class MagnitudNegocio
    {
        MagnitudDatos magnitudDatos = new MagnitudDatos();

        public List<Magnitud> getAllMagnitud()
        {
            return magnitudDatos.getAllMagnitud();
        }
        public Boolean registrarMagnitud(Magnitud magnitudes)
        {
            return magnitudDatos.registrarMagnitud(magnitudes);
        }
        public Boolean editarMagnitud(Magnitud magnitudes)
        {
            return magnitudDatos.editarMagnitud(magnitudes);
        }
        public Boolean eliminarMagnitud(Magnitud magnitudes)
        {
            return magnitudDatos.eliminarMagnitud(magnitudes);
        }
    }
}

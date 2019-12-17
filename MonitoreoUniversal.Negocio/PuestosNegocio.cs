using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PuestosNegocio
    {
        PuestoDatos puestosDatos = new PuestoDatos();

        public List<Puestos> getAllPuestos()
        {
            return puestosDatos.getAllPuestos();
        }
    }
}

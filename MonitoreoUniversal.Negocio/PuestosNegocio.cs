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
        public Boolean registraPuesto(Puestos puestos)
        {
            return puestosDatos.registraPuesto(puestos);
        }
        public Boolean editarPuesto(Puestos puestos)
        {
            return puestosDatos.editarPuesto(puestos);
        }
        public Boolean eliminarPuesto(Puestos puestos)
        {
            return puestosDatos.eliminarPuesto(puestos);
        }
    }
}

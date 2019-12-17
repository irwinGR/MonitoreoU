using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class EstadosNegocio
    {
        EstadosDatos estadosDatos = new EstadosDatos();

        public List<Estados> getAllEstados()
        {
            return estadosDatos.getAllEstados();
        }
    }
}

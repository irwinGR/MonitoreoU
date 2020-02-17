using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class GraficasNegocio
    {
        GraficasDatos graficasDatos = new GraficasDatos();

        public List<Graficas> getDatosGrafica(int idDispositivos, int idVariable, int opcion, string fechaIni, string fechaFin)
        {
            return graficasDatos.getDatosGrafica(idDispositivos, idVariable, opcion, fechaIni, fechaFin);
        }
    }
}

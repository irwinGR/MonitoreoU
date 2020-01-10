using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PlacasNegocio
    {
        PlacasDatos placasDatos = new PlacasDatos();
        public List<Placas> getAllPlacas()
        {
            return placasDatos.getAllPlacas();
        }
        public Boolean registrarPlacas(Placas placas)
        {
            return placasDatos.registrarPlacas(placas);
        }
        public Boolean editarPlacas(Placas placas)
        {
            return placasDatos.editarPlacas(placas);
        }
        public Boolean eliminarPlacas(Placas placas)
        {
            return placasDatos.eliminarPlacas(placas);
        }
    }
}

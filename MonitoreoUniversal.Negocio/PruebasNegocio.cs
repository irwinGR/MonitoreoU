using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PruebasNegocio
    {
        PruebasDatos pruebasDatos = new PruebasDatos();
        public List<Pruebas> getAllPruebas()
        {
            return pruebasDatos.getAllPruebas();
        }

        public List<Pruebas> getAllBitacora(int idDispositivo)
        {
            return pruebasDatos.getAllBitacora(idDispositivo);
        }
        public Boolean agregarPruebas(int idDispositivo, string coordenadas, string humedad, string conductividadElectrica)
        {
            return pruebasDatos.agregarPruebas(idDispositivo, coordenadas, humedad,conductividadElectrica);
        }
    }
}

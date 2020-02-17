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
        public List<Dispositivos> getDispositivos(int idCliente, int idSector)
        {
            return pruebasDatos.getDispositivos(idCliente, idSector);
        }

        public List<Variables> getVariablesxDispositivos(int idDispositivo) {
            return pruebasDatos.getVariablesxDispositivos(idDispositivo);
        }

        public List<Pruebas> getAllBitacora(int idDispositivo)
        {
            return pruebasDatos.getAllBitacora(idDispositivo);
        }
        public Boolean agregarPruebas(int idDispositivo, string coordenadas, int idVariable, string valor)
        {
            return pruebasDatos.agregarPruebas(idDispositivo, coordenadas, idVariable, valor);
        }
    }
}

using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class FallasDispositivosNegocio
    {
        FallasDispositivosDatos fallasDispositivosDatos = new FallasDispositivosDatos();
        public List<FallasDispositivos> getAllFallasDispositivos()
        {
            return fallasDispositivosDatos.getAllFallasDispositivos();
        }
        public Boolean registrarFallasDispositivos(FallasDispositivos fallasDispositivos)
        {
            return fallasDispositivosDatos.registrarFallasDispositivos(fallasDispositivos);
        }
        public Boolean editarFallasDispositivos(FallasDispositivos fallasDispositivos)
        {
            return fallasDispositivosDatos.editarFallasDispositivos(fallasDispositivos);
        }
        public Boolean eliminarFallasDispositivos(FallasDispositivos fallasDispositivos)
        {
            return fallasDispositivosDatos.eliminarFallasDispositivos(fallasDispositivos);
        }
    }
}

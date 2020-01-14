using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class DispositivosNegocio
    {
        DispositivosDatos dispositivosDatos = new DispositivosDatos();
        public List<Dispositivos> getAllDispositivos()
        {
            return dispositivosDatos.getAllDispositivos();
        }
        public Boolean registrarDispositivos(Dispositivos dispositivos)
        {
            return dispositivosDatos.registrarDispositivos(dispositivos);
        }
        public Boolean editarDispositivos(Dispositivos dispositivos)
        {
            return dispositivosDatos.editarDispositivos(dispositivos);
        }
        public Boolean eliminarDispositivos(Dispositivos dispositivos)
        {
            return dispositivosDatos.eliminarDispositivos(dispositivos);
        }
    }
}


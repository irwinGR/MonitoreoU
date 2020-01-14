using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class AccionesxPerfilNegocio
    {
        AccionesxPerfilDatos accionesxPerfilDatos = new AccionesxPerfilDatos();
        public List<AccionesxPerfil> getAllAccionesxPerfil()
        {
            return accionesxPerfilDatos.getAllAccionesxPerfil();
        }
        public Boolean registrarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
        {
            return accionesxPerfilDatos.registrarAccionesxPerfil(accionesxPerfil);
        }
        public Boolean editarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
        {
            return accionesxPerfilDatos.editarAccionesxPerfil(accionesxPerfil);
        }
        public Boolean eliminarAccionesxPerfil(AccionesxPerfil accionesxPerfil)
        {
            return accionesxPerfilDatos.eliminarAccionesxPerfil(accionesxPerfil);
        }
    }
}

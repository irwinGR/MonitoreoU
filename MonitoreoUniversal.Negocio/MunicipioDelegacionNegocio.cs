using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class MunicipioDelegacionNegocio
    {
        MunicipioDelegacionDatos municipioDelegacionDatos = new MunicipioDelegacionDatos();

        public List<MunicipioDelegacion> getAllMunicipioDelegacion() {
            return municipioDelegacionDatos.getAllMunicipioDelegacion();
        }

        public Boolean registraMunicipioDelegacion(MunicipioDelegacion municipioDelegacion) {
            return municipioDelegacionDatos.registraMunicipioDelegacion(municipioDelegacion);
        }

        public Boolean editarMunicipioDelegacion(MunicipioDelegacion municipioDelegacion) {
            return municipioDelegacionDatos.editarMunicipioDelegacion(municipioDelegacion);
        }

        public Boolean eliminarMunicipioDelegacion(MunicipioDelegacion municipioDelegacion) {
            return municipioDelegacionDatos.eliminarMunicipioDelegacion(municipioDelegacion);
        }
    }
}

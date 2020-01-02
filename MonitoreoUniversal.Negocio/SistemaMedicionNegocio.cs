using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class SistemaMedicionNegocio
    {
        SistemaMedicionDatos sistemaMedicionDatos = new SistemaMedicionDatos();
        public List<SistemaMedicion> getAllSistemaMedicion()
        {
            return sistemaMedicionDatos.getAllSistemaMedicion();
        }
        public Boolean registrarSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            return sistemaMedicionDatos.registrarSistemaMedicion(sistemaMedicion);
        }
        public Boolean editarSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            return sistemaMedicionDatos.editarSistemaMedicion(sistemaMedicion);
        }
        public Boolean eliminarSistemaMedicion(SistemaMedicion sistemaMedicion)
        {
            return sistemaMedicionDatos.eliminarSistemaMedicion(sistemaMedicion);
        }
    }
}

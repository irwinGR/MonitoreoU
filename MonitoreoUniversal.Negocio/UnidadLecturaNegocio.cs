using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class UnidadLecturaNegocio
    {
        UnidadLecturaDatos unidadLecturaDatos = new UnidadLecturaDatos();
        public List<UnidadLectura> getAllUnidadLectura()
        {
            return unidadLecturaDatos.getAllUnidadLectura();
        }
        public Boolean registrarUnidadLectura(UnidadLectura unidadLectura)
        {
            return unidadLecturaDatos.registrarUnidadLectura(unidadLectura);
        }
        public Boolean editarUnidadLectura(UnidadLectura unidadLectura)
        {
            return unidadLecturaDatos.editarUnidadLectura(unidadLectura);
        }
        public Boolean eliminarUnidadLectura(UnidadLectura unidadLectura)
        {
            return unidadLecturaDatos.eliminarUnidadLectura(unidadLectura);
        }
    }
}

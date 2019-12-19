using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class IdiomasNegocio
    {
        IdiomasDatos idiomasDatos = new IdiomasDatos();

        public List<Idiomas> getAllIdiomas()
        {
            return idiomasDatos.getAllIdiomas();
        }
        public Boolean registraIdiomas(Idiomas idiomas)
        {
            return idiomasDatos.registraIdiomas(idiomas);
        }

        public Boolean editarIdiomas(Idiomas idiomas)
        {
            return idiomasDatos.editarIdiomas(idiomas);
        }

        public Boolean eliminarIdiomas(Idiomas idiomas)
        {
            return idiomasDatos.eliminarIdiomas(idiomas);
        }
    }
}

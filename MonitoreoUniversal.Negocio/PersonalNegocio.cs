using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PersonalNegocio
    {
        PersonalDatos personalDatos = new PersonalDatos();

        public List<Personal> getAllPersonal() {
            return personalDatos.getAllPersonal();
        }
    }
}

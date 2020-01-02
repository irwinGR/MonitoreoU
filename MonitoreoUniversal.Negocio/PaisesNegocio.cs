using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PaisesNegocio
    {
        PaisesDatos paisesDatos = new PaisesDatos();

        public List<Paises> getAllPaises()
        {
            return paisesDatos.getAllPaises();
        }
        public Boolean registraPais(Paises paises)
        {
            return paisesDatos.registraPais(paises);
        }
        public Boolean editarPais(Paises paises)
        {
            return paisesDatos.editarPais(paises);
        }
        public Boolean eliminarPais(Paises paises)
        {
            return paisesDatos.eliminarPais(paises);
        }
    }
}

using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class MediosComunicacionNegocio
    {
        MediosComunicacionDatos mediosComunicacionDatos = new MediosComunicacionDatos();
        public List<MediosComunicacion> getAllMedioComunicacion()
        {
            return mediosComunicacionDatos.getAllMedioComunicacion();
        }
        public Boolean registrarMedioComunicacion(MediosComunicacion mediosComunicacion)
        {
            return mediosComunicacionDatos.registrarMedioComunicacion(mediosComunicacion);
        }
        public Boolean editarMedioComunicacion(MediosComunicacion mediosComunicacion)
        {
            return mediosComunicacionDatos.editarMedioComunicacion(mediosComunicacion);
        }
        public Boolean eliminarMedioComunicacion(MediosComunicacion mediosComunicacion)
        {
            return mediosComunicacionDatos.eliminarMedioComunicacion(mediosComunicacion);
        }
    }
}

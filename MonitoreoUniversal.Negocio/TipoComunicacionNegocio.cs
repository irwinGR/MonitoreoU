using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class TipoComunicacionNegocio
    {
        TipoComunicacionDatos tipoComunicacionDatos = new TipoComunicacionDatos();
        public List<TipoComunicacion> getAllTipoComunicacion()
        {
            return tipoComunicacionDatos.getAllTipoComunicacion();
        }
        public Boolean registrarTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            return tipoComunicacionDatos.registrarTipoComunicacion(tipoComunicacion);
        }
        public Boolean editarTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            return tipoComunicacionDatos.editarTipoComunicacion(tipoComunicacion);
        }
        public Boolean eliminarTipoComunicacion(TipoComunicacion tipoComunicacion)
        {
            return tipoComunicacionDatos.eliminarTipoComunicacion(tipoComunicacion);
        }
    }   
}

using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class TipoDatoNegocio
    {
        TipoDatoDatos tipoDatoDatos = new TipoDatoDatos();
        public List<TipoDato> getAllTipoDato()
        {
            return tipoDatoDatos.getAllTipoDato();
        }
        public Boolean registrarTipoDato(TipoDato tipoDato)
        {
            return tipoDatoDatos.registrarTipoDato(tipoDato);
        }
        public Boolean editarTipoDato(TipoDato tipoDato)
        {
            return tipoDatoDatos.editarTipoDato(tipoDato);
        }
        public Boolean eliminarTipoDato(TipoDato tipoDato)
        {
            return tipoDatoDatos.eliminarTipoDato(tipoDato);
        }
    }
}

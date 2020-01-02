using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class PersonalMantenimientoNegocio
    {
        PersonalMantenimientoDatos personalMantenimientoDatos = new PersonalMantenimientoDatos();
        public List<PersonalMantenimiento> getAllPersonalMantenimiento()
        {
            return personalMantenimientoDatos.getAllPersonalMantenimiento();
        }
        public Boolean registraPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            return personalMantenimientoDatos.registraPersonalMantenimiento(personalMantenimiento);
        }
        public  Boolean editarPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            return personalMantenimientoDatos.editarPersonalMantenimiento(personalMantenimiento);
        }
        public  Boolean eliminarPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            return personalMantenimientoDatos.eliminarPersonalMantenimiento(personalMantenimiento);
        }
    }
}

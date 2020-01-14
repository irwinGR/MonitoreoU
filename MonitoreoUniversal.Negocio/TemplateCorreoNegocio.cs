using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class TemplateCorreoNegocio
    {
        TemplateCorreoDatos templateCorreoDatos = new TemplateCorreoDatos();
        public List<TemplateCorreo> getAllTemplateCorreo()
        {
            return templateCorreoDatos.getAllTemplateCorreo();
        }
        public Boolean registrarTemplateCorreo(TemplateCorreo templateCorreo)
        {
            return templateCorreoDatos.registrarTemplateCorreo(templateCorreo);
        }
        public Boolean editarTemplateCorreo(TemplateCorreo templateCorreo)
        {
            return templateCorreoDatos.editarTemplateCorreo(templateCorreo);
        }
        public Boolean eliminarTemplate(TemplateCorreo templateCorreo)
        {
            return templateCorreoDatos.eliminarTemplateCorreo(templateCorreo);
        }
    }
}

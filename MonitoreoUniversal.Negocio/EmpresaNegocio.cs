using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class EmpresaNegocio
    {
        EmpresaDatos empresaDatos = new EmpresaDatos();
        public List<Empresa> getAllEmpresa()
        {
            return empresaDatos.getAllEmpresa();
        }
        public Boolean registrarEmpresa(Empresa empresa)
        {
            return empresaDatos.registrarEmpresa(empresa);
        }
        public Boolean editarEmpresa(Empresa empresa)
        {
            return empresaDatos.editarEmpresa(empresa);
        }
        public Boolean eliminarEmpresa(Empresa empresa)
        {
            return empresaDatos.eliminarEmpresa(empresa);
        }
    }
}

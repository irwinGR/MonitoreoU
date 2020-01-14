using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class VariablesNegocio
    {
        VariablesDatos variablesDatos = new VariablesDatos();
        public List<Variables> getAllVariables()
        {
            return variablesDatos.getAllVariables();
        }
        public Boolean registrarVariables(Variables variables)
        {
            return variablesDatos.registrarVariables(variables);
        }
        public Boolean editarVariables(Variables variables)
        {
            return variablesDatos.editarVariables(variables);
        }
        public Boolean eliminarVariables(Variables variables)
        {
            return variablesDatos.eliminarVariables(variables);
        }
    }
}

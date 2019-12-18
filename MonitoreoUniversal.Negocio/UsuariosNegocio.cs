using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class UsuariosNegocio
    {
        UsuariosDatos usuariosDatos = new UsuariosDatos();

        public List<Usuarios> getAllUsuarios() {
            return usuariosDatos.getAllUsuarios();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Usuarios
    {
        public int idUsuario { set; get; }
        public string nombre { set; get; }
        public string apellidoP {set; get;}
        public string apellidoM { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public string rfc { set; get; }
        public string codigoPostal { set; get; }
        public string calle { set; get; }
        public int numeroInterior { set; get; }
        public int numeroExterior { set; get; }
        public string fechaAlta { set; get; }
        public string fechaModificacion { set; get; }
        public bool estatus { set; get; }
        public Empresa empresa { set; get; }
        public Perfiles perfiles { set; get; }

    }
}

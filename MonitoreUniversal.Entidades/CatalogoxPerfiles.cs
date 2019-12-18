using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class CatalogoxPerfiles
    {
        public int idCatalogoxPerfil { set; get; }
        public Perfiles perfiles { set; get; }
        public Catalogos catalogos { set; get; }
    }
}

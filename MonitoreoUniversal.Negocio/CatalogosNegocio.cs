using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class CatalogosNegocio
    {
        CatalogosDatos catalogosDatos = new CatalogosDatos();
        public List<Catalogos> getAllCatalogos()
        {
            return catalogosDatos.getAllCatalogos();
        }
        public Boolean registrarCatalogos(Catalogos catalogos)
        {
            return catalogosDatos.registrarCatalogos(catalogos);
        }
        public Boolean editarCatalogos(Catalogos catalogos)
        {
            return catalogosDatos.editarCatalogos(catalogos);
        }
        public Boolean eliminarCatalogos(Catalogos catalogos)
        {
            return catalogosDatos.eliminarCatalogos(catalogos);
        }
    }
}

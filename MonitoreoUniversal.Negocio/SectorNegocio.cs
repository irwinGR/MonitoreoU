using MonitoreoUniversal.Datos;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Negocio
{
    public class SectorNegocio
    {
        SectorDatos sectorDatos = new SectorDatos();
        public List<Sector> getAllSector()
        {
            return sectorDatos.getAllSector();
        }

        public List<Sector> sectoresxEmpresa(int idEmpresa)
        {
            return sectorDatos.sectoresxEmpresa(idEmpresa);
        }

        public Boolean registrarSector(Sector sector)
        {
            return sectorDatos.registrarSector(sector);
        }
        public Boolean editarSector(Sector sector)
        {
            return sectorDatos.editarSector(sector);
        }
        public Boolean eliminarSector(Sector sector)
        {
            return sectorDatos.eliminarSector(sector);
        }
    }
}

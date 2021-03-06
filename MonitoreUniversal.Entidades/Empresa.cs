﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Empresa
    {
        public int idCliente { set; get; }
        public string nombre { set; get; }
        public string comprobanteServicio { set; get; }
        public string contraseña { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public string tipoPersona { set; get; }
        public string codigoPostal { set; get; }
        public int numeroExterior { set; get; }
        public string calle { set; get; }
        public int numeroInterior { set; get; }
        public string razonSocial { set; get; }
        public string RFC { set; get; }
        public bool estatus { set; get; }
        public MunicipioDelegacion municipioDelegacion { set; get; }
        public Estados estados { set; get; }
        public Paises paises { set; get; }
        public Idiomas idiomas { set; get; }
        public Sector sector { set; get; }        
        public Servicio servicio {set; get;}  
    }
}

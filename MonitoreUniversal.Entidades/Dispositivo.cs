﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Dispositivo
    {
        public int idDispositivo { set; get; }
        public string numeroSerie { set; get; }
        public string descripcion { set; get; }
        public Placas placas { set; get; }
    }
}

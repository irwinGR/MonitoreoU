﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class MunicipioDelegacion
    {
        public int idMunicipioDelegacion { set; get; }
        public string descripcion { set; get; }
        public bool estatus { set; get; }
        public Estados Estados { set; get; }
    }
}

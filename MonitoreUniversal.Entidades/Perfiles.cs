﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreUniversal.Entidades
{
    public class Perfiles
    {
       public static string path = @"C:\logs\Log.txt";
        public int idPerfil { set; get; }
        public string descripcion { set; get; }
        public bool estatus { set; get; }
        public Empresa empresa { set; get; }
        public string acciones { set; get; }
    }
}

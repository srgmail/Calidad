using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.Entidades
{
    public class Mesa
    {
        public int IdEvento { get; set; }
        public string IdUsuario { get; set; }
        public bool Estado { get; set; }
        //0 cerrada 1 abierta 
    }
}
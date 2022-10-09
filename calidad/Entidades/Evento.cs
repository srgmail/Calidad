using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.Entidades
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
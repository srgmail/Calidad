using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.Entidades
{
    public class Asistencia
    {

        public int IdMiembro { get; set; }

        public int IdEvento { get; set; }

        public DateTime Fecha { get; set; }


        public string IdUsuario { get; set; }

        public bool Confirmado { get; set; }

        public bool asistencia { get; set; }


    }
}
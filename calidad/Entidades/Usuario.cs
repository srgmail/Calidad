using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.Entidades
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        //email 

        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public int IdRole { get; set; }

    }
}
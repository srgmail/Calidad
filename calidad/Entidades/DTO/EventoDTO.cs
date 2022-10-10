using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.Entidades.DTO
{
    public class EventoDTO
    {
        public int idEvento { get; set; }
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

    }
}
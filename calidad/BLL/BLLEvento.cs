using calidad.DAL;
using calidad.Entidades;
using calidad.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace calidad.BLL
{
    public class BLLEvento
    {
        DALEvento oDALEvento = new DALEvento();

        public Evento SaveEvento(Evento pEvento)
        {
            //   IDALEvento _DALEvento = new DALEvento();
            Evento oEvento = null;
          //  if (oDALEvento.GetEventoById(pEvento.IdEvento) == null)
            oEvento = oDALEvento.SaveEvento(pEvento);
            //else
              //  oEvento = oDALEvento.UpdateEvento(pEvento);

            return oEvento;
        }
        public Evento GetEventoById(int pId)
        {
            return oDALEvento.GetEventoById(pId);
        }
        //public List<EventoDTO> GetAllEvento()
        //{
        //    return oDALEvento.GetAllEvento();
        //}

        

    }
}
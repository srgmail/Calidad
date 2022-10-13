using calidad.DAL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.BLL
{
    public class BLLMiembro
    {

        DALMiembro oDALMiembro = new DALMiembro();

        public Miembro SaveMiembro(Miembro pMiembro)
        {
            //   IDALMiembro _DALMiembro = new DALMiembro();
            Miembro oMiembro = null;
            //  if (oDALMiembro.GetMiembroById(pMiembro.IdMiembro) == null)
            oMiembro = oDALMiembro.SaveMiembro(pMiembro);
            //else
            //  oMiembro = oDALMiembro.UpdateMiembro(pMiembro);

            return oMiembro;
        }


        public Miembro GetMiembroById(int pId)
        {
            return oDALMiembro.GetMiembroById(pId);
        }
        //public List<MiembroDTO> GetAllMiembro()
        //{
        //    return oDALMiembro.GetAllMiembro();
        //}



    }
}
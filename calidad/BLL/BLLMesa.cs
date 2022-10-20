using calidad.DAL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.BLL
{
    public class BLLMesa
    {

        DALMesa oDalMesa = new DALMesa();

        public Mesa CerrarMesa(Mesa pMesa) 
        {

            Mesa oMesa = null;

            oMesa = oDalMesa.CerrarMesa(pMesa);

            return oMesa;

        }

    }
}
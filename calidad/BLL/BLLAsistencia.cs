using calidad.DAL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calidad.BLL
{
    public class BLLAsistencia
    {


        DALAsistencia oDALAsistencia = new DALAsistencia();

        public Asistencia SaveAsistencia(Asistencia pAsistencia)
        {
            //   IDALAsistencia _DALAsistencia = new DALAsistencia();
            Asistencia oAsistencia = null;
            //  if (oDALAsistencia.GetAsistenciaById(pAsistencia.IdAsistencia) == null)
            oAsistencia = oDALAsistencia.SaveAsistencia(pAsistencia);
            //else
            //  oAsistencia = oDALAsistencia.UpdateAsistencia(pAsistencia);

            return oAsistencia;
        }
        public Asistencia GetAsistenciaById(int pIdMiembro,int pIdEvento)
        {
            return oDALAsistencia.GetAsistenciaById( pIdMiembro,  pIdEvento);
        }
        //public List<AsistenciaDTO> GetAllAsistencia()
        //{
        //    return oDALAsistencia.GetAllAsistencia();
        //}




    }
}
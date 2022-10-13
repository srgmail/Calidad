using calidad.BLL;
using calidad.DAL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calidad.Interfaz_web.Evento
{
	public partial class AdministrarEvento : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

 

        protected void Buscar(object sender, EventArgs e)
        {

			int _id = int.Parse(idvalue.Text);
			DALMiembro dALMiembro = new DALMiembro();
			//dALMiembro.GetMiembroById(_id);

			Miembro oMiembro = dALMiembro.GetMiembroById(_id);

			Nombre.Text = oMiembro.Nombre;

			if (oMiembro.Activo.Equals(true))
			{
				txtActivo.Text = "Miembro activo";
			}
			else 
			{
				txtActivo.Text = "Miembro inactivo";
			}
			

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
			BLLAsistencia bLLAsistencia = new BLLAsistencia();
			BLLEvento oBllevento = new BLLEvento();
			
			Asistencia oAsistencia = new Asistencia();



			//oAsistencia.IdMiembro = int.Parse(idvalue.Text);
			//oAsistencia.IdEvento = idEventoCell.Text;
			//oAsistencia.Fecha = 
			//oAsistencia.IdUsuario =
			//oAsistencia.Confirmado =
			//oAsistencia.asistencia = 
			


        }
    }
}
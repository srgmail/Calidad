using calidad.BLL;
using calidad.DAL;
using calidad.Entidades;
using calidad.Utils;
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
			String idEvento = Request.QueryString["id"];

			idNumeroEvento.Text = idEvento;

			String idUser = Global.idUser;
			
		}

 

        protected void Buscar(object sender, EventArgs e)
        {

			int _id = int.Parse(idvalue.Text);
			DALMiembro dALMiembro = new DALMiembro();
			//dALMiembro.GetMiembroById(_id);

			Miembro oMiembro = dALMiembro.GetMiembroById(_id);
            if (oMiembro != null) { 
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
            else { txtActivo.Text = "Miembro no existe"; }

		}

        protected void Registrar_Click(object sender, EventArgs e)
        {
			BLLAsistencia bLLAsistencia = new BLLAsistencia();
			BLLEvento oBllevento = new BLLEvento();
			
			Asistencia oAsistencia = new Asistencia();

			var dia = DateTime.Now.Day;
			var mes = DateTime.Now.Month;
			var anio = DateTime.Now.Year;
			//var FechaCompar = mes + "/" + dia + "/" + anio + " " +"0:00:00";
			var FechaInsert = anio + "/" + mes + "/" + dia ;

			String idUser = Global.idUser;

			oAsistencia.IdMiembro = int.Parse(idvalue.Text);
			oAsistencia.IdEvento = int.Parse(idNumeroEvento.Text);
			oAsistencia.Fecha =  DateTime.Parse(FechaInsert);
			//oAsistencia.IdUsuario = "neiichango@gmail.com";
			oAsistencia.IdUsuario = idUser;
			//oAsistencia.Confirmado = true;
			oAsistencia.asistencia = true;

			bLLAsistencia.SaveAsistencia(oAsistencia);

			if (oAsistencia.Confirmado.Equals(true))
			{
				Confirmadotextbox.Text = "Confirmado";
			}
			else
			{
				Confirmadotextbox.Text = "No Confirmado";
			}
		}

        protected void Reporte(object sender, EventArgs e)
        {
			Response.Redirect("../Evento/ReporteAsistencia.aspx?idEvento=" + idNumeroEvento.Text);

		}

        protected void Cerrar(object sender, EventArgs e)
        {
			BLLMesa oBllMesa = new BLLMesa();
			Mesa oMesa = new Mesa();

			oMesa.IdEvento = int.Parse(idNumeroEvento.Text);
			oMesa.IdUsuario = Global.idUser;
			oMesa.Estado = true;

			oBllMesa.CerrarMesa(oMesa);


		}
    }
}
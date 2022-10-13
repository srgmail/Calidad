using calidad.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using calidad.Entidades;

namespace calidad.Interfaz_web.Evento
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            BLLEvento oBllevento = new BLLEvento();
            DateTime oDate = calFecha.SelectedDate;
            DateTime Today = DateTime.Now;

            Entidades.Evento oEvento = new Entidades.Evento();
            oEvento.Fecha = oDate;
            oEvento.Nombre = this.txtNombre.Text;
            oBllevento.SaveEvento(oEvento);
            Response.Redirect("../Inicio/Home.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Inicio/Home.aspx");
        }
    }
}
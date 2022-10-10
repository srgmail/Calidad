using calidad.Utils;
using System;
using System.Web.UI;

namespace calidad.Interfaz_web.Inicio
{
    public partial class HomeAdmin : System.Web.UI.MasterPage
    {
        public int userType { get; set; }
        public string Nombre { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userType = Global.userType;
            this.Nombre = Global.Nombre;

            if(this.userType!=1 && this.userType != 2)
            {
                Response.Redirect("LogIn.aspx");
            }
        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {
          
            Global.userType = 0;
            Global.idUser = null;
            Global.Nombre = null;
            Response.Redirect("LogIn.aspx");
        }

       
    }
}
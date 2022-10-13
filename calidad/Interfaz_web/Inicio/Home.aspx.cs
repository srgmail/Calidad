using calidad.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calidad.Interfaz_web.Inicio
{
    public partial class Home : System.Web.UI.Page
    {

        BLLEvento oBLLEvento = new BLLEvento();

        protected void Page_Load(object sender, EventArgs e)
        {
            //cargarDatos();

        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Abrir")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell contactName = selectedRow.Cells[1];
                string contact = contactName.Text;
                TableCell fecha = selectedRow.Cells[2];

                var dateAndTime = DateTime.Now;
                var _date = dateAndTime.Date;
                var dia = DateTime.Now.Day;
                var mes = DateTime.Now.Month;
                var anio = DateTime.Now.Year;
                var FechaCompar = mes + "/" + dia + "/" + anio + " " +"0:00:00";

                if (fecha.Text.Equals(FechaCompar))
                {
                    Console.WriteLine("Si funciona");
                    Response.Redirect("../Evento/AdministrarEvento.aspx");
                }
                else 
                {
                    Console.WriteLine("No funciona");
                }


            } else if (e.CommandName == "Eliminar") {



            } else if (e.CommandName == "Cargar")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell idEventoCell = selectedRow.Cells[0];
                string redirectString = "../Miembros/CargarMiembros.aspx?id="+ idEventoCell.Text;
                Response.Redirect(redirectString);

            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Evento/CrearEvento.aspx");
        }

        //private void cargarDatos()

        //{

        //    try
        //    {

        //        dgvDatos.AutoGenerateColumns = false;
        //      //  dgvDatos.RowTemplate.Height = 100;
        //       // dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        //        // Cargar el DataGridView
        //        this.dgvDatos.DataSource = oBLLEvento.GetAllEvento();
        //    }
        //    catch (Exception er)
        //    {



        //    }

        //}

    }
}
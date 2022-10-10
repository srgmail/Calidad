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
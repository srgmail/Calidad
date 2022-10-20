using calidad.BLL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calidad.Interfaz_web.Evento
{
    public partial class ReporteAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String idEven = Request.QueryString["idEvento"];

            //var _idEvento = idEvento;

            LlenarTabla(int.Parse(idEven));

        }

        private void LlenarTabla(int parametro)
        {
            DataTable _Asis = new DataTable();
            _Asis.Columns.AddRange(new DataColumn[] {
                new DataColumn("idMiembro",typeof(string)),
                new DataColumn("Confirmado",typeof(string)),
                new DataColumn("Fecha",typeof(string)),
                new DataColumn("idUsuario",typeof(string)),

            });



            //BLLAsistencia oAsistencia = new BLLAsistencia();

            //oAsistencia.GetAsistencia(2004);

            //SqlCommand cmd = new SqlCommand(@" select * from  Asistencia where idEvento=2004" + parametro, Conexion.Open());
            SqlCommand cmd = new SqlCommand(@" select * from  Asistencia where idEvento=" + parametro , Conexion.Open());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) 
            {
                //if (dr["Confirmado"].Equals(false).ToString().Replace('0', Convert.ToChar("N"))
                //{
                //    dr["Confirmado"].ToString().Replace('0', 'N');
                //}
                //else
                //{
                //    dr["Confirmado"].ToString().Replace('0', 'S');
                //}

                while (dr.Read())
                {
                    _Asis.Rows.Add(
                        dr["idMiembro"].ToString(),
                        dr["Confirmado"].ToString(),
                        dr["Fecha"].ToString(),
                        dr["idUsuario"].ToString()
                    );
                }
                      
            }

            Conexion.Close();

            GV.DataSource = _Asis;
            GV.DataBind();
        
        }
    }
}
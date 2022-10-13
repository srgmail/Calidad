using calidad.BLL;
using calidad.Entidades;
using IronXL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calidad.Interfaz_web.Miembros
{
    public partial class CargarMiembros : System.Web.UI.Page
    {

        BLLMiembro oBLLMiembro = new BLLMiembro();
        BLLAsistencia oBLLAsistencia = new BLLAsistencia();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("../../Files");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;

            strFileName = Path.GetFileName(strFileName);





            if (oFile.Value != "")
            {
                string finalName="";
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                 finalName = "event" + Request.QueryString["id"] + strFileName;
                // Save the uploaded file to the server.
                strFilePath = strFolder + "\\"+ finalName;
                if (File.Exists(strFilePath))
                {
                    lblUploadResult.Text = strFileName + " already exists on the server!";
                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);
                    lblUploadResult.Text = strFileName + " has been successfully uploaded.";

                    WorkBook workbook = WorkBook.Load(strFilePath);
                    WorkSheet sheet = workbook.DefaultWorkSheet;
                    DataTable csvFilereader = new DataTable();
                    csvFilereader = sheet.ToDataTable(true);
                    string columnData = csvFilereader.Columns[0].ToString();
                    insertData(csvFilereader);

                }
            }
            else
            {
                lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
            }
            // Display the result of the upload.
            frmConfirmation.Visible = true;
        }



        protected void insertData(DataTable csvFilereader) {
            int columnCount = csvFilereader.Columns.Count;
            int rowCount = csvFilereader.Rows.Count;


            var row = csvFilereader.Rows[1].ItemArray;

            for (int i = 0; i < rowCount; i++)
            {
                var currentRow = csvFilereader.Rows[i].ItemArray;
                //for (int j = 0; j <= columnCount; j++)
                //{
                //insertar miembro
                Miembro oMiembro = new Miembro();

                oMiembro.IdMiembro = int.Parse(currentRow[0].ToString());
                oMiembro.Nombre = currentRow[1].ToString();
                oMiembro.Apellido = currentRow[2].ToString();
                oMiembro.Activo = (currentRow[3].ToString().ToLower().Equals("si") == true) ? true : false;

                oBLLMiembro.SaveMiembro(oMiembro);

                //insertar asistencia inicial

                Asistencia oAsistencia = new Asistencia();
                oAsistencia.IdMiembro = int.Parse(currentRow[0].ToString());
                oAsistencia.IdEvento = int.Parse(Request.QueryString["id"]);
                oAsistencia.Fecha = DateTime.Now;
                oAsistencia.IdUsuario = null;
                oAsistencia.Confirmado = (currentRow[4].ToString().ToLower().Equals("si") == true) ? true : false;
                oAsistencia.asistencia = false;

                oBLLAsistencia.SaveAsistencia(oAsistencia);
                //}

            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Inicio/Home.aspx");
        }
    }




}
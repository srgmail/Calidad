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
        }


    }




}
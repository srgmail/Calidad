using calidad.Entidades;
using calidad.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace calidad.DAL
{
    public class DALLogin
    {

        DBUser oDBUser = new DBUser();

        public DALLogin()
        {

            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            oDBUser.Login = con.UserID;
            oDBUser.Password = con.Password;

        }

        public Usuario GetUserId(string pId)
        {
            DataSet ds = null;
            Usuario oUsuario = null;
            string sql = @" select * from  [Usuario] where idUsuario= @idUsuario";

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue("@idUsuario", pId.ToString());
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
          //      command.Parameters["@idUsuario"].Value = pId;
                //command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si retornó valores 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Extraer la primera fila, como se buscó por Id entonces solo una debe devolver  
                    DataRow dr = ds.Tables[0].Rows[0];
                    oUsuario = new Usuario()
                    {
                        IdUsuario = dr["idUsuario"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Contrasena = dr["Contrasena"].ToString(),
                        IdRole = int.Parse(dr["idRole"].ToString()),
                    

              
                    };


                }

                return oUsuario;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }


    }



}
using calidad.Entidades;
using calidad.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace calidad.DAL
{
    public class DALMiembro
    {
        private DBUser oDBUser = new DBUser();

        public DALMiembro()
        {

            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            oDBUser.Login = con.UserID;
            oDBUser.Password = con.Password;

        }





        public Miembro GetMiembroById(int pId)
        {
            DataSet ds = null;
            Miembro oMiembro = null;
            string sql = @" select * from  Miembro where idMiembro= @id";
            //  string sql = @"usp_SELECT_Miembro_ByID";

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue("@id", pId.ToString());
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
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
                    oMiembro = new Miembro()
                    {
                        IdMiembro = int.Parse(dr["idMiembro"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                       //Activo = Convert.ToBoolean(int.Parse(dr["Activo"].ToString()))
                       Activo = bool.Parse(dr["Activo"].ToString())
                    };


                }

                return oMiembro;
            }
            catch (SqlException sqlError)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlMiembros.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Miembro SaveMiembro(Miembro pMiembro)
        {
            Miembro oMiembro = null;
            oMiembro = GetMiembroById(pMiembro.IdMiembro);
            if (oMiembro == null)
            {
                //if the user does not exists needs to be inserted
                string sql = @"Insert into Miembro(idMiembro,Nombre,Apellido,Activo) values (@idMiembro,@Nombre,@Apellido,@Activo)";
                SqlCommand cmd = new SqlCommand();
                double rows = 0;

                try
                {
                    cmd.Parameters.AddWithValue("@idMiembro", pMiembro.Nombre);
                    cmd.Parameters.AddWithValue("@Nombre", pMiembro.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", pMiembro.Apellido);
                    cmd.Parameters.AddWithValue("@Activo", (pMiembro.Activo == false) ? 0 : 1);

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;


                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                    {

                        rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                    }

                    // Si devuelve filas quiere decir que se salvo entonces extraerlo
                    if (rows > 0)
                        oMiembro = GetMiembroById(pMiembro.IdMiembro);

                    // return oMiembro;
                }
                catch (SqlException sqlError)
                {
                    //StringBuilder msg = new StringBuilder();
                    //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                    //msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
                    //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                    throw;
                }
                catch (Exception er)
                {
                    //StringBuilder msg = new StringBuilder();
                    //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                    //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                    throw;
                }

            }
            else
            {
                //si el usuario existe, se valida si necesita actualizar el estado de activo
                if (oMiembro.Activo != pMiembro.Activo)
                {
                    string sql = @"update Miembro set Activo=@Activo  where idMiembro=@idMiembro)";
                    SqlCommand cmd = new SqlCommand();
                    double rows = 0;

                    try
                    {
                        cmd.Parameters.AddWithValue("@idMiembro", pMiembro.Nombre);
                        cmd.Parameters.AddWithValue("@Activo", (pMiembro.Activo == false) ? 0 : 1);

                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;


                        using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                        {

                            rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                        }

                        // Si devuelve filas quiere decir que se salvo entonces extraerlo
                        if (rows > 0)
                            oMiembro = GetMiembroById(pMiembro.IdMiembro);

                    }
                    catch (SqlException sqlError)
                    {
                        //StringBuilder msg = new StringBuilder();
                        //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                        //msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
                        //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                        throw;
                    }





                }

               
            }
            return oMiembro;



        }
    }
}
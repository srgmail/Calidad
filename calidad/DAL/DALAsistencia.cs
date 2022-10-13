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
    public class DALAsistencia
    {

        private DBUser oDBUser = new DBUser();

        public DALAsistencia()
        {

            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            oDBUser.Login = con.UserID;
            oDBUser.Password = con.Password;

        }

        public Asistencia GetAsistenciaById(int pIdMiembro, int pIdEvento)
        {
            DataSet ds = null;
            Asistencia oAsistencia = null;
            string sql = @" select * from  Asistencia where idMiembro= @idMiembro AND idEvento=@idEvento ";
            //  string sql = @"usp_SELECT_Asistencia_ByID";

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue("@idMiembro", pIdMiembro.ToString());
                command.Parameters.AddWithValue("@idEvento", pIdEvento.ToString());

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
                    oAsistencia = new Asistencia()
                    {
                        IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                        IdEvento = int.Parse(dr["IdEvento"].ToString()),
                        //Fecha = DateTime.Parse(dr["fecha"].ToString()),
                        //IdUsuario = dr["IdUsuario"].ToString(),
                        //Confirmado = Convert.ToBoolean(int.Parse(dr["Confirmado"].ToString())),
                        //asistencia = Convert.ToBoolean(int.Parse(dr["asistencia"].ToString()))
                        Fecha = dr["Fecha"].ToString().Equals("") ? DateTime.Now : DateTime.Parse(dr["fecha"].ToString()),
                        IdUsuario = dr["IdUsuario"].ToString().Equals("") ? null : dr["IdUsuario"].ToString(),
                        Confirmado = Convert.ToBoolean(dr["Confirmado"].ToString()),
                        asistencia = dr["asistencia"].ToString().Equals("") ? false : Convert.ToBoolean(int.Parse(dr["asistencia"].ToString()))
                    };


                }

                return oAsistencia;
            }
            catch (SqlException sqlError)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
                //_MyLogControlAsistencias.ErrorFormat("Error {0}", msg.ToString());
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

        public Asistencia SaveAsistencia(Asistencia pAsistencia)
        {
            Asistencia oAsistencia = null;
            oAsistencia = GetAsistenciaById(pAsistencia.IdMiembro,pAsistencia.IdEvento);
            if (oAsistencia == null)
            {
                //if the user does not exists needs to be inserted
                //string sql = @"Insert into Asistencia(idMiembro,idEvento,Fecha,idUsuario,Confirmado,asistencia) values (@idMiembro,@idEvento,@Fecha,@idUsuario,@Confirmado,@asistencia)";
                string sql = @"Insert into Asistencia(idMiembro,idEvento,Confirmado) values (@idMiembro,@idEvento,@Confirmado)";
                SqlCommand cmd = new SqlCommand();
                double rows = 0;

                try
                {
                    cmd.Parameters.AddWithValue("@idMiembro", pAsistencia.IdMiembro.ToString());
                    cmd.Parameters.AddWithValue("@idEvento", pAsistencia.IdEvento.ToString());
                   // cmd.Parameters.AddWithValue("@Fecha", pAsistencia.Fecha);
                    //cmd.Parameters.AddWithValue("@idUsuario", pAsistencia.IdUsuario);
                    cmd.Parameters.AddWithValue("@Confirmado", (pAsistencia.Confirmado == false) ? 0 : 1);
                    //cmd.Parameters.AddWithValue("@asistencia", (pAsistencia.asistencia == false) ? 0 : 1);
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;


                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                    {

                        rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                    }

                    // Si devuelve filas quiere decir que se salvo entonces extraerlo
                    if (rows > 0)
                        oAsistencia = GetAsistenciaById(pAsistencia.IdMiembro,pAsistencia.IdEvento);

                    // return oAsistencia;
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
                //si el asistencia existe, se valida si necesita actualizar 
                if (oAsistencia.asistencia != pAsistencia.asistencia)
                {
                    string sql = @"update Asistencia set idUsuario=@idUsuario,fecha=@fecha,asistencia=@asistencia  where idMiembro=@idMiembro AND idEvento=@idEvento)";
                    SqlCommand cmd = new SqlCommand();
                    double rows = 0;

                    try
                    {
                        cmd.Parameters.AddWithValue("@idMiembro", pAsistencia.IdMiembro.ToString());
                        cmd.Parameters.AddWithValue("@idEvento", pAsistencia.IdEvento.ToString());
                        cmd.Parameters.AddWithValue("@Fecha", pAsistencia.Fecha);
                        cmd.Parameters.AddWithValue("@idUsuario", pAsistencia.IdUsuario);
                        cmd.Parameters.AddWithValue("@Confirmado", (pAsistencia.Confirmado == false) ? 0 : 1);
                        cmd.Parameters.AddWithValue("@asistencia", (pAsistencia.asistencia == false) ? 0 : 1);

                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;


                        using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                        {

                            rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                        }

                        // Si devuelve filas quiere decir que se salvo entonces extraerlo
                        if (rows > 0)
                            oAsistencia = GetAsistenciaById(pAsistencia.IdMiembro,pAsistencia.IdEvento);

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
            return oAsistencia;



        }





    }
}
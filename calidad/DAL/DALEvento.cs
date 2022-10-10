using calidad.Entidades;
using calidad.Entidades.DTO;
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
    public class DALEvento
    {

        private DBUser oDBUser = new DBUser();

        public DALEvento()
        {

            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            oDBUser.Login = con.UserID;
            oDBUser.Password = con.Password;

        }


        public bool DeleteEvento(int pId)
        {

            double rows = 0;
            // Crear el SQL
            string sql = @" delete   from  Evento where Id = @IdEvento ";
            //string sql = @"usp_DELETE_Evento_ByID";
            SqlCommand command = new SqlCommand();

            try
            {
                // Pasar parámetros
                command.Parameters.AddWithValue("@IdEvento", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                //command.CommandType = CommandType.StoredProcedure;
                // Ejecutar
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return rows > 0;
            }
            catch (SqlException sqlError)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
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

        public List<EventoDTO> GetAllEvento()
        {

            DataSet ds = null;
            List<EventoDTO> lista = new List<EventoDTO>();
            SqlCommand command = new SqlCommand();

            string sql = @"SELECT * from Evento";

            //string sql = @"usp_SELECT_Huesped_All";
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                // command.CommandType = CommandType.StoredProcedure;
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {

                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EventoDTO oEventoDTO = new EventoDTO()
                        {
                            idEvento = int.Parse(dr["idEvento"].ToString()),
                            Nombre = dr["nombre"].ToString(),
                            Fecha = DateTime.Parse(dr["fecha"].ToString()),

                        };

                        lista.Add(oEventoDTO);
                    }
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
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


        public Evento GetEventoById(int pId)
        {
            DataSet ds = null;
            Evento oEvento = null;
            string sql = @" select * from  Evento where idEvento= @id";
            //  string sql = @"usp_SELECT_Evento_ByID";

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
                    oEvento = new Evento()
                    {
                        IdEvento = int.Parse(dr["idEvento"].ToString()),
                        Nombre = dr["nombre"].ToString(),
                        Fecha = DateTime.Parse(dr["fecha"].ToString()),


                    };


                }

                return oEvento;
            }
            catch (SqlException sqlError)
            {
                //StringBuilder msg = new StringBuilder();
                //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                //msg.AppendFormat("SQL             {0}\n", command.CommandText);
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

        public Evento SaveEvento(Evento pEvento)
        {

            Evento oEvento = null;
            string sql = @"Insert into Evento(nombre,Fecha) values (@nombre,@fecha)";
            // string sql = @"usp_INSERT_Evento";
            SqlCommand cmd = new SqlCommand();
            double rows = 0;

            try
            {
                cmd.Parameters.AddWithValue("@nombre", pEvento.Nombre);
                cmd.Parameters.AddWithValue("@fecha", pEvento.Fecha);

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                {

                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oEvento = GetEventoById(pEvento.IdEvento);

                return oEvento;
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

        //    public Evento UpdateEvento(Evento pEvento)
        //    {
        //        Evento oEvento = null;
        //        string sql = @"usp_UPDATE_Evento";



        //        SqlCommand command = new SqlCommand();
        //        double rows = 0;

        //        try
        //        {
        //            command.Parameters.AddWithValue("@id", pEvento.id);
        //            command.Parameters.AddWithValue("@descripcion", pEvento.descripcion);
        //            command.Parameters.AddWithValue("@fotografia", pEvento.fotografia.ToArray());
        //            command.Parameters.AddWithValue("@idTipoEvento", pEvento.idTipoEvento);
        //            command.CommandText = sql;

        //            command.CommandType = CommandType.StoredProcedure;

        //            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
        //            {

        //                rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
        //            }

        //            // Si devuelve filas quiere decir que se salvo entonces extraerlo
        //            if (rows > 0)
        //                oEvento = GetEventoById(pEvento.id);

        //            return oEvento;
        //        }
        //        catch (SqlException sqlError)
        //        {
        //            //StringBuilder msg = new StringBuilder();
        //            //msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
        //            //msg.AppendFormat("SQL             {0}\n", command.CommandText);
        //            //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
        //            throw;
        //        }
        //        catch (Exception er)
        //        {
        //            //StringBuilder msg = new StringBuilder();
        //            //msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
        //            //_MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
        //            throw;
        //        }
        //  }
        //}
    }
}
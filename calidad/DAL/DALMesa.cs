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
    public class DALMesa
    {

        private DBUser oDBUser = new DBUser();

        public DALMesa()
        {

            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            oDBUser.Login = con.UserID;
            oDBUser.Password = con.Password;

        }

        public Mesa CerrarMesa(Mesa pMesa) 
        {
            Mesa oMesa = null;
            string sql = @"Insert into Mesa(idEvento,idUsuario,estado) values (@idEvento,@idUsuario,@estado)";
            SqlCommand cmd = new SqlCommand();
            double rows = 0;

            try
            {
                cmd.Parameters.AddWithValue("@idEvento", pMesa.IdEvento);
                cmd.Parameters.AddWithValue("@idUsuario", pMesa.IdUsuario);
                cmd.Parameters.AddWithValue("@estado", pMesa.Estado);

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(oDBUser.Login, oDBUser.Password)))
                {

                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                return oMesa;

            }
            catch (SqlException sqlError)
            {
                throw;
            }

            catch (Exception er)
            {
                throw;
            }
        }

    }
}
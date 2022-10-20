using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace calidad.Entidades
{
    public class Conexion
    {
        public static SqlConnection Open() {
            SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-LT2FBGP;Initial Catalog=CalidadProyecto;Integrated Security=False;User Id=sa;Password=123456");
            Conn.Open();
            return Conn;

        }

        public static SqlConnection Close()
        {
            SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-LT2FBGP;Initial Catalog=CalidadProyecto;Integrated Security=False;User Id=sa;Password=123456");
            Conn.Close();
            return Conn;

        }

    }
}
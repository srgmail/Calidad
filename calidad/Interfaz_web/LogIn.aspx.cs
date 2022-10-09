using calidad.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace calidad.Interfaz_web
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void IniciarSesion(object sender, EventArgs e)
        {
            BLLLogin oBLLLogin = new BLLLogin();
            if (!oBLLLogin.IsValidEmail(Login1.UserName))
            {
                Login1.FailureText = "El correo tiene un formato inválido";

            }
            else
            {
                Login1.FailureText =  oBLLLogin.Login(Login1.UserName, Login1.Password).IdUsuario;

            }



        }

        /* bool IsValidEmail(string strIn)
         {
             // Return true if strIn is in valid email format.
             return Regex.IsMatch(strIn, @"^([\w\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
         }

         void OnLoggingIn(System.Web.UI.WebControls.LoginCancelEventArgs e)
         {
             if (!IsValidEmail(Login1.UserName))
             {
                 Login1.InstructionText = "Enter a valid email address.";
                 Login1.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
                 e.Cancel = true;
             }
             else
             {
                 Login1.InstructionText = String.Empty;
             }
         }
         */

    }
}
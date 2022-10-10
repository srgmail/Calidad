using calidad.BLL;
using calidad.Utils;
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
                Login1.FailureText  = "El correo tiene un formato inválido";

            }
            else if (!oBLLLogin.userExists(Login1.UserName, Login1.Password)) { 

                Login1.FailureText =   "El usuario no existe, póngase en contacto con el administrador";

           }else if(!oBLLLogin.ValidatePassword(Login1.UserName, Login1.Password)){ 
              Login1.FailureText =   "Contraseña incorrecta";
            }
            else
            {
                Response.Redirect("Home.aspx");
               // Login1.FailureText =   "login correcto";
                
            }



        }


    }
}
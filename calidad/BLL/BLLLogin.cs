using calidad.DAL;
using calidad.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace calidad.BLL
{
    public class BLLLogin
    {
        DALLogin oDALLogin = new DALLogin();

        public bool ValidatePassword(string pUsuario, string pContrasena)
        {
            
           Usuario result =  oDALLogin.GetUserId(pUsuario);

            if (result.Contrasena == pContrasena)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public bool userExists(string pUsuario, string pContrasena)
        {
           
           Usuario result =  oDALLogin.GetUserId(pUsuario);
            if (result == null)
            {
                return false;

            }
            else
            {
               return true;
            }
        }

      public  bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid email format.
            return Regex.IsMatch(strIn, @"^([\w\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }

    
}
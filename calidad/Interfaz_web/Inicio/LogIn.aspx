<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="calidad.Interfaz_web.LogIn" %>

<!DOCTYPE html>





<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="display:flex; flex:1; flex-direction:column;width:100%;vertical-align:central; align-self: center; align-content:center;align-items:center">
    <form id="LogInForm" runat="server" >
                
   

            <asp:Login ID="Login1" runat="server" OnAuthenticate="IniciarSesion"
                BorderStyle="Solid"
                BackColor="#d5d7f2"
                BorderWidth="5px"
                BorderColor="#070d87"
                Font-Size="10pt" UserNameLabelText="Correo:"
                PasswordLabelText="Contraseña:"
                TitleText="Inicio de Sesión"
                DisplayRememberMe="False"
                LoginButtonText="Inicio">
            </asp:Login>

        
    </form>

            </div>
</body>
</html>

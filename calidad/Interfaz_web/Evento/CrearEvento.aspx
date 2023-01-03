<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="CrearEvento.aspx.cs" Inherits="calidad.Interfaz_web.Evento.CrearEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div style="flex-direction:column;flex:1;display:flex; width:20%;margin:20px auto">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre del evento:"></asp:Label>

    <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>

    <asp:Label ID="lblFecha" runat="server" Text="Fecha del evento:"></asp:Label>

    <asp:Calendar ID="calFecha" runat="server"></asp:Calendar>

        <asp:label id="Message"
        forecolor="Red"
        runat="server"
     />

        <div style="display:flex;flex-direction:row">
             <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" style="width:100px;margin-top:15px"/>
             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" style="width:100px;margin-top:15px"/>

        </div>

        </div>

</asp:Content>

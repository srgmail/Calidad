<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="AdministrarEvento.aspx.cs" Inherits="calidad.Interfaz_web.Evento.AdministrarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <asp:Label runat="server" Text="Label">Administrar Evento</asp:Label>
    <br />
    <br />
    <asp:Label runat="server" Text="Label">Registro Asistencia</asp:Label>
    <br />
    <br />
    <asp:TextBox ID="idvalue" runat="server">Ingrese id</asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" Text="Buscar" OnClick="Buscar" />
    <br />
    <br />
    <asp:TextBox runat="server">Nombre</asp:TextBox>
    <br />
    <br />
    <asp:TextBox runat="server">confirmado</asp:TextBox>
    <br />
    <br />
    <asp:TextBox runat="server">Activo</asp:TextBox>


    

        
    

</asp:Content>

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
    <asp:TextBox ID="idNumeroEvento" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="idvalue" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" Text="Buscar" OnClick="Buscar" />
    <br />
    <br />
    <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="Confirmadotextbox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="txtActivo" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Registrar" OnClick="Registrar_Click" runat="server" Text="Registrar asistencia" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Reporte Asistencia" OnClick="Reporte"/>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Cerrar mesa" />
    

        
    

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="CargarMiembros.aspx.cs" Inherits="calidad.Interfaz_web.Miembros.CargarMiembros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div style="flex-direction:column;flex:1;display:flex; width:20%;margin:20px auto">
    <asp:Label ID="Label1" runat="server" Text="Label">CARGAR MIEMBROS</asp:Label>

      <input id="oFile" type="file" name="oFile" runat="server"/>

            <asp:button id="btnUpload" type="submit" text="Upload" runat="server" OnClick="btnUpload_Click"></asp:button>

          <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
    <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
</asp:Panel>
       </div>   
</asp:Content>

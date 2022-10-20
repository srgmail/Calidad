<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="ReporteAsistencia.aspx.cs" Inherits="calidad.Interfaz_web.Evento.ReporteAsistencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 20px">
        <div style="margin-bottom:20px;height:50px;align-content:space-between">

        </div>

        <div>
            <asp:ScriptManager id="scriptManager1" runat="server"></asp:ScriptManager>
            
                <ContentTemplate>
                    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="false">
                     <Columns>
                         <asp:BoundField HeaderText="Cedula" DataField="idMiembro"/>
                         <asp:BoundField HeaderText="Confirmo" DataField="Confirmado"/>
                         <asp:BoundField HeaderText="Hora" DataField="Fecha"/>
                         <asp:BoundField HeaderText="Registrado por" DataField="idUsuario"/>
                     </Columns>   
                    </asp:GridView>
                </ContentTemplate>
            
        </div>
    </div>
</asp:Content>

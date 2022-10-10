<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="calidad.Interfaz_web.Inicio.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 20px">

        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true">Lista de eventos</asp:Label>

        <%-- <asp:GridView ID="dgvDatos" runat="server" ></asp:GridView>--%>

        <asp:SqlDataSource ID="Source"
            SelectCommand="SELECT IdEvento, nombre, Fecha FROM Evento"
            ConnectionString="<%$ ConnectionStrings:default %>"
            runat="server" />

        <asp:GridView ID="GridView"
            DataSourceID="Source"
            AutoGenerateColumns="False"
            EmptyDataText="No se encontraron eventos"
            CellPadding="5"
            AllowPaging="True"
            AllowSorting="true"
            HeaderStyle-BackColor="#cccccc"
            runat="server" DataKeyNames="IdEvento">
            <Columns>
                <asp:BoundField DataField="IdEvento" HeaderText="IdEvento"
                    InsertVisible="False" ReadOnly="True" SortExpression="IdEvento" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre"
                    SortExpression="nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha"
                    SortExpression="Fecha" />
               <asp:ButtonField  buttontype="Button" 
            commandname="Select" 
            headertext="Abrir" 
            text="Abrir"  />
            </Columns>
        </asp:GridView>





    </div>




</asp:Content>

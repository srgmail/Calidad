<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="calidad.Interfaz_web.Inicio.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 20px">
        <div style="margin-bottom:20px;height:50px;align-content:space-between;flex-direction:column;display:flex">
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true" >Lista de eventos</asp:Label>
        <asp:Button ID="btnCrear" runat="server" Text="Crear Evento" OnClick="btnCrear_Click" style="width:100px;margin-top:15px"/>

        </div>



     

        <asp:SqlDataSource ID="Source"
            SelectCommand="SELECT IdEvento, nombre, Fecha FROM Evento"
            ConnectionString="<%$ ConnectionStrings:default %>"
            runat="server" />


         <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="GridView"/>


        <asp:GridView ID="GridView"
            DataSourceID="Source"
            AutoGenerateColumns="False"
            EmptyDataText="No se encontraron eventos"
            CellPadding="5"
            AllowPaging="True"
            AllowSorting="true"
            OnRowCommand="GridView_RowCommand"
            HeaderStyle-BackColor="#cccccc"
            runat="server" DataKeyNames="IdEvento">
            <Columns>
                <asp:BoundField DataField="IdEvento" HeaderText="IdEvento"
                    InsertVisible="False" ReadOnly="True" SortExpression="IdEvento" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre"
                    SortExpression="nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha"
                    SortExpression="Fecha" />
               <asp:ButtonField  buttontype="Link" 
            commandname="Abrir" 
            headertext="Abrir" 
            text="Abrir"  />
                <asp:ButtonField  buttontype="Link" 
            commandname="Eliminar" 
            headertext="Eliminar" 
            text="Eliminar"  />
            </Columns>
        </asp:GridView>





    </div>




</asp:Content>

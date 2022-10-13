<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz_web/Inicio/MenuMaster.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="calidad.Interfaz_web.Inicio.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 20px">
        <div style="margin-bottom:20px;height:50px;align-content:space-between;flex-direction:column;display:flex">
        <asp:Label ID="Label1" runat="server" Text="Reporte" Font-Bold="True" ></asp:Label>

        </div>



     

        <asp:SqlDataSource ID="Source"
            SelectCommand="SELECT IdEvento, nombre, Fecha FROM Evento"
            ConnectionString="<%$ ConnectionStrings:default %>"
            runat="server" OnSelecting="Source_Selecting" />


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
            runat="server" DataKeyNames="IdEvento" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
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
                 <asp:ButtonField  buttontype="Link" 
            commandname="Cargar" 
            headertext="Cargar" 
            text="Cargar"  />
            </Columns>
        </asp:GridView>





    </div>




</asp:Content>

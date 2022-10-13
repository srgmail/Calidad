<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="calidad.Interfaz_web.Evento.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <H1>Reporte Evento:
           </H1>


        <asp:GridView ID="GridView"
            DataSourceID="Source"
            AutoGenerateColumns="False"
            EmptyDataText="No se encontraron eventos"
            CellPadding="5"
            AllowPaging="True"
            AllowSorting="true"
            OnRowCommand="GridView_RowCommand"
            HeaderStyle-BackColor="#cccccc"
            runat="server" DataKeyNames="Cedula" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="IdEvento" HeaderText="Cédula"
                    InsertVisible="False" ReadOnly="True" SortExpression="IdEvento" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre"
                    SortExpression="nombre" />
                <asp:BoundField DataField="Confirmo" HeaderText="Confirmó"
                    SortExpression="confirmo" />
                <asp:BoundField DataField="Hora" HeaderText="Hora"
                    SortExpression="Fecha" />
                <asp:BoundField DataField="Regitro" HeaderText="Regitró"
                    SortExpression="registro"/>
            </Columns>
        </asp:GridView>
        </div>
        <asp:Button ID="Back" runat="server" Text="Atrás" />
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="PruebaTecnica.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Gestión de Clientes</h2>

        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>

        <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido"></asp:TextBox>

        <asp:TextBox ID="txtCorreo" runat="server" placeholder="Correo" TextMode="Email"></asp:TextBox>

        <asp:TextBox ID="txtTelefono" runat="server" placeholder="Teléfono"></asp:TextBox>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btnGuardar_Click" />

        <hr />

        <asp:GridView ID="gvClientes" runat="server"
            AutoGenerateColumns="True"
            EmptyDataText="No hay clientes registrados.">
        </asp:GridView>

    </form>
</body>
</html>
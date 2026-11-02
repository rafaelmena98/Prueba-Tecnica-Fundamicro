<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="PruebaTecnica.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Gestión de Clientes</h2>

        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="True">
        </asp:GridView>

    </form>
</body>
</html>
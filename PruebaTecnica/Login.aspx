<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="PruebaTecnica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>                        
            <h2>Inicio de sesión</h2>

            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>

            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>

            <br /><br />

            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>

            <asp:TextBox ID="txtPassword" runat="server"
                TextMode="Password"></asp:TextBox>

            <br /><br />

            <asp:Button ID="btnLogin" runat="server"
                Text="Iniciar sesión" />

            <br /><br />

            <asp:Label ID="lblMensaje" runat="server"
                ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

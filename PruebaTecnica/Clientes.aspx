
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="PruebaTecnica.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Gestión de Clientes</h2>

        <asp:TextBox
            ID="txtNombre"
            runat="server"
            placeholder="Nombre" />

        <asp:TextBox
            ID="txtApellido"
            runat="server"
            placeholder="Apellido" />

        <asp:TextBox
            ID="txtCorreo"
            runat="server"
            TextMode="Email"
            placeholder="Correo" />

        <asp:TextBox
            ID="txtTelefono"
            runat="server"
            placeholder="Teléfono" />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar Cliente"
            OnClick="btnGuardar_Click" />

        <hr />

        <asp:GridView
            ID="gvClientes"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdCliente"
            OnRowDeleting="gvClientes_RowDeleting"
            OnRowEditing="gvClientes_RowEditing"
            OnRowUpdating="gvClientes_RowUpdating"
            OnRowCancelingEdit="gvClientes_RowCancelingEdit"
            EmptyDataText="No hay clientes registrados.">

            <Columns>
                <asp:BoundField
                    DataField="IdCliente"
                    HeaderText="ID"
                    ReadOnly="True" />

                <asp:BoundField
                    DataField="Nombre"
                    HeaderText="Nombre" />

                <asp:BoundField
                    DataField="Apellido"
                    HeaderText="Apellido" />

                <asp:BoundField
                    DataField="Correo"
                    HeaderText="Correo" />

                <asp:BoundField
                    DataField="Telefono"
                    HeaderText="Teléfono" />

                <asp:BoundField
                    DataField="FechaRegistro"
                    HeaderText="Fecha de Registro"
                    DataFormatString="{0:dd/MM/yyyy HH:mm}"
                    ReadOnly="True" />

                <asp:CommandField
                    ShowEditButton="True"
                    ShowDeleteButton="True"
                    EditText="Editar"
                    UpdateText="Actualizar"
                    CancelText="Cancelar"
                    DeleteText="Eliminar"
                    HeaderText="Acciones" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>

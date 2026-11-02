
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
            MaxLength="100"
            placeholder="Nombre" />

        <asp:TextBox
            ID="txtApellido"
            runat="server"
            MaxLength="100"
            placeholder="Apellido" />

        <asp:TextBox
            ID="txtCorreo"
            runat="server"
            TextMode="Email"
            MaxLength="150"
            placeholder="Correo" />

        <asp:TextBox
            ID="txtTelefono"
            runat="server"
            MaxLength="35"
            placeholder="Teléfono" />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar Cliente"
            ValidationGroup="GuardarCliente"
            OnClick="btnGuardar_Click" />

        <asp:Button
            ID="btnCerrarSesion"
            runat="server"
            Text="Cerrar sesión"
            CausesValidation="False"
            OnClick="btnCerrarSesion_Click" />

        <br /><br />

        <asp:RequiredFieldValidator
            ID="rfvNombre"
            runat="server"
            ControlToValidate="txtNombre"
            ValidationGroup="GuardarCliente"
            ErrorMessage="El nombre es obligatorio."
            ForeColor="Red"
            Display="Dynamic" />

        <br />

        <asp:RequiredFieldValidator
            ID="rfvApellido"
            runat="server"
            ControlToValidate="txtApellido"
            ValidationGroup="GuardarCliente"
            ErrorMessage="El apellido es obligatorio."
            ForeColor="Red"
            Display="Dynamic" />

        <br />

        <asp:RequiredFieldValidator
            ID="rfvCorreo"
            runat="server"
            ControlToValidate="txtCorreo"
            ValidationGroup="GuardarCliente"
            ErrorMessage="El correo es obligatorio."
            ForeColor="Red"
            Display="Dynamic" />

        <br />

        <asp:RegularExpressionValidator
            ID="revCorreo"
            runat="server"
            ControlToValidate="txtCorreo"
            ValidationGroup="GuardarCliente"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            ErrorMessage="Ingrese un correo electrónico válido."
            ForeColor="Red"
            Display="Dynamic" />

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
                    HeaderText="Acciones"
                    CausesValidation="False" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>

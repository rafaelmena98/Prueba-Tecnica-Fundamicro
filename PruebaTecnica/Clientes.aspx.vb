Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            gvClientes.DataSource = ClienteDAO.ObtenerClientes()
            gvClientes.DataBind()
        End If

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido.Text) OrElse
           String.IsNullOrWhiteSpace(txtCorreo.Text) Then

            Return
        End If

        Dim clienteNuevo As New Cliente()

        clienteNuevo.Nombre = txtNombre.Text.Trim()
        clienteNuevo.Apellido = txtApellido.Text.Trim()
        clienteNuevo.Correo = txtCorreo.Text.Trim()
        clienteNuevo.Telefono = txtTelefono.Text.Trim()

        ClienteDAO.InsertarCliente(clienteNuevo)

        Response.Redirect("Clientes.aspx")

    End Sub

    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Dim idCliente As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)

        ClienteDAO.EliminarCliente(idCliente)

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub

    Protected Sub gvClientes_RowEditing(sender As Object, e As GridViewEditEventArgs)

        gvClientes.EditIndex = e.NewEditIndex

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub

    Protected Sub gvClientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        gvClientes.EditIndex = -1

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub

    Protected Sub gvClientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim fila As GridViewRow = gvClientes.Rows(e.RowIndex)

        Dim clienteActualizado As New Cliente()

        clienteActualizado.IdCliente = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)

        clienteActualizado.Nombre = CType(fila.Cells(1).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Apellido = CType(fila.Cells(2).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Correo = CType(fila.Cells(3).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Telefono = CType(fila.Cells(4).Controls(0), TextBox).Text.Trim()

        If String.IsNullOrWhiteSpace(clienteActualizado.Nombre) OrElse
           String.IsNullOrWhiteSpace(clienteActualizado.Apellido) OrElse
           String.IsNullOrWhiteSpace(clienteActualizado.Correo) Then

            Return
        End If

        ClienteDAO.ActualizarCliente(clienteActualizado)

        gvClientes.EditIndex = -1

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub

End Class
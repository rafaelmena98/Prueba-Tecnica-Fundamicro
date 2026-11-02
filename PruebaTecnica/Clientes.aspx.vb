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

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub

End Class

Imports System.Text.RegularExpressions

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnInit(e As EventArgs)

        If Session("IdUsuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
            Return
        End If

        MyBase.OnInit(e)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarClientes()
        End If

    End Sub


    Private Sub CargarClientes()

        gvClientes.DataSource = ClienteDAO.ObtenerClientes()
        gvClientes.DataBind()

    End Sub


    Private Function DatosValidos(clienteActual As Cliente) As Boolean

        If String.IsNullOrWhiteSpace(clienteActual.Nombre) OrElse
           String.IsNullOrWhiteSpace(clienteActual.Apellido) OrElse
           String.IsNullOrWhiteSpace(clienteActual.Correo) Then

            Return False

        End If

        If clienteActual.Nombre.Length > 100 OrElse
           clienteActual.Apellido.Length > 100 OrElse
           clienteActual.Correo.Length > 150 OrElse
           (clienteActual.Telefono IsNot Nothing AndAlso
            clienteActual.Telefono.Length > 35) Then

            Return False

        End If

        If Not Regex.IsMatch(clienteActual.Correo,
                             "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then

            Return False

        End If

        Return True

    End Function


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Page.Validate("GuardarCliente")

        If Not Page.IsValid Then
            Return
        End If

        Dim clienteNuevo As New Cliente()

        clienteNuevo.Nombre = txtNombre.Text.Trim()
        clienteNuevo.Apellido = txtApellido.Text.Trim()
        clienteNuevo.Correo = txtCorreo.Text.Trim()
        clienteNuevo.Telefono = txtTelefono.Text.Trim()

        If Not DatosValidos(clienteNuevo) Then
            Return
        End If

        Dim idUsuario As Integer = Convert.ToInt32(Session("IdUsuario"))
        Dim nombreUsuario As String = Session("NombreUsuario").ToString()

        ClienteDAO.InsertarCliente(clienteNuevo, idUsuario, nombreUsuario)

        Response.Redirect("~/Clientes.aspx")

    End Sub


    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Dim idCliente As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)

        Dim idUsuario As Integer = Convert.ToInt32(Session("IdUsuario"))
        Dim nombreUsuario As String = Session("NombreUsuario").ToString()

        ClienteDAO.EliminarCliente(idCliente, idUsuario, nombreUsuario)

        CargarClientes()

    End Sub


    Protected Sub gvClientes_RowEditing(sender As Object, e As GridViewEditEventArgs)

        gvClientes.EditIndex = e.NewEditIndex

        CargarClientes()

    End Sub


    Protected Sub gvClientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        gvClientes.EditIndex = -1

        CargarClientes()

    End Sub


    Protected Sub gvClientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim fila As GridViewRow = gvClientes.Rows(e.RowIndex)

        Dim clienteActualizado As New Cliente()

        clienteActualizado.IdCliente = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)

        clienteActualizado.Nombre = CType(fila.Cells(1).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Apellido = CType(fila.Cells(2).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Correo = CType(fila.Cells(3).Controls(0), TextBox).Text.Trim()
        clienteActualizado.Telefono = CType(fila.Cells(4).Controls(0), TextBox).Text.Trim()

        If Not DatosValidos(clienteActualizado) Then
            Return
        End If

        Dim idUsuario As Integer = Convert.ToInt32(Session("IdUsuario"))
        Dim nombreUsuario As String = Session("NombreUsuario").ToString()

        ClienteDAO.ActualizarCliente(clienteActualizado, idUsuario, nombreUsuario)

        gvClientes.EditIndex = -1

        CargarClientes()

    End Sub


    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs)

        Session.Clear()
        Session.Abandon()

        Response.Redirect("~/Login.aspx", False)
        Context.ApplicationInstance.CompleteRequest()

    End Sub

End Class

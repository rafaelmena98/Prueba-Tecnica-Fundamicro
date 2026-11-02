Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim nombreUsuario As String = txtUsuario.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(nombreUsuario) OrElse String.IsNullOrWhiteSpace(password) Then
            lblMensaje.Text = "Ingrese usuario y contraseña."
            Return
        End If

        Dim usuarioActual As Usuario = UsuarioDAO.AutenticarUsuario(nombreUsuario, password)

        If usuarioActual IsNot Nothing Then

            Session("IdUsuario") = usuarioActual.idUsuario
            Session("NombreUsuario") = usuarioActual.NombreUsuario

            Response.Redirect("~/Clientes.aspx")

        Else

            lblMensaje.Text = "Usuario o contraseña incorrectos."

        End If

    End Sub
End Class
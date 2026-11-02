Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            gvClientes.DataSource = ClienteDAO.ObtenerClientes()
            gvClientes.DataBind()
        End If

    End Sub

End Class
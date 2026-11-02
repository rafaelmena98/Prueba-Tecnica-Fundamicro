Imports System.Data.SqlClient

Public Class TestConexion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

                conexion.Open()

                Response.Write("Conexion Exitosa a SQL Server")

            End Using

        Catch ex As Exception
            Response.Write("Error de Conexion: " & Server.HtmlEncode(ex.Message))

        End Try


    End Sub

End Class
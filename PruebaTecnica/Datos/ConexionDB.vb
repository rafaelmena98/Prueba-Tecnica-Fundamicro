Imports System.Data.SqlClient
Imports System.Configuration


Public Class ConexionDB

    Public Shared Function ObtenerConexion() As SqlConnection

        Dim cadena As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString

        Dim baseDeDatos As New SqlConnection(cadena)

        Return baseDeDatos

    End Function

End Class

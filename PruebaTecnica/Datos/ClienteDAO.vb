Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class ClienteDAO
    Public Shared Function ObtenerClientes() As List(Of Cliente)
        Dim Lista As New List(Of Cliente)()

        Dim query As String = "SELECT IdCliente, Nombre, Apellido, Correo, Telefono, FechaRegistro FROM Clientes"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

            conexion.Open()

            Using comando As New SqlCommand(query, conexion)

                Using lector As SqlDataReader = comando.ExecuteReader()

                    While lector.Read()

                        Dim ClienteActual As New Cliente()
                        ClienteActual.IdCliente = Convert.ToInt32(lector("idCliente"))
                        ClienteActual.Nombre = lector("Nombre").ToString()
                        ClienteActual.Apellido = lector("Apellido").ToString()
                        ClienteActual.Correo = lector("Correo").ToString()
                        ClienteActual.FechaRegistro = Convert.ToDateTime(lector("FechaRegistro"))
                        ClienteActual.Telefono = If(lector.IsDBNull(lector.GetOrdinal("Telefono")), Nothing, lector("Telefono").ToString())
                        Lista.Add(ClienteActual)

                    End While

                End Using

            End Using

        End Using

        Return Lista

    End Function

End Class

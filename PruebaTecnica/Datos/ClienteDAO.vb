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


    Public Shared Sub InsertarCliente(ClienteNuevo As Cliente)
        Dim query As String = "INSERT INTO Clientes (Nombre, Apellido, Correo, Telefono) VALUES (@Nombre, @Apellido, @Correo, @Telefono)"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = ClienteNuevo.Nombre
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 100).Value = ClienteNuevo.Apellido
                comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = ClienteNuevo.Correo
                comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = If(String.IsNullOrWhiteSpace(ClienteNuevo.Telefono), CType(DBNull.Value, Object), ClienteNuevo.Telefono)

                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        End Using

    End Sub

    Public Shared Sub EliminarCliente(idCliente As Integer)
        Dim query As String = "DELETE FROM Clientes WHERE idCliente = @IdCliente"
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente
                conexion.Open()
                comando.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub ActualizarCliente(ClienteActualizado As Cliente)
        Dim query As String = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Telefono = @Telefono WHERE IdCliente = @IdCliente"
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = ClienteActualizado.IdCliente
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = ClienteActualizado.Nombre
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = ClienteActualizado.Apellido
                comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = ClienteActualizado.Correo
                comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 35).Value = If(String.IsNullOrWhiteSpace(ClienteActualizado.Telefono), CType(DBNull.Value, Object), ClienteActualizado.Telefono)
                conexion.Open()
                comando.ExecuteNonQuery()
                comando.ExecuteNonQuery()
            End Using
        End Using
    End Sub


End Class

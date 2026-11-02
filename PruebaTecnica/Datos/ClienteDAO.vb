Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.EnterpriseServices
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


    Public Shared Sub InsertarCliente(ClienteNuevo As Cliente,
                                      idUsuario As Integer,
                                      nombreUsuario As String)
        Dim query As String = "INSERT INTO Clientes (Nombre, Apellido, Correo, Telefono) " &
                      "OUTPUT INSERTED.IdCliente " &
                      "VALUES (@Nombre, @Apellido, @Correo, @Telefono)"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using transaccion As SqlTransaction = conexion.BeginTransaction()
                Try
                    Using comando As New SqlCommand(query, conexion, transaccion)
                        comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = ClienteNuevo.Nombre
                        comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = ClienteNuevo.Apellido
                        comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = ClienteNuevo.Correo
                        comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 35).Value = If(String.IsNullOrWhiteSpace(ClienteNuevo.Telefono), CType(DBNull.Value, Object), ClienteNuevo.Telefono)


                        Dim idNuevoCliente As Integer = Convert.ToInt32(comando.ExecuteScalar())
                        ClienteNuevo.IdCliente = idNuevoCliente

                    End Using

                    BitacoraDAO.RegistrarAccion(
                        idUsuario,
                        nombreUsuario,
                        ClienteNuevo.IdCliente,
                        "INSERTAR",
                        conexion,
                        transaccion
                    )

                    transaccion.Commit()

                Catch
                    transaccion.Rollback()
                    Throw

                End Try
            End Using
        End Using

    End Sub


    Public Shared Sub EliminarCliente(idCliente As Integer,
                                  idUsuario As Integer,
                                  nombreUsuario As String)

        Dim query As String = "DELETE FROM Clientes WHERE IdCliente = @IdCliente"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

            conexion.Open()

            Using transaccion As SqlTransaction = conexion.BeginTransaction()

                Try

                    Dim filasAfectadas As Integer

                    Using comando As New SqlCommand(query, conexion, transaccion)

                        comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente

                        filasAfectadas = comando.ExecuteNonQuery()

                    End Using

                    If filasAfectadas <> 1 Then
                        Throw New InvalidOperationException("No se pudo eliminar el cliente.")
                    End If

                    BitacoraDAO.RegistrarAccion(
                    idUsuario,
                    nombreUsuario,
                    idCliente,
                    "ELIMINAR",
                    conexion,
                    transaccion
                )

                    transaccion.Commit()

                Catch
                    transaccion.Rollback()
                    Throw
                End Try

            End Using

        End Using

    End Sub


    Public Shared Sub ActualizarCliente(ClienteActualizado As Cliente,
                                        idUsuario As Integer,
                                        nombreUsuario As String)
        Dim query As String = "UPDATE Clientes SET Nombre = @Nombre, " &
                          "Apellido = @Apellido, Correo = @Correo, " &
                          "Telefono = @Telefono WHERE IdCliente = @IdCliente"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

            conexion.Open()

            Using transaccion As SqlTransaction = conexion.BeginTransaction()

                Try

                    Dim filasAfectadas As Integer

                    Using comando As New SqlCommand(query, conexion, transaccion)

                        comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = ClienteActualizado.IdCliente
                        comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = ClienteActualizado.Nombre
                        comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = ClienteActualizado.Apellido
                        comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = ClienteActualizado.Correo
                        comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 35).Value = If(String.IsNullOrWhiteSpace(ClienteActualizado.Telefono), CType(DBNull.Value, Object), ClienteActualizado.Telefono)

                        filasAfectadas = comando.ExecuteNonQuery()

                    End Using

                    If filasAfectadas <> 1 Then
                        Throw New InvalidOperationException("No se pudo actualizar el cliente.")
                    End If

                    BitacoraDAO.RegistrarAccion(
                    idUsuario,
                    nombreUsuario,
                    ClienteActualizado.IdCliente,
                    "ACTUALIZAR",
                    conexion,
                    transaccion
                )

                    transaccion.Commit()

                Catch
                    transaccion.Rollback()
                    Throw
                End Try

            End Using

        End Using

    End Sub


End Class

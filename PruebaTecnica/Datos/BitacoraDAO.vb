
Imports System.Data
Imports System.Data.SqlClient

Public Class BitacoraDAO

    Public Shared Sub RegistrarAccion(idUsuario As Integer,
                                     nombreUsuario As String,
                                     idCliente As Integer,
                                     accion As String)

        Dim query As String = "INSERT INTO Bitacora " &
                              "(IdUsuario, nombreUsuario, IdCliente, Accion, FechaAccion) " &
                              "VALUES (@IdUsuario, @nombreUsuario, @IdCliente, @Accion, SYSDATETIME())"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

            Using comando As New SqlCommand(query, conexion)

                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario
                comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = nombreUsuario
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente
                comando.Parameters.Add("@Accion", SqlDbType.VarChar, 30).Value = accion

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using

        End Using

    End Sub


    Public Shared Sub RegistrarAccion(idUsuario As Integer,
                                 nombreUsuario As String,
                                 idCliente As Integer,
                                 accion As String,
                                 conexion As SqlConnection,
                                 transaccion As SqlTransaction)

        Dim query As String = "INSERT INTO Bitacora " &
                          "(IdUsuario, nombreUsuario, IdCliente, Accion, FechaAccion) " &
                          "VALUES (@IdUsuario, @nombreUsuario, @IdCliente, @Accion, SYSDATETIME())"

        Using comando As New SqlCommand(query, conexion, transaccion)

            comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario
            comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = nombreUsuario
            comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente
            comando.Parameters.Add("@Accion", SqlDbType.VarChar, 30).Value = accion

            comando.ExecuteNonQuery()

        End Using

    End Sub


End Class

Imports System.Data.SqlClient

Public Class UsuarioDAO


    Public Shared Function AutenticarUsuario(nombreUsuario As String, password As String) As Usuario

        Dim query As String = "SELECT IdUsuario, nombreUsuario, PasswordHash FROM Usuarios WHERE nombreUsuario = @nombreUsuario"

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()

            Using comando As New SqlCommand(query, conexion)

                comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = nombreUsuario

                conexion.Open()

                Using lector As SqlDataReader = comando.ExecuteReader()

                    If lector.Read() Then

                        Dim hashGuardado As String = lector("PasswordHash").ToString()

                        If PasswordHelper.VerificarPassword(password, hashGuardado) Then

                            Dim usuarioActual As New Usuario()

                            usuarioActual.idUsuario = Convert.ToInt32(lector("IdUsuario"))
                            usuarioActual.NombreUsuario = lector("nombreUsuario").ToString()

                            Return usuarioActual

                        End If

                    End If

                End Using

            End Using

        End Using

        Return Nothing

    End Function


End Class


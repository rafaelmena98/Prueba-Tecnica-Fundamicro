
Imports System.Security.Cryptography

Public Class PasswordHelper

    Private Const Iteraciones As Integer = 100000
    Private Const TamanoSal As Integer = 16
    Private Const TamanoHash As Integer = 32

    Public Shared Function GenerarHash(password As String) As String

        Dim sal(TamanoSal - 1) As Byte

        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            rng.GetBytes(sal)
        End Using

        Using pbkdf2 As New Rfc2898DeriveBytes(password, sal, Iteraciones, HashAlgorithmName.SHA256)

            Dim hash As Byte() = pbkdf2.GetBytes(TamanoHash)

            Return "PBKDF2-SHA256$" &
                   Iteraciones.ToString() & "$" &
                   Convert.ToBase64String(sal) & "$" &
                   Convert.ToBase64String(hash)

        End Using

    End Function


    Public Shared Function VerificarPassword(password As String, hashGuardado As String) As Boolean

        Try
            Dim partes As String() = hashGuardado.Split("$"c)

            If partes.Length <> 4 OrElse partes(0) <> "PBKDF2-SHA256" Then
                Return False
            End If

            Dim iteracionesHash As Integer = Integer.Parse(partes(1))

            If iteracionesHash <> Iteraciones Then
                Return False
            End If

            Dim sal As Byte() = Convert.FromBase64String(partes(2))
            Dim hashOriginal As Byte() = Convert.FromBase64String(partes(3))

            If sal.Length <> TamanoSal OrElse hashOriginal.Length <> TamanoHash Then
                Return False
            End If

            Using pbkdf2 As New Rfc2898DeriveBytes(password, sal, iteracionesHash, HashAlgorithmName.SHA256)

                Dim hashCalculado As Byte() = pbkdf2.GetBytes(hashOriginal.Length)

                Dim diferencia As Integer = 0

                For i As Integer = 0 To hashOriginal.Length - 1
                    diferencia = diferencia Or (CInt(hashOriginal(i)) Xor CInt(hashCalculado(i)))
                Next

                Return diferencia = 0

            End Using

        Catch ex As FormatException
            Return False
        Catch ex As OverflowException
            Return False
        Catch ex As ArgumentException
            Return False
        End Try

    End Function


End Class

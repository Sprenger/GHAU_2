﻿Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class Salas
    Dim dt As DataTable
    Function buscarSala(ByVal parametro As String, ByVal columnaconsulta As String, ByVal columnaretorno As String) As DataTable
        'Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim Consulta As String = "select " & columnaretorno & " from salas where " & columnaconsulta & "='" & parametro & "'"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
            cmd = New SqlCommand(Consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        '  Return dt
    End Function


    Public Function MostrarSalas_Disponibles() As DataTable
        'Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim Consulta As String = "SELECT S.SALA_CODIGO, S.SALA , s.Descripcion_sala, s.Ubicacion from Salas s, Salas_Edificios se, Edificios e where s.sala_codigo = se.sala_codigo and se.edificio_codigo=e.edificio_codigo and e.descipcion like '%VM%' and s.Descripcion_sala <> 'NO DISPONIBLE'"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
            cmd = New SqlCommand(Consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        '  Return dt
    End Function
End Class

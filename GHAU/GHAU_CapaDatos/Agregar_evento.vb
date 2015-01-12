Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class Agregar_evento
    Dim dx
    Dim insertar As String
    Dim dt As DataTable
    Dim dt2 As DataTable

    Sub guardar_evento_errores(ByVal dato As DataTable)
        dt = dato
        Dim stringconeccion = Mod_Coneccion.Parametros
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        cnn.Open()
        For i = 0 To dato.Rows.Count - 1
            insertar = ("INSERT INTO Error_Evento VALUES ('" & dt.Rows(i).Item(0).ToString & "', '" & dt.Rows(i).Item(1).ToString & "')")

            Try
                Dim ds As New DataSet
                insertar = insertar.ToUpper
                Dim da As New SqlDataAdapter(insertar, cnn)
                da.Fill(ds)
            Catch
            End Try
            cnn.Close()
        Next

    End Sub

    Sub guardar_evento(ByVal dato As DataTable)
        dt2 = dato
        Dim stringconeccion = Mod_Coneccion.Parametros
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        cnn.Open()
        For i = 0 To dato.Rows.Count - 1
            insertar = ("INSERT INTO Eventos VALUES ('" & _
                      dt2.Rows(i).Item(0).ToString & "', '" & _
                      dt2.Rows(i).Item(1).ToString & "', '" & _
                      dt2.Rows(i).Item(2).ToString & "', '" & _
                      dt2.Rows(i).Item(3).ToString & "', '" & _
                      dt2.Rows(i).Item(4).ToString & "', '" & _
                      dt2.Rows(i).Item(5).ToString & "', '" & _
                      dt2.Rows(i).Item(6).ToString & "', '" & _
                      dt2.Rows(i).Item(7).ToString & "', '" & _
                      dt2.Rows(i).Item(8).ToString & "', '" & _
                      dt2.Rows(i).Item(9).ToString & "', '" & _
                      dt2.Rows(i).Item(10).ToString & "', '" & _
                      dt2.Rows(i).Item(11).ToString & "')")

            Try
                Dim ds As New DataSet
                insertar = insertar.ToUpper
                Dim da As New SqlDataAdapter(insertar, cnn)
                da.Fill(ds)
            Catch
            End Try
            cnn.Close()
        Next

    End Sub

End Class

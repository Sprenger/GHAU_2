Public Class Eventos
    Dim dx As DateTime
    Dim dx2 As DateTime
    Dim x As New GHAU_CapaDatos.Agregar_evento


    Function ingreso_evento(ByVal dato As DataTable) As DataTable
        Dim dterror As New DataTable
        Dim dtevento As New DataTable
        'encabezado de la datatable error
        dterror.Columns.Add("NRC", Type.GetType("System.String"))
        dterror.Columns.Add("ERROR", Type.GetType("System.String"))
        'encabezado de la datatable evento
        dtevento.Columns.Add(dato.Columns(0).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(1).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(2).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(3).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(4).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(5).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(6).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(7).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(8).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(9).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(10).ColumnName.ToString, Type.GetType("System.String"))
        dtevento.Columns.Add(dato.Columns(11).ColumnName.ToString, Type.GetType("System.String"))

        For i = 0 To dato.Rows.Count - 1
            'filtro campus
            If "VIÑADELMAR" = Replace(dato.Rows(i).Item(4).ToString.ToUpper, " ", "") Then
                'filtro sala
                If dato.Rows(i).Item(11).ToString <> "" Then
                    'filtro fecha in fecha ter
                    If Not DBNull.Value.Equals(dato.Rows(i).Item(5)) Then
                        If Not DBNull.Value.Equals(dato.Rows(i).Item(6)) Then
                            '************ valida fecha no invertida *************
                            Dim f As Date = dato.Rows(i).Item(5)
                            Dim f1 = f.ToString("yyyy/MM/dd")
                            Dim ff = Replace(f1, "/", "")
                            Dim h As Date = dato.Rows(i).Item(6)
                            Dim h1 = h.ToString("yyyy/MM/dd")
                            Dim hh = Replace(h1, "/", "")
                            '****************************************************
                            If CInt(ff) <= CInt(hh) Then

                                'en caso que falle convertir a cdate(D A T O)
                                'filtro para saber si esta dentro de la fecha actual
                                dx = CDate(dato.Rows(i).Item(5))
                                dx2 = CDate(dato.Rows(i).Item(6))
                                If dx >= DateTime.Now.Date Or dx2 >= DateTime.Now.Date Then
                                    'filtro edificio
                                    If dato.Rows(i).Item(10).ToString <> "" Then
                                        'filtro hora de clase
                                        If dato.Rows(i).Item(8).ToString <> "" And dato.Rows(i).Item(9).ToString <> "" Then

                                            Dim a = dato.Rows(i).Item(8).ToString.Trim
                                            Dim b = dato.Rows(i).Item(9).ToString.Trim
                                            'Dia de la semana
                                            If dato.Rows(i).Item(8).ToString <> "" Then
                                                '********** Agregar nuevo registro a la Grilla **********
                                                dtevento.Rows.Add()
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(1) = dato.Rows(i).Item(1).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(2) = dato.Rows(i).Item(2).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(3) = dato.Rows(i).Item(3).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(4) = dato.Rows(i).Item(4).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(5) = dato.Rows(i).Item(5).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(6) = dato.Rows(i).Item(6).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(7) = dato.Rows(i).Item(7).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(8) = dato.Rows(i).Item(8).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(9) = dato.Rows(i).Item(9).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(10) = dato.Rows(i).Item(10).ToString.ToUpper
                                                dtevento.Rows(dtevento.Rows.Count - 1).Item(11) = dato.Rows(i).Item(11).ToString.ToUpper

                                                '*********************************************************
                                            Else
                                                dterror.Rows.Add()
                                                dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                                dterror.Rows(dterror.Rows.Count - 1).Item(1) = "dia no asignado"
                                            End If
                                        Else
                                            dterror.Rows.Add()
                                            dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                            dterror.Rows(dterror.Rows.Count - 1).Item(1) = "hora de clase no asignado"
                                        End If

                                    Else
                                        dterror.Rows.Add()
                                        dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                        dterror.Rows(dterror.Rows.Count - 1).Item(1) = "edificio no asignado"
                                    End If
                                Else
                                    dterror.Rows.Add()
                                    dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                    dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Fecha fuera de rango"
                                End If
                            Else
                                dterror.Rows.Add()
                                dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                dterror.Rows(dterror.Rows.Count - 1).Item(1) = "La fecha de fin es menor a la de inicio"
                            End If
                        Else
                            dterror.Rows.Add()
                            dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                            dterror.Rows(dterror.Rows.Count - 1).Item(1) = "No tiene Fecha de fin"
                        End If

                    Else
                        dterror.Rows.Add()
                        dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                        dterror.Rows(dterror.Rows.Count - 1).Item(1) = "No tiene Fecha de inicio"

                    End If
                Else
                    dterror.Rows.Add()
                    dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                    dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Sala Vacia"

                End If
            End If

        Next

        If dterror.Rows.Count > 0 Then

            Dim resultado = MsgBox("errores ocurridos durante la carga", MsgBoxStyle.YesNo, "GHAU")
            If resultado = MsgBoxResult.Yes Then
                x.guardar_evento_errores(dterror)
                x.guardar_evento(dtevento)
                Return dterror
            Else
                Return Nothing
            End If

        End If
        
    End Function



    ''Function horario(ByVal dia As String, ByVal fecha As String) As DataTable
    'Dim dia_Numero As String = Mid(dia.ToUpper.Trim, 1, 2)
    '    Select Case dia_Numero
    '        Case "LU"
    '            dia = "1"
    '        Case "MA"
    '            dia = "2"
    '        Case "MI"
    '            dia = "3"
    '        Case "JU"
    '            dia = "4"
    '        Case "VI"
    '            dia = "5"
    '        Case "SA"
    '            dia = "6"
    '        Case "DO"
    '            dia = "7"
    '        Case Else
    '            dia = "8"

    '    End Select
    'End Function

End Class

Imports GHAU_CapaNegocio
Public Class evento

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TXT_nombre_actividad.Text <> "" Then


            Dim ingresoevento As New GHAU_CapaNegocio.ImportarHorario
            Dim dias As String = ""
            If CB_Lunes.Checked = True Then
                dias = "1 + "
            End If
            If CB_Martes.Checked = True Then
                dias = dias & "2 + "
            End If
            If CB_Miercoles.Checked = True Then
                dias = dias & "3 + "
            End If
            If CB_Jueves.Checked = True Then
                dias = dias & "4 + "
            End If
            If CB_Viernes.Checked = True Then
                dias = dias & "5 + "
            End If
            If CB_Sabado.Checked = True Then
                dias = dias & "6 + "
            End If
            If CB_Domingo.Checked = True Then
                dias = dias & "7 + "
            End If
            If dias = "" Then

                GoTo 2
            End If
            Dim FechaForm = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.ShortDate)
            Dim FechaInicio = String.Format(DTP_Inicio.Value.ToShortDateString)
            Dim fechaFin = String.Format(DTP_Termino.Value.ToShortDateString)


            ingresoevento.ingreso_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, CB_Docente.Text, TXT_Sala.Text, LBL_Jornada.Text, LBL_Bloque.Text)


            Dim NRC_actual As String = ingresoevento.Count_eventos.ToString

            If FechaForm <= fechaFin And FechaForm >= FechaInicio Then
                'Dim a = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)
                Select Case Mid(FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate), 1, 2).ToUpper
                    Case "LU"
                        If CB_Lunes.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "MA"
                        If CB_Martes.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "MI"
                        If CB_Miercoles.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "JU"
                        If CB_Jueves.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "VI"
                        If CB_Viernes.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "DO"
                        If CB_Domingo.Checked = True Then
                            llenado(NRC_actual)

                        End If
                    Case "SA"
                        If CB_Sabado.Checked = True Then
                            llenado(NRC_actual)
                        End If

                End Select

            End If
            Form3.GRILLA_MOSTRAR.ClearSelection()
            Me.Close()


        Else
2:
        End If

    End Sub
    Public Sub llenado(ByVal NRC_actual As String) 'llena grilla
        Dim temp_arr_horario() As Char = LBL_Bloque.Text.ToCharArray
        Dim a = Form3.xinicio
        Dim b = Form3.Mes.DataBindings.ToString
        '   For I = 0 To temp_arr_horario.Length - 1

        For i = CInt(Form3.xinicio) To CInt(Form3.xfin)
                Form3.GRILLA_MOSTRAR.Rows(i).Cells(CInt(Form3.yinicio)).Value = NRC_actual
            Form3.GRILLA_MOSTRAR.Rows(i).Cells(CInt(Form3.yinicio)).ToolTipText = NRC_actual & vbNewLine & " " & vbNewLine & "EVENTO" & vbNewLine & TXT_nombre_actividad.Text.ToString.ToUpper & vbNewLine & CB_Docente.Text.ToString.ToUpper

        Next

    End Sub


    Private Sub evento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CB_Docente.Items.Clear()
        CB_Docente.DataSource = Form3.datatableDocente
        CB_Docente.DisplayMember = Form3.datatableDocente.Columns(1).ColumnName.ToString
        CB_Docente.SelectedIndex = 0
        DTP_Inicio.Value = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.ShortDate)
        Me.CB_Docente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        'Recorrer y cargar los items para el Autocompletado



    End Sub

    Private Sub DTP_Inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Inicio.ValueChanged
        If String.Format(DTP_Termino.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Termino.Value = DTP_Inicio.Value
        End If
    End Sub

    Private Sub DTP_Termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Termino.ValueChanged
        If String.Format(DTP_Termino.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Inicio.Value = DTP_Termino.Value
        End If
    End Sub
End Class
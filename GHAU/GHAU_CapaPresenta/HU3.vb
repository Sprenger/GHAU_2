Public Class HU3
    Public nrc_ultimo As String
    Private Sub HU3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CB_Docente.DataSource = Form3.datatableDocente
        CB_Docente.DisplayMember = Form3.datatableDocente.Columns(1).ColumnName.ToString
        Dim dt As New GHAU_CapaNegocio.Negocio
        Dim datos = dt.consultarHorario(Form3.GRILLA_MOSTRAR.Rows(Form3.xinicio).Cells(Form3.yfin).Value)
        Dim p = Form3.dtevento.Rows(0).Item(8).ToString
        CB_Docente.Text = Form3.dtevento.Rows(0).Item(8).ToString
        TXT_nombre_actividad.Text = Form3.dtevento.Rows(0).Item(7).ToString
        CB_Sala.DataSource = Form3.datatablesalas
        CB_Sala.DisplayMember = Form3.datatablesalas.Columns(1).ColumnName.ToString
        CB_Sala.Text = Form3.dtevento.Rows(0).Item(4).ToString
        DTP_Inicio.Value = CDate(Form3.dtevento.Rows(0).Item(5).ToString)
        DTP_Termino.Value = CDate(Form3.dtevento.Rows(0).Item(6).ToString)

        Dim dia As Integer = CInt(Form3.dtevento.Rows(0).Item(1).ToString)
        Select Case dia
            Case 1
                CB_Lunes.CheckState = CheckState.Checked
            Case 2
                CB_Martes.CheckState = CheckState.Checked
            Case 3
                CB_Miercoles.CheckState = CheckState.Checked
            Case 4
                CB_Jueves.CheckState = CheckState.Checked
            Case 5
                CB_Viernes.CheckState = CheckState.Checked
            Case 6
                CB_Sabado.CheckState = CheckState.Checked
            Case 7
                CB_Domingo.CheckState = CheckState.Checked
        End Select
    End Sub

    Private Sub CB_Lunes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Lunes.CheckedChanged
        If CB_Lunes.Checked Then
            CB_Martes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Jueves.CheckState = False
            CB_Viernes.CheckState = False
            CB_Sabado.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Martes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Martes.CheckedChanged
        If CB_Martes.Checked Then
            CB_Lunes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Jueves.CheckState = False
            CB_Viernes.CheckState = False
            CB_Sabado.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Miercoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Miercoles.CheckedChanged
        If CB_Miercoles.Checked Then
            CB_Lunes.CheckState = False
            CB_Martes.CheckState = False
            CB_Jueves.CheckState = False
            CB_Viernes.CheckState = False
            CB_Sabado.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Jueves_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Jueves.CheckedChanged
        If CB_Jueves.Checked Then
            CB_Lunes.CheckState = False
            CB_Martes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Viernes.CheckState = False
            CB_Sabado.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Viernes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Viernes.CheckedChanged
        If CB_Viernes.Checked Then
            CB_Lunes.CheckState = False
            CB_Martes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Jueves.CheckState = False
            CB_Sabado.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Sabado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Sabado.CheckedChanged
        If CB_Sabado.Checked Then
            CB_Lunes.CheckState = False
            CB_Martes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Jueves.CheckState = False
            CB_Viernes.CheckState = False
            CB_Domingo.CheckState = False
        End If
    End Sub

    Private Sub CB_Domingo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Domingo.CheckedChanged
        If CB_Domingo.Checked Then
            CB_Lunes.CheckState = False
            CB_Martes.CheckState = False
            CB_Miercoles.CheckState = False
            CB_Jueves.CheckState = False
            CB_Viernes.CheckState = False
            CB_Sabado.CheckState = False
        End If
    End Sub
    Dim dias As String = ""
    Private Sub BTN_MODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MODIFICAR.Click


        Dim ingresoevento As New GHAU_CapaNegocio.Negocio

        If CB_Lunes.Checked = True Then
            dias = "1"
        End If
        If CB_Martes.Checked = True Then
            dias = "2"
        End If
        If CB_Miercoles.Checked = True Then
            dias = "3"
        End If
        If CB_Jueves.Checked = True Then
            dias = "4"
        End If
        If CB_Viernes.Checked = True Then
            dias = "5"
        End If
        If CB_Sabado.Checked = True Then
            dias = "6"
        End If
        If CB_Domingo.Checked = True Then
            dias = "7"

        End If
        llenado()
        Dim FechaForm = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.ShortDate)
        Dim FechaInicio = String.Format(DTP_Inicio.Value.ToShortDateString)
        Dim fechaFin = String.Format(DTP_Termino.Value.ToShortDateString)

        ingresoevento.ModificarEvento(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text.ToUpper, Form3.dtevento.Rows(0).Item(3).ToString, CB_Sala.Text)
        'CStr(Me.DTP_Inicio.Value)
        Form3.GRILLA_MOSTRAR.ClearSelection()
        Me.Close()







    End Sub

    Public Sub llenado() 'llena grilla
        Dim temp_arr_horario() As Char = Form3.dtevento.Rows(0).Item(0).ToString.ToCharArray
        Dim diaAnterior = Form3.dtevento.Rows(0).Item(1).ToString
        If diaAnterior = dias Then
            For I = 0 To temp_arr_horario.Length - 1
                If temp_arr_horario(I) = "1" Then
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = Form3.dtevento.Rows(0).Item(3)
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = Form3.dtevento.Rows(0).Item(3) & vbNewLine & " " & vbNewLine & "EVENTO" & vbNewLine & TXT_nombre_actividad.Text.ToString.ToUpper & vbNewLine & CB_Docente.Text & vbNewLine & " "
                End If
            Next
        Else
            For I = 0 To temp_arr_horario.Length - 1
                If temp_arr_horario(I) = "1" Then
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = " "
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = " "
                End If
            Next

        End If
    End Sub

    Private Sub BTN_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Eliminar.Click

        Dim eliminar As New GHAU_CapaNegocio.Negocio
        eliminar.Eliminarevento(Form3.GRILLA_MOSTRAR.Rows(Form3.xinicio).Cells(Form3.yfin).Value)
        'CStr(Me.DTP_Inicio.Value)
        Dim temp_arr_horario() As Char = Form3.dtevento.Rows(0).Item(0).ToString.ToCharArray

        For I = 0 To temp_arr_horario.Length - 1
            If temp_arr_horario(I) = "1" Then
                Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = " "
                Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = " "
            End If
        Next
        Form3.GRILLA_MOSTRAR.ClearSelection()
        Me.Close()

    End Sub
End Class
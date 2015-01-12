Public Class liberar_hu23

    Dim dt As New DataTable

    Private Sub cargar_datos()

        dgv.Rows.Add()
        dgv.Rows(0).Cells(1).Value = "lala"
        dgv.RowHeadersVisible = False

    End Sub


    Private Sub Liberador_hu23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_datos()
    End Sub
End Class
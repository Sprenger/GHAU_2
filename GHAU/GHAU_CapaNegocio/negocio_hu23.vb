Public Class negocio_hu23
    Public _NombreServidor_, _NombreUsuario_, _Pass_
    Function Consultaliberar(ByVal dia_evento, ByVal docente_evento, ByVal nrc_evento, ByVal nombre_evento) As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Dim dtHorario As DataTable = Horario.Liberar(dia_evento, docente_evento, nrc_evento, nombre_evento)
        Return dtHorario
    End Function
End Class

Public Class FSifre
    Inherits System.Web.UI.Page

    Private Sub BKaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        If Sifre.Text = "" Then
            Mesaj.Text = "Şifre bilgisi muhakkak girilmeli!"
            Mesaj.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        If Sifre.Text <> YSifre.Text Then
            Mesaj.Text = "Şifre ve şifre tekrarı aynı olmalı!"
            Mesaj.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        Dim RSQL As New SqlForConnection
        If RSQL.RunSQL("UPDATE BoschUsers SET Sifre=@Sifre WHERE Userid=@Userid", {New SqlParameter("@Sifre", Sifre.Text), New SqlParameter("@Userid", Session("PersNr"))}) Then
            Mesaj.Text = "Şifre değiştirildi!"
            Mesaj.ForeColor = Drawing.Color.Red
        Else
            Mesaj.Text = "Şifre değiştirilemedi!"
            Mesaj.ForeColor = Drawing.Color.Green
        End If
    End Sub

End Class
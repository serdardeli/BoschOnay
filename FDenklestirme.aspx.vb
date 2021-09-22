Imports Telerik.Web.UI

Public Class FDenklestirme
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
        End If
        Dim RSql As New SqlForConnection
        RadGrid1.DataSource = RSql.GetValue("SELECT isnull(Kodu,'') AS Kodu, isnull(Kodu2,'') AS Kodu2, isnull(Aciklama,'') AS Aciklama, isnull(Tarih, getdate()) AS Tarih, isnull(OnayBasTar, getdate()) AS OnayBasTar, isnull(OnayBitTar, getdate()) AS OnayBitTar, IdNr FROM BoschLimit ORDER BY Kodu, Tarih DESC")
    End Sub

    Protected Sub Ekle_Click(sender As Object, e As ImageClickEventArgs) Handles BEkle.Click
        Temizle()
        Kayit.Text = "Yeni Kayıt"

        'BEkle.Enabled = False
        BDegistir.Enabled = False
        BTumu.Enabled = False
        BSil.Enabled = False

        Kodu.Enabled = True
        Kodu2.Enabled = True
        Aciklama.Enabled = True

        Tarih.Enabled = True
        Tarih.SelectedDate = Now.Date
        Tarih2.Enabled = True
        Tarih2.SelectedDate = Now.Date
        Tarih3.Enabled = True
        Tarih3.SelectedDate = DateAdd(DateInterval.Month, 1, Now.Date)
        BKaydet.Visible = True
        BVazgec.Visible = True
    End Sub

    Protected Sub Tumu_Click(sender As Object, e As ImageClickEventArgs) Handles BTumu.Click
        Kayit.Text = "Tümüne uygula"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BTumu.Enabled = False
        BSil.Enabled = False

        Kodu.Enabled = False
        Kodu2.Enabled = False
        Aciklama.Enabled = False
        Kodu.Text = "TÜMÜ"
        Kodu2.Text = "TÜMÜ"
        Aciklama.Text = "TÜMÜNE UYGULANACAK!"
        Tarih.Enabled = True
        Tarih2.Enabled = True
        Tarih3.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True

    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BTumu.Enabled = False
        BSil.Enabled = False

        Kodu.Enabled = False
        Kodu2.Enabled = False
        Aciklama.Enabled = False
        Tarih.Enabled = True
        Tarih2.Enabled = True
        Tarih3.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True

    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschLimit WHERE IdNr=@IdNr", {New SqlParameter("@IdNr", Secilen("IdNr").Text.ToString)}) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Kayıt silindi!"

            Dim logParam(4) As SqlParameter
            logParam(0) = New SqlParameter("@ModulNo", "M31")
            logParam(1) = New SqlParameter("@Uygulama", "1")
            logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
            logParam(3) = New SqlParameter("@Tipi", 2) ' 0:Ekleme , 1:Değiştirme , 2:Silme
            logParam(4) = New SqlParameter("@Yapilan", Secilen("IdNr").Text.ToString() & " nolu kayıt silindi.")
            RSQL.AddLog(logParam)

            Refresh_Data(3)
        Else
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim mParam(7) As SqlParameter
        mParam(0) = New SqlParameter("@Kodu", Kodu.Text)
        mParam(1) = New SqlParameter("@Kodu2", Kodu2.Text)
        mParam(2) = New SqlParameter("@Aciklama", Aciklama.Text)
        mParam(3) = New SqlParameter("@Tarih", Tarih.SelectedDate)
        mParam(4) = New SqlParameter("@Tarih2", Tarih2.SelectedDate)
        mParam(5) = New SqlParameter("@Tarih3", Tarih3.SelectedDate)
        mParam(6) = New SqlParameter("@Userid", Session("PersNr"))
        Dim RSQL As New SqlForConnection

        'Kullanıcı Log İşlemleri
        Dim _yapilan = ""
        _yapilan += IIf(_yapilan = "", "Kodu:" & Kodu.Text, " | Kodu:" & Kodu.Text)
        _yapilan += IIf(_yapilan = "", "Kodu2:" & Kodu2.Text, " | Kodu2:" & Kodu2.Text)
        _yapilan += IIf(_yapilan = "", "Tarih:" & Tarih.SelectedDate, " | Tarih:" & Tarih.SelectedDate)
        _yapilan += IIf(_yapilan = "", "Tarih2:" & Tarih2.SelectedDate, " | Tarih2:" & Tarih2.SelectedDate)
        _yapilan += IIf(_yapilan = "", "Tarih3:" & Tarih3.SelectedDate, " | Tarih3:" & Tarih3.SelectedDate)
        _yapilan += IIf(_yapilan = "", "Açıklama:" & Aciklama.Text, " | Açıklama:" & Aciklama.Text)

        Select Case Kayit.Text
            'Case "Yeni Kayıt"
            '    If RSQL.RunSQL("INSERT INTO BoschLimit (Kodu, Kodu2, Aciklama, Tarih, OnayBasTar, OnayBitTar, Userid, UDate) VALUES(@Kodu, @Kodu2, @Aciklama, @Tarih, @Tarih2, @Tarih3, @Userid, GETDATE())", mParam) Then
            '        Mesaj.ForeColor = Drawing.Color.Green
            '        Mesaj.Text = "Bilgiler kaydedildi!"
            '    Else
            '        Mesaj.Text = "Bilgiler kaydedilemedi!"
            '        Mesaj.ForeColor = Drawing.Color.Red
            '    End If
            Case "Tümüne uygula"
                Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
                Dim NdxText = Secilen("IdNr").Text
                mParam(7) = New SqlParameter("@IdNr", NdxText)

                If RSQL.RunSQL("UPDATE BoschLimit SET Tarih=@Tarih, OnayBasTar=@Tarih2, OnayBitTar=@Tarih3, Userid=@Userid, UDate=GETDATE()  ", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M31")
                    logParam(1) = New SqlParameter("@Uygulama", "1")
                    logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
                    logParam(3) = New SqlParameter("@Tipi", 1) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                    logParam(4) = New SqlParameter("@Yapilan", _yapilan)
                    RSQL.AddLog(logParam)
                Else
                    Mesaj.Text = "Bilgiler kaydedilemedi!"
                    Mesaj.ForeColor = Drawing.Color.Red
                End If
            Case "Değiştirmek için"
                Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
                Dim NdxText = Secilen("IdNr").Text
                mParam(7) = New SqlParameter("@IdNr", NdxText)

                If RSQL.RunSQL("UPDATE BoschLimit SET Tarih=@Tarih, OnayBasTar=@Tarih2, OnayBitTar=@Tarih3, Userid=@Userid, UDate=GETDATE() WHERE IdNr = @IdNr", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M31")
                    logParam(1) = New SqlParameter("@Uygulama", "1")
                    logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
                    logParam(3) = New SqlParameter("@Tipi", 1) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                    logParam(4) = New SqlParameter("@Yapilan", _yapilan)
                    RSQL.AddLog(logParam)
                Else
                    Mesaj.Text = "Bilgiler kaydedilemedi!"
                    Mesaj.ForeColor = Drawing.Color.Red
                End If
        End Select

        If Kayit.Text = "Yeni Kayıt" Then
            'Refresh_Data(1)
        Else
            Refresh_Data(0)
        End If
        Kayit.Text = ""

    End Sub

    Protected Sub Refresh_Data(ByVal Durum As Integer)
        Dim RSQL As New SqlForConnection
        Dim SiraNo As Integer = 0
        Dim NdxText As String = ""
        Select Case Durum
            Case 0
                'Seç
                If RadGrid1.SelectedIndexes.Count > 0 Then
                    SiraNo = RadGrid1.SelectedIndexes(0)
                End If
            Case 1
                'Ekle
                SiraNo = -1
                NdxText = Kodu.Text
            Case 2
                'Değiştir
                If RadGrid1.SelectedIndexes.Count > 0 Then
                    SiraNo = RadGrid1.SelectedIndexes(0)
                End If
            Case 3
                'Sil
                If RadGrid1.SelectedIndexes.Count > 0 Then
                    SiraNo = RadGrid1.SelectedIndexes(0)
                End If
                If SiraNo < 0 Then SiraNo = 0
        End Select

        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Kodu,'') AS Kodu, isnull(Kodu2,'') AS Kodu2, isnull(Aciklama,'') AS Aciklama, isnull(Tarih, getdate()) AS Tarih, isnull(OnayBasTar, getdate()) AS OnayBasTar, isnull(OnayBitTar, getdate()) AS OnayBitTar, IdNr FROM BoschLimit ORDER BY Kodu, Tarih DESC")
        RadGrid1.Rebind()


        'Temizle()
        'If RadGrid1.MasterTableView.Items.Count = 0 Then
        '    Exit Sub
        'End If

        'If SiraNo >= 0 Then
        '    If SiraNo >= RadGrid1.MasterTableView.Items.Count Then
        '        SiraNo = RadGrid1.MasterTableView.Items.Count - 1
        '    End If
        '    RadGrid1.MasterTableView.Items(SiraNo).Selected = True
        '    Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        '    NdxText = Secilen("IdNr").Text
        'Else
        '    For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
        '        If Satir("Kodu").Text = NdxText Then
        '            Satir.Selected = True
        '            Exit For
        '        End If
        '    Next
        'End If


        If RadGrid1.MasterTableView.Items.Count > 0 Then
            RadGrid1.MasterTableView.ClearSelectedItems()
            If SiraNo >= 0 Then
                If SiraNo >= RadGrid1.MasterTableView.Items.Count Then
                    SiraNo = RadGrid1.MasterTableView.Items.Count - 1
                End If
                RadGrid1.MasterTableView.Items(SiraNo).Selected = True
            Else
                For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
                    If Satir("IdNr").Text = NdxText Then
                        Satir.Selected = True
                        Exit For
                    End If
                Next
            End If
        End If

        Temizle()
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        NdxText = Secilen("IdNr").Text

        Dim mTable As DataTable = RSQL.GetValue("SELECT isnull(Kodu,'') AS Kodu, isnull(Kodu2,'') AS Kodu2, isnull(Aciklama,'') AS Aciklama, isnull(Tarih, getdate()) AS Tarih, isnull(OnayBasTar, getdate()) AS OnayBasTar, isnull(OnayBitTar, getdate()) AS OnayBitTar, IdNr FROM BoschLimit WHERE IdNr=@IdNr", {New SqlParameter("@IdNr", NdxText)})
        If mTable.Rows.Count > 0 Then
            Kodu.Text = mTable.Rows(0)!Kodu.ToString
            Kodu2.Text = mTable.Rows(0)!Kodu2.ToString
            Aciklama.Text = mTable.Rows(0)!Aciklama.ToString
            Tarih.SelectedDate = mTable.Rows(0)!Tarih
            Tarih2.SelectedDate = mTable.Rows(0)!OnayBasTar
            Tarih3.SelectedDate = mTable.Rows(0)!OnayBitTar
        Else
            Mesaj.Text = "Seçilen kayıt bulunamadı!"
        End If
    End Sub

    Protected Sub Vazgec_Click(sender As Object, e As ImageClickEventArgs) Handles BVazgec.Click
        Mesaj.ForeColor = Drawing.Color.Red
        Mesaj.Text = "Kaydetmekten vazgeçildi!"
        Kayit.Text = ""
        Refresh_Data(0)
    End Sub

    Protected Sub Temizle()
        Kodu.Text = ""
        Kodu2.Text = ""
        Aciklama.Text = ""
        Tarih.SelectedDate = Nothing
        Tarih2.SelectedDate = Nothing
        Tarih3.SelectedDate = Nothing

        Kayit.Text = ""
        Mesaj.Text = ""

        Kodu.Enabled = False
        Kodu2.Enabled = False
        Aciklama.Enabled = False
        Tarih.Enabled = False
        Tarih2.Enabled = False
        Tarih3.Enabled = False

        'BEkle.Enabled = True
        BDegistir.Enabled = True
        BTumu.Enabled = True
        BSil.Enabled = True

        BKaydet.Visible = False
        BVazgec.Visible = False

    End Sub

    Private Sub RadGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGrid1.SelectedIndexChanged
        Refresh_Data(0)
    End Sub

    Private Sub RadGrid1_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        Temizle()
    End Sub

End Class
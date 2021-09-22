Imports Telerik.Web.UI

Public Class FTatil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
        End If
        Dim RSql As New SqlForConnection
        RadGrid1.DataSource = RSql.GetValue("SELECT IdNr, isnull(Fei_Jahr,'') AS Yil, isnull(Fei_Monat,0) AS Ay, isnull(Fei_Tag,0) AS Gun, isnull(Fei_FeiName,'') Aciklama FROM BoschTatil ORDER BY Fei_Jahr, Fei_Monat, Fei_Tag")
    End Sub

    Protected Sub Ekle_Click(sender As Object, e As ImageClickEventArgs) Handles BEkle.Click
        Temizle()
        Kayit.Text = "Eklemek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        Yil.Enabled = True
        Ay.Enabled = True
        Gun.Enabled = True
        Aciklama.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True

    End Sub

    Private Sub RadGrid1_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        Temizle()
    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        Yil.Enabled = True
        Ay.Enabled = True
        Gun.Enabled = True
        Aciklama.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True

    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschTatil WHERE IdNr=@IdNr", {New SqlParameter("@IdNr", Secilen("IdNr").Text.ToString)}) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Kayıt silindi!"
            Refresh_Data(3)
        Else
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim _yapilan = ""
        If Kayit.Text = "Eklemek için" Then
            For Each Satir As GridDataItem In RadGrid1.Items
                If Satir.Cells(0).Text = Gun.Text And Satir.Cells(1).Text = Ay.Text And Satir.Cells(2).Text = Yil.Text Then
                    Mesaj.ForeColor = Drawing.Color.Red
                    Mesaj.Text = "Bu tatil daha önce kaydedilmiş!"
                    Exit Sub
                End If
            Next
        End If

        Dim mParam(5) As SqlParameter
        mParam(0) = New SqlParameter("@Fei_Jahr", Yil.Text)
        mParam(1) = New SqlParameter("@Fei_Monat", Ay.Text)
        mParam(2) = New SqlParameter("@Fei_Tag", Gun.Text)
        mParam(3) = New SqlParameter("@Fei_FeiName", Aciklama.Text)
        mParam(4) = New SqlParameter("@IdNr", HiddenField1.Value)
        mParam(5) = New SqlParameter("@Userid", Session("PersNr"))

        _yapilan += IIf(_yapilan = "", "Yıl:" & Yil.Text, " | Yıl:" & Yil.Text)

        _yapilan += IIf(_yapilan = "", "Ay:" & Ay.Text, " | Ay:" & Ay.Text)

        _yapilan += IIf(_yapilan = "", "Gün:" & Gun.Text, " | Gün:" & Gun.Text)

        _yapilan += IIf(_yapilan = "", "Açıklama:" & Aciklama.Text, " | Açıklama:" & Aciklama.Text)

        Dim RSQL As New SqlForConnection
        Select Case Kayit.Text
            Case "Eklemek için"
                If RSQL.RunSQL("INSERT INTO BoschTatil (Fei_Jahr, Fei_Monat, Fei_Tag, Fei_FeiName, Userid, UDate) VALUES(@Fei_Jahr, @Fei_Monat, @Fei_Tag, @Fei_FeiName, @Userid, GETDATE())", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    'Kullanıcı Log İşlemleri
                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M25")
                    logParam(1) = New SqlParameter("@Uygulama", "1")
                    logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
                    logParam(3) = New SqlParameter("@Tipi", 0) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                    logParam(4) = New SqlParameter("@Yapilan", _yapilan)
                    RSQL.AddLog(logParam)
                Else
                    Mesaj.Text = "Bilgiler kaydedilemedi!"
                    Mesaj.ForeColor = Drawing.Color.Red
                End If
            Case "Değiştirmek için"
                If RSQL.RunSQL("UPDATE BoschTatil SET Fei_Jahr=@Fei_Jahr, Fei_Monat=@Fei_Monat, Fei_Tag=@Fei_Tag, Fei_FeiName=@Fei_FeiName, Userid=@Userid, UDate=GETDATE() WHERE IdNr=@IdNr", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    'Kullanıcı Log İşlemleri
                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M25")
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

        If Kayit.Text = "Eklemek için" Then
            Refresh_Data(1)
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
                NdxText = HiddenField1.Value
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

        RadGrid1.DataSource = RSQL.GetValue("SELECT IdNr, isnull(Fei_Jahr,'') AS Yil, isnull(Fei_Monat,0) AS Ay, isnull(Fei_Tag,0) AS Gun, isnull(Fei_FeiName,'') Aciklama FROM BoschTatil ORDER BY Fei_Jahr, Fei_Monat, Fei_Tag")
        RadGrid1.Rebind()
        Temizle()
        If RadGrid1.MasterTableView.Items.Count = 0 Then
            Exit Sub
        End If
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
            If RadGrid1.SelectedItems.Count = 0 Then
                SiraNo = RadGrid1.MasterTableView.Items.Count - 1
                RadGrid1.MasterTableView.Items(SiraNo).Selected = True
            End If
        End If
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        NdxText = Secilen("IdNr").Text
        Dim mTable As DataTable = RSQL.GetValue("SELECT IdNr, isnull(Fei_Jahr,'') AS Yil, isnull(Fei_Monat,0) AS Ay, isnull(Fei_Tag,0) AS Gun, isnull(Fei_FeiName,'') Aciklama FROM BoschTatil WHERE IdNr=@IdNr", {New SqlParameter("@IdNr", NdxText)})
        If mTable.Rows.Count > 0 Then
            Yil.Text = mTable.Rows(0)!Yil.ToString
            Ay.Text = mTable.Rows(0)!Ay.ToString
            Gun.Text = mTable.Rows(0)!Gun.ToString
            Aciklama.Text = mTable.Rows(0)!Aciklama.ToString
            HiddenField1.Value = mTable.Rows(0)!IdNr.ToString
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
        Yil.Text = "0"
        Ay.Text = "0"
        Gun.Text = "0"
        Aciklama.Text = ""

        Kayit.Text = ""
        Mesaj.Text = ""

        Yil.Enabled = False
        Ay.Enabled = False
        Gun.Enabled = False
        Aciklama.Enabled = False

        BEkle.Enabled = True
        BDegistir.Enabled = True
        BSil.Enabled = True

        BKaydet.Visible = False
        BVazgec.Visible = False

    End Sub

    Private Sub RadGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGrid1.SelectedIndexChanged
        Refresh_Data(0)
    End Sub

End Class
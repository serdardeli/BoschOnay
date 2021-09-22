Imports Telerik.Web.UI

Public Class FYetkiOnay
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RSQL As New SqlForConnection
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
            Temizle()
        End If
    End Sub

    Protected Sub Ekle_Click(sender As Object, e As ImageClickEventArgs) Handles BEkle.Click
        Temizle()
        Kayit.Text = "Eklemek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False
        RadGrid2.Enabled = True
        BKaydet.Visible = True
        BVazgec.Visible = True
    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False
        RadGrid2.Enabled = True
        BKaydet.Visible = True
        BVazgec.Visible = True
    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschYetkiOnay WHERE YetkiNo=@YetkiNo", {New SqlParameter("@YetkiNo", Secilen("YetkiNo").Text.ToString)}) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Kayıt silindi!"
            Refresh_Data(3)
        Else
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        If Kayit.Text = "Eklemek için" Then
            For Each Satir As GridDataItem In RadGrid1.Items
                If UCase(Satir.Cells(2).Text) = UCase(YtkNo.Text) Then
                    Mesaj.ForeColor = Drawing.Color.Red
                    Mesaj.Text = "Aynı yetki kodu ile başka bir yetkide kayıtlı."
                    Exit Sub
                End If
            Next
        End If
        If YtkNo.Text = "" Then
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Yetki kodunu giriniz!"
            Exit Sub
        End If

        '                                  1         2         3         4         5         6         7         8         9        10      
        '                         1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        Dim YetkiStr As String = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            Mid(YetkiStr, Mid(Satir("Kodu").Text, 2, 2), 1) = IIf(TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked, "1", "0")
        Next

        Dim mParam(2) As SqlParameter
        mParam(0) = New SqlParameter("@YetkiNo", YtkNo.Text)
        mParam(1) = New SqlParameter("@Yetkisi", YetkiStr)
        mParam(2) = New SqlParameter("@Userid", Session("PersNr"))
        Dim RSQL As New SqlForConnection
        If RSQL.RunSQL("UPDATE BoschYetki SET Yetkisi=@Yetkisi, Userid=@Userid, UDate=GETDATE() WHERE YetkiNo=@YetkiNo ", mParam) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Bilgiler kaydedildi!"
            If RSQL.RunSQL("DELETE BoschYetkiOnay WHERE YetkiNo=@YetkiNo", {New SqlParameter("@YetkiNo", YtkNo.Text.ToString)}) Then
            End If
        Else
            Mesaj.Text = "Bilgiler kaydedilemedi!"
            Mesaj.ForeColor = Drawing.Color.Red
        End If

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
                NdxText = YtkNo.Text
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

        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(YetkiNo,'') AS YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi FROM BoschYetkiOnay ORDER BY YetkiNo")
        RadGrid1.Rebind()

        If RadGrid1.MasterTableView.Items.Count > 0 Then
            If SiraNo >= 0 Then
                If SiraNo >= RadGrid1.MasterTableView.Items.Count Then
                    SiraNo = RadGrid1.MasterTableView.Items.Count - 1
                End If
                RadGrid1.MasterTableView.Items(SiraNo).Selected = True
            Else
                For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
                    If Satir("YetkiNo").Text = NdxText Then
                        Satir.Selected = True
                        Exit For
                    End If
                Next
            End If
        End If

        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        NdxText = Secilen("YetkiNo").Text
        Temizle()
        Dim mTable As DataTable = RSQL.GetValue("SELECT YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi, isnull(Yetkisi,'') AS Yetkisi FROM BoschYetkiOnay WHERE YetkiNo=@YetkiNo", {New SqlParameter("@YetkiNo", NdxText)})
        If mTable.Rows.Count > 0 Then
            YtkNo.Text = mTable.Rows(0)!YetkiNo.ToString
            Aciklama.Text = mTable.Rows(0)!YetkiAdi.ToString
            HiddenField1.Value = mTable.Rows(0)!Yetkisi

            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                If Mid(mTable.Rows(0)!Yetkisi, Mid(Satir("Kodu").Text, 2, 2), 1) = "1" Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                    TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True
                    TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = "Onay bekliyor"
                Else
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
                    TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = False
                End If
            Next
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
        YtkNo.Text = ""
        Aciklama.Text = ""
        Kayit.Text = ""
        Mesaj.Text = ""
        HiddenField1.Value = ""
        YtkNo.Enabled = False
        Aciklama.ReadOnly = True
        RadGrid2.Enabled = False

        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
            TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = False
            TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = ""
        Next

        BEkle.Enabled = True
        BDegistir.Enabled = True
        BSil.Enabled = True

        BKaydet.Visible = False
        BVazgec.Visible = False

    End Sub

    Private Sub RadGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGrid1.SelectedIndexChanged
        Refresh_Data(0)
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid2.DataSource = RSQL.GetValue("SELECT isnull(Kodu, 'M00') AS Kodu, isnull(Baslik,'') AS Baslik, CAST('false' as bit) AS Yetki FROM BoschMenu WHERE Durumu>0 AND Uygulama=2 AND UstMenu>0 ORDER BY Ndx")
    End Sub

    Private Sub RadGrid2_DataBound(sender As Object, e As EventArgs) Handles RadGrid2.DataBound
        If HiddenField1.Value <> "" Then
            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                Dim _chv1 = TryCast(Satir.FindControl("CheckBox1"), CheckBox)
                Dim _chv2 = TryCast(Satir.FindControl("CheckBox2"), CheckBox)

                If Mid(HiddenField1.Value, Mid(Satir("Kodu").Text, 2, 2), 1) = "1" Then
                    _chv1.Checked = True
                    _chv2.Enabled = True
                    _chv2.Text = "Onay bekliyor."
                Else
                    _chv1.Checked = False
                    _chv2.Enabled = False
                    _chv2.Text = ""
                End If
            Next
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(YetkiNo,'') AS YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi FROM BoschYetkiOnay ORDER BY YetkiNo")
    End Sub

End Class
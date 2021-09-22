Imports Telerik.Web.UI

Public Class FYetki
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RSQL As New SqlForConnection

        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
            Temizle()
            If Session("YetkiNo").ToString() = "5" Then
                YtkNo.Enabled = False
                Aciklama.Enabled = False
                Tipi.Enabled = False
                EmpSubGrp.Enabled = False
                CorpFunc.Enabled = False
                CounSpField.Enabled = False
                REmpSubGrp.Enabled = False
            End If
        End If
    End Sub
    Protected Sub Ekle_Click(sender As Object, e As ImageClickEventArgs) Handles BEkle.Click
        Temizle()
        Kayit.Text = "Eklemek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        YtkNo.Enabled = True
        Aciklama.ReadOnly = False
        Tipi.Enabled = True

        EmpSubGrp.ReadOnly = False
        CorpFunc.ReadOnly = False
        CounSpField.ReadOnly = False
        REmpSubGrp.ReadOnly = False

        RadGrid2.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True


        If Session("YetkiNo").ToString() = "5" Then
            YtkNo.Enabled = False
            Aciklama.Enabled = False
            Tipi.Enabled = False
            EmpSubGrp.Enabled = False
            CorpFunc.Enabled = False
            CounSpField.Enabled = False
            REmpSubGrp.Enabled = False
        End If
    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        YtkNo.Enabled = False
        Aciklama.ReadOnly = False
        Tipi.Enabled = True

        EmpSubGrp.ReadOnly = False
        CorpFunc.ReadOnly = False
        CounSpField.ReadOnly = False
        REmpSubGrp.ReadOnly = False

        RadGrid2.Enabled = True

        BKaydet.Visible = True
        BVazgec.Visible = True

        If Session("YetkiNo").ToString() = "5" Then
            YtkNo.Enabled = False
            Aciklama.Enabled = False
            Tipi.Enabled = False
            EmpSubGrp.Enabled = False
            CorpFunc.Enabled = False
            CounSpField.Enabled = False
            REmpSubGrp.Enabled = False
        End If
    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschYetki WHERE YetkiNo=@YetkiNo", {New SqlParameter("@YetkiNo", Secilen("YetkiNo").Text.ToString)}) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Kayıt silindi!"
            Refresh_Data(3)
        Else
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub
    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim _tipi = 1
        Dim _yapilan = "", _yapilanaciklama = ""
        If Kayit.Text = "Eklemek için" Then
            _tipi = 0

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
            Mid(YetkiStr, Mid(Satir("Kodu").Text, 2, 2), 1) = IIf(TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked, "1", "0")

            If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked Then
                _yapilan += IIf(_yapilan = "", "Yetki Kodları:" & Satir("Kodu").Text, "," & Satir("Kodu").Text)
                _yapilanaciklama += IIf(_yapilanaciklama = "", Satir("Kodu").Text, "," & Satir("Kodu").Text)
            End If
        Next

        Select Case Session("YetkiNo")
            Case "5"
                Dim mParam(3) As SqlParameter
                mParam(0) = New SqlParameter("@YetkiNo", YtkNo.Text)
                mParam(1) = New SqlParameter("@YetkiAdi", Aciklama.Text)
                mParam(2) = New SqlParameter("@Yetkisi", YetkiStr)
                mParam(3) = New SqlParameter("@Userid", Session("PersNr"))
                Dim RSQL As New SqlForConnection
                If RSQL.RunSQL("UPDATE BoschYetkiOnay SET YetkiAdi=@YetkiAdi,Yetkisi=@Yetkisi, Userid=@Userid, UDate=GETDATE() WHERE YetkiNo = @YetkiNo IF @@ROWCOUNT=0 INSERT INTO BoschYetkiOnay (YetkiNo, YetkiAdi,Yetkisi, Userid, UDate) VALUES (@YetkiNo, @YetkiAdi, @Yetkisi, @Userid, GETDATE())", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    'Kullanıcı Log İşlemleri
                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M25")
                    logParam(1) = New SqlParameter("@Uygulama", "1")
                    logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
                    logParam(3) = New SqlParameter("@Tipi", _tipi) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                    logParam(4) = New SqlParameter("@Yapilan", _yapilan)
                    RSQL.AddLog(logParam)

                    'Açıklama
                    If HAciklama.Value <> Aciklama.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Açıklama", HAciklama.Value, Aciklama.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Tipi
                    If HTipi.Value <> Tipi.SelectedItem.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Tipi", HTipi.Value, Tipi.SelectedItem.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Employee sub group (Per_Grp2)
                    If HEmpSubGrp.Value <> EmpSubGrp.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Employee sub group (Per_Grp2)", HEmpSubGrp.Value, EmpSubGrp.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Corporate function (Per_Grp6)
                    If HCorpFunc.Value <> CorpFunc.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Corporate function (Per_Grp6)", HCorpFunc.Value, CorpFunc.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Country specific field (Per_Grp7)
                    If HCounSpField.Value <> CounSpField.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Country specific field (Per_Grp7)", HCounSpField.Value, CounSpField.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Rapor alt grupları (Per_Grp2)
                    If HREmpSubGrp.Value <> REmpSubGrp.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Rapor alt grupları (Per_Grp2)", HREmpSubGrp.Value, REmpSubGrp.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Menü Yetkisi
                    If Hmenuyetki.Value <> _yapilan Then
                        RSQL.AddLogYetki(YtkNo.Text, "Menü Yetkisi", Hmenuyetki.Value, _yapilanaciklama, "0", Session("PersNr"), Session("YetkiNo"))
                    End If
                Else
                    Mesaj.Text = "Bilgiler kaydedilemedi!"
                    Mesaj.ForeColor = Drawing.Color.Red
                End If
            Case Else
                Dim mParam(8) As SqlParameter
                mParam(0) = New SqlParameter("@YetkiNo", YtkNo.Text)
                mParam(1) = New SqlParameter("@YetkiAdi", Aciklama.Text)
                mParam(2) = New SqlParameter("@YetkiTipi", Tipi.SelectedIndex)
                mParam(3) = New SqlParameter("@Yetkisi", YetkiStr)
                mParam(4) = New SqlParameter("@EmpSubGrp", EmpSubGrp.Text)
                mParam(5) = New SqlParameter("@CorpFunc", CorpFunc.Text)
                mParam(6) = New SqlParameter("@CounSpField", CounSpField.Text)
                mParam(7) = New SqlParameter("@REmpSubGrp", REmpSubGrp.Text)
                mParam(8) = New SqlParameter("@Userid", Session("PersNr"))
                Dim RSQL As New SqlForConnection
                If RSQL.RunSQL("UPDATE BoschYetki SET YetkiAdi=@YetkiAdi, YetkiTipi=@YetkiTipi, EmpSubGrp=@EmpSubGrp, Yetkisi=@Yetkisi, Userid=@Userid, UDate=GETDATE(), CorpFunc=@CorpFunc, CounSpField=@CounSpField, REmpSubGrp=@REmpSubGrp WHERE YetkiNo = @YetkiNo IF @@ROWCOUNT=0 INSERT INTO BoschYetki (YetkiNo, YetkiAdi, YetkiTipi, EmpSubGrp, Yetkisi, Userid, UDate, CorpFunc, CounSpField, REmpSubGrp) VALUES (@YetkiNo, @YetkiAdi, @YetkiTipi, @EmpSubGrp, @Yetkisi, @Userid, GETDATE(), @CorpFunc, @CounSpField, @REmpSubGrp)", mParam) Then
                    Mesaj.ForeColor = Drawing.Color.Green
                    Mesaj.Text = "Bilgiler kaydedildi!"

                    'Kullanıcı Log İşlemleri
                    Dim logParam(4) As SqlParameter
                    logParam(0) = New SqlParameter("@ModulNo", "M25")
                    logParam(1) = New SqlParameter("@Uygulama", "1")
                    logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
                    logParam(3) = New SqlParameter("@Tipi", _tipi) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                    logParam(4) = New SqlParameter("@Yapilan", _yapilan)
                    RSQL.AddLog(logParam)

                    'Açıklama
                    If HAciklama.Value <> Aciklama.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Açıklama", HAciklama.Value, Aciklama.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Tipi
                    If HTipi.Value <> Tipi.SelectedItem.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Tipi", HTipi.Value, Tipi.SelectedItem.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Employee sub group (Per_Grp2)
                    If HEmpSubGrp.Value <> EmpSubGrp.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Employee sub group (Per_Grp2)", HEmpSubGrp.Value, EmpSubGrp.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Corporate function (Per_Grp6)
                    If HCorpFunc.Value <> CorpFunc.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Corporate function (Per_Grp6)", HCorpFunc.Value, CorpFunc.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Country specific field (Per_Grp7)
                    If HCounSpField.Value <> CounSpField.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Country specific field (Per_Grp7)", HCounSpField.Value, CounSpField.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Rapor alt grupları (Per_Grp2)
                    If HREmpSubGrp.Value <> REmpSubGrp.Text Then
                        RSQL.AddLogYetki(YtkNo.Text, "Rapor alt grupları (Per_Grp2)", HREmpSubGrp.Value, REmpSubGrp.Text, "0", Session("PersNr"), Session("YetkiNo"))
                    End If

                    'Menü Yetkisi
                    If Hmenuyetki.Value <> _yapilanaciklama Then
                        RSQL.AddLogYetki(YtkNo.Text, "Menü Yetkisi", Hmenuyetki.Value, _yapilanaciklama, "0", Session("PersNr"), Session("YetkiNo"))
                    End If
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

        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(YetkiNo,'') AS YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi FROM BoschYetki ORDER BY YetkiNo")
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
        Dim mTable As DataTable = RSQL.GetValue("SELECT YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi, isnull(YetkiTipi,0) AS YetkiTipi, isnull(EmpSubGrp,'') AS EmpSubGrp, isnull(Yetkisi,'') AS Yetkisi, isnull(CorpFunc,'') AS CorpFunc, isnull(CounSpField,'') AS CounSpField, isnull(REmpSubGrp,'') AS REmpSubGrp FROM BoschYetki WHERE YetkiNo=@YetkiNo", {New SqlParameter("@YetkiNo", NdxText)})
        If mTable.Rows.Count > 0 Then
            YtkNo.Text = mTable.Rows(0)!YetkiNo.ToString
            Aciklama.Text = mTable.Rows(0)!YetkiAdi.ToString
            Tipi.SelectedIndex = mTable.Rows(0)!YetkiTipi
            HiddenField1.Value = mTable.Rows(0)!Yetkisi
            EmpSubGrp.Text = mTable.Rows(0)!EmpSubGrp.ToString
            CorpFunc.Text = mTable.Rows(0)!CorpFunc.ToString
            CounSpField.Text = mTable.Rows(0)!CounSpField.ToString
            REmpSubGrp.Text = mTable.Rows(0)!REmpSubGrp.ToString

            Dim _yapilan = ""
            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                If Mid(mTable.Rows(0)!Yetkisi, Mid(Satir("Kodu").Text, 2, 2), 1) = "1" Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                Else
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
                End If

                If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked Then
                    _yapilan += IIf(_yapilan = "", Satir("Kodu").Text, "," & Satir("Kodu").Text)
                End If
            Next

            HAciklama.Value = Aciklama.Text
            HTipi.Value = Tipi.SelectedItem.Text
            HEmpSubGrp.Value = EmpSubGrp.Text
            HCorpFunc.Value = CorpFunc.Text
            HCounSpField.Value = CounSpField.Text
            HREmpSubGrp.Value = REmpSubGrp.Text
            Hmenuyetki.Value = _yapilan
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
        Tipi.SelectedIndex = -1
        Kayit.Text = ""
        Mesaj.Text = ""


        HAciklama.Value = ""
        HTipi.Value = ""
        HEmpSubGrp.Value = ""
        HCorpFunc.Value = ""
        HCounSpField.Value = ""
        HREmpSubGrp.Value = ""
        Hmenuyetki.Value = ""

        EmpSubGrp.Text = ""
        CorpFunc.Text = ""
        CounSpField.Text = ""
        REmpSubGrp.Text = ""

        HiddenField1.Value = ""

        YtkNo.Enabled = False
        Aciklama.ReadOnly = True
        Tipi.Enabled = False

        EmpSubGrp.ReadOnly = True
        CorpFunc.ReadOnly = True
        CounSpField.ReadOnly = True
        REmpSubGrp.ReadOnly = True

        RadGrid2.Enabled = False

        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
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
                If Mid(HiddenField1.Value, Mid(Satir("Kodu").Text, 2, 2), 1) = "1" Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                Else
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
                End If
            Next
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(YetkiNo,'') AS YetkiNo, isnull(YetkiAdi,'') AS YetkiAdi FROM BoschYetki ORDER BY YetkiNo")
    End Sub

End Class
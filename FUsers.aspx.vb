Imports Telerik.Web.UI

Public Class FUsers
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RSql As New SqlForConnection
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
            Temizle()

            Dim mTable As DataTable = RSql.GetValue("SELECT isnull(YetkiNo,'') AS Kodu, isnull(YetkiAdi,'') AS Aciklama FROM BoschYetki ORDER BY YetkiNo")
            PerYetki.Items.Clear()
            PerYetki.Items.Add(New ListItem With {.Value = "", .Text = "Seçilmedi", .Selected = False})
            If Not mTable Is Nothing Then
                If mTable.Rows.Count > 0 Then
                    For Each Satir In mTable.Rows
                        PerYetki.Items.Add(New ListItem With {.Value = Satir!Kodu, .Text = Satir!Aciklama, .Selected = False})
                    Next
                End If
            End If

            If Session("YetkiNo").ToString() = "5" Then
                Durumu.Enabled = False
                Email.Enabled = False
                PerPersNr.Enabled = False
                PerYetki.Enabled = False
                Username.Enabled = False
                Kendisi.Enabled = False
                Userid.Enabled = False
                euser.Enabled = False
            End If
        End If
    End Sub

    Protected Sub Ekle_Click(sender As Object, e As ImageClickEventArgs) Handles BEkle.Click
        Temizle()
        Kayit.Text = "Eklemek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        Userid.Enabled = True
        Kendisi.Enabled = True
        Username.Enabled = True
        PerYetki.Enabled = True
        PerPersNr.Enabled = True
        Email.Enabled = True
        Durumu.Enabled = True

        RadGrid2.Enabled = True
        BEkle.Enabled = True
        BDegistir.Enabled = False
        BSil.Enabled = False
        BKaydet.Visible = True
        BVazgec.Visible = True

        If Session("YetkiNo").ToString() = "5" Then
            Durumu.Enabled = False
            Email.Enabled = False
            PerPersNr.Enabled = False
            PerYetki.Enabled = False
            Username.Enabled = False
            Kendisi.Enabled = False
            Userid.Enabled = False
            euser.Enabled = False
        End If
    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        Userid.Enabled = False
        Kendisi.Enabled = True
        Username.Enabled = True
        PerYetki.Enabled = True
        PerPersNr.Enabled = True
        Email.Enabled = True
        Durumu.Enabled = True
        RadGrid2.Enabled = True
        BKaydet.Visible = True
        BVazgec.Visible = True

        If Session("YetkiNo").ToString() = "5" Then
            Durumu.Enabled = False
            Email.Enabled = False
            PerPersNr.Enabled = False
            PerYetki.Enabled = False
            Username.Enabled = False
            Kendisi.Enabled = False
            Userid.Enabled = False
            euser.Enabled = False
        End If
    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschUsers WHERE Userid=@Userid", {New SqlParameter("@Userid", Secilen("Userid").Text.ToString)}) Then
            'Mesaj.ForeColor = Drawing.Color.Green
            'Mesaj.Text = "Kayıt silindi!"

            'Kullanıcı Log İşlemleri
            Dim logParam(4) As SqlParameter
            logParam(0) = New SqlParameter("@ModulNo", "M25")
            logParam(1) = New SqlParameter("@Uygulama", "1")
            logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
            logParam(3) = New SqlParameter("@Tipi", 2) ' 0:Ekleme , 1:Değiştirme , 2:Silme
            logParam(4) = New SqlParameter("@Yapilan", "Kullanıcı id:" & Secilen("Userid").Text.ToString())
            RSQL.AddLog(logParam)

            Refresh_Data(3)
        Else
            ' Mesaj.ForeColor = Drawing.Color.Red
            ' Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim _tipi = 1
        If Kayit.Text = "Eklemek için" Then
            _tipi = 0
            For Each Satir As GridDataItem In RadGrid1.Items
                If UCase(Satir.Cells(2).Text) = UCase(Userid.Text) Then
                    '   Mesaj.ForeColor = Drawing.Color.Red
                    '  Mesaj.Text = "Aynı kullanıcı kodu ile başka bir kullanıcı kayıtlı."
                    Exit Sub
                End If
            Next
        End If

        If Userid.Text = "" Then
            ' Mesaj.ForeColor = Drawing.Color.Red
            ' Mesaj.Text = "Kullanıcı kodunu muhakkak giriniz!"
            Exit Sub
        End If

        Dim _perlistekle = ""
        Dim _perlistsil = ""
        Dim _eskiler = ""
        Dim _kodu = ""
        Dim PerList As String = ""
        Dim _PerListgecici() = PerListTmp.Value.Split("+")
        Dim _yapilan = ""

        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked And TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedIndex = -1 Then
                If _eskiler = "" Then
                    _eskiler = Satir("Kodu").Text
                Else
                    _eskiler = _eskiler & "+" & Satir("Kodu").Text
                End If
            ElseIf TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False And TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedValue = "0" Then
                If _perlistekle = "" Then
                    _perlistekle = Satir("Kodu").Text
                Else
                    _perlistekle = _perlistekle & "+" & Satir("Kodu").Text
                End If
            ElseIf TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked And TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedValue = "1" Then
                If _perlistsil = "" Then
                    _perlistsil = Satir("Kodu").Text
                Else
                    _perlistsil = _perlistsil & "+" & Satir("Kodu").Text
                End If
            End If


            'If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked And TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedIndex = -1 Then
            '    If Session("YetkiNo") = "5" Then
            '        For Each _satir As String In _PerListgecici
            '            If Satir("Kodu").Text = _satir Then
            '                _kodu = "OK"
            '                Exit For
            '            End If
            '        Next

            '        If _kodu = "" Then
            '            _perlistekle = IIf(_perlistekle = "", Satir("Kodu").Text, _perlistekle & "+" & Satir("Kodu").Text)
            '        End If
            '    End If

            '    If PerList = "" Then
            '        PerList = Satir("Kodu").Text
            '    Else
            '        PerList = PerList & "+" & Satir("Kodu").Text
            '    End If
            'End If
            '_kodu = ""
        Next

        'Silinen yetkiler kontrol ediliyor
        _kodu = ""
        'For Each _satir As String In _PerListgecici
        '    For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
        '        If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked Then
        '            If Satir("Kodu").Text = _satir Then
        '                _kodu = "OK"
        '                Exit For
        '            End If
        '        End If
        '    Next

        '    If _kodu = "" Then
        '        _perlistsil = IIf(_perlistsil = "", _satir, _perlistsil & "+" & _satir)
        '    End If
        '    _kodu = ""
        'Next

        _yapilan += IIf(_yapilan = "", "Sadece kendisi:" & IIf(Kendisi.Checked, "Evet", "Hayır"), " | Sadece kendisi:" & IIf(Kendisi.Checked, "Evet", "Hayır"))

        _yapilan += IIf(_yapilan = "", "Kullanıcı Adı:" & Username.Text, " | Kullanıcı Adı:" & Username.Text)

        _yapilan += IIf(_yapilan = "", "Kullanıcı Grubu:" & PerYetki.SelectedItem.Text, " | Kullanıcı Grubu:" & PerYetki.SelectedItem.Text)

        _yapilan += IIf(_yapilan = "", "Personel Sicil No:" & PerPersNr.Text, " | Personel Sicil No:" & PerPersNr.Text)

        _yapilan += IIf(_yapilan = "", "EMail:" & Email.Text, " | EMail:" & Email.Text)

        _yapilan += IIf(_yapilan = "", "Durumu:" & Durumu.SelectedItem.Text, " | Durumu:" & Durumu.SelectedItem.Text)

        _yapilan += IIf(_yapilan = "", "External Kullanıcı:" & IIf(euser.Checked, "Evet", "Hayır"), " | External Kullanıcı:" & IIf(euser.Checked, "Evet", "Hayır"))

        Dim _sqlstr = "UPDATE BoschUsers SET username=@username, PerYetki=@PerYetki, PerList=@PerList, EMail=@EMail, Kendisi=@Kendisi, PerPersNr=@PerPersNr, UUserid=@UUserid, UDate=GETDATE(), Durumu=@Durumu,Extern=@Extern  WHERE Userid=@Userid IF @@ROWCOUNT=0 INSERT INTO BoschUsers (Userid, username, PerYetki, PerList, EMail, Kendisi, PerPersNr, UUserid, UDate, Durumu,Extern) VALUES (@Userid, @username, @PerYetki, @PerList, @EMail, @Kendisi, @PerPersNr, @UUSerid, GETDATE(), @Durumu,@Extern)"
        Dim mParam(11) As SqlParameter
        Select Case Session("YetkiNo")
            Case "5"
                _sqlstr = "UPDATE BoschUsersOnay SET username=@username, PerYetki=@PerYetki, PerListSil=@PerListSil, EMail=@EMail, Kendisi=@Kendisi, PerPersNr=@PerPersNr, UUserid=@UUserid, UDate=GETDATE(), Durumu=@Durumu,Extern=@Extern,PerListEkle=@PerListEkle,PerList=@PerList WHERE Userid=@Userid IF @@ROWCOUNT=0 INSERT INTO BoschUsersOnay (Userid, username, PerYetki, PerListSil, EMail, Kendisi, PerPersNr, UUserid, UDate, Durumu,Extern,PerListEkle,PerList) VALUES (@Userid, @username, @PerYetki, @PerListSil, @EMail, @Kendisi, @PerPersNr, @UUSerid, GETDATE(), @Durumu,@Extern,@PerListEkle,@PerList)"
        End Select

        mParam(3) = New SqlParameter("@PerList", _eskiler)
        mParam(0) = New SqlParameter("@Userid", Userid.Text)
        mParam(1) = New SqlParameter("@Username", Username.Text)
        mParam(2) = New SqlParameter("@PerYetki", PerYetki.SelectedValue)
        mParam(4) = New SqlParameter("@Email", Email.Text)
        mParam(5) = New SqlParameter("@Kendisi", IIf(Kendisi.Checked, 1, 0))
        mParam(6) = New SqlParameter("@PerPersNr", PerPersNr.Text)
        mParam(7) = New SqlParameter("@UUserid", Session("PersNr"))
        mParam(8) = New SqlParameter("@Durumu", Durumu.SelectedIndex)
        mParam(9) = New SqlParameter("@Extern", IIf(euser.Checked, 1, 0))
        mParam(11) = New SqlParameter("@PerListSil", _perlistsil)
        mParam(10) = New SqlParameter("@PerListEkle", _perlistekle)
        Dim RSQL As New SqlForConnection
        If RSQL.RunSQL(_sqlstr, mParam) Then
            'Mesaj.ForeColor = Drawing.Color.Green
            'Mesaj.Text = "Bilgiler kaydedildi!"

            If _eskiler <> "" Then
                _yapilan += IIf(_yapilan = "", "Yetkiler:" & _eskiler, " | Yetkiler:" & _eskiler)
            End If

            If _perlistsil <> "" Then
                _yapilan += IIf(_yapilan = "", "Silmek için onaya sunulan yetkiler:" & _perlistsil, " | Silmek için onaya sunulan yetkiler:" & _perlistsil)
            End If

            If _perlistekle <> "" Then
                _yapilan += IIf(_yapilan = "", "Eklemek için onaya sunulan yetkiler:" & _perlistekle, " | Eklemek için onaya sunulan yetkiler:" & _perlistekle)
            End If

            'Kullanıcı Log İşlemleri
            Dim logParam(4) As SqlParameter
            logParam(0) = New SqlParameter("@ModulNo", "M25")
            logParam(1) = New SqlParameter("@Uygulama", "1")
            logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
            logParam(3) = New SqlParameter("@Tipi", _tipi) ' 0:Ekleme , 1:Değiştirme , 2:Silme
            logParam(4) = New SqlParameter("@Yapilan", _yapilan)
            RSQL.AddLog(logParam)
        Else
            'Mesaj.Text = "Bilgiler kaydedilemedi!"
            'Mesaj.ForeColor = Drawing.Color.Red
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
        PerListTmp.Value = ""

        Select Case Durum
            Case 0
                'Seç
                If RadGrid1.SelectedIndexes.Count > 0 Then
                    SiraNo = RadGrid1.SelectedIndexes(0)
                End If
            Case 1
                'Ekle
                SiraNo = -1
                NdxText = Userid.Text
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

        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username FROM BoschUsers ORDER BY Userid")
        RadGrid1.Rebind()

        If RadGrid1.MasterTableView.Items.Count > 0 Then
            RadGrid1.MasterTableView.ClearSelectedItems()
            If SiraNo >= 0 Then
                If SiraNo >= RadGrid1.MasterTableView.Items.Count Then
                    SiraNo = RadGrid1.MasterTableView.Items.Count - 1
                End If
                RadGrid1.MasterTableView.Items(SiraNo).Selected = True
            Else
                For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
                    If Satir("Userid").Text = NdxText Then
                        Satir.Selected = True
                        Exit For
                    End If
                Next
            End If
        End If

        Temizle()
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        NdxText = Secilen("Userid").Text
        Dim mTable As DataTable = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username, isnull(PerYetki,'') AS PerYetki, isnull(PerList,'') AS PerList, isnull(EMail,'') AS EMail, isnull(Kendisi,0) AS Kendisi, isnull(PerPersNr,0) AS PerPersNr, isnull(Durumu,0) AS Durumu,isnull(Extern,0) AS Extern,			(SELECT PerListEkle  FROM BoschUsersOnay WHERE BoschUsersOnay.Userid=BoschUsers.Userid AND BoschUsersOnay.UUserid='" & Session("PersNr") & "') AS PersLisEkle,(SELECT PerListSil  FROM BoschUsersOnay WHERE BoschUsersOnay.Userid=BoschUsers.Userid AND BoschUsersOnay.UUserid='" & Session("PersNr") & "') AS PersLisSil FROM BoschUsers   WHERE Userid=@Userid", {New SqlParameter("@Userid", NdxText)})
        If mTable.Rows.Count > 0 Then
            Userid.Text = mTable.Rows(0)!Userid.ToString()
            Kendisi.Checked = IIf(mTable.Rows(0)!Kendisi = 0, False, True)
            Username.Text = mTable.Rows(0)!Username.ToString()

            PerYetki.SelectedValue = mTable.Rows(0)!PerYetki.ToString()
            PerPersNr.Text = mTable.Rows(0)!PerPersNr.ToString()
            Email.Text = mTable.Rows(0)!Email.ToString()

            HiddenField1.Value = mTable.Rows(0)!PerList.ToString()

            Durumu.SelectedIndex = mTable.Rows(0)!Durumu
            euser.Checked = IIf(mTable.Rows(0)!Extern = 0, False, True)

            Dim Kayitlar() As String = mTable.Rows(0)!PerList.ToString().Split("+")
            Dim eklenenler() As String = mTable.Rows(0)!PersLisEkle.ToString().Split("+")
            Dim silinenler() As String = mTable.Rows(0)!PersLisSil.ToString().Split("+")

            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                For Each Kayitstr As String In Kayitlar
                    If Kayitstr = Satir("Kodu").Text Then
                        TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                        Exit For
                    End If
                Next

                TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedIndex = -1

                If Session("YetkiNo").ToString() = "5" Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Enabled = False
                    For Each eklenen As String In eklenenler
                        If eklenen = Satir("Kodu").Text Then
                            TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedIndex = 0
                        End If
                    Next

                    For Each silinen As String In silinenler
                        If silinen = Satir("Kodu").Text Then
                            TryCast(Satir.FindControl("RadioButtonList1"), RadioButtonList).SelectedIndex = 1
                        End If
                    Next
                End If
            Next
        Else
            ' Mesaj.Text = "Seçilen kayıt bulunamadı!"
        End If
    End Sub

    Protected Sub Vazgec_Click(sender As Object, e As ImageClickEventArgs) Handles BVazgec.Click
        ' Mesaj.ForeColor = Drawing.Color.Red
        ' Mesaj.Text = "Kaydetmekten vazgeçildi!"
        Kayit.Text = ""
        Refresh_Data(0)
    End Sub
    Protected Sub Temizle()
        Userid.Text = ""
        Kendisi.Checked = False
        euser.Checked = False
        Username.Text = ""
        PerYetki.SelectedIndex = -1
        PerPersNr.Value = 0
        Email.Text = ""
        Durumu.SelectedIndex = -1
        Kayit.Text = ""
        PerListTmp.Value = ""
        '.Text = ""
        HiddenField1.Value = ""
        HiddenField2.Value = ""
        HiddenField3.Value = ""
        Userid.Enabled = False
        Kendisi.Enabled = False
        Username.Enabled = False
        PerYetki.Enabled = False
        PerPersNr.Enabled = False
        Email.Enabled = False
        Durumu.Enabled = False
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
        PerListTmp.Value = ""
        Refresh_Data(0)
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username FROM BoschUsers ORDER BY Userid")
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid2.DataSource = RSQL.GetValue("SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5<>'' AND Per_Grp5 is not null GROUP BY Per_Grp5 ORDER BY Per_Grp5")
    End Sub

    Private Sub RadGrid2_DataBound(sender As Object, e As EventArgs) Handles RadGrid2.DataBound
        Dim Kayitlar() As String = HiddenField1.Value.ToString.Split("+")
        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            For Each Kayitstr As String In Kayitlar
                If Kayitstr = Satir("Kodu").Text Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Protected Sub RadGrid2_PreRender(sender As Object, e As EventArgs)
        Dim gridCol As GridColumn = RadGrid2.MasterTableView.GetColumn("YetkiTmp")
        If Session("YetkiNo").ToString() = "5" Then
            gridCol.Visible = True
        Else
            gridCol.Visible = False
        End If
    End Sub

End Class
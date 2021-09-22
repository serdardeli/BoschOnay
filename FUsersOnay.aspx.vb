Imports Telerik.Web.UI
Public Class FUsersOnay
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RSql As New SqlForConnection
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
            Temizle()

            Dim mTableg As DataTable = RSql.GetValue("SELECT isnull(YetkiNo,'') AS Kodu, isnull(YetkiAdi,'') AS Aciklama FROM BoschYetki   ORDER BY YetkiNo")
            PerYetki.Items.Clear()
            PerYetki.Items.Add(New ListItem With {.Value = "", .Text = "Seçilmedi", .Selected = False})
            If Not mTableg Is Nothing Then
                If mTableg.Rows.Count > 0 Then
                    For Each Satir In mTableg.Rows
                        PerYetki.Items.Add(New ListItem With {.Value = Satir!Kodu, .Text = Satir!Aciklama, .Selected = False})
                    Next
                End If
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
        BDegistir.Enabled = True
        BSil.Enabled = True
        BKaydet.Visible = True
        BVazgec.Visible = True
    End Sub

    Protected Sub Degistir_Click(sender As Object, e As ImageClickEventArgs) Handles BDegistir.Click
        Kayit.Text = "Değiştirmek için"

        BEkle.Enabled = False
        BDegistir.Enabled = False
        BSil.Enabled = False

        Userid.Enabled = False
        Kendisi.Enabled = False
        Username.Enabled = False
        PerYetki.Enabled = False
        PerPersNr.Enabled = False
        Email.Enabled = False
        Durumu.Enabled = False
        euser.Enabled = False
        RadGrid2.Enabled = True
        BKaydet.Visible = True
        BVazgec.Visible = True
    End Sub

    Protected Sub Sil_Click(sender As Object, e As ImageClickEventArgs) Handles BSil.Click
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim RSQL As New SqlForConnection

        If RSQL.RunSQL("DELETE BoschUsersOnay WHERE Userid=@Userid", {New SqlParameter("@Userid", Secilen("Userid").Text.ToString)}) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Kayıt silindi!"

            'Kullanıcı Log İşlemleri
            Dim logParam(4) As SqlParameter
            logParam(0) = New SqlParameter("@ModulNo", "M37")
            logParam(1) = New SqlParameter("@Uygulama", "1")
            logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
            logParam(3) = New SqlParameter("@Tipi", 2) ' 0:Ekleme , 1:Değiştirme , 2:Silme
            logParam(4) = New SqlParameter("@Yapilan", "Kullanıcı id:" & Secilen("Userid").Text.ToString())
            RSQL.AddLog(logParam)

            Refresh_Data(3)
        Else
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kayıt silinemedi!"
        End If
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        If Kayit.Text = "Eklemek için" Then
            For Each Satir As GridDataItem In RadGrid1.Items
                If UCase(Satir.Cells(2).Text) = UCase(Userid.Text) Then
                    Mesaj.ForeColor = Drawing.Color.Red
                    Mesaj.Text = "Aynı kullanıcı kodu ile başka bir kullanıcı kayıtlı."
                    Exit Sub
                End If
            Next
        End If

        If Userid.Text = "" Then
            Mesaj.ForeColor = Drawing.Color.Red
            Mesaj.Text = "Kullanıcı kodunu muhakkak giriniz!"
            Exit Sub
        End If

        Dim _yapilan = ""
        Dim PerListTMP As String = ""
        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            If TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True Then
                If (TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = True) Or (TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = False) Then
                    If PerListTMP = "" Then
                        PerListTMP = Satir("Kodu").Text
                    Else
                        PerListTMP = PerListTMP & "+" & Satir("Kodu").Text
                    End If
                End If

                If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = True Then
                    _yapilan += IIf(_yapilan = "", "Yetki Eklme:" & Satir("Kodu").Text & " Onaylandı.", " | Yetki Eklme:" & Satir("Kodu").Text & " Onaylandı.")
                ElseIf TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = False Then
                    _yapilan += IIf(_yapilan = "", "Yetki Eklme:" & Satir("Kodu").Text & " Onaylanmadı.", " | Yetki Eklme:" & Satir("Kodu").Text & " Onaylanmadı.")
                End If

                If TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = True Then
                    _yapilan += IIf(_yapilan = "", "Yetki Silme:" & Satir("Kodu").Text & " Onaylandı.", " | Yetki Silme:" & Satir("Kodu").Text & " Onaylandı.")
                ElseIf TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True And TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = False Then
                    _yapilan += IIf(_yapilan = "", "Yetki Silme:" & Satir("Kodu").Text & " Onaylanmadı.", " | Yetki Silme:" & Satir("Kodu").Text & " Onaylanmadı.")
                End If
            Else
                'Eski yetkileri ekle
                If PerListTMP = "" Then
                    PerListTMP = Satir("Kodu").Text
                Else
                    PerListTMP = PerListTMP & "+" & Satir("Kodu").Text
                End If
            End If
        Next

        _yapilan += IIf(_yapilan = "", "Sadece kendisi:" & IIf(Kendisi.Checked, "Evet", "Hayır"), " | Sadece kendisi:" & IIf(Kendisi.Checked, "Evet", "Hayır"))

        _yapilan += IIf(_yapilan = "", "Kullanıcı Adı:" & Username.Text, " | Kullanıcı Adı:" & Username.Text)

        _yapilan += IIf(_yapilan = "", "Kullanıcı Grubu:" & PerYetki.SelectedItem.Text, " | Kullanıcı Grubu:" & PerYetki.SelectedItem.Text)

        _yapilan += IIf(_yapilan = "", "Personel Sicil No:" & PerPersNr.Text, " | Personel Sicil No:" & PerPersNr.Text)

        _yapilan += IIf(_yapilan = "", "EMail:" & Email.Text, " | EMail:" & Email.Text)

        _yapilan += IIf(_yapilan = "", "Durumu:" & Durumu.SelectedItem.Text, " | Durumu:" & Durumu.SelectedItem.Text)

        _yapilan += IIf(_yapilan = "", "External Kullanıcı:" & IIf(euser.Checked, "Evet", "Hayır"), " | External Kullanıcı:" & IIf(euser.Checked, "Evet", "Hayır"))

        Dim mParam(9) As SqlParameter
        mParam(0) = New SqlParameter("@Userid", Userid.Text)
        mParam(1) = New SqlParameter("@Username", Username.Text)
        mParam(2) = New SqlParameter("@PerYetki", PerYetki.SelectedValue)
        mParam(3) = New SqlParameter("@PerList", PerListTMP)
        mParam(4) = New SqlParameter("@Email", Email.Text)
        mParam(5) = New SqlParameter("@Kendisi", IIf(Kendisi.Checked, 1, 0))
        mParam(6) = New SqlParameter("@PerPersNr", PerPersNr.Text)
        mParam(7) = New SqlParameter("@UUserid", Session("PersNr"))
        mParam(8) = New SqlParameter("@Durumu", Durumu.SelectedIndex)
        mParam(9) = New SqlParameter("@Extern", IIf(euser.Checked, 1, 0))
        Dim RSQL As New SqlForConnection
        If RSQL.RunSQL("UPDATE BoschUsers SET username=@username, PerYetki=@PerYetki, PerList=@PerList, EMail=@EMail, Kendisi=@Kendisi, PerPersNr=@PerPersNr, UUserid=@UUserid, UDate=GETDATE(), Durumu=@Durumu,Extern=@Extern WHERE Userid=@Userid IF @@ROWCOUNT=0 INSERT INTO BoschUsers (Userid, username, PerYetki, PerList, EMail, Kendisi, PerPersNr, UUserid, UDate, Durumu,Extern) VALUES (@Userid, @username, @PerYetki, @PerList, @EMail, @Kendisi, @PerPersNr, @UUSerid, GETDATE(), @Durumu,@Extern)", mParam) Then
            Mesaj.ForeColor = Drawing.Color.Green
            Mesaj.Text = "Bilgiler kaydedildi!"

            If RSQL.RunSQL("DELETE BoschUsersOnay WHERE IdNr=@IdNr", {New SqlParameter("@IdNr", hdfid.Value)}) Then
            End If


            'Kullanıcı Log İşlemleri
            Dim logParam(4) As SqlParameter
            logParam(0) = New SqlParameter("@ModulNo", "M37")
            logParam(1) = New SqlParameter("@Uygulama", "1")
            logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
            logParam(3) = New SqlParameter("@Tipi", 0) ' 0:Ekleme , 1:Değiştirme , 2:Silme
            logParam(4) = New SqlParameter("@Yapilan", _yapilan)
            RSQL.AddLog(logParam)
        Else
            Mesaj.Text = "Bilgiler kaydedilemedi!"
            Mesaj.ForeColor = Drawing.Color.Red
        End If

        'If Kayit.Text = "Eklemek için" Then
        '    Refresh_Data(1)
        'Else
        '    Refresh_Data(0)
        'End If

        Temizle()
        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username FROM BoschUsersOnay ORDER BY Userid")
        RadGrid1.Rebind()
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

        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username FROM BoschUsersOnay ORDER BY Userid")
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
                If Satir("Kodu").Text = NdxText Then
                    Satir.Selected = True
                    Exit For
                End If
            Next
        End If


        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        NdxText = Secilen("Userid").Text
        Dim mTable As DataTable = RSQL.GetValue("SELECT IdNr,isnull(Userid,'') AS Userid, isnull(username,'') AS username, isnull(PerYetki,'') AS PerYetki, isnull(PerListEkle,'') AS PerListEkle, isnull(PerListSil,'') AS PerListSil, isnull(EMail,'') AS EMail, isnull(Kendisi,0) AS Kendisi, isnull(PerPersNr,0) AS PerPersNr, isnull(Durumu,0) AS Durumu,isnull(Extern,0) AS Extern, isnull(PerList,'') AS PerList FROM BoschUsersOnay WHERE Userid=@Userid", {New SqlParameter("@Userid", NdxText)})
        If mTable.Rows.Count > 0 Then
            Userid.Text = mTable.Rows(0)!Userid.ToString
            Kendisi.Checked = IIf(mTable.Rows(0)!Kendisi = 0, False, True)
            Username.Text = mTable.Rows(0)!Username.ToString

            PerYetki.SelectedValue = mTable.Rows(0)!PerYetki
            PerPersNr.Text = mTable.Rows(0)!PerPersNr.ToString
            Email.Text = mTable.Rows(0)!Email

            HiddenField1.Value = mTable.Rows(0)!PerList

            hdfid.Value = mTable.Rows(0)!IdNr

            Durumu.SelectedIndex = mTable.Rows(0)!Durumu
            euser.Checked = IIf(mTable.Rows(0)!Extern = 0, False, True)

            hdfekle.Value = mTable.Rows(0)!PerListEkle.ToString()
            hdfsil.Value = mTable.Rows(0)!PerListSil.ToString()
            hdfeskiler.Value = mTable.Rows(0)!PerList.ToString()

            Dim EklenenKayitlar() As String = mTable.Rows(0)!PerListEkle.split("+")
            Dim SilinenKayitlar() As String = mTable.Rows(0)!PerListSil.split("+")
            Dim PerList() As String = mTable.Rows(0)!PerList.split("+")
            Dim _var = 0

            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                _var = 0
                TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = False
                TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = ""

                For Each Kayitstr As String In EklenenKayitlar
                    If Kayitstr = Satir("Kodu").Text Then
                        TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = "(Ekle) Onay bekliyor"
                        _var = 1
                        Exit For
                    End If
                Next

                For Each Kayitstr As String In SilinenKayitlar
                    If Kayitstr = Satir("Kodu").Text Then
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = "(Sil) Onay bekliyor"
                        _var = 1
                        Exit For
                    End If
                Next
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
        Userid.Text = ""
        Kendisi.Checked = False
        euser.Checked = False
        Username.Text = ""
        PerYetki.SelectedIndex = -1
        PerPersNr.Value = 0
        Email.Text = ""
        Durumu.SelectedIndex = -1
        Kayit.Text = ""
        hdfid.Value = ""
        hdfsil.Value = ""
        hdfekle.Value = ""
        hdfeskiler.Value = ""
        Mesaj.Text = ""
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
        Temizle()
        'Dim _rdatatable As New DataTable("BatasLokasyoninfo")

        'Dim Kodu As New DataColumn("Kodu")
        'Kodu.DataType = System.Type.GetType("System.String")
        '_rdatatable.Columns.Add(Kodu)

        'Dim Adi As New DataColumn("Adi")
        'Adi.DataType = System.Type.GetType("System.String")
        '_rdatatable.Columns.Add(Adi)

        Dim RSQL As New SqlForConnection
        Dim Secilen As GridDataItem = RadGrid1.SelectedItems(0)
        Dim mTable As DataTable = RSQL.GetValue("SELECT IdNr,isnull(Userid,'') AS Userid, isnull(username,'') AS username, isnull(PerYetki,'') AS PerYetki, isnull(PerListEkle,'') AS PerListEkle, isnull(PerListSil,'') AS PerListSil, isnull(EMail,'') AS EMail, isnull(Kendisi,0) AS Kendisi, isnull(PerPersNr,0) AS PerPersNr, isnull(Durumu,0) AS Durumu,isnull(Extern,0) AS Extern, isnull(PerList,'') AS PerList FROM BoschUsersOnay WHERE Userid=@Userid", {New SqlParameter("@Userid", Secilen("Userid").Text)})
        If mTable.Rows.Count > 0 Then
            Userid.Text = mTable.Rows(0)!Userid.ToString
            Kendisi.Checked = IIf(mTable.Rows(0)!Kendisi = 0, False, True)
            Username.Text = mTable.Rows(0)!Username.ToString

            PerYetki.SelectedValue = mTable.Rows(0)!PerYetki
            PerPersNr.Text = mTable.Rows(0)!PerPersNr.ToString
            Email.Text = mTable.Rows(0)!Email

            hdfekle.Value = mTable.Rows(0)!PerListEkle.ToString()
            hdfsil.Value = mTable.Rows(0)!PerListSil.ToString()
            hdfeskiler.Value = mTable.Rows(0)!PerList.ToString()

            hdfid.Value = mTable.Rows(0)!IdNr

            Durumu.SelectedIndex = mTable.Rows(0)!Durumu
            euser.Checked = IIf(mTable.Rows(0)!Extern = 0, False, True)

            Dim EklenenKayitlar() As String = mTable.Rows(0)!PerListEkle.split("+")
            Dim SilinenKayitlar() As String = mTable.Rows(0)!PerListSil.split("+")
            Dim PerList() As String = mTable.Rows(0)!PerList.split("+")
            Dim EklenenKayitlarTMP = ""
            Dim SilinenKayitlarTMP = ""
            Dim PerListTMP = ""

            For Each Kayitstr As String In EklenenKayitlar
                If Kayitstr.Trim() <> "" Then
                    EklenenKayitlarTMP &= IIf(EklenenKayitlarTMP = "", "'" & Kayitstr & "'", ",'" & Kayitstr & "'")
                End If
            Next

            For Each Kayitstr As String In SilinenKayitlar
                If Kayitstr.Trim() <> "" Then
                    SilinenKayitlarTMP &= IIf(SilinenKayitlarTMP = "", "'" & Kayitstr & "'", ",'" & Kayitstr & "'")
                End If
            Next

            For Each Kayitstr As String In PerList
                If Kayitstr.Trim() <> "" Then
                    PerListTMP &= IIf(PerListTMP = "", "'" & Kayitstr & "'", ",'" & Kayitstr & "'")
                End If
            Next

            Dim _str = ""
            If EklenenKayitlarTMP <> "" Then
                _str += " SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5 in(" & EklenenKayitlarTMP & ")  GROUP BY Per_Grp5 "
            End If

            If SilinenKayitlarTMP <> "" Then
                _str += IIf(_str = "", " SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5 in(" & SilinenKayitlarTMP & ")  GROUP BY Per_Grp5 ", " UNION ALL SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5 in(" & SilinenKayitlarTMP & ")  GROUP BY Per_Grp5")
            End If

            If PerListTMP <> "" Then
                _str += IIf(_str = "", " SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5 in(" & PerListTMP & ")  GROUP BY Per_Grp5 ", " UNION ALL SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab WHERE Per_Grp5 in(" & PerListTMP & ")  GROUP BY Per_Grp5 ")
            End If

            RadGrid2.DataSource = RSQL.GetValue(_str)
            RadGrid2.Rebind()

            For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
                TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = False
                TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = ""

                For Each Kayitstr As String In EklenenKayitlar
                    If Kayitstr = Satir("Kodu").Text Then
                        TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = False
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = "(Ekle) Onay bekliyor"
                        Exit For
                    End If
                Next

                For Each Kayitstr As String In SilinenKayitlar
                    If Kayitstr = Satir("Kodu").Text Then
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = True
                        TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = "(Sil) Onay bekliyor"
                        Exit For
                    End If
                Next
            Next
        Else
            Mesaj.Text = "Seçilen kayıt bulunamadı!"
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid1.DataSource = RSQL.GetValue("SELECT isnull(Userid,'') AS Userid, isnull(username,'') AS username FROM BoschUsersOnay ORDER BY Userid")
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim RSQL As New SqlForConnection
        RadGrid2.DataSource = RSQL.GetValue("SELECT isnull(Per_Grp5,'') AS Kodu, CAST('false' as bit) AS Yetki FROM BoschPerTab   GROUP BY Per_Grp5 ORDER BY Per_Grp5")
    End Sub

    Private Sub RadGrid2_DataBound(sender As Object, e As EventArgs) Handles RadGrid2.DataBound
        Dim Kayitlar() As String = HiddenField1.Value.ToString.Split("+")
        For Each Satir As GridDataItem In RadGrid2.MasterTableView.Items
            TryCast(Satir.FindControl("CheckBox2"), CheckBox).Enabled = False
            TryCast(Satir.FindControl("CheckBox2"), CheckBox).Text = ""
            For Each Kayitstr As String In Kayitlar
                If Kayitstr = Satir("Kodu").Text Then
                    TryCast(Satir.FindControl("CheckBox1"), CheckBox).Checked = True
                    TryCast(Satir.FindControl("CheckBox2"), CheckBox).Checked = False
                    Exit For
                End If
            Next
        Next
    End Sub

End Class
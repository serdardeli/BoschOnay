Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("mesaj") <> "" Then
            Label3.Text = Request("mesaj")
        End If
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Session("Kayitlar") = ""

        SicilList.Visible = False
        Devam.Visible = False

        If Not IsPostBack() Then
            Dim WinUsername As String = HttpContext.Current.User.Identity.Name
            WinUsername = Mid(WinUsername, InStr(WinUsername, "\") + 1, Len(WinUsername) - InStr(WinUsername, "\"))

            If WinUsername <> "" Then
                SicilList.Items.Clear()

                Dim BEYAZGRP As String = ConfigurationManager.AppSettings("BEYAZGRP")
                Dim BEYAZYTK As String = ConfigurationManager.AppSettings("BEYAZYTK")
                If BEYAZGRP Is Nothing Then BEYAZGRP = ""
                If BEYAZYTK Is Nothing Then BEYAZYTK = ""

                Dim KullaniciPasif As Boolean = False
                Dim RSQL As New SqlForConnection

                Dim _strquery = " SELECT TOP 1 Per_PersNr, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, WinLogon, isnull(Aktif,0) AS Aktif,  "
                _strquery += " isnull((SELECT TOP 1 isnull(YetkiNo,'999') AS YetkiNo FROM BoschYetki WHERE (',' + EmpSubGrp +',' LIKE '%,' + CASE WHEN isnull(Per_Grp2,'')='' THEN '' ELSE Per_Grp2 END + ',%') AND EmpSubGrp<>''),'' ) AS Ytk1,isnull((SELECT TOP 1 isnull(YetkiNo,'999') AS YetkiNo FROM BoschYetki WHERE (',' + CorpFunc +',' LIKE '%,'  + CASE WHEN isnull(Per_Grp6,'')='' THEN '' ELSE Per_Grp6 END + ',%') AND CorpFunc<>''),'' )  AS Ytk2,isnull((SELECT TOP 1 isnull(YetkiNo,'999') AS YetkiNo FROM BoschYetki WHERE (',' + CounSPField +','  LIKE '%,' + CASE WHEN isnull(Per_Grp7,'')='' THEN '' ELSE Per_Grp7 END + ',%') AND  CounSPField<>''),'' ) AS Ytk3  "
                _strquery += " FROM BoschPerTab WHERE UPPER(CAST(WinLogon AS nvarchar) COLLATE SQL_Latin1_General_CP1_CI_AS)=@Userid "

                Dim mTable As DataTable = RSQL.GetValue(_strquery, {New SqlParameter("@Userid", RmvTrChr(UCase(WinUsername)))})
                If mTable.Rows.Count > 0 Then
                    If mTable.Rows(0)!Aktif > 0 Then
                        Dim Yetki As String = 0
                        Dim Kendisi As String = 0
                        Dim pTable As DataTable = RSQL.GetValue("SELECT Userid, isnull(Durumu,0) AS Durumu FROM BoschUsers WHERE PerPersNr=@Userid ", {New SqlParameter("@Userid", mTable.Rows(0)!Per_PersNr)})
                        If pTable.Rows.Count > 0 Then
                            For Each Satir In pTable.Rows
                                If Satir!Durumu > 0 Then
                                    SicilList.Items.Add(Satir!Userid)
                                End If
                            Next

                            If SicilList.Items.Count = 0 Then
                                Label3.Text = "Kullanıcı pasif durumda! Kullanıcı adı : '" & WinUsername & "'"
                            Else
                                SicilList.SelectedIndex = 0
                                SicilList.Visible = True
                                Devam.Visible = True
                            End If

                            Dim pParametre(1) As SqlParameter

                            '0 nolu yetki "Sadece Kendisi" olarak ayılıyor. Yönetici ve Sadece kendi  yetkileri aynı Per_Grp2  alanından kontrol edildiğinden dolayı. 
                            If mTable.Rows(0)!Ytk1 <> "" And mTable.Rows(0)!Ytk1 <> "8" Then
                                Yetki = mTable.Rows(0)!Ytk1
                            ElseIf mTable.Rows(0)!Ytk2 <> "" Then
                                Yetki = mTable.Rows(0)!Ytk2
                            ElseIf mTable.Rows(0)!Ytk3 <> "" Then
                                Yetki = mTable.Rows(0)!Ytk3
                            ElseIf mTable.Rows(0)!Ytk1 <> "" And mTable.Rows(0)!Ytk1 = "8" Then
                                Yetki = mTable.Rows(0)!Ytk1
                            End If

                            If Yetki > 0 Then
                                'Eğer Boschusersa da yetki alanı 1,5,6,7 ise otomtik yetkilendirme olmayacak, update etmeyecektir
                                'Kullanıcı varsa güncelle
                                pParametre(0) = New SqlParameter("@Userid", mTable.Rows(0)!Per_PersNr.ToString())
                                pParametre(1) = New SqlParameter("@PerYetki", Yetki)
                                If RSQL.RunSQL("UPDATE BoschUsers SET PerYetki=@PerYetki WHERE Userid=@Userid  AND PerYetki NOT IN('1','5','6','7') ", pParametre) Then
                                    'SicilList.Items.Add(mTable.Rows(0)!Per_PersNr)
                                    SicilList.SelectedIndex = 0
                                    SicilList.Visible = True
                                    Devam.Visible = True
                                Else
                                    'Label3.Text = "Kullanıcı kaydı güncellenemedi"
                                End If
                            Else
                                Label3.Text = "Kullanıcı yetki tipi güncellenemedi!"
                            End If
                        Else
                            Dim pParametre(4) As SqlParameter
                            '0 nolu yetki "Sadece Kendisi" olarak ayılıyor. Yönetici ve Sadece kendi  yetkileri aynı Per_Grp2  alanından kontrol edildiğinden dolayı. 
                            If mTable.Rows(0)!Ytk1 <> "" And mTable.Rows(0)!Ytk1 <> "8" Then
                                Yetki = mTable.Rows(0)!Ytk1
                            ElseIf mTable.Rows(0)!Ytk2 <> "" Then
                                Yetki = mTable.Rows(0)!Ytk2
                            ElseIf mTable.Rows(0)!Ytk3 <> "" Then
                                Yetki = mTable.Rows(0)!Ytk3
                            ElseIf mTable.Rows(0)!Ytk1 <> "" And mTable.Rows(0)!Ytk1 = "8" Then
                                Yetki = mTable.Rows(0)!Ytk1
                            End If

                            If Yetki > 0 Then
                                If Yetki = 4 Then
                                    Kendisi = 1
                                End If

                                pParametre(0) = New SqlParameter("@Userid", mTable.Rows(0)!Per_PersNr)
                                pParametre(1) = New SqlParameter("@Username", mTable.Rows(0)!AdSoyad)
                                pParametre(2) = New SqlParameter("@PerPersNr", mTable.Rows(0)!Per_PersNr)
                                pParametre(3) = New SqlParameter("@PerYetki", Yetki)
                                pParametre(4) = New SqlParameter("@Kendisi", Kendisi)
                                If RSQL.RunSQL("INSERT INTO BoschUsers (Userid, Username, PerYetki, Durumu, UUserid, UDate, PerPersNr, Kendisi) VALUES (@Userid, @Username, @PerYetki, 1, 'OTOMATIK', GETDATE(), @PerPersNr, @Kendisi)", pParametre) Then
                                    SicilList.Items.Add(mTable.Rows(0)!Per_PersNr)
                                    SicilList.SelectedIndex = 0
                                    SicilList.Visible = True
                                    Devam.Visible = True
                                Else
                                    Label3.Text = "Kullanıcı kaydı oluşturulamadı!"
                                End If
                            Else
                                Label3.Text = "Kullanıcı yetki tipi oluşturulamadı!"
                            End If
                        End If
                    Else
                        Label3.Text = "Personel kaydı pasif! Sicil No : " & mTable.Rows(0)!Per_PersNr & " Kullanıcı adı : '" & WinUsername & "'"
                    End If
                Else
                    Dim mTable1 As DataTable = RSQL.GetValue("SELECT Userid, isnull(Durumu,0) AS Durumu FROM BoschUsers WHERE Extern=1 AND Userid=@Userid AND @Userid<>''", {New SqlClient.SqlParameter("@Userid", RmvTrChr(UCase(WinUsername)))})
                    If mTable1.Rows.Count > 0 Then
                        SicilList.Items.Add(mTable1.Rows(0)!Userid)
                        SicilList.SelectedIndex = 0
                        SicilList.Visible = True
                        Devam.Visible = True
                    Else
                        Label3.Text = "Kullanıcı kaydı bulunamadı. Kullanıcı adı : '" & WinUsername & "'"
                    End If
                End If
                RSQL.ConnDbClose()
            Else
                Label3.Text = "Windows kullanıcı adı alınamadı! Anonymous Auhentication=disable olmalı!"
            End If
        End If
    End Sub

    Protected Sub Devam_Click(sender As Object, e As EventArgs) Handles Devam.Click
        Dim RSQL As New SqlForConnection
        Dim PrmText As String = ""
        Session("Kayitlar") = ""
        PrmText = SicilList.SelectedItem.ToString
        Dim mTable As DataTable = RSQL.GetValue("SELECT BoschUsers.PerYetki,isnull(BoschUsers.Userid,'') AS Userid, isnull(username,'') AS username, isnull(Yetkisi,'0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000') AS PerYetki1, isnull(YetkiTipi,7) AS YetkiTipi, isnull(Kendisi,0) AS Kendisi, isnull(Durumu,0) AS Durumu, isnull(Per_Grp5,'') AS OrgUnit, isnull(PerList,'') AS PerList, isnull(REmpSubGrp,'') AS REmpSubGrp, isnull(PerPersNr,'') AS PerPersNr FROM BoschUsers LEFT JOIN BoschYetki ON PerYetki=YetkiNo LEFT JOIN BoschPerTab ON PerPersNr=Per_PersNr WHERE BoschUsers.Userid=@Sicilno AND @SicilNo<>''", {New SqlClient.SqlParameter("@SicilNo", PrmText)})

        If mTable.Rows.Count > 0 Then
            If mTable.Rows(0)!Durumu = 1 Then
                Session("PersNr") = mTable.Rows(0)!Userid
                Session("PersName") = mTable.Rows(0)!UserName
                Session("UDate") = Format(Now, "dd.MM.yyyy HH:mm")
                Session("PerPersNr") = IIf(mTable.Rows(0)!PerPersNr = "", "0", mTable.Rows(0)!PerPersNr)
                Session("PerMYetki") = mTable.Rows(0)!PerYetki1
                Session("PerTipi") = mTable.Rows(0)!YetkiTipi
                Session("Kendisi") = mTable.Rows(0)!Kendisi
                Session("OrgUnit") = mTable.Rows(0)!OrgUnit
                Session("PerList") = mTable.Rows(0)!PerList
                Session("REmpSubGrp") = mTable.Rows(0)!REmpSubGrp
                Session("YetkiNo") = mTable.Rows(0)!PerYetki
                Me.Response.Redirect("~/FMainPage2.aspx")
            Else
                Label3.Text = "Kullanıcı pasif edilmiş."
            End If
        Else
            Label3.Text = "Kullanıcı kaydı bulunamadı."
        End If
    End Sub

End Class
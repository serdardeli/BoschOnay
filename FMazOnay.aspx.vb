Imports Telerik.Web.UI

Public Class FMazOnay
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")

            BasTar.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Dim AyBasi As Date = New Date(Now.Year, Now.Month, 1)
            Dim Aysonu As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, AyBasi))

            BasTar.SelectedDate = AyBasi
            BitTar.SelectedDate = Aysonu

            If RadGrid1.MasterTableView.Items.Count > 0 Then
                BOnayla.Visible = True
                BReddet.Visible = True
                BTemizle.Visible = True
                BKaydet.Visible = True
            Else
                BOnayla.Visible = False
                BReddet.Visible = False
                BTemizle.Visible = False
                BKaydet.Visible = False
            End If
        End If
    End Sub

    Protected Sub Onayla_Click(sender As Object, e As ImageClickEventArgs) Handles BOnayla.Click
        For Each Satir As GridDataItem In RadGrid1.SelectedItems
            Satir("Onay").Text = "Onaylandı"
            Satir("OAciklama").Text = OnayText.Text
        Next
    End Sub

    Protected Sub Reddet_Click(sender As Object, e As ImageClickEventArgs) Handles BReddet.Click
        For Each Satir As GridDataItem In RadGrid1.SelectedItems
            Satir("Onay").Text = "Rededildi"
            Satir("OAciklama").Text = OnayText.Text
        Next
    End Sub

    Protected Sub Yenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim RSQL As New SqlForConnection
        'RadGrid1.DataSource = RSQL.GetValue(" SELECT IdNr, isnull(SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, Tarih, BasTar, Bittar, Sure, CASE WHEN GTipi=0 THEN 'TG' WHEN GTipi=1 THEN 'YGÖÖ'  WHEN GTipi=2 THEN 'YGOS' ELSE 'Belirsiz' END AS GunTipi, '' AS Onay, Kodu, Aciklama, '' AS OAciklama,CASE WHEN AvansOK=1 THEN 'Evet' ELSE '' END Avans FROM BoschOnay INNER JOIN BoschPerTab ON Sicilno=Per_PersNr WHERE Tarih>=@BasTar AND Tarih<=@BitTar AND Durumu=0 AND Tipi=0 AND AktarimOK is null AND SicilNo IN (" & Session("Secilen") & ") ORDER BY SicilNo, Tarih ", {New SqlParameter("@BasTar", BasTar.SelectedDate.Value), New SqlParameter("@BitTar", BitTar.SelectedDate.Value)})
        Dim _query = " SELECT BoschOnay.IdNr, isnull(SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, BoschOnay.Tarih, BasTar, Bittar, Sure, CASE WHEN GTipi=0 THEN 'TG' WHEN GTipi=1 THEN 'YGÖÖ'  WHEN GTipi=2 THEN 'YGOS' ELSE 'Belirsiz' END AS GunTipi, '' AS Onay, BoschOnay.Kodu, BoschOnay.Aciklama, '' AS OAciklama,CASE WHEN AvansOK=1 THEN 'Evet' ELSE '' END Avans  FROM BoschOnay INNER JOIN BoschPerTab ON Sicilno=Per_PersNr JOIN  BoschLimit WITH (NOLOCK)  ON BoschLimit.Kodu=BoschPerTab.Per_Grp0 AND BoschPerTab.Per_Grp3=BoschLimit.Kodu2 WHERE BoschLimit.Tarih<=BoschOnay.Bastar AND BoschOnay.Tarih>=@BasTar AND BoschOnay.Tarih<=@BitTar AND  Durumu=0 AND Tipi=0 AND AktarimOK is null AND SicilNo IN (" & Session("Secilen") & ")  ORDER BY SicilNo, BoschOnay.Tarih "
        RadGrid1.DataSource = RSQL.GetValue(_query, {New SqlParameter("@BasTar", BasTar.SelectedDate.Value), New SqlParameter("@BitTar", BitTar.SelectedDate.Value)})
        RadGrid1.Rebind()
        If RadGrid1.MasterTableView.Items.Count > 0 Then
            BOnayla.Visible = True
            BReddet.Visible = True
            BTemizle.Visible = True
            BKaydet.Visible = True
        Else
            BOnayla.Visible = False
            BReddet.Visible = False
            BTemizle.Visible = False
            BKaydet.Visible = False
        End If
    End Sub

    Protected Sub Temizle_Click(sender As Object, e As ImageClickEventArgs) Handles BTemizle.Click
        For Each Satir As GridDataItem In RadGrid1.SelectedItems
            Satir("Onay").Text = ""
            Satir("OAciklama").Text = ""
        Next
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim RSQL As New SqlForConnection
        Dim KayitNOK As Integer = 0
        Dim BarkodFiltre As String = ""
        Dim _yapilan = ""

        For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
            If Satir("Onay").Text = "Onaylandı" Or Satir("Onay").Text = "Rededildi" Then
                _yapilan += IIf(_yapilan = "", "Id No:" & Satir("IdNr").Text & ", Durumu:" & Satir("Onay").Text & ", Açıklama:" & Satir("OAciklama").Text, " | Id No:" & Satir("IdNr").Text & ", Durumu:" & Satir("Onay").Text & ", Açıklama:" & Satir("OAciklama").Text)
                Dim mParam(3) As SqlParameter
                mParam(0) = New SqlParameter("@IdNr", Satir("IdNr").Text)
                mParam(1) = New SqlParameter("@Userid", Session("PersNr"))
                mParam(2) = New SqlParameter("@Onay", IIf(Satir("Onay").Text = "Onaylandı", 1, 2))
                mParam(3) = New SqlParameter("@Aciklama", Satir("OAciklama").Text)
                If Not RSQL.RunSQL("UPDATE BoschOnay SET Userid=@Userid, UDate=GETDATE(), Durumu=@Onay, OAciklama=@Aciklama WHERE IdNr=@IdNr", mParam) Then
                    KayitNOK = KayitNOK + 1
                End If
            End If
            If BarkodFiltre = "" Then
                BarkodFiltre = Satir("IdNr").Text
            Else
                BarkodFiltre = BarkodFiltre & "," & Satir("IdNr").Text
            End If
        Next

        'Kullanıcı Log İşlemleri
        Dim logParam(4) As SqlParameter
        logParam(0) = New SqlParameter("@ModulNo", "M25")
        logParam(1) = New SqlParameter("@Uygulama", "1")
        logParam(2) = New SqlParameter("@Userid", Session("PersNr"))
        logParam(3) = New SqlParameter("@Tipi", 1) ' 0:Ekleme , 1:Değiştirme , 2:Silme
        logParam(4) = New SqlParameter("@Yapilan", _yapilan)
        RSQL.AddLog(logParam)

        RadGrid1.DataSource = RSQL.GetValue("SELECT IdNr, isnull(SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, Tarih, BasTar, Bittar, Sure, CASE WHEN GTipi=0 THEN 'TG' WHEN GTipi=1 THEN 'YGÖÖ'  WHEN GTipi=2 THEN 'YGOS' END AS GunTipi, '' AS Onay, Kodu, Aciklama, '' AS OAciklama,CASE WHEN AvansOK=1 THEN 'Evet' ELSE '' END Avans FROM BoschOnay INNER JOIN BoschPerTab ON Sicilno=Per_PersNr WHERE Durumu=0 AND Tipi=0 AND AktarimOK is null AND IdNr IN (" & BarkodFiltre & ") ORDER BY SicilNo, Tarih")
        RadGrid1.Rebind()
        If RadGrid1.MasterTableView.Items.Count > 0 Then
            BOnayla.Visible = True
            BReddet.Visible = True
            BTemizle.Visible = True
            BKaydet.Visible = True
        Else
            BOnayla.Visible = False
            BReddet.Visible = False
            BTemizle.Visible = False
            BKaydet.Visible = False
        End If
    End Sub

    Protected Sub BarkodAl_Click(sender As Object, e As ImageClickEventArgs) Handles BarkodAl.Click
        Barkods.Text = ""
        BarMess.Text = ""
        Dim script As String = "function f(){$find(""" + RadWindow2.ClientID + """).show(); Sys.Application.remove_load(f);} Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub

    Protected Sub KabulEt_Click(sender As Object, e As ImageClickEventArgs) Handles KabulEt.Click
        If Barkods.Text.Trim() = "" Then
            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "alert('Sorgulama için barkod girmelisiniz!');", True)

            BarMess.Text = "Sorgulama için barkod girmelisiniz!"
            Dim script As String = "function f(){$find(""" + RadWindow2.ClientID + """).show(); Sys.Application.remove_load(f);} Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            Return
        End If

        Dim Barkodlar() As String = Barkods.Text.Replace(vbLf, "").Split(vbCr)
        Dim BarkodFiltre As String = ""
        Dim BarkodKodu As Long = 0L
        For Each Satir As String In Barkodlar
            If Mid(Satir, 1, 1) = "4" And Satir.Length = 13 Then
                Try
                    If BarkodFiltre = "" Then
                        BarkodFiltre = CLng(Mid(Satir, 2, 11)).ToString
                    Else
                        BarkodFiltre = BarkodFiltre & "," & CLng(Mid(Satir, 2, 11)).ToString
                    End If
                Catch ex As Exception
                    BarMess.Text = ex.Message
                End Try
            End If
        Next
        If BarkodFiltre <> "" Then
            Dim RSQL As New SqlForConnection
            RadGrid1.DataSource = RSQL.GetValue("SELECT IdNr, isnull(SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, Tarih, BasTar, Bittar, Sure, CASE WHEN GTipi=0 THEN 'TG' WHEN GTipi=1 THEN 'YGÖÖ'  WHEN GTipi=2 THEN 'YGOS' END AS GunTipi, '' AS Onay, Kodu, Aciklama, '' AS OAciklama,CASE WHEN AvansOK=1 THEN 'Evet' ELSE '' END Avans FROM BoschOnay INNER JOIN BoschPerTab ON Sicilno=Per_PersNr WHERE Durumu=0 AND Tipi=0 AND AktarimOK is null AND IdNr IN (" & BarkodFiltre & ") ORDER BY SicilNo, Tarih")
            RadGrid1.Rebind()
            If RadGrid1.MasterTableView.Items.Count > 0 Then
                BOnayla.Visible = True
                BReddet.Visible = True
                BTemizle.Visible = True
                BKaydet.Visible = True
            Else
                BOnayla.Visible = False
                BReddet.Visible = False
                BTemizle.Visible = False
                BKaydet.Visible = False
            End If
        Else
            BarMess.Text = "Sorgulamaya uygun barkod bulunamadı!"
            Dim script As String = "function f(){$find(""" + RadWindow2.ClientID + """).show(); Sys.Application.remove_load(f);} Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        End If
    End Sub

End Class
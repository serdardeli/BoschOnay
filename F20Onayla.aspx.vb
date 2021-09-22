Imports Telerik.Web.UI

Public Class F20Onayla
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")

            BasTar.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Dim AyBasi As Date = New Date(Now.Year, Now.Month, 1)
            Dim Aysonu As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, AyBasi))

            BasTar.SelectedDate = AyBasi
            BitTar.SelectedDate = Aysonu

            Dim RSQL As New SqlForConnection
            RadGrid1.DataSource = RSQL.GetValue("SELECT TabloA.IdNr, isnull(TabloA.SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, TabloA.Tarih, TabloA.Baslangic, TabloA.Bitis, TabloA.Sure, '' AS Onay, '' AS Aciklama FROM BoschFMOnay AS TabloA INNER JOIN BoschPerTab ON TabloA.Sicilno=Per_PersNr  JOIN  BoschLimit WITH (NOLOCK)  ON BoschLimit.Kodu=BoschPerTab.Per_Grp0 AND BoschPerTab.Per_Grp3=BoschLimit.Kodu2 WHERE  isnull(TabloA.iptal,0)<>1  And TabloA.Tarih BETWEEN BoschLimit.OnayBasTar And BoschLimit.OnayBitTar AND  TabloA.Tarih>=@BasTar AND TabloA.Tarih<=@BitTar AND TabloA.Onay is null AND TabloA.FMTipi=2 AND TabloA.SicilNo IN (" & Session("Secilen") & ") AND EXISTS(SELECT TabloB.Sicilno FROM BoschFMOnay AS TabloB WHERE TabloB.SicilNo=TabloA.SicilNo AND TabloB.Tarih=TabloA.Tarih AND TabloB.FMTipi=1 AND TabloB.Sure=TabloA.Sure AND TabloB.Onay=0) ORDER BY TabloA.SicilNo, TabloA.Tarih", {New SqlParameter("@BasTar", BasTar.SelectedDate.Value), New SqlParameter("@BitTar", BitTar.SelectedDate.Value)})
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
        End If
    End Sub

    Protected Sub Onayla_Click(sender As Object, e As ImageClickEventArgs) Handles BOnayla.Click
        For Each Satir As GridDataItem In RadGrid1.SelectedItems
            Satir("Onay").Text = "Onaylandı"
            Satir("Aciklama").Text = OnayText.Text
        Next
    End Sub

    Protected Sub Reddet_Click(sender As Object, e As ImageClickEventArgs) Handles BReddet.Click
        For Each Satir As GridDataItem In RadGrid1.SelectedItems
            Satir("Onay").Text = "Rededildi"
            Satir("Aciklama").Text = OnayText.Text
        Next
    End Sub
    Protected Sub Yenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim RSQL As New SqlForConnection
        RadGrid1.DataSource = RSQL.GetValue("SELECT TabloA.IdNr, isnull(TabloA.SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, TabloA.Tarih, TabloA.Baslangic, TabloA.Bitis, TabloA.Sure, '' AS Onay, '' AS Aciklama FROM BoschFMOnay AS TabloA INNER JOIN BoschPerTab ON TabloA.Sicilno=Per_PersNr  JOIN  BoschLimit WITH (NOLOCK)  ON BoschLimit.Kodu=BoschPerTab.Per_Grp0 AND BoschPerTab.Per_Grp3=BoschLimit.Kodu2 WHERE  isnull(TabloA.iptal,0)<>1  And TabloA.Tarih BETWEEN BoschLimit.OnayBasTar And BoschLimit.OnayBitTar AND  TabloA.Tarih>=@BasTar AND TabloA.Tarih<=@BitTar AND TabloA.Onay is null AND TabloA.FMTipi=2 AND TabloA.SicilNo IN (" & Session("Secilen") & ") AND EXISTS(SELECT TabloB.Sicilno FROM BoschFMOnay AS TabloB WHERE TabloB.SicilNo=TabloA.SicilNo AND TabloB.Tarih=TabloA.Tarih AND TabloB.FMTipi=1 AND TabloB.Sure=TabloA.Sure AND TabloB.Onay=0) ORDER BY TabloA.SicilNo, TabloA.Tarih", {New SqlParameter("@BasTar", BasTar.SelectedDate.Value), New SqlParameter("@BitTar", BitTar.SelectedDate.Value)})
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
            Satir("Aciklama").Text = ""
        Next
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim RSQL As New SqlForConnection
        Dim KayitNOK As Integer = 0
        For Each Satir As GridDataItem In RadGrid1.MasterTableView.Items
            If Satir("Onay").Text = "Onaylandı" Or Satir("Onay").Text = "Rededildi" Then
                Dim mParam(3) As SqlParameter
                mParam(0) = New SqlParameter("@IdNr", Satir("IdNr").Text)
                mParam(1) = New SqlParameter("@Userid", Session("PersNr"))
                mParam(2) = New SqlParameter("@Onay", IIf(Satir("Onay").Text = "Onaylandı", 0, 1))
                mParam(3) = New SqlParameter("@Aciklama", Satir("Aciklama").Text)
                If Not RSQL.RunSQL("UPDATE BoschFMOnay SET Userid=@Userid, UDate=GETDATE(), Onay=@Onay, Aciklama=@Aciklama WHERE IdNr=@IdNr", mParam) Then
                    KayitNOK = KayitNOK + 1
                End If
            End If
        Next
        RadGrid1.DataSource = RSQL.GetValue("SELECT TabloA.IdNr, isnull(TabloA.SicilNo,0) AS SicilNo, isnull(Adi,'') + ' ' + isnull(Soyadi,'') AS AdSoyad, isnull(Per_Grp4,'') AS MasrafYeri, TabloA.Tarih, TabloA.Baslangic, TabloA.Bitis, TabloA.Sure, '' AS Onay, '' AS Aciklama FROM BoschFMOnay AS TabloA INNER JOIN BoschPerTab ON TabloA.Sicilno=Per_PersNr  JOIN  BoschLimit WITH (NOLOCK)  ON BoschLimit.Kodu=BoschPerTab.Per_Grp0 AND BoschPerTab.Per_Grp3=BoschLimit.Kodu2 WHERE  isnull(TabloA.iptal,0)<>1  And TabloA.Tarih BETWEEN BoschLimit.OnayBasTar And BoschLimit.OnayBitTar AND  TabloA.Tarih>=@BasTar AND TabloA.Tarih<=@BitTar AND TabloA.Onay is null AND TabloA.FMTipi=2 AND TabloA.SicilNo IN (" & Session("Secilen") & ") AND EXISTS(SELECT TabloB.Sicilno FROM BoschFMOnay AS TabloB WHERE TabloB.SicilNo=TabloA.SicilNo AND TabloB.Tarih=TabloA.Tarih AND TabloB.FMTipi=1 AND TabloB.Sure=TabloA.Sure AND TabloB.Onay=0) ORDER BY TabloA.SicilNo, TabloA.Tarih", {New SqlParameter("@BasTar", BasTar.SelectedDate.Value), New SqlParameter("@BitTar", BitTar.SelectedDate.Value)})
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

End Class
Public Class FBoschRapor01
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            BasTar.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Dim AyBasi As Date = New Date(Now.Year, Now.Month, 1)
            Dim Aysonu As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, AyBasi))

            BasTar.SelectedDate = AyBasi
            BitTar.SelectedDate = Aysonu
            OBaslangic.SelectedDate = AyBasi
            OBitis.SelectedDate = Aysonu
        End If

    End Sub

    Private Sub RaporGoster_PreRender(sender As Object, e As EventArgs) Handles RaporGoster.PreRender
        Dim MyReport As New BoschRapor01
        MyReport.ReportParameters("Filtre").Value = Format(BasTar.SelectedDate, "dd.MM.yyyy") & " - " & Format(BitTar.SelectedDate, "dd.MM.yyyy") & " " & RaporTipi.Text
        MyReport.ReportParameters("RaporAdi").Value = BBaslik.Text

        Dim SqlStr As String = ""
        SqlStr = "SELECT DISTINCT SicilNo, isnull(Adi,'') AS Adi, isnull(Soyadi,'') AS Soyadi, Tarih, isnull(Baslangic,0) AS Giris, isnull(Bitis,0) AS Cikis, isnull(Per_Grp4,'') AS MasrafYeri, isnull(Sure,0.00) AS Sure, isnull(Userid,'') AS Onaylayan, UDate AS OnayZaman, isnull(Onay,3) AS TEe_Status, isnull(Aciklama,'') AS Aciklama, isnull(AktarimOK,0) AS AktarimOK "
        SqlStr = SqlStr & "FROM BoschFMOnay INNER JOIN BoschPerTab ON SicilNo = Per_PersNr "
        SqlStr = SqlStr & "WHERE  isnull(BoschFMOnay.iptal,0)<>1 AND FMTipi=1 AND (Tarih >= CONVERT(datetime, '" & BasTar.SelectedDate & "',104)) AND (Tarih <= CONVERT(datetime, '" & BitTar.SelectedDate & "',104)) AND "
        SqlStr = SqlStr & "((DATEADD(dd, 0, DATEDIFF(dd, 0, UDate)) >= CONVERT(datetime, '" & OBaslangic.SelectedDate & "',104)) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, UDate)) <= CONVERT(datetime, '" & OBitis.SelectedDate & "',104)) OR UDate IS NULL) AND "
        SqlStr = SqlStr & "('," & Session("Secilen") & ",' LIKE '%,' + CAST(SicilNo AS nvarchar) + ',%') "

        Select Case RaporTipi.SelectedIndex
            Case 1
                SqlStr = SqlStr & " AND Onay=0 "
            Case 2
                SqlStr = SqlStr & " AND Onay=1 "
            Case 3
                SqlStr = SqlStr & " AND Onay IS NULL "
        End Select

        SqlStr = SqlStr & "ORDER BY SicilNo, Tarih"

        MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
        MyReport.SqlDataSource1.SelectCommand = SqlStr
        Dim InsReports As New Telerik.Reporting.InstanceReportSource
        InsReports.ReportDocument = MyReport
        RaporGoster.ReportSource = InsReports
        RaporGoster.RefreshReport()
    End Sub

End Class
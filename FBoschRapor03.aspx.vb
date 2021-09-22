Public Class FBoschRapor03
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            BasTar.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Dim AyBasi As Date = New Date(Now.Year, Now.Month, 1)
            Dim Aysonu As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, AyBasi))

            BasTar.SelectedDate = AyBasi
            BitTar.SelectedDate = Aysonu
        End If
    End Sub

    Private Sub RaporGoster_PreRender(sender As Object, e As EventArgs) Handles RaporGoster.PreRender
        Dim RSQL As New SqlForConnection
        Dim GrpName00 As String = ""
        Dim GrpName01 As String = ""
        Dim GrpName02 As String = ""
        Dim GrpName03 As String = ""
        Dim GrpName04 As String = ""
        Dim mTable As DataTable = RSQL.GetValue("SELECT isnull(GrpName00,'') AS GrpName00, isnull(GrpName01,'') AS GrpName01, isnull(GrpName02,'') AS GrpName02, isnull(GrpName03,'') AS GrpName03, isnull(GrpName04,'') AS GrpName04 FROM BoschLisans")
        If mTable.Rows.Count > 0 Then
            GrpName00 = mTable.Rows(0)!GrpName00
            GrpName01 = mTable.Rows(0)!GrpName01
            GrpName02 = mTable.Rows(0)!GrpName02
            GrpName03 = mTable.Rows(0)!GrpName03
            GrpName04 = mTable.Rows(0)!GrpName04
        End If
        Dim MyReport As New BoschRapor03
        MyReport.ReportParameters("RaporAdi").Value = BBaslik.Text
        MyReport.ReportParameters("Filtre").Value = Format(BasTar.SelectedDate, "dd.MM.yyyy") & " - " & Format(BitTar.SelectedDate, "dd.MM.yyyy") & " " & RaporTipi.Text
        MyReport.ReportParameters("Grp0").Value = GrpName00
        MyReport.ReportParameters("Grp1").Value = GrpName01
        MyReport.ReportParameters("Grp2").Value = GrpName02
        MyReport.ReportParameters("Grp3").Value = GrpName03
        MyReport.ReportParameters("Grp4").Value = GrpName04

        Dim SqlStr As String = ""

        SqlStr = "Select SicilNo, isnull(adi,'') AS Adi, isnull(Soyadi,'') AS Soyadi, Per_Grp5 AS Kisim, Per_Grp0, Per_Grp1, Per_Grp2, Per_Grp3, Per_Grp4, Tarih, BasTar, BitTar, Sure, isnull(Aciklama,'') AS Aciklama, AvansOK, Vekil, VekilKisim, Durumu,BoschOnay.TUserid AS TUserid,Userid, UDate, isnull(AktarimOK,0) AS AktarimOK,(CASE WHEN GTipi=0 THEN 'TG' WHEN GTipi=1 THEN 'ÖÖ' WHEN GTipi=2 THEN 'ÖS' ELSE '' END)AS Tipi,CASE WHEN AvansOK=1 THEN 'Evet' ELSE '' END Avans FROM BoschOnay INNER JOIN BoschPerTab ON Sicilno=Per_PersNr "
        SqlStr = SqlStr & "WHERE Tipi=0 AND Tarih>= CONVERT(datetime, '" & BasTar.SelectedDate & "',104) AND Tarih<= CONVERT(datetime, '" & BitTar.SelectedDate & "',104) AND "
        SqlStr = SqlStr & "('," & Session("Secilen") & ",' LIKE '%,' + CAST(SicilNo AS nvarchar) + ',%') "

        Select Case RaporTipi.SelectedIndex
            Case 1
                SqlStr = SqlStr & " AND Durumu=1 "
            Case 2
                SqlStr = SqlStr & " AND Durumu=2 "
            Case 3
                SqlStr = SqlStr & " AND Durumu=0 "
        End Select

        SqlStr = SqlStr & "ORDER BY Per_Grp5, SicilNo, Tarih"

        MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
        MyReport.SqlDataSource1.SelectCommand = SqlStr

        Dim InsReports As New Telerik.Reporting.InstanceReportSource
        InsReports.ReportDocument = MyReport
        RaporGoster.ReportSource = InsReports
        RaporGoster.RefreshReport()
    End Sub

End Class
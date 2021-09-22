Public Class FBoschRapor04
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BBaslik.Text = Request("Baslik")
        End If
    End Sub

    Private Sub RaporGoster_PreRender(sender As Object, e As EventArgs) Handles RaporGoster.PreRender
        Dim MyReport As New BoschRapor04
        MyReport.ReportParameters("RaporAdi").Value = BBaslik.Text
        MyReport.ReportParameters("Filtre").Value = Now.Year.ToString
        MyReport.ReportParameters("SicilList").Value = "," & Session("Secilen") & ","
        MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
        Dim InsReports As New Telerik.Reporting.InstanceReportSource
        InsReports.ReportDocument = MyReport
        RaporGoster.ReportSource = InsReports
        RaporGoster.RefreshReport()
    End Sub

End Class
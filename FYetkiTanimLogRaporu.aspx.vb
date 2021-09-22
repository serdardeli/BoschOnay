Imports Microsoft.Reporting.WebForms
Imports Telerik.Web.UI

Public Class FYetkiTanimLogRaporu
    Inherits System.Web.UI.Page

    Private _sql As New SqlForConnection()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            Dim _yetki = "SELECT YetkiNo,YetkiAdi FROM BoschYetki ORDER BY YetkiNo"
            Dim _myetkidata = _sql.GetValue(_yetki)
            ryetki.DataSource = _myetkidata
            ryetki.DataTextField = "YetkiAdi"
            ryetki.DataValueField = "YetkiNo"
            ryetki.DataBind()

            Dim _yetkirmenurkullanici = "SELECT Userid,Username  FROM BoschUsers ORDER BY Username "
            Dim _myetkidatarmenurkullanici = _sql.GetValue(_yetkirmenurkullanici)
            rkullanici.DataSource = _myetkidatarmenurkullanici
            rkullanici.DataTextField = "Username"
            rkullanici.DataValueField = "Userid"
            rkullanici.DataBind()

            BasTar.SelectedDate = Now
            BitTar.SelectedDate = Now
        End If
    End Sub

    Protected Sub BYenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim _query = " SELECT BoschYetkiLog.YetkiNo AS Kodu,BoschYetki.YetkiAdi AS YetkiTanimi,BoschYetkiLog.DegisenAlan,BoschYetkiLog.Eskiveri,BoschYetkiLog.YeniVeri,BoschYetkiLog.Tarih AS Degisikliktarihi,BoschUsers.Username as DegisiklikYapan,BoschYetki.YetkiAdi AS Degisiklikyapanyetkisi FROM BoschYetkiLog WITH (NOLOCK) JOIN BoschUsers ON BoschUsers.Userid=BoschYetkiLog.Kullanici JOIN BoschYetki WITH (NOLOCK)  ON BoschYetki.YetkiNo=BoschUsers.PerYetki WHERE BoschYetkiLog.Tarih>@Tarih AND BoschYetkiLog.Tarih<@Tarih1  "

        Dim _rfunction = ""
        Dim collection1 As IList(Of RadComboBoxItem) = ryetki.CheckedItems
        If (collection1.Count <> 0) Then
            For Each item As RadComboBoxItem In collection1
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND BoschYetkiLog.YetkiNo in( " & _rfunction & ") ", "")
        End If

        _rfunction = ""
        Dim collection2 As IList(Of RadComboBoxItem) = rkullanici.CheckedItems
        If (collection2.Count <> 0) Then
            For Each item As RadComboBoxItem In collection2
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND BoschYetkiLog.Kullanici in( " & _rfunction & ") ", "")
        End If

        _query += " ORDER BY BoschYetkiLog.Tarih "

        Dim _param(1) As SqlParameter
        _param(0) = New SqlParameter("@Tarih", BasTar.SelectedDate)
        _param(1) = New SqlParameter("@Tarih1", BitTar.SelectedDate)

        Dim _mydatatable = New DataTable()
        _mydatatable = _sql.GetValue(_query, _param)
        ReportViewer1.LocalReport.ReportPath = "FYetkiTanimLogRaporu.rdlc"
        Dim datasource As New ReportDataSource("DataSet1", _mydatatable)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(datasource)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class
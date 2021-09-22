Imports Microsoft.Reporting.WebForms
Imports Telerik.Web.UI

Public Class FYetkiTanimRaporu
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

            Dim _yetkirmenu = "SELECT Kodu,Baslik FROM BoschMenu WHERE Durumu=1 AND Kodu like 'M%' ORDER BY Kodu"
            Dim _myetkidatarmenu = _sql.GetValue(_yetkirmenu)
            rmenu.DataSource = _myetkidatarmenu
            rmenu.DataTextField = "Baslik"
            rmenu.DataValueField = "Kodu"
            rmenu.DataBind()

            Dim _yetkirmenurkullanici = "SELECT YetkiTipi,CASE WHEN YetkiTipi=0 THEN 'Sistem Yöneticisi' WHEN YetkiTipi=1 THEN 'Yönetici'  WHEN YetkiTipi=2 THEN 'Takım Lideri'  WHEN YetkiTipi=3 THEN 'Grupbaşı'  WHEN YetkiTipi=3 THEN 'Grupbaşı'  WHEN YetkiTipi=4 THEN 'Puantaj sorumlusu'   WHEN YetkiTipi=5 THEN 'HRL Yöneticisi'   WHEN YetkiTipi=6 THEN 'CI Yöneticisi'   WHEN YetkiTipi=7 THEN 'Kendisi'     END  AS yetkiGrubu   FROM BoschYetki ORDER BY YetkiTipi "
            Dim _myetkidatarmenurkullanici = _sql.GetValue(_yetkirmenurkullanici)
            rkullanici.DataSource = _myetkidatarmenurkullanici
            rkullanici.DataTextField = "yetkiGrubu"
            rkullanici.DataValueField = "YetkiTipi"
            rkullanici.DataBind()
        End If
    End Sub

    Protected Sub BYenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim _query = " SELECT YetkiNo,YetkiAdi, CASE WHEN YetkiTipi=0 THEN 'Sistem Yöneticisi' WHEN YetkiTipi=1 THEN 'Yönetici'  WHEN YetkiTipi=2 THEN 'Takım Lideri'  WHEN YetkiTipi=3 THEN 'Grupbaşı'  WHEN YetkiTipi=3 THEN 'Grupbaşı'  WHEN YetkiTipi=4 THEN 'Puantaj sorumlusu'   WHEN YetkiTipi=5 THEN 'HRL Yöneticisi'   WHEN YetkiTipi=6 THEN 'CI Yöneticisi'   WHEN YetkiTipi=7 THEN 'Kendisi'     END  AS yetkiGrubu,EmpSubGrp,CorpFunc,REmpSubGrp ,CounSpField,SUBSTRING(BoschMenu.Kodu,2,2) AS MenuKodu,BoschMenu.Baslik AS MenuAdi FROM BoschYetki WITH (NOLOCK) LEFT OUTER JOIN  BoschMenu WITH (NOLOCK) ON SUBSTRING(BoschYetki.Yetkisi,CAST(SUBSTRING(BoschMenu.Kodu,2,2) AS INT),2)='11'  WHERE 1=1  "

        Dim _rfunction = ""
        Dim collection1 As IList(Of RadComboBoxItem) = ryetki.CheckedItems
        If (collection1.Count <> 0) Then
            For Each item As RadComboBoxItem In collection1
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND YetkiNo in( " & _rfunction & ") ", "")
        End If

        _rfunction = ""
        Dim collection2 As IList(Of RadComboBoxItem) = rkullanici.CheckedItems
        If (collection2.Count <> 0) Then
            For Each item As RadComboBoxItem In collection2
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND YetkiTipi in( " & _rfunction & ") ", "")
        End If

        _rfunction = ""
        Dim collection3 As IList(Of RadComboBoxItem) = rmenu.CheckedItems
        If (collection3.Count <> 0) Then
            For Each item As RadComboBoxItem In collection3
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND BoschMenu.Kodu in( " & _rfunction & ") ", "")
        End If


        Dim _mydatatable = New DataTable()
        _mydatatable = _sql.GetValue(_query)
        ReportViewer1.LocalReport.ReportPath = "FYetkiTanimRaporu.rdlc"
        Dim datasource As New ReportDataSource("DataSet1", _mydatatable)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(datasource)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class
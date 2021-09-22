Imports Microsoft.Reporting.WebForms
Imports Telerik.Web.UI

Public Class KullaniciTanimRaporu
    Inherits System.Web.UI.Page

    Private _sql As New SqlForConnection()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            Dim _yetki = "SELECT distinct BoschPerTab.Per_Grp5 FROM BoschPerTab"
            Dim _myetkidata = _sql.GetValue(_yetki)
            ryetki.DataSource = _myetkidata
            ryetki.DataTextField = "Per_Grp5"
            ryetki.DataValueField = "Per_Grp5"
            ryetki.DataBind()

            Dim _yetkirmenurkullanici = "SELECT  BoschYetki.YetkiNo,BoschYetki.YetkiAdi FROM BoschYetki ORDER BY YetkiNo "
            Dim _myetkidatarmenurkullanici = _sql.GetValue(_yetkirmenurkullanici)
            rkullanici.DataSource = _myetkidatarmenurkullanici
            rkullanici.DataTextField = "YetkiAdi"
            rkullanici.DataValueField = "YetkiNo"
            rkullanici.DataBind()
        End If
    End Sub

    Protected Sub BYenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim _query = " SELECT BoschUsers.userid,Username,BoschPerTab.Per_Grp5,Kendisi,BoschYetki.YetkiAdi,BoschUsers.PerPersNr,BoschUsers.EMail,BoschUsers.Durumu,BoschUsers.Extern,BoschUsers.PerList FROM BoschUsers WITH (NOLOCK) LEFT OUTER JOIN BoschPerTab  WITH (NOLOCK) ON  CAST(BoschPerTab.Per_PersNr AS nvarchar(16))=BoschUsers.Userid LEFT OUTER JOIN BoschYetki  WITH (NOLOCK) ON BoschYetki.YetkiNo=BoschUsers.PerYetki WHERE 1=1 "

        Dim _rfunction = ""
        Dim collection1 As IList(Of RadComboBoxItem) = ryetki.CheckedItems
        If (collection1.Count <> 0) Then
            For Each item As RadComboBoxItem In collection1
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND BoschPerTab.Per_Grp5 in( " & _rfunction & ") ", "")
        End If

        _rfunction = ""
        Dim collection2 As IList(Of RadComboBoxItem) = rkullanici.CheckedItems
        If (collection2.Count <> 0) Then
            For Each item As RadComboBoxItem In collection2
                _rfunction &= IIf(_rfunction.Length > 0, ",'" + item.Value + "'", "'" + item.Value + "'")
            Next
            _query += IIf(_rfunction.Length > 0, " AND BoschYetki.YetkiNo in( " & _rfunction & ") ", "")
        End If

        Dim TmpStr As String = ""
        If FltSicilNo.Text.Trim() <> "" Then
            Dim _scl() = FltSicilNo.Text.Split(",")
            For Each _ftr As String In _scl
                TmpStr += IIf(TmpStr = "", "'" + _ftr + "'", ",'" + _ftr + "'")
            Next

            _query += " AND BoschUsers.userid IN (" & TmpStr & ")"
        End If

        TmpStr = RmvErrChr(FltAdSoyad.Text)

        If FltAdSoyad.Text <> "" Then
            _query += " AND Username LIKE '%" & TmpStr & "%'"
        End If

        If CheckBox1.SelectedIndex <> 0 Then
            _query += " AND isnull(BoschUsers.Extern,0)=" & CheckBox1.SelectedValue
        End If

        Dim _mydatatable = New DataTable()
        _mydatatable = _sql.GetValue(_query)
        ReportViewer1.LocalReport.ReportPath = "KullaniciTanimRaporu.rdlc"
        Dim datasource As New ReportDataSource("DataSet1", _mydatatable)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(datasource)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class
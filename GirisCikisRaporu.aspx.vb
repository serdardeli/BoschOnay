Imports Microsoft.Reporting.WebForms
Imports Telerik.Web.UI

Public Class GirisCikisRaporu
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            BasTar.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Dim AyBasi As Date = New Date(Now.Year, Now.Month, 1)
            Dim Aysonu As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, AyBasi))

            BasTar.SelectedDate = AyBasi
            BitTar.SelectedDate = Aysonu

            Dim RSql As New SqlForConnection

            Dim mTable As DataTable = RSql.GetValue("SELECT isnull(Mazeret,'') AS Mazeret FROM BoschRapor05 GROUP BY Mazeret ORDER BY Mazeret")

            RMazeretTipi.Items.Clear()
            RCalismaTipi.Items.Clear()

            If Not mTable Is Nothing Then
                If mTable.Rows.Count > 0 Then
                    For Each Satir In mTable.Rows
                        If Satir!Mazeret <> "" Then
                            RMazeretTipi.Items.Add(New RadComboBoxItem With {.Value = Satir!Mazeret, .Text = Satir!Mazeret, .Selected = False})
                        End If
                    Next
                End If
            End If

            If RMazeretTipi.Items.Count = 0 Then
                RMazeretTipi.Items.Add(New RadComboBoxItem With {.Value = "", .Text = "", .Selected = False})
            End If

            mTable = RSql.GetValue("SELECT isnull(Calisma,'') AS Calisma FROM BoschRapor05 GROUP BY Calisma ORDER BY Calisma")

            If Not mTable Is Nothing Then
                If mTable.Rows.Count > 0 Then
                    For Each Satir In mTable.Rows
                        If Satir!Calisma <> "" Then
                            RCalismaTipi.Items.Add(New RadComboBoxItem With {.Value = Satir!Calisma, .Text = Satir!Calisma, .Selected = False})
                        End If
                    Next
                End If
            End If

            If RCalismaTipi.Items.Count = 0 Then
                RCalismaTipi.Items.Add(New RadComboBoxItem With {.Value = "", .Text = "", .Selected = False})
            End If

        End If
    End Sub

    Protected Sub BYenile_Click(sender As Object, e As ImageClickEventArgs) Handles BYenile.Click
        Dim _query = " SELECT Sicilno, isnull(Adi,'') AS Adi, isnull(Soyadi,'') AS Soyadi, Tarih, Giris, Cikis, isnull(Mazeret,'') AS Mazeret, isnull(Calisma,'') AS Calisma, Planlanan, Gerceklesen, NormalMesai, FazlaMesai, RFazlaMesai, EsnekCalisma, isnull(SiraNo,0) AS SiraNo FROM BoschRapor05 INNER JOIN BoschPerTab ON Sicilno=Per_PersNr WHERE Tarih>=@BasTar AND Tarih<=@BitTar "
        Dim RSql As New SqlForConnection
        Dim _rfunction = "", _filtre = ""
        Dim MazKodu As String = ""
        Dim CalKodu As String = ""

        _filtre = "Tarih:" & BasTar.SelectedDate & " - " & BitTar.SelectedDate

        For Each Satir As RadComboBoxItem In RMazeretTipi.CheckedItems
            _rfunction &= IIf(_rfunction = "", "'" & Satir.Value & "'", ",'" & Satir.Value & "'")
        Next

        If _rfunction <> "" Then
            _query &= " AND Mazeret in ( " & _rfunction & " ) "
            _filtre += " , Mazeret:" & _rfunction
        End If

        _rfunction = ""

        For Each Satir As RadComboBoxItem In RCalismaTipi.CheckedItems
            _rfunction &= IIf(_rfunction = "", "'" & Satir.Value & "'", ",'" & Satir.Value & "'")
        Next

        If _rfunction <> "" Then
            _query &= " AND Calisma in ( " & _rfunction & " ) "
            _filtre += " , Çalışma Tipi:" & _rfunction
        End If

        If Session("Secilen").ToString() <> "" Then
            _query &= " AND Sicilno in ( " & Session("Secilen").ToString() & " ) "
            _filtre += " , Siciller:" & Session("Secilen").ToString()
        End If

        Dim _param(1) As SqlParameter
        _param(0) = New SqlParameter("@BasTar", BasTar.SelectedDate)
        _param(1) = New SqlParameter("@BitTar", BitTar.SelectedDate)

        '_query += " ORDER BY SicilNo, Tarih, isnull(SiraNo,0) "

        Dim _mydatatable = RSql.GetValue(_query, _param)
        ReportViewer1.LocalReport.ReportPath = "GirisCikisRaporu.rdlc"
        Dim datasource As New ReportDataSource("DataSet1", _mydatatable)

        Dim params(0) As ReportParameter
        params(0) = New ReportParameter("Filtre", _filtre, False)
        ReportViewer1.LocalReport.SetParameters(params)

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(datasource)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class
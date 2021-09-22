Imports Telerik.Web.UI

Public Class FBoschRapor05
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
        Dim MazText As String = ""
        Dim CalText As String = ""

        Dim MazKodu As String = ""
        Dim CalKodu As String = ""

        For Each Satir As RadComboBoxItem In RMazeretTipi.Items
            If Satir.Checked Then
                If MazKodu = "" Then
                    MazKodu = Satir.Value
                Else
                    MazKodu = MazKodu & "," & Satir.Value
                End If
            End If
        Next

        For Each Satir As RadComboBoxItem In RCalismaTipi.Items
            If Satir.Checked Then
                If CalKodu = "" Then
                    CalKodu = Satir.Value
                Else
                    CalKodu = CalKodu & "," & Satir.Value
                End If
            End If
        Next

        Dim MyReport As New BoschRapor05
        MyReport.ReportParameters("RaporAdi").Value = BBaslik.Text
        MyReport.ReportParameters("Filtre").Value = "Tarih : " & Format(BasTar.SelectedDate, "dd.MM.yyyy") & " - " & Format(BitTar.SelectedDate, "dd.MM.yyyy") & " - Mazeret : " & RMazeretTipi.Text & " / Çalışma Tipi : " & RCalismaTipi.Text
        MyReport.ReportParameters("BasTar").Value = BasTar.SelectedDate
        MyReport.ReportParameters("BitTar").Value = BitTar.SelectedDate
        MyReport.ReportParameters("Mazeret").Value = IIf(MazKodu = "", "", "," & MazKodu & ",")
        MyReport.ReportParameters("Calisma").Value = IIf(CalKodu = "", "", "," & CalKodu & ",")
        MyReport.ReportParameters("SicilList").Value = "," & Session("Secilen") & ","
        MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
        Dim InsReports As New Telerik.Reporting.InstanceReportSource
        InsReports.ReportDocument = MyReport
        RaporGoster.ReportSource = InsReports
        RaporGoster.RefreshReport()
    End Sub

End Class
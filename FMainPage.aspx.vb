Imports Telerik.Web.UI

Public Class FMainPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim RSQL As New ErbenSql
        Dim mTable As DataTable = RSQL.GetValue("SELECT TOP 1 * FROM BoschLisans WITH (NOLOCK)")
        If mTable.Rows.Count > 0 Then
            Dim SQLStr As String = "SELECT isnull(Per_PersNr, '') AS Per_PersNr, isnull(Adi, '') + ' ' + isnull(Soyadi, '') AS PersName "
            Dim Satir As DataRow = mTable.Rows(0)

            For i As Integer = 0 To 7
                If Satir.Item("GrpName" & i.ToString("00")).ToString <> "" And Satir.Item("Grp" & i.ToString("00")).ToString <> "" Then
                    RadGrid1.Columns(i + 2).Visible = True
                    RadGrid1.Columns(i + 2).HeaderText = Satir.Item("GrpName" & i.ToString("00")).ToString
                    SQLStr = SQLStr & ", " & Satir.Item("Grp" & i.ToString("00")).ToString & " AS Per_Grp" & i
                Else
                    RadGrid1.Columns(i + 2).Visible = False
                End If
            Next
            SQLStr = SQLStr & ","

            Dim Gelen As String = Session("PerList")
            If Gelen IsNot Nothing Then Gelen = Gelen.Replace("+", "','") Else Gelen = ""

            If Gelen <> "" Then
                Gelen = Gelen & "','" & Session("OrgUnit")
            Else
                Gelen = Session("OrgUnit")
            End If

            Dim EmpSubGrp() As String = Session("REmpSubGrp").ToString().Split(",")

            'If EmpSubGrp IsNot Nothing Then EmpSubGrp = EmpSubGrp.Replace(",", "','")
            Dim _EmpSubGrplist = ""

            For Each _drow As String In EmpSubGrp
                _EmpSubGrplist &= IIf(_EmpSubGrplist = "", "'" & _drow & "'", ",'" & _drow & "'")
            Next

            Select Case Session("PerTipi")
                Case 0
                    'Sistem yöneticisi
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE 1=0 ORDER BY Per_PersNr"
                Case 1
                    'Yönetici
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
                Case 2
                    'Takım lideri
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
                Case 3
                    'Grup başı
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
                Case 4
                    'Proje sorumlusu
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " And Per_PersNr <> " & Session("PerPersNr"), "") & " ORDER BY Per_PersNr"
                Case 5
                    'HRL yöneticisi
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " And Per_PersNr <> " & Session("PerPersNr"), "") & " ORDER BY Per_PersNr"
                Case 6
                    'CI yöneticisi
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE 1=0 ORDER BY Per_PersNr"
                Case 7
                    SQLStr = SQLStr & " isnull(Per_Grp4,'') AS KstNr FROM BoschPerTab WHERE Aktif=1 AND Per_PersNr=" & Session("PerPersNr") & " ORDER BY Per_PersNr"
            End Select

            mTable = RSQL.GetValue(SQLStr)
            RadGrid1.DataSource = mTable
        End If
    End Sub

    Protected Sub RadGrid1_FilterCheckListItemsRequested(sender As Object, e As GridFilterCheckListItemsRequestedEventArgs) Handles RadGrid1.FilterCheckListItemsRequested
        Dim names As New List(Of String)
        For Each dataItem As GridDataItem In RadGrid1.MasterTableView.Items
            names.Add(dataItem(e.Column.UniqueName).Text)
        Next
        Dim result = From nms In names Order By nms
                     Group By Baslik = nms Into Group
        e.ListBox.DataSource = result
        e.ListBox.DataTextField = "Baslik"
        e.ListBox.DataBind()

    End Sub

    Private Sub RadGrid1_DataBound(sender As Object, e As EventArgs) Handles RadGrid1.DataBound
        Dim Secilen As String = "0"
        For Each dataItem As GridDataItem In RadGrid1.MasterTableView.Items
            Secilen = Secilen & "," & dataItem("Per_PersNr").Text
        Next
        Session("Secilen") = Secilen
    End Sub

    Private Sub FMainPage_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Dim lb = TryCast(RadGrid1.FindControl("filterCheckList"), RadListBox)
        lb.OnClientLoad = "listBoxLoad"
    End Sub

End Class
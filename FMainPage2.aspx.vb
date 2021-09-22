Imports Telerik.Web.UI

Public Class FMainPage2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack() Then Exit Sub
        Dim RSQL As New SqlForConnection
        Dim mTable As DataTable = RSQL.GetValue("SELECT TOP 1 * FROM BoschLisans WITH (NOLOCK)")
        If mTable.Rows.Count = 0 Then Exit Sub

        Dim SQLStr As String = "SELECT isnull(Per_PersNr, '') AS Per_PersNr, isnull(Adi, '') + ' ' + isnull(Soyadi, '') AS PersName "
        Dim Satir As DataRow = mTable.Rows(0)
        For i As Integer = 0 To 7
            Dim Lbltxt = TryCast(Filtre.FindControl("LblGrp" & i), RadLabel)
            Dim HdnTxt = TryCast(Filtre.FindControl("HiddenField" & i), HiddenField)
            If Satir.Item("GrpName" & i.ToString("00")).ToString <> "" And Satir.Item("Grp" & i.ToString("00")).ToString <> "" Then
                RadGrid1.Columns(i + 2).Visible = True
                RadGrid1.Columns(i + 2).HeaderText = Satir.Item("GrpName" & i.ToString("00")).ToString
                SQLStr = SQLStr & ", " & Satir.Item("Grp" & i.ToString("00")).ToString & " AS Per_Grp" & i
                Lbltxt.Visible = True
                Lbltxt.Text = Satir.Item("GrpName" & i.ToString("00")).ToString
                HdnTxt.Value = Satir.Item("Grp" & i.ToString("00")).ToString
                Filtre.FindControl("FltGrp" & i).Visible = True
            Else
                RadGrid1.Columns(i + 2).Visible = False
                Lbltxt.Visible = False
                Filtre.FindControl("FltGrp" & i).Visible = False
                HdnTxt.Value = ""
            End If
        Next

        If Session("PerTipi") = 0 Or Session("PerTipi") = 6 Or Session("PerTipi") = 7 Then
            Filtre.Visible = False
            If Session("PerTipi") = 0 Or Session("PerTipi") = 6 Then
                SQLStr = SQLStr & " FROM BoschPerTab WHERE 1=0"
            Else
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1 AND Per_PersNr=" & Session("PerPersNr") & " ORDER BY Per_PersNr"
            End If
            mTable = RSQL.GetValue(SQLStr)
            RadGrid1.DataSource = mTable
            Exit Sub
        Else
            Filtre.Visible = True
        End If

        Dim Gelen As String = Session("PerList")
        If Gelen IsNot Nothing Then Gelen = Gelen.Replace("+", "','") Else Gelen = ""

        If Gelen <> "" Then
            Gelen = Gelen & "','" & Session("OrgUnit")
        Else
            Gelen = Session("OrgUnit")
        End If

        'Dim EmpSubGrp As String = Session("REmpSubGrp")
        'If EmpSubGrp IsNot Nothing Then EmpSubGrp = EmpSubGrp.Replace(",", "','")

        Dim EmpSubGrp() As String = Session("REmpSubGrp").ToString().Split(",")

        'If EmpSubGrp IsNot Nothing Then EmpSubGrp = EmpSubGrp.Replace(",", "','")
        Dim _EmpSubGrplist = ""

        For Each _drow As String In EmpSubGrp
            _EmpSubGrplist &= IIf(_EmpSubGrplist = "", "'" & _drow & "'", ",'" & _drow & "'")
        Next

        Select Case Session("PerTipi")
            Case 1
                'Yönetici
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
            Case 2
                'Takım lideri
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
            Case 3
                'Grup başı
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
            Case 4
                'Proje sorumlusu
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & "  AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
            Case 5
                'HRL yöneticisi
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & "  AND Per_Grp2 IN (" & _EmpSubGrplist & ") ORDER BY Per_PersNr"
        End Select

        mTable = RSQL.GetValue(SQLStr)

        If HiddenField0.Value <> "" Then
            Dim result = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp0")
                         Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp0") Into Group
                         Select GroupedField = WhatToGroupIs
            For Each Deger As String In result.ToList
                FltGrp0.Items.Add(Deger)
            Next
        End If

        If HiddenField1.Value <> "" Then
            Dim result1 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp1")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp1") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result1.ToList
                FltGrp1.Items.Add(Deger)
            Next
        End If

        If HiddenField2.Value <> "" Then
            Dim result2 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp2")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp2") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result2.ToList
                FltGrp2.Items.Add(Deger)
            Next
        End If

        If HiddenField3.Value <> "" Then
            Dim result3 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp3")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp3") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result3.ToList
                FltGrp3.Items.Add(Deger)
            Next
        End If

        If HiddenField4.Value <> "" Then
            Dim result4 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp4")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp4") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result4.ToList
                FltGrp4.Items.Add(Deger)
            Next
        End If
        If HiddenField5.Value <> "" Then
            Dim result5 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp5")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp5") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result5.ToList
                FltGrp5.Items.Add(Deger)
            Next
        End If

        If HiddenField6.Value <> "" Then
            Dim result6 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp6")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp6") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result6.ToList
                FltGrp6.Items.Add(Deger)
            Next
        End If

        If HiddenField7.Value <> "" Then
            Dim result7 = From AnonymusType_DataRow In mTable.AsEnumerable() Order By AnonymusType_DataRow.Field(Of String)("Per_Grp7")
                          Group AnonymusType_DataRow By WhatToGroupIs = AnonymusType_DataRow.Field(Of String)("Per_Grp7") Into Group
                          Select GroupedField = WhatToGroupIs
            For Each Deger As String In result7.ToList
                FltGrp7.Items.Add(Deger)
            Next
        End If

        RadGrid1.DataSource = mTable

    End Sub

    Private Sub RadGrid1_DataBound(sender As Object, e As EventArgs) Handles RadGrid1.DataBound
        Dim Secilen As String = "0"
        For Each dataItem As GridDataItem In RadGrid1.MasterTableView.Items
            Secilen = Secilen & "," & dataItem("Per_PersNr").Text
        Next
        Session("Secilen") = Secilen
    End Sub

    Private Sub Yenile_Click(sender As Object, e As ImageClickEventArgs) Handles Yenile.Click
        Dim RSQL As New SqlForConnection
        Dim SQLStr As String = "SELECT isnull(Per_PersNr, '') AS Per_PersNr, isnull(Adi, '') + ' ' + isnull(Soyadi, '') AS PersName "
        For i As Integer = 0 To 7
            Dim HdnTxt1 = TryCast(Filtre.FindControl("HiddenField" & i), HiddenField)
            If HdnTxt1.Value <> "" Then
                SQLStr = SQLStr & ", " & HdnTxt1.Value & " AS Per_Grp" & i
            End If
        Next

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
            Case 1
                'Yönetici
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ")  "
            Case 2
                'Takım lideri
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ")  "
            Case 3
                'Grup başı
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN (" & _EmpSubGrplist & ")  "
            Case 4
                'Proje sorumlusu
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp2 IN (" & _EmpSubGrplist & ")  "
            Case 5
                'HRL yöneticisi
                SQLStr = SQLStr & " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp2 IN (" & _EmpSubGrplist & ")  "
        End Select

        Dim FSqlStr As String = ""

        'Select Case Session("PerTipi")
        '    Case 1
        '        'Yönetici
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN ('" & _EmpSubGrplist & "')"
        '    Case 2
        '        'Takım lideri
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN ('" & _EmpSubGrplist & "')"
        '    Case 3
        '        'Grup başı
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN ('" & _EmpSubGrplist & "')"
        '    Case 4
        '        'Proje sorumlusu
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " And Per_PersNr <> " & Session("PerPersNr"), "")
        '    Case 5
        '        'HRL yöneticisi
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN ('" & _EmpSubGrplist & "')"
        '    Case 6
        '        'HRL yöneticisi
        '        FSqlStr = " FROM BoschPerTab WHERE Aktif=1" & IIf(Session("Kendisi") = "0", " AND Per_PersNr <> " & Session("PerPersNr"), "") & " AND Per_Grp5 IN ('" & Gelen & "') AND Per_Grp2 IN ('" & _EmpSubGrplist & "')"
        'End Select

        Dim TmpStr As String
        If FltSicilNo.Text <> "" Then
            TmpStr = RmvTrChr(FltSicilNo.Text)
            TmpStr = TmpStr.Replace("+", ",")
            FSqlStr = FSqlStr & " AND Per_PersNr IN (" & TmpStr & ")"
        End If

        TmpStr = RmvErrChr(FltAdSoyad.Text)

        If FltAdSoyad.Text <> "" Then
            FSqlStr = FSqlStr & " AND (Adi + ' ' + Soyadi) LIKE '%" & TmpStr & "%'"
        End If

        Dim HdnTxt = TryCast(Filtre.FindControl("HiddenField0"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp0.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField1"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp1.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField2"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp2.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField3"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp3.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField4"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp4.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField5"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp5.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField6"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp6.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If
        HdnTxt = TryCast(Filtre.FindControl("HiddenField7"), HiddenField)
        If HdnTxt.Value <> "" Then
            TmpStr = ""
            For Each Kayit In FltGrp7.CheckedItems
                If TmpStr = "" Then
                    TmpStr = "'" & Kayit.Text & "'"
                Else
                    TmpStr = TmpStr & ",'" & Kayit.Text & "'"
                End If
            Next
            If TmpStr <> "" Then
                FSqlStr = FSqlStr & " AND " & HdnTxt.Value & " IN (" & TmpStr & ")"
            End If
        End If


        SQLStr = SQLStr & FSqlStr & " ORDER BY Per_PersNr"

        Dim mTable As DataTable = RSQL.GetValue(SQLStr)
        RadGrid1.DataSource = mTable
        RadGrid1.DataBind()
    End Sub

    Private Sub ClearFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ClearFilter.Click
        FltSicilNo.Text = ""
        FltAdSoyad.Text = ""
        FltGrp0.ClearCheckedItems()
        FltGrp1.ClearCheckedItems()
        FltGrp2.ClearCheckedItems()
        FltGrp3.ClearCheckedItems()
        FltGrp4.ClearCheckedItems()
        FltGrp5.ClearCheckedItems()
        FltGrp6.ClearCheckedItems()
        FltGrp7.ClearCheckedItems()
        Dim RSQL As New SqlForConnection
        Dim SQLStr As String = "SELECT isnull(Per_PersNr, '') AS Per_PersNr, isnull(Adi, '') + ' ' + isnull(Soyadi, '') AS PersName "
        For i As Integer = 0 To 7
            Dim HdnTxt = TryCast(Filtre.FindControl("HiddenField" & i), HiddenField)
            If HdnTxt.Value <> "" Then
                SQLStr = SQLStr & ", " & HdnTxt.Value & " AS Per_Grp" & i
            End If
        Next
        SQLStr = SQLStr & " FROM BoschPerTab WHERE 1=0 ORDER BY Per_PersNr"
        Dim mTable As DataTable = RSQL.GetValue(SQLStr)
        RadGrid1.DataSource = mTable
        RadGrid1.DataBind()
    End Sub

End Class
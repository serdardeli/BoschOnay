Imports Telerik.Web.UI

Public Class BoschOnay
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("PersNr") = "" Or Session("UDate") = "" Then
            Me.Response.Redirect("~/Default.aspx")
        Else
            Session.Timeout = 15
            If Not IsPostBack Then
                LoginUser.Text = Session("PersNr") & " / Adı ve Soyadı : " & Session("PersName") & " / Giriş Zamanı : " & Session("UDate")
                Dim RSQL As New SqlForConnection
                Dim mTable As DataTable = RSQL.GetValue("SELECT isnull(Kodu, 'M00') AS Kodu, isnull(UstMenu,'') AS UstMenu, isnull(Baslik,'') AS Baslik, isnull(Tipi,0) AS Tipi, isnull(Durumu,0) AS Durumu, isnull(Icons,'') AS Icons, isnull(url,'') AS URL FROM BoschMenu WHERE Durumu>0 AND Uygulama=2 ORDER BY Ndx")
                If mTable.Rows.Count > 0 Then
                    Dim Anamenu As RadMenuItem = RadMenu1.Items(0)
                    Dim UstMenu As RadMenuItem
                    RadMenu1.Items(0).Items.Clear()
                    Dim MenuYetki As String = Session("PerMYetki")
                    For Each Satir As DataRow In mTable.Rows
                        If Satir!UstMenu = 0 Then
                            Select Case Satir!Tipi
                                Case 0
                                    Anamenu.Items.Add(New RadMenuItem With {.Value = Satir!Kodu, .Text = Satir!Baslik, .NavigateUrl = Satir!url})
                                Case 1
                                    Anamenu.Items.Add(New RadMenuItem With {.Value = Satir!Kodu, .IsSeparator = True})
                            End Select
                        Else
                            UstMenu = Anamenu.Items(Satir!UstMenu - 1)
                            Select Case Satir!Tipi
                                Case 0
                                    If Mid(MenuYetki, Val(Mid(Satir!Kodu, 2, 2)), 1) = "1" Then
                                        UstMenu.Items.Add(New RadMenuItem With {.Value = Satir!Kodu, .Text = Satir!Baslik, .NavigateUrl = Satir!url & "?Baslik=" & Satir!Baslik})
                                    End If
                                Case 1
                                    UstMenu.Items.Add(New RadMenuItem With {.Value = Satir!Kodu, .IsSeparator = True})
                            End Select
                        End If
                    Next
                    For i As Integer = 0 To 2
                        If Anamenu.Items(i).Items.Count = 0 Then
                            Anamenu.Items(i).Visible = False
                        End If
                    Next
                End If
            End If
        End If
    End Sub

End Class
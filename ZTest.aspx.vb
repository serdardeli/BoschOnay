Public Class ZTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim colors As Array = [Enum].GetValues(GetType(KnownColors))
        For Each color As KnownColors In colors
            DropDownList1.Items.Add(New ListItem(color.ToString(), color.ToString()))
        Next
    End Sub

    Private Sub CmtRenk_ColorChanged(sender As Object, e As EventArgs) Handles CmtRenk.ColorChanged
        RadLabel1.Text = "SelectedColor.tostring  : " & CmtRenk.SelectedColor.ToString
        RadLabel2.Text = "SelectedColor.Name  : " & CmtRenk.SelectedColor.Name
        RadLabel3.Text = "SelectedColor.ToKnownColor  : " & CmtRenk.SelectedColor.ToKnownColor
        RadLabel4.Text = "SelectedColor.ToKnownColor  : " & CmtRenk.SelectedColor.ToKnownColor.ToString

    End Sub

End Class
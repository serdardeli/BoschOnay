Imports System.ComponentModel
Imports System.Drawing
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing

Partial Public Class BoschRapor05
    Inherits Telerik.Reporting.Report

    Public Sub New()
        InitializeComponent()
    End Sub

    Dim EskiSicil As String = ""
    Dim Atla As Boolean = False

    Private Sub RRapor1_ItemDataBinding(sender As Object, e As EventArgs) Handles Me.ItemDataBinding
        EskiSicil = ""
        Atla = False
    End Sub

    Private Sub TextBox1_ItemDataBound(sender As Object, e As EventArgs) Handles TextBox1.ItemDataBound
        Dim Alan As Telerik.Reporting.Processing.TextBox = sender
        If Alan IsNot Nothing Then
            If Alan.Text = EskiSicil Then
                Alan.Value = ""
                Atla = True
            Else
                EskiSicil = Alan.Text
                Atla = False
            End If
        End If
    End Sub

    Private Sub TextBox2_ItemDataBound(sender As Object, e As EventArgs) Handles TextBox2.ItemDataBound
        Dim Alan As Telerik.Reporting.Processing.TextBox = sender
        If Atla Then Alan.Value = ""
    End Sub

    Private Sub TextBox3_ItemDataBound(sender As Object, e As EventArgs) Handles TextBox3.ItemDataBound
        Dim Alan As Telerik.Reporting.Processing.TextBox = sender
        If Atla Then Alan.Value = ""
    End Sub

End Class
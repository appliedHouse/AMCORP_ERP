Imports System.Collections.Generic
Imports System.Data


Public Class frmJoinLedgers


    Dim Table_JoinSupplier As DataTable
    Dim View_JoinSupplier As New DataView

    Dim MyReportProcedure As String = "[master].[dbo].[Join Suppliers Ledger]"
    Dim MyReportParameter As New Dictionary(Of String, String)

    Private Sub Join_Ledgers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyRefresh()


    End Sub

    Private Sub MyRefresh()
        Table_JoinSupplier = Connection_Class.Get_DataTable("[Join Ledgers]", Connection_Master)

        View_JoinSupplier.Table = Table_JoinSupplier
        View_JoinSupplier.Sort = "Title"

        cBoxSupplierJoin.DataSource = View_JoinSupplier
        cBoxSupplierJoin.DisplayMember = "Title"
        cBoxSupplierJoin.ValueMember = "ID"

    End Sub

    Private Sub BtnJoinLedger_Click(sender As Object, e As EventArgs) Handles btnJoinLedger.Click

        Dim _Report As New Connection_Class.Report_Parameters


        _Report.CompanyID = 1
        _Report.CompanyName = My.Settings.CompanyName
        _Report.CompanyAddress = My.Settings.CompanyAddress

        _Report.ReportHeading = String.Concat("Join Ledger ", cBoxSupplierJoin.Text)
        _Report.SQLProcedure = MyReportProcedure
        '_Report.SQLParameters = MyReportParameter

    End Sub
End Class
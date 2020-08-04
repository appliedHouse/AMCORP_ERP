Imports System.Data
Imports System.Collections.Generic
Imports System.Drawing
Imports Connection_Class


Public Class frmGeneralLedger

    ' 09-May-2019
    ' Print and Preview General Ledger

    Property MyDataTable As DataTable
    Property MyReport As New Report_Parameters

    Property MyCompanyID As Integer = 1             ' Default Amcorp Engineering

    Dim TableName_COA As String = "[BizzTrax_Amcorp].[dbo].[tblChartofAccount]"
    Dim TableName_Project As String = "[BizzTrax_Amcorp].[dbo].[tblProject]"
    Dim TableName_Company As String = "[BizzTrax_Amcorp].[dbo].[tblCompany]"
    Dim ReportProcedure As String = "[master].[dbo].[Accounts Ledger (NEW)]"

    Dim MyDataTable_COA As DataTable
    Dim MyDataTable_Project As DataTable
    Dim MyDataTable_Company As DataTable

    Dim DataView_COA As New DataView
    Dim DataView_Project As New DataView
    Dim DataView_Company As New DataView



    Private Sub FrmGeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyDataTable_COA = Get_DataTable(TableName_COA, Connection_Amcorp)
        MyDataTable_Project = Get_DataTable(TableName_Project, Connection_Amcorp)
        MyDataTable_Company = Get_DataTable(TableName_Company, Connection_Amcorp)

        dtFrom.Value = My.Settings.ReportFrom
        dtTo.Value = Now

        MyRefresh()

    End Sub

    Private Sub MyRefresh()

        DataView_Company.Table = MyDataTable_Company
        cBoxCompany.DataSource = DataView_Company
        cBoxCompany.ValueMember = "CompanyID"
        cBoxCompany.DisplayMember = "CompanyTitle"

        DataView_COA.Table = MyDataTable_COA
        cboxCOA.DataSource = DataView_COA
        cboxCOA.ValueMember = "ChartofAccountID"
        cboxCOA.DisplayMember = "AccountTitle"
        DataView_COA.Sort = "AccountTitle"
        DataView_COA.RowFilter = "Type='Detail' and CompanyID=" & MyCompanyID.ToString

        DataView_Project.Table = MyDataTable_Project
        cboxProject.DataSource = DataView_Project
        cboxProject.ValueMember = "ProjectID"
        cboxProject.DisplayMember = "ProjectTitle"
        DataView_Project.Sort = "ProjectTitle"

    End Sub


    Private Sub Report_GL()

        Dim _Parameters As New Dictionary(Of String, String)
        Dim _DataTable As DataTable

        MyReport.DateFormatText = My.Settings.DateFormat
        MyReport.DateFrom = dtFrom.Value
        MyReport.DateTo = dtTo.Value
        MyReport.AmountFormat = My.Settings.AmountFormat

        MyReport.COAID1 = cboxCOA.SelectedValue
        MyReport.All_Projects = chkAllProjects.Checked
        MyReport.SQLProcedure = ReportProcedure


        MyReport.SQLConnection = Connection_Bizztrax()
        MyReport.SQLCommand = New SqlClient.SqlCommand("", MyReport.SQLConnection)
        MyReport.SQLCommand.CommandText = CommandType.StoredProcedure
        MyReport.SQLCommand.CommandText = ReportProcedure
        MyReport.SQLCommand.Parameters.AddWithValue("@CompanyID", MyCompanyID)
        MyReport.SQLCommand.Parameters.AddWithValue("@AccountID", MyReport.COAID1)
        MyReport.SQLCommand.Parameters.AddWithValue("@Date_From", MyReport.DateFrom)
        MyReport.SQLCommand.Parameters.AddWithValue("Date_To", MyReport.DateTo)


        _DataTable = Get_Procedure(MyReport)

        MyReport.CompanyName = cBoxCompany.Text
        MyReport.ReportName = "General Ledger"
        MyReport.ReportHeading = "General Ledger as on " & MyReport.FormatDate(MyReport.DateTo)

        MyDataTable = _DataTable

    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        lblMessage.Text = "Report is being generated."
        lblMessage.ForeColor = Color.Red

        Report_GL()
        Excel_General_Ledger(MyDataTable, MyReport)

        lblMessage.Text = "Report Completed."
        lblMessage.ForeColor = Color.Black

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub cBoxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxCompany.DropDownClosed
        MyCompanyID = cBoxCompany.SelectedValue
        MyRefresh()
    End Sub
End Class
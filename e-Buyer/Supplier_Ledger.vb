Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class frmSupplier_Ledger

    Private Property MyCompany As Integer = 1           ' Default Company is Amcorp (CompanyId = 1)

    Dim _DataTable_Company As DataTable
    Dim _DataTable_Supplier As DataTable
    Dim _DataTable_Project As DataTable

    Dim DataView_Company As New DataView
    Dim DataView_Supplier As New DataView
    Dim DataView_Project As New DataView

    Private Sub frmSupplier_Ledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh(0)
    End Sub

    Private Sub MyRefresh(_All As Integer)

        _DataTable_Company = Connection_Class.Get_DataTable("tblCompany", Connection_Amcorp)
        _DataTable_Supplier = Connection_Class.Get_DataTable("tblSupplier", Connection_Amcorp)
        _DataTable_Project = Connection_Class.Get_DataTable("tblProject", Connection_Amcorp)

        If _All = 0 Then
            DataView_Company.Table = _DataTable_Company
            cBoxCompany.DataSource = DataView_Company
            cBoxCompany.ValueMember = "CompanyID"
            cBoxCompany.DisplayMember = "CompanyTitle"
        End If

        DataView_Supplier.Table = _DataTable_Supplier
        DataView_Supplier.RowFilter = String.Concat("CompanyID=", MyCompany)
        DataView_Supplier.Sort = "SupplierTitle"
        cboxSupplier.DataSource = DataView_Supplier
        cboxSupplier.ValueMember = "SupplierID"
        cboxSupplier.DisplayMember = "SupplierTitle"

        DataView_Project.Table = _DataTable_Project
        DataView_Project.RowFilter = String.Concat("CompanyID=", MyCompany)
        DataView_Project.Sort = "ProjectTitle"
        cboxProject.DataSource = DataView_Project
        cboxProject.ValueMember = "ProjectID"
        cboxProject.DisplayMember = "ProjectTitle"

        dtReportTo.Value = Now



    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub cboxAllProject_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllProject.CheckedChanged

        If chkAllProject.Checked Then
            cboxProject.Enabled = False
        Else
            cboxProject.Enabled = True
        End If

    End Sub

    Private Sub btnLedgerProject_Click(sender As Object, e As EventArgs) Handles btnLedgerProject.Click
        ' 02-04-2019
        ' Generate report for Supplier Project wise Ledger.
        MyMessage.Text = "Report is being processed..... Wait"
        MyMessage.ForeColor = Drawing.Color.Red

        If cBoxCompany.Text.Length = 0 Then
            MyMessage.Text = "Company is not Selected."
            Return
        End If

        Dim _Report As New Connection_Class.Report_Parameters
        Dim _Parameters As New Dictionary(Of String, String)
        Dim _DataTable As DataTable

        _Report.ShowProperties = False                                               ' Show Properties when it call ShowParameters()
        _Report.CompanyID = cBoxCompany.SelectedValue
        _Report.CompanyName = cBoxCompany.Text
        _Report.DateFormatText = My.Settings.DateFormat
        _Report.AmountFormat = My.Settings.AmountFormat
        _Report.ReportSort = "[Project ID],[Vou Date]"
        _Report.SupplierID1 = cboxSupplier.SelectedValue
        _Report.DateFrom = dtReportFrom.Value
        _Report.DateTo = dtReportTo.Value
        _Report.All_Projects = chkAllProject.Checked

        _Report.ReportName = "Supplier Project Ledger"
        _Report.ReportHeading = "Supplier Ledger Project wise as on " & _Report.DateTo.ToShortDateString

        If _Report.All_Projects Then                     ' Print all Projects if chekc [All Projects]
            _Report.ProjectID1 = 0
            _Report.ProjectID2 = 99999
        Else
            _Report.ProjectID1 = cboxProject.SelectedValue
            _Report.ProjectID2 = cboxProject.SelectedValue
        End If

        '_Report.SQLCommand = Connection_Master.CreateCommand

        _Report.SQLConnection = Connection_Master()
        _Report.SQLCommand = _Report.SQLConnection.CreateCommand
        _Report.SQLProcedure = "[master].[dbo].[Supplier Ledger eBuyer (Date)]"

        _Report.SQLCommand.Parameters.AddWithValue("@CompanyID", _Report.CompanyID)
        _Report.SQLCommand.Parameters.AddWithValue("@SupplierID", _Report.SupplierID1)
        _Report.SQLCommand.Parameters.AddWithValue("@ProjectID_From", _Report.ProjectID1)
        _Report.SQLCommand.Parameters.AddWithValue("@ProjectID_to", _Report.ProjectID2)
        _Report.SQLCommand.Parameters.AddWithValue("@DateFrom", _Report.DateFrom)
        _Report.SQLCommand.Parameters.AddWithValue("@DateTo", _Report.DateTo)

        _DataTable = Connection_Class.Get_Procedure(_Report)

        Excel_Supplier_Project_Ledger(_DataTable, _Report)               ' Execute and show reports in excel.

        MyMessage.ForeColor = Drawing.Color.Black
        MyMessage.Text = "Report is complete."

    End Sub

    Private Sub btnLedgerSupplier_Click(sender As Object, e As EventArgs) Handles btnLedgerSupplier.Click
        ' 06-04-2019
        ' Generate report for Supplier Project wise Ledger.
        MyMessage.Text = "Report is being processed..... Wait"
        MyMessage.ForeColor = Drawing.Color.Red

        Dim _Report As New Connection_Class.Report_Parameters
        Dim _Parameters As New Dictionary(Of String, String)
        Dim _DataTable As New DataTable

        _Report.ShowProperties = False                                               ' Show Properties when it call ShowParameters()
        _Report.CompanyName = My.Settings.CompanyAddress
        _Report.CompanyAddress = My.Settings.CompanyAddress

        _Report.ReportSort = "[Vou Date]"
        _Report.DateFormatText = My.Settings.DateFormat
        _Report.AmountFormat = My.Settings.AmountFormat
        _Report.SupplierID1 = cboxSupplier.SelectedValue
        _Report.DateFrom = dtReportFrom.Value
        _Report.DateTo = dtReportTo.Value
        _Report.All_Projects = chkAllProject.Checked

        _Report.ReportName = "Supplier Project Ledger"
        _Report.ReportHeading = "Supplier Ledger Project wise as on " & _Report.DateTo.ToShortDateString

        If _Report.All_Projects Then                     ' Print all Projects if chekc [All Projects]
            _Report.ProjectID1 = 0
            _Report.ProjectID2 = 99999
        Else
            _Report.ProjectID1 = cboxProject.SelectedValue
            _Report.ProjectID2 = cboxProject.SelectedValue
        End If


        _Report.SQLConnection = Connection_Master()
        _Report.SQLCommand = _Report.SQLConnection.CreateCommand
        _Report.SQLProcedure = "[master].[dbo].[Supplier Ledger eBuyer (Date - Head)]"

        _Report.SQLCommand.Parameters.AddWithValue("SupplierID", _Report.SupplierID1)
        _Report.SQLCommand.Parameters.AddWithValue("ProjectID_From", _Report.ProjectID1)
        _Report.SQLCommand.Parameters.AddWithValue("ProjectID_To", _Report.ProjectID2)
        _Report.SQLCommand.Parameters.AddWithValue("DateFrom", _Report.DateFrom)
        _Report.SQLCommand.Parameters.AddWithValue("DateTo", _Report.DateTo)

        _DataTable = Connection_Class.Get_Procedure(_Report)

        Excel_Supplier_Ledger(_DataTable, _Report)               ' Execute and show reports in excel.

        MyMessage.ForeColor = Drawing.Color.Black
        MyMessage.Text = "Report is complete."

        'EOF(06-04-2019)  


    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click

        '06-04-2019
        ' Generate report for Supplier Project wise Ledger.
        MyMessage.Text = "Report is being processed..... Wait"
        MyMessage.ForeColor = Drawing.Color.Red

        Dim Report As New Connection_Class.Report_Parameters
        Dim _Parameters As New Dictionary(Of String, String)
        Dim _DataTable As New DataTable

        Report.ShowProperties = False                                               ' Show Properties when it call ShowParameters()

        Report.ReportSort = "[Project Title]"
        Report.DateFormatText = My.Settings.DateFormat
        Report.AmountFormat = My.Settings.AmountFormat
        Report.SupplierID1 = cboxSupplier.SelectedValue
        Report.DateFrom = dtReportFrom.Value
        Report.DateTo = dtReportTo.Value
        Report.All_Projects = chkAllProject.Checked
        Report.ShowZeros = Not chkZeroBalance.Checked

        Report.ReportName = "Supplier Project Ledger"
        Report.ReportHeading = "Supplier Ledger wise as on " & Report.FormatDate(Report.DateTo)

        If Report.All_Projects Then                     ' Print all Projects if chekc [All Projects]
            Report.ProjectID1 = 0
            Report.ProjectID2 = 99999
        Else
            Report.ProjectID1 = cboxProject.SelectedValue
            Report.ProjectID2 = cboxProject.SelectedValue
        End If

        ' Parameter must start with lower cap char n=Numaric, d=Date, c=Character, b=Boolean
        ' This dertimed the paramter value type in SQL Command Paramters.

        Report.SQLConnection = Connection_Amcorp()
        Report.SQLCommand = Report.SQLConnection.CreateCommand
        Report.SQLProcedure = "[master].[dbo].[Supplier Ledger eBuyer (Date) TB]"

        Report.SQLCommand.Parameters.AddWithValue("SupplierID", Report.SupplierID1)
        Report.SQLCommand.Parameters.AddWithValue("DateTo", Report.DateTo)

        _DataTable = Connection_Class.Get_Procedure(Report)

        Excel_Supplier_Project_TB(_DataTable, Report)               ' Execute and show reports in excel.

        MyMessage.ForeColor = Drawing.Color.Black
        MyMessage.Text = "Report is complete."


        'EOF(06-04-2019)  

    End Sub

    Private Sub cBoxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxCompany.DropDownClosed
        MyCompany = cBoxCompany.SelectedValue
        MyRefresh(1)
    End Sub



End Class
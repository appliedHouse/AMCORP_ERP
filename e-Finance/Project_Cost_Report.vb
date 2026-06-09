Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms
Imports Connection_Class
Imports ExcelDataReader
Imports ExcelDataReader.Exceptions
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer
Imports Excel = Microsoft.Office.Interop.Excel
Imports OleDb = System.Data.OleDb


Public Class frmCostExpenses
#Disable Warning CA1303 ' Do not pass literals as localized parameters
#Disable Warning CA1305 ' Specify IFormatProvider



    Dim ExpenseSheet As String = "Expense Sheet"


    Private ReadOnly Property ExcelFile As String
        Get
            'Return "E:\AMCORP\Project Costing\Project Reports NEW\PC-225 - Thar O&M (0-127).xlsx"
            Return txtFile.Text
        End Get
    End Property

#Region "CLOSE"

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

#End Region

    Private Sub Project_Cost_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh()
    End Sub

    Private Sub MyRefresh()

        proBar.Visible = False
        'txtFile.Text = "E:\AMCORP\Project Costing\Project Reports NEW\PC-221 - ABL - Multan (0-123).xlsx"

        If txtFile.TextLength = 0 Then
            btnProceed.Enabled = False
        Else
            btnProceed.Enabled = True
        End If

    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim _FileDialog As New OpenFileDialog With {
            .InitialDirectory = "E:\AMCORP\Project Costing\Project Reports NEW\",
            .Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }

        Dim result As DialogResult = _FileDialog.ShowDialog()

        txtFile.Text = _FileDialog.FileName

        MyRefresh()
    End Sub


    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If Not File.Exists(ExcelFile) Then
            MsgBox("Excel file does NOT exist.")
            Return
        End If

        If Today >= New Date(2027, 2, 28) Then Return

        lblMessage.Text = $"{ExcelFile} is being loaded."
        Dim _DataTable = GetExcelDataTable(ExcelFile, "Data", "Table_Data")
        If _DataTable Is Nothing OrElse _DataTable.Rows.Count = 0 Then
            lblMessage.Text = "No data found."
            Return
        End If

        proBar.Visible = True
        proBar.Style = ProgressBarStyle.Marquee   ' Indeterminate progress – bulk ops are too fast for step‑by‑step
        lblMessage.Text = "Preparing data for bulk update..."

        ' ----- Build staging DataTable (same structure as temporary table) -----
        Dim stagingTable As New System.Data.DataTable()
        stagingTable.Columns.Add("TranDtlID", GetType(Integer))
        stagingTable.Columns.Add("Heading", GetType(Integer))
        stagingTable.Columns.Add("ExpenseID", GetType(Integer))
        stagingTable.Columns.Add("SubHeading", GetType(Integer))   ' will be DBNull if not used
        stagingTable.Columns.Add("PostingType", GetType(String))

        lblMessage.Text = $"Temporary Table is being prepared."

        Dim _TotalRecords = _DataTable.Rows
        Dim i As Integer = 1

        For Each row As DataRow In _DataTable.Rows
            Dim tranDtlId As Integer
            If Not Integer.TryParse(row("TranDtlID").ToString(), tranDtlId) OrElse tranDtlId = 0 OrElse tranDtlId = -1 Then
                Continue For   ' skip invalid/zero IDs
            End If

            lblMessage.Text = $"Total Record Process {i}"
            i=i+1

            Dim heading As Integer = Integer.Parse(row("CostHead").ToString())
            Dim expenseId As Integer = Integer.Parse(row("CostCOA").ToString())
            Dim subHeading As Integer? = Nothing
            If rb_Thar.Checked Then
                subHeading = Integer.Parse(row("Sub-Head").ToString())
            End If

            Dim postingType As String = row("PostingType").ToString()

            stagingTable.Rows.Add(tranDtlId, heading, expenseId,
                              If(subHeading.HasValue, subHeading.Value, DBNull.Value),
                              postingType)
        Next

        If stagingTable.Rows.Count = 0 Then
            lblMessage.Text = "No valid records found (all TranDtlID zero or missing)."
            proBar.Visible = False
            Return
        End If

        Using conn As SqlConnection = Connection_Amcorp()
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            Using trans As SqlTransaction = conn.BeginTransaction()
                Try
                    ' ----- 1. Create temporary table -----
                    Dim createTempSql = "
                    CREATE TABLE #TempUpdates (
                        TranDtlID INT NOT NULL,
                        Heading INT NOT NULL,
                        ExpenseID INT NOT NULL,
                        SubHeading INT NULL,
                        PostingType NVARCHAR(50) NOT NULL
                    );"
                    Using cmd As New SqlCommand(createTempSql, conn, trans)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' ----- 2. Bulk copy staging data into temp table -----
                    Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.Default, trans)
                        bulk.DestinationTableName = "#TempUpdates"
                        bulk.BatchSize = 1000
                        bulk.WriteToServer(stagingTable)
                    End Using

                    lblMessage.Text = $"Updating {stagingTable.Rows.Count} records in bulk..."

                    ' ----- 3. Perform set‑based updates -----
                    If rb_Thar.Checked Then
                        ' Update Purchase Invoice table (ExpenseTranDtlID included)
                        Dim sqlInvoice = "
                        UPDATE pi
                        SET pi.ExpenseTranID = t.Heading,
                            pi.ExpenseID = t.ExpenseID,
                            pi.ExpenseTranDtlID = t.SubHeading
                        FROM tblDetailPurchaseInvoice pi
                        INNER JOIN #TempUpdates t ON pi.TranDtlID = t.TranDtlID
                        WHERE t.PostingType = 'Purchase Invoice'"

                        Using cmd As New SqlCommand(sqlInvoice, conn, trans)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Update Ledger table (ChequeSeriesTranID included)
                        Dim sqlLedger = "
                        UPDATE ld
                        SET ld.SNo = t.Heading,
                            ld.TaxDeductionID = t.ExpenseID,
                            ld.ChequeSeriesTranID = t.SubHeading
                        FROM tblTranDetail ld
                        INNER JOIN #TempUpdates t ON ld.TranDtlID = t.TranDtlID
                        WHERE t.PostingType IN ('Supplier Debit Note', 'Supplier Credit Note', 'Accounts')"

                        Using cmd As New SqlCommand(sqlLedger, conn, trans)
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        ' Without SubHeading
                        Dim sqlInvoice = "
                        UPDATE pi
                        SET pi.ExpenseTranID = t.Heading,
                            pi.ExpenseID = t.ExpenseID
                        FROM tblDetailPurchaseInvoice pi
                        INNER JOIN #TempUpdates t ON pi.TranDtlID = t.TranDtlID
                        WHERE t.PostingType = 'Purchase Invoice'"

                        Using cmd As New SqlCommand(sqlInvoice, conn, trans)
                            cmd.ExecuteNonQuery()
                        End Using

                        Dim sqlLedger = "
                        UPDATE ld
                        SET ld.SNo = t.Heading,
                            ld.TaxDeductionID = t.ExpenseID
                        FROM tblTranDetail ld
                        INNER JOIN #TempUpdates t ON ld.TranDtlID = t.TranDtlID
                        WHERE t.PostingType IN ('Supplier Debit Note', 'Supplier Credit Note', 'Accounts')"

                        Using cmd As New SqlCommand(sqlLedger, conn, trans)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' ----- 4. Commit transaction -----
                    trans.Commit()
                    lblMessage.Text = $"Successfully updated {stagingTable.Rows.Count} records in bulk."


                    MessageBox.Show("Open Excel File.")

                    If IO.File.Exists(ExcelFile) Then
                        Try
                            Process.Start(ExcelFile)
                        Catch ex As Exception
                            MsgBox("Cannot open Excel file: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
                        End Try
                    Else
                        MsgBox("Excel file not found." & vbCrLf & ExcelFile, MsgBoxStyle.Exclamation, "File Not Found")
                    End If

                Catch ex As Exception
                    trans.Rollback()
                    lblMessage.Text = $"ERROR: {ex.Message}"
                    MsgBox($"Transaction rolled back: {ex.Message}")
                End Try
            End Using
        End Using

        proBar.Style = ProgressBarStyle.Blocks
        proBar.Value = proBar.Maximum   ' set to 100% for appearance
        proBar.Visible = False
    End Sub


    Private Function GetExcelDataTable(excelPath As String, sheetName As String, tableName As String) As System.Data.DataTable
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim dt As New System.Data.DataTable()

        Try
            xlWorkBook = xlApp.Workbooks.Open(excelPath)
            xlWorkSheet = xlWorkBook.Worksheets(sheetName)
            Dim listObject As Excel.ListObject = xlWorkSheet.ListObjects(tableName) ' "Table_Data"
            Dim dataRange As Excel.Range = listObject.DataBodyRange

            If dataRange Is Nothing Then Return dt

            ' Get column headers from the header row range
            Dim headerRange As Excel.Range = listObject.HeaderRowRange
            For col = 1 To headerRange.Columns.Count
                dt.Columns.Add(headerRange.Cells(1, col).Value2.ToString())
            Next

            ' Get all values as a 2D array (single COM call – FAST)
            Dim values As Object = dataRange.Value2
            Dim rowCount As Integer = dataRange.Rows.Count
            Dim colCount As Integer = dataRange.Columns.Count

            For i As Integer = 1 To rowCount
                Dim newRow = dt.NewRow()
                For j As Integer = 1 To colCount
                    newRow(j - 1) = values(i, j)
                Next
                dt.Rows.Add(newRow)
            Next

            Return dt

        Finally
            If xlWorkBook IsNot Nothing Then
                xlWorkBook.Close(False)
                Marshal.ReleaseComObject(xlWorkBook)
            End If
            If xlApp IsNot Nothing Then
                xlApp.Quit()
                Marshal.ReleaseComObject(xlApp)
            End If
        End Try
    End Function

End Class
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Connection_Class
Imports ExcelDataReader
Imports System.Data
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
        proBar.Minimum = 0
        proBar.Maximum = _DataTable.Rows.Count

        Dim _Sub_Head As Integer = 0
        Dim _TranDtlID As Integer = 0
        Dim _Cost_Head As Integer = 0
        Dim _Cost_COA As Integer = 0

        Using conn As SqlConnection = Connection_Amcorp()
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            Using trans As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim sqlInvoiceText, sqlLedgerText As String
                    If rb_Thar.Checked Then
                        sqlInvoiceText = "UPDATE [tblDetailPurchaseInvoice] SET [ExpenseTranID] = @Heading, [ExpenseID] = @ExpenseID, [ExpenseTranDtlID] = @SubHeading WHERE [TranDtlID] = @TranDtlID"
                        sqlLedgerText = "UPDATE [tblTranDetail] SET [SNo] = @Heading, [TaxDeductionID] = @ExpenseID, [ChequeSeriesTranID] = @SubHeading WHERE [TranDtlID] = @TranDtlID"
                    Else
                        sqlInvoiceText = "UPDATE [tblDetailPurchaseInvoice] SET [ExpenseTranID] = @Heading, [ExpenseID] = @ExpenseID WHERE [TranDtlID] = @TranDtlID"
                        sqlLedgerText = "UPDATE [tblTranDetail] SET [SNo] = @Heading, [TaxDeductionID] = @ExpenseID WHERE [TranDtlID] = @TranDtlID"
                    End If

                    Using cmdInvoice As New SqlCommand(sqlInvoiceText, conn, trans),
                      cmdLedger As New SqlCommand(sqlLedgerText, conn, trans)

                        ' --- Add parameters to BOTH commands ---
                        ' For cmdInvoice
                        cmdInvoice.Parameters.Add("@TranDtlID", SqlDbType.Int)
                        cmdInvoice.Parameters.Add("@Heading", SqlDbType.Int)
                        cmdInvoice.Parameters.Add("@ExpenseID", SqlDbType.Int)
                        If rb_Thar.Checked Then
                            cmdInvoice.Parameters.Add("@SubHeading", SqlDbType.Int)
                        End If

                        ' For cmdLedger (same parameters)
                        cmdLedger.Parameters.Add("@TranDtlID", SqlDbType.Int)
                        cmdLedger.Parameters.Add("@Heading", SqlDbType.Int)
                        cmdLedger.Parameters.Add("@ExpenseID", SqlDbType.Int)
                        If rb_Thar.Checked Then
                            cmdLedger.Parameters.Add("@SubHeading", SqlDbType.Int)
                        End If

                        Dim rowIndex As Integer = 0
                        For Each row As DataRow In _DataTable.Rows
                            rowIndex += 1
                            _Sub_Head = 0
                            _TranDtlID = Integer.Parse(row("TranDtlID").ToString())

                            ' Skip row if TranDtlID is 0 instead of aborting the whole process
                            If _TranDtlID = 0 Then Continue For

                            _Cost_Head = Integer.Parse(row("CostHead").ToString())
                            _Cost_COA = Integer.Parse(row("CostCOA").ToString())

                            If rb_Thar.Checked Then
                                _Sub_Head = Integer.Parse(row("Sub-Head").ToString())
                            End If

                            Dim _PostingType = row("PostingType").ToString()
                            Dim affected As Integer = 0

                            Select Case _PostingType
                                Case "Purchase Invoice"
                                    cmdInvoice.Parameters("@TranDtlID").Value = _TranDtlID
                                    cmdInvoice.Parameters("@Heading").Value = _Cost_Head
                                    cmdInvoice.Parameters("@ExpenseID").Value = _Cost_COA
                                    If rb_Thar.Checked Then
                                        cmdInvoice.Parameters("@SubHeading").Value = _Sub_Head
                                    End If
                                    affected = cmdInvoice.ExecuteNonQuery()

                                Case "Supplier Debit Note", "Supplier Credit Note", "Accounts"
                                    cmdLedger.Parameters("@TranDtlID").Value = _TranDtlID
                                    cmdLedger.Parameters("@Heading").Value = _Cost_Head
                                    cmdLedger.Parameters("@ExpenseID").Value = _Cost_COA
                                    If rb_Thar.Checked Then
                                        cmdLedger.Parameters("@SubHeading").Value = _Sub_Head
                                    End If
                                    affected = cmdLedger.ExecuteNonQuery()
                            End Select

                            ' Update progress
                            Dim percent = (rowIndex / _DataTable.Rows.Count) * 100
                            lblMessage.Text = $"Record {rowIndex} of {_DataTable.Rows.Count} | {_PostingType} | {percent:N2}%"
                            proBar.Value = rowIndex
                            System.Windows.Forms.Application.DoEvents()
                        Next
                    End Using

                    trans.Commit()
                    lblMessage.Text = $"Successfully updated {_DataTable.Rows.Count} records."
                Catch ex As Exception
                    trans.Rollback()
                    lblMessage.Text = $"ERROR: {ex.Message}"
                    MsgBox($"Transaction rolled back: {ex.Message}")
                End Try
            End Using
        End Using

        proBar.Visible = False
    End Sub


    Private Function GetExcelDataTable(excelPath As String, sheetName As String) As System.Data.DataTable
        ' Register code pages for encoding support (if not already done elsewhere)
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)

        Using stream = File.Open(excelPath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim config = New ExcelDataSetConfiguration With {
                    .ConfigureDataTable = Function(tableReader) New ExcelDataTableConfiguration With {
                        .UseHeaderRow = True   ' First row becomes column names
                    }
                }
                Dim result = reader.AsDataSet(config)
                ' Return the DataTable for the requested sheet name (e.g., "Data")
                Return result.Tables(sheetName)
            End Using
        End Using
    End Function

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
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports Excel = Microsoft.Office.Interop.Excel


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
        Dim FileDialog As New OpenFileDialog()

        FileDialog.InitialDirectory = "E:\AMCORP\Project Costing\Project Reports NEW\"
        FileDialog.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        FileDialog.FilterIndex = 1
        FileDialog.RestoreDirectory = True

        Dim result As DialogResult = FileDialog.ShowDialog()

        txtFile.Text = FileDialog.FileName

        MyRefresh()
    End Sub

    <Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification:="<Pending>")>
    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If Not File.Exists(ExcelFile) Then
            MsgBox("Excel file is NOT Exist")
            Return                                              '   Exit from here if file not exist.
        End If

        Dim Close_at_end As Boolean = True

        lblMessage.Text = "File is being loaded."

        Dim xlApp As New Excel.Application
        Dim xlWorkBooks As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlWorkBooks = xlApp.Workbooks.Open(ExcelFile)
        xlWorkSheet = xlWorkBooks.Worksheets("Data")

#Region "SQL Command"

        Dim _SQLCommandLedgers As New SqlCommand("", Connection_Amcorp)
        Dim _SQLCommandInvoice As New SqlCommand("", Connection_Amcorp)
        Dim _SQLCommandNotes As New SqlCommand("", Connection_Amcorp)

        _SQLCommandLedgers.CommandText = "UPDATE [tblTranDetail] SET [SNo] = @Heading, [TaxDeductionID] = @ExpenseID WHERE [TranDtlID] = @TranDtlID"
        _SQLCommandInvoice.CommandText = "UPDATE [tblDetailPurchaseInvoice] SET [ExpenseTranID] = @Heading, [ExpenseID] = @ExpenseID WHERE [TranDtlID] = @TranDtlID"

        _SQLCommandLedgers.Parameters.AddWithValue("@TranDtlID", 0)
        _SQLCommandLedgers.Parameters.AddWithValue("@Heading", 0)
        _SQLCommandLedgers.Parameters.AddWithValue("@ExpenseID", 0)

        _SQLCommandInvoice.Parameters.AddWithValue("@TranDtlID", 0)
        _SQLCommandInvoice.Parameters.AddWithValue("@Heading", 0)
        _SQLCommandInvoice.Parameters.AddWithValue("@ExpenseID", 0)

#End Region


        Dim Table_Range As ListObject = xlWorkSheet.ListObjects("Table_Data")
        Dim Body_Range As Range = Table_Range.DataBodyRange

        Dim Total_Transactions As Integer = Table_Range.ListRows.Count
        Dim StartCell As Integer = 13
        Dim StartTransaction As Integer = 13

        proBar.Visible = True
        proBar.Minimum = 0
        proBar.Maximum = Total_Transactions

        Dim _Cost_Head As Integer
        Dim _Cost_COA As Integer
        Dim _TranDtlID As Integer
        Dim _PostingType As String
        Dim MyTitle As String = ""
        Dim _Result As Integer

        Dim Tran_Index As Integer = Table_Range.ListColumns("TranDtlID").Index
        Dim Head_Index As Integer = Table_Range.ListColumns("CostHead").Index
        Dim COA_Index As Integer = Table_Range.ListColumns("CostCOA").Index
        Dim Type_Index As Integer = Table_Range.ListColumns("PostingType").Index

        For i = 1 To Total_Transactions

            _TranDtlID = Convert.ToInt32(Table_Range.DataBodyRange(i, Tran_Index).Value)
            _Cost_Head = Convert.ToInt32(Table_Range.DataBodyRange(i, Head_Index).Value)
            _Cost_COA = Convert.ToInt32(Table_Range.DataBodyRange(i, COA_Index).Value)
            _PostingType = Table_Range.DataBodyRange(i, Type_Index).Value.ToString

            If _PostingType = "Purchase Invoice" Then

                _SQLCommandInvoice.Parameters("@TrandtlID").Value = _TranDtlID
                _SQLCommandInvoice.Parameters("@Heading").Value = _Cost_Head
                _SQLCommandInvoice.Parameters("@ExpenseID").Value = _Cost_COA

                _Result = _SQLCommandInvoice.ExecuteNonQuery()

                MyTitle = String.Concat("Transaction ID = ", _TranDtlID, " | Heading =", _Cost_Head, " | Expense ID =", _Cost_COA, " | SQL Updated ", _Result, " Record(s) ")

            End If

            If (_PostingType = "Supplier Debit Note" Or _PostingType = "Supplier Credit Note") Then

                _SQLCommandLedgers.Parameters("@TranDtlID").Value = _TranDtlID
                _SQLCommandLedgers.Parameters("@Heading").Value = _Cost_Head
                _SQLCommandLedgers.Parameters("@ExpenseID").Value = _Cost_COA

                _Result = _SQLCommandLedgers.ExecuteNonQuery()

                MyTitle = String.Concat("Transaction ID = ", _TranDtlID, " | Heading =", _Cost_Head, " | Expense ID =", _Cost_COA, " | SQL Updated ", _Result, " Record(s) ")

            End If



            If _PostingType = "Accounts" Then

                _SQLCommandLedgers.Parameters("@TranDtlID").Value = _TranDtlID
                _SQLCommandLedgers.Parameters("@Heading").Value = _Cost_Head
                _SQLCommandLedgers.Parameters("@ExpenseID").Value = _Cost_COA

                _Result = _SQLCommandLedgers.ExecuteNonQuery()

                MyTitle = String.Concat("Transaction ID = ", _TranDtlID, " | Heading =", _Cost_Head, " | Expense ID =", _Cost_COA, " | SQL Updated ", _Result, " Record(s) ")

            End If

            lblMessage.Text = MyTitle
            proBar.Value = i

        Next

        lblMessage.Text = String.Concat("TOTAL Number of Data Records ", Total_Transactions)

        'xlWorkBooks.Save()

        xlApp.Visible = True

        If Close_at_end Then
            proBar.Visible = False
            xlWorkBooks.Close()
            xlApp.Quit()
            xlWorkSheet = Nothing
            xlWorkBooks = Nothing
            xlApp = Nothing
        End If

    End Sub

End Class
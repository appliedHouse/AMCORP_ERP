Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmProject_Expense_Report

#Disable Warning CA1303 ' Do not pass literals as localized parameters
#Disable Warning CA1305 ' Specify IFormatProvider

    Dim xlApp As New Excel.Application
    Dim xlWorkBooks As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet


    Dim ExpenseSheet As String = "Expense Sheet"


    Private ReadOnly Property ExcelFile As String
        Get
            Return txtFile.Text
        End Get
    End Property


    Private Sub frmProject_Expense_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh()
    End Sub



    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click

        Dim FileDialog As New OpenFileDialog()
        Dim _Path As String = "SOFTWARE\Applied"
        Dim _Key As String = "Path_ExpenseSheet"

        Dim KeyCreate As RegistryKey = Registry.CurrentUser.CreateSubKey(_Path)
        Dim KeyOpen As RegistryKey = Registry.CurrentUser.OpenSubKey(_Path)

        If KeyOpen IsNot Nothing Then
            FileDialog.InitialDirectory = KeyOpen.GetValue(_Key)
        Else
            FileDialog.InitialDirectory = "E:\AMCORP\Project Expense Sheet\PROJECTS EXPENSE SHEETS\"
        End If

        FileDialog.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        FileDialog.FilterIndex = 1
        FileDialog.RestoreDirectory = False

        Dim result As DialogResult = FileDialog.ShowDialog()
        txtFile.Text = FileDialog.FileName
        txtFileName.Text = FileDialog.SafeFileName

        Dim SavePath = Replace(txtFile.Text, txtFileName.Text, "")

        If SavePath IsNot Nothing Then
            KeyCreate.SetValue(_Key, SavePath)
        End If

        MyRefresh()

    End Sub

    Private Sub MyRefresh()

        proBar.Visible = False

        If txtFile.TextLength = 0 Then
            btnProceed.Enabled = False
        Else
            btnProceed.Enabled = True
        End If

    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click

        Dim MyDate = DateTime.Today
        Dim ExpiryDate = New DateTime(2027, 2, 28)

        If (MyDate < ExpiryDate) Then
            If Not File.Exists(ExcelFile) Then
                MsgBox("Excel file is NOT Exist")
                Return                                              '   Exit from here if file not exist.
            End If

            lblMessage.Text = "File is being loaded."

            Try
                xlWorkBooks = xlApp.Workbooks.Open(ExcelFile)
                xlWorkSheet = xlWorkBooks.Worksheets(4)
            Catch ex As Exception
                MessageBox.Show("Error : " + ex.Message)
                Return
            End Try



            Dim Total_Transactions As Integer = xlWorkSheet.Range("H13").Value
            Dim StartCell As Integer = 13
            Dim StartTransaction As Integer = 13

            proBar.Visible = True
            proBar.Minimum = 0
            proBar.Maximum = Total_Transactions

            lblMessage.Text = "Wait......"


            xlWorkSheet.Range("L1").ColumnWidth = 12
            xlWorkSheet.Range("N1").ColumnWidth = 35
            xlWorkSheet.Range("P1").ColumnWidth = 45

            For i = 1 To Total_Transactions

                lblMessage.Text = String.Concat("Transaction No ", i, "/", Total_Transactions.ToString, " is being copied")


                Dim Line1 As String = (StartCell + 0).ToString
                Dim Line2 As String = (StartCell + 1).ToString

                xlWorkSheet.Range(String.Concat("J", StartTransaction.ToString)).Value = xlWorkSheet.Range("H15").Value                      ' Sheet #
                xlWorkSheet.Range(String.Concat("K", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("A", Line1)).Value  ' Serial No. 
                xlWorkSheet.Range(String.Concat("L", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("B", Line1)).Value  ' Date
                xlWorkSheet.Range(String.Concat("M", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("C", Line1)).Value  ' Account ID
                xlWorkSheet.Range(String.Concat("N", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("D", Line1)).Value  ' Title of Account (value)
                xlWorkSheet.Range(String.Concat("O", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("C", Line2)).Value  ' Debit Voucher No.
                xlWorkSheet.Range(String.Concat("P", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("D", Line2)).Value  ' Description
                xlWorkSheet.Range(String.Concat("Q", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("E", Line1)).Value  ' Amount
                xlWorkSheet.Range(String.Concat("R", StartTransaction.ToString)).Value = xlWorkSheet.Range(String.Concat("F", Line1)).Value  ' Note
                xlWorkSheet.Range(String.Concat("S", StartTransaction.ToString)).Value = xlWorkSheet.Range("H14").Value                      ' Voucher No

                StartCell += 2                                           ' Skip Next Transaction (Source)
                StartTransaction += 1                                    ' Skip Next Transaction (Target)
                proBar.Value = i

            Next

            xlWorkBooks.Save()

            xlApp.Visible = True

        End If
        'Close_ExcelFile()

    End Sub

    Private Sub Close_ExcelFile()

        proBar.Visible = False
        xlWorkBooks.Close()
        xlApp.Quit()

        xlWorkSheet = Nothing
        xlWorkBooks = Nothing
        xlApp = Nothing

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub


End Class
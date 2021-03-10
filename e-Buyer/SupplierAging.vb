
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Connection_Class
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmSupplierAging

    Private Property File_location As String = "E:\AMCORP\Project Costing\Supplier Againg.xlsx"
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Private Sub SupplierAging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh()

    End Sub

    Private Sub MyRefresh()
        If File.Exists(File_location) Then
            txtFileLocation.Text = File_location
            xlWorkBook = xlApp.Workbooks.Open(File_location)
            xlWorkSheet = xlWorkBook.Worksheets("Title")
            txtAge1.Text = xlWorkSheet.Range("_Age1").Value
            txtAge2.Text = xlWorkSheet.Range("_Age2").Value
            txtAge3.Text = xlWorkSheet.Range("_Age3").Value
            txtAge4.Text = xlWorkSheet.Range("_Age4").Value
            txtAge5.Text = xlWorkSheet.Range("_Age5").Value
            txtAge6.Text = xlWorkSheet.Range("_Age6").Value
            txtAge7.Text = xlWorkSheet.Range("_Age7").Value
            txtAge8.Text = xlWorkSheet.Range("_Age8").Value
        Else
            txtFileLocation.Text = "File not exist...."
        End If
    End Sub


    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        xlApp.Visible = False

        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        xlApp.Visible = True
    End Sub

    Private Sub BtnFileSearch_Click(sender As Object, e As EventArgs) Handles btnFileSearch.Click
        Dim OFD As New OpenFileDialog()

        OFD.InitialDirectory = "E:\AMCORP\Project Costing\"
        OFD.Filter = "Excel files (*.xlsx)|*.txt|All files (*.*)|*.*"
        OFD.FilterIndex = 2
        OFD.RestoreDirectory = True

        If OFD.ShowDialog = DialogResult.OK Then
            File_location = OFD.FileName
        End If

        MyRefresh()

        'txtFileLocation.Text = OFD.FileName

    End Sub
End Class
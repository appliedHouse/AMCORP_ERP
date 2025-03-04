Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text
Imports System.Collections

Module CopyCOA_AG_JV_

    Dim MyMessages As New ArrayList
    Dim Table_Name As String = "[BizzTrax_Amcorp].[dbo].[tblChartofAccount]"
    Private Table_UnitName As String = "[Bizztrax_Amcorp].[dbo].[tblChartAccount_CompanyUnit]"
    Dim Table_COA As DataTable = Connection_Class.Get_DataTable(Table_Name, Connection_Amcorp)
    Dim Table_Units As DataTable = Connection_Class.Get_DataTable(Table_UnitName, Connection_Amcorp)
    Dim CompanyUnits As Integer() = {17, 18}            ' Company Units assign to MAP 

    Dim _ChartOfAccountID As Integer
    Dim _AccountCode As String '[nvarchar](50) Not NULL,
    Dim _AccountTitle As String '[nvarchar](100) Not NULL,
    Dim _Type As String '[nvarchar (25) Not NULL,
    Dim _SetLevel As Integer '[Int  Not NULL,
    Dim _ParentChartOfAccountID As Integer '[bigint  Not NULL,
    Dim _IsClosableAccount As Integer '[bit  Not NULL,
    Dim _AccountCategoryID As Integer '[bigint  Not NULL,
    Dim _AccountNature As String '[nvarchar (25) Not NULL,
    Dim _OpeningBalance As Integer '[money  Not NULL,
    Dim _CurrentBalance As Integer '_money  Not NULL,
    Dim _Remarks As String '_nvarchar (1000) Not NULL,
    Dim _Active As Integer '_bit  Not NULL,
    Dim _OldCode As String '_nvarchar (20) Not NULL,
    Dim _IsTaxApplied As Integer '_bit  Not NULL,
    Dim _TaxDeductionID As Integer '_bigint  Not NULL,
    Dim _TaxExmpDate As Date '_DateTime  NULL,
    Dim _isChequePrintingRequired As Integer  '_bit  Not NULL,
    Dim _CompanyID As Integer '_bigint  Not NULL,
    Dim _CurrencyID As Integer '_bigint  Not NULL,
    Dim _CreationDate As Date '_DateTime  Not NULL,
    Dim _ModificationDate As Date '_DateTime  Not NULL,     
    Dim _MobileNo As String '_varchar (100) Not NULL,
    Dim _IsBalanceSheet As Integer '_bit  Not NULL,
    Dim _IsPNL As Integer '_bit  Not NULL,
    Dim _FifiCode As String '_nvarchar (50) Not NULL,
    Dim _OldTitle As String '_varchar (100) Not NULL,
    Dim _IsFundTransfer As Integer '[bit] Not NULL

    Dim MyCompanyID As Integer = 5                          ' SSELECT AMCORP-GGASCO JV ERP Account PIN = "AG"
    Dim MessageForm As New frmMessageForm


    Public Sub Copy_COA_JV_ACC()

        MyMessages.Add("Copy Chart of Accounts Start at " & Now.ToLongDateString & " " & Now.ToLongTimeString)



        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open("E:\AMCORP\COPY_COA_JV.xlsx")
        Dim xlWorkSheet As Excel.Worksheet = xlWorkBook.Worksheets("Sheet1")

        Dim Sheet_Row As Integer = 2
        Dim Sheet_Column As Integer = 0

        MyMessages.Add(CType(xlApp.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet))

        MessageForm.Show()

        While True

            If IsNothing(xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 1).Value) Then
                Exit While
            End If

            _ChartOfAccountID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 1).value
            _AccountCode = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 2).value
            _AccountTitle = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 3).value
            _Type = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 4).value
            _SetLevel = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 5).value
            _ParentChartOfAccountID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 6).value
            _IsClosableAccount = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 7).value
            _AccountCategoryID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 8).value
            _AccountNature = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 9).value
            _OpeningBalance = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 10).value
            _CurrentBalance = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 11).value
            _Remarks = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 12).value
            _Active = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 13).value
            _OldCode = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 14).value
            _IsTaxApplied = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 15).value
            _TaxDeductionID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 16).value
            _TaxExmpDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 17).value
            _isChequePrintingRequired = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 18).value
            _CompanyID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 19).value
            _CurrencyID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 20).value
            _CreationDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 21).value
            _ModificationDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 22).value
            _MobileNo = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 23).value
            _IsBalanceSheet = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 24).value
            _IsPNL = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 25).value
            _FifiCode = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 26).value
            _OldTitle = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 27).value
            _IsFundTransfer = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 28).value

            RecordSave(_ChartOfAccountID)

            For i = 0 To CompanyUnits.Length - 1
                UpdateUnits(_ChartOfAccountID, CompanyUnits(i), _CompanyID)
            Next

            '=====================
            Sheet_Row += 1
        End While

        MsgBox("Chart of Accounts have been updated.")


        '================================================ CLOSE EXCELL OBJECT FROM COMPUTER MEMEORY

        xlWorkBook.Close()
        xlApp.Quit()

        Marshal.ReleaseComObject(xlWorkBook)
        Marshal.ReleaseComObject(xlWorkSheet)
        Marshal.ReleaseComObject(xlApp)
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        '====================================================================================== END


    End Sub



    Private Sub RecordSave(_RecordID As Integer)

        Dim _Messages As New ArrayList
        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)
        Dim View_COA As New DataView

        View_COA.Table = Table_COA
        View_COA.RowFilter = String.Concat("CompanyID=", MyCompanyID.ToString, " AND ChartofAccountID=", _RecordID.ToString)

        If View_COA.Count = 0 Then
            _SQLCommand.CommandText = GetCommandInsert()
        Else
            _SQLCommand.CommandText = GetCommandUpdate()
        End If

        Try
            'Dim _ResultRow As Integer = _SQLCommand.ExecuteNonQuery
            _Messages.Add("Records ")
            _Messages.Add(IIF(View_COA.Count = 0, "Insert ", "Update "))
            _Messages.Add("Record ID=" & _RecordID)
            _Messages.Add("Account Title=" & _AccountTitle)
            _Messages.Add("------------")
        Catch ex As Exception
            _Messages.Add("")
            _Messages.Add("ERROR")
            _Messages.Add("=====")
            _Messages.Add("")
            _Messages.Add(ex.Message)
            _Messages.Add("------------")
        End Try

        MessageForm.Text = _Messages.ToString
        MessageForm.Refresh()

    End Sub

    Private Function GetCommandInsert()
        Dim _CommandText As New StringBuilder

        _CommandText.Append("INSERT INTO ")
        _CommandText.Append(Table_Name)
        _CommandText.Append(" VALUES ")

        _CommandText.Append("(")
        _CommandText.Append(_ChartOfAccountID & ",")
        _CommandText.Append("'" & _AccountCode & "',")
        _CommandText.Append("'" & _AccountTitle & "',")
        _CommandText.Append("'" & _Type & "',")
        _CommandText.Append(_SetLevel & ",")
        _CommandText.Append(_ParentChartOfAccountID & ",")
        _CommandText.Append(_IsClosableAccount & ",")
        _CommandText.Append(_AccountCategoryID & ",")
        _CommandText.Append("'" & _AccountNature & "',")
        _CommandText.Append(_OpeningBalance & ",")
        _CommandText.Append(_CurrentBalance & ",")
        _CommandText.Append("'" & _Remarks & "',")
        _CommandText.Append(_Active & ",")
        _CommandText.Append("'" & _OldCode & "',")
        _CommandText.Append(_IsTaxApplied & ",")
        _CommandText.Append(_TaxDeductionID & ",")
        _CommandText.Append("'" & _TaxExmpDate & "',")
        _CommandText.Append(_isChequePrintingRequired & ",")
        _CommandText.Append(_CompanyID & ",")
        _CommandText.Append(_CurrencyID & ",")
        _CommandText.Append("'" & _CreationDate & "',")
        _CommandText.Append("'" & _ModificationDate & "',")
        _CommandText.Append("'" & _MobileNo & "',")
        _CommandText.Append(_IsBalanceSheet & ",")
        _CommandText.Append(_IsPNL & ",")
        _CommandText.Append("'" & _FifiCode & "',")
        _CommandText.Append("'" & _OldTitle & "',")
        _CommandText.Append(_IsFundTransfer)
        _CommandText.Append(")")

        Return _CommandText.ToString
    End Function

    Private Function GetCommandUpdate()
        Dim _CommandText As New StringBuilder

        _CommandText.Append("UPDATE ")
        _CommandText.Append(Table_Name)
        _CommandText.Append(" SET ")

        _CommandText.Append("ChartOfAccountID=" & _ChartOfAccountID & ",")
        _CommandText.Append("AccountCode='" & _AccountCode & "',")
        _CommandText.Append("AccountTitle='" & _AccountTitle & "',")
        _CommandText.Append("Type='" & _Type & "',")
        _CommandText.Append("SetLevel=" & _SetLevel & ",")
        _CommandText.Append("ParentChartOfAccountID=" & _ParentChartOfAccountID & ",")
        _CommandText.Append("IsClosableAccount=" & _IsClosableAccount & ",")
        _CommandText.Append("AccountCategoryID=" & _AccountCategoryID & ",")
        _CommandText.Append("AccountNature='" & _AccountNature & "',")
        _CommandText.Append("OpeningBalance=" & _OpeningBalance & ",")
        _CommandText.Append("CurrentBalance=" & _CurrentBalance & ",")
        _CommandText.Append("Remarks='" & _Remarks & "',")
        _CommandText.Append("Active=" & _Active & ",")
        _CommandText.Append("OldCode='" & _OldCode & "',")
        _CommandText.Append("IsTaxApplied=" & _IsTaxApplied & ",")
        _CommandText.Append("TaxDeductionID=" & _TaxDeductionID & ",")
        _CommandText.Append("TaxExmpDate='" & _TaxExmpDate & "',")
        _CommandText.Append("isChequePrintingRequired=" & _isChequePrintingRequired & ",")
        _CommandText.Append("CompanyID=" & _CompanyID & ",")
        _CommandText.Append("CurrencyID=" & _CurrencyID & ",")
        _CommandText.Append("CreationDate='" & _CreationDate & "',")
        _CommandText.Append("ModificationDate='" & _ModificationDate & "',")
        _CommandText.Append("MobileNo='" & _MobileNo & "',")
        _CommandText.Append("IsBalanceSheet=" & _IsBalanceSheet & ",")
        _CommandText.Append("IsPNL=" & _IsPNL & ",")
        _CommandText.Append("FifiCode='" & _FifiCode & "',")
        _CommandText.Append("OldTitle='" & _OldTitle & "',")
        _CommandText.Append("IsFundTransfer=" & _IsFundTransfer)
        _CommandText.Append(" WHERE " & "ChartOfAccountID=" & _ChartOfAccountID)


        Return _CommandText.ToString
    End Function

    Private Function UpdateUnits(_COA As Integer, _Unit As Integer, _Company As Integer)

        Dim IsError As Boolean = False
        Dim View_Table As New DataView
        View_Table.Table = Table_Units
        View_Table.RowFilter = String.Concat("ChartofAccountID=", _COA.ToString, " AND CompanyUnitID=", _Unit.ToString, " AND CompanyID=", _Company.ToString)

        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)

        If View_Table.Count = 0 Then
            _SQLCommand.CommandText = String.Concat("INSERT INTO ", Table_UnitName, " VALUES (", _COA, ",", _Unit, ",", _Company, ")")
        ElseIf View_Table.Count = 1 Then
            _SQLCommand.CommandText = String.Concat("UPDATE ", Table_UnitName, " SET ChartofAccountID=", _COA, ", CompanyUnitID=", _Unit, ", CompanyID=", _Company, " WHERE ", View_Table.RowFilter)
        Else
            IsError = True
            MsgBox("Two Records of same value found...", MsgBoxStyle.Critical, "ERROR")
        End If

        'Dim _Result As Integer = 0

        If Not IsError Then
            _SQLCommand.ExecuteNonQuery()
        End If

        'MsgBox(_Result.ToString & " Records " & IIF(View_Table.Count = 0, "Inserted.", "Updated."))

        'Stop

        Return True
    End Function


    Private Function IIF(_Login As Boolean, _True As Object, _False As Object) As Object
        Dim _Result As Object
        If _Login Then
            _Result = _True
        Else
            _Result = _False
        End If
        Return _Result
    End Function

End Module

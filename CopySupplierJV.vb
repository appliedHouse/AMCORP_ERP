Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text
Imports System.Collections

Module CopySupplierJV

    Dim ExcelFile As String = "E:\AMCORP\COPY_SUPPLIER.xlsx"
    Dim Table_Name As String = "[master].[dbo].[tblSupplier]"
    Dim Table_Supplier As DataTable = Connection_Class.Get_DataTable(Table_Name, Connection_Amcorp)

    Dim _SupplierID As Integer             '[bigint] Not NULL,
    Dim _SupplierTitle As String           '[varchar](100) Not NULL,
    Dim _SupplierCategoryID As Integer     '[bigint] Not NULL,
    Dim _TownID As Integer                 '[bigint] Not NULL,
    Dim _ContactPerson As String           '[varchar](50) Not NULL,
    Dim _Designation As String             '[varchar](50) Not NULL,
    Dim _Address As String                 '[varchar](200) Not NULL,
    Dim _Email As String                   '[varchar](50) Not NULL,
    Dim _ContactNumber As String           '[varchar](50) Not NULL,
    Dim _FaxNumber As String               '[varchar](50) Not NULL,
    Dim _NTNNumber As String               '[varchar](20) Not NULL,
    Dim _CreditDays As Integer             '[float] Not NULL,
    Dim _AccountCode As String             '[varchar](50) Not NULL,
    Dim _Remarks As String                 '[nvarchar](1000) Not NULL,
    Dim _Active As Boolean                 '[bit] Not NULL,
    Dim _Commission As Integer             '[float] Not NULL,
    Dim _OpeningBalance As Integer         '[float] Not NULL,
    Dim _SupplierRefNo As String           '[nvarchar](50) Not NULL,
    Dim _CompanyID As Integer              '[bigint] Not NULL,
    Dim _ChartOfAccountID As Integer       '[bigint] Not NULL,
    Dim _CreationDate As Date              '[DateTime] Not NULL,
    Dim _ModificationDate As Date          '[DateTime] Not NULL,
    Dim _CurrencyID As Integer             '[bigint] Not NULL,
    Dim _TaxCategoryID As Integer          '[bigint] NULL,
    Dim _NIC As String                     '[varchar](50) Not NULL,
    Dim _STN As String                     '[varchar](50) Not NULL,
    Dim _IsExemption As Integer            '[bit] Not NULL,
    Dim _ExemptionFromDate As Date         '[DateTime] Not NULL,
    Dim _ExemptionToDate As Date           '[DateTime] Not NULL,
    Dim _SupplierType As String            '[varchar](50) Not NULL,
    Dim _SupplierBusinessTitle As String   '[varchar](100) Not NULL,
    Dim _SupplierCityID As Integer         '[bigint] Not NULL,
    Dim _SupplierCountryID As Integer      '[bigint] Not NULL,
    Dim _Description As String             '[varchar](1000) Not NULL,
    Dim _PaymentTermID As Integer          '[bigint] Not NULL,
    Dim _TaxPayerStatus As String          '[varchar](25) Not NULL,
    Dim _Latitude As Integer               '[float] Not NULL,
    Dim _Longitude As Integer              '[float] Not NULL

    Dim MyCompanyID As Integer = 5                          ' SSELECT AMCORP-GGASCO JV ERP Account PIN = "AG"
    Dim MessageForm As New frmMessageForm()
    Dim AddonlyNew As Boolean = True
    Dim MyMessages As New ArrayList

    Public Sub Copy_SupplierJV()

        MyMessages.Add("Copy Supplier to AG-JV Start at " & Now.ToLongDateString & " " & Now.ToLongTimeString)

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open(ExcelFile)
        Dim xlWorkSheet As Excel.Worksheet = xlWorkBook.Worksheets("Sheet1")

        Dim Sheet_Row As Integer = 2
        Dim Sheet_Column As Integer = 0

        MyMessages.Add(CType(xlApp.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet))

        While True

            If IsNothing(xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 1).Value) Then
                MsgBox("Cell has nothing value")
                Exit While
            End If

            _SupplierID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 1).value
            _SupplierTitle = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 2).value
            _SupplierCategoryID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 3).value
            _TownID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 4).value
            _ContactPerson = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 5).value
            _Designation = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 6).value
            _Address = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 7).value
            _Email = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 8).value
            _ContactNumber = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 9).value
            _FaxNumber = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 10).value
            _NTNNumber = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 11).value
            _CreditDays = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 12).value
            _AccountCode = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 13).value
            _Remarks = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 14).value
            _Active = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 15).value
            _Commission = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 16).value
            _OpeningBalance = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 17).value
            _SupplierRefNo = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 18).value
            _CompanyID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 19).value
            _ChartOfAccountID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 20).value
            _CreationDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 21).value
            _ModificationDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 22).value
            _CurrencyID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 23).value
            _TaxCategoryID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 24).value
            _NIC = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 25).value
            _STN = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 26).value
            _IsExemption = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 27).value
            _ExemptionFromDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 28).value
            _ExemptionToDate = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 29).value
            _SupplierType = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 30).value
            _SupplierBusinessTitle = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 31).value
            _SupplierCityID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 32).value
            _SupplierCountryID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 33).value
            _Description = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 34).value
            _PaymentTermID = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 35).value
            _TaxPayerStatus = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 36).value
            _Latitude = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 37).value
            _Longitude = xlWorkSheet.Cells(Sheet_Row, Sheet_Column + 38).value

            RecordSave(_SupplierID)

            MessageForm.txtMessages.Text = MyMessages.ToString
            MessageForm.Refresh()
            'MessageForm.Show()

            '=====================
            Sheet_Row += 1


        End While

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

        View_COA.Table = Table_Supplier
        View_COA.RowFilter = String.Concat("CompanyID=", MyCompanyID.ToString, " AND ChartofAccountID=", _RecordID.ToString)

        If View_COA.Count = 0 Then
            _SQLCommand.CommandText = GetCommandInsert()
        Else
            If Not AddonlyNew Then
                MyMessages.Add(_SupplierTitle & " Skip.  (Do not Update).")
                _SQLCommand.CommandText = GetCommandUpdate()
            End If
        End If

        'Try
        Dim _ResultRow As Integer = _SQLCommand.ExecuteNonQuery
            _Messages.Add("Records ")
            _Messages.Add(IIf(View_COA.Count = 0, "Insert ", "Update "))
            _Messages.Add("Record ID=" & _RecordID)
            _Messages.Add("Supplier Title=" & _SupplierTitle)
            _Messages.Add("------------")
        'Catch ex As Exception
        '_Messages.Add("")
        '_Messages.Add("ERROR")
        '_Messages.Add("=====")
        '_Messages.Add("")
        '_Messages.Add(ex.Message)
        '_Messages.Add("------------")

        'Stop
        'Dim ShowForm As New frmMessageForm(_Messages)
        'ShowForm.ShowDialog()
        'End Try


    End Sub

    Private Function GetCommandInsert()
        Dim _CommandText As New StringBuilder

        _CommandText.Append("INSERT INTO ")
        _CommandText.Append(Table_Name)
        _CommandText.Append(" VALUES ")

        _CommandText.Append("(")
        _CommandText.Append(_SupplierID & ",")
        _CommandText.Append("'" & _SupplierTitle & "',")
        _CommandText.Append(_SupplierCategoryID & ",")
        _CommandText.Append(_TownID & ",")
        _CommandText.Append("'" & _ContactPerson & "',")
        _CommandText.Append("'" & _Designation & "',")
        _CommandText.Append("'" & _Address & "',")
        _CommandText.Append("'" & _Email & "',")
        _CommandText.Append("'" & _ContactNumber & "',")
        _CommandText.Append("'" & _FaxNumber & "',")
        _CommandText.Append("'" & _NTNNumber & "',")
        _CommandText.Append(_CreditDays & ",")
        _CommandText.Append("'" & _AccountCode & "',")
        _CommandText.Append("'" & _Remarks & "',")
        _CommandText.Append(IIf(_Active, 1, 0) & ",")
        _CommandText.Append(_Commission & ",")
        _CommandText.Append(_OpeningBalance & ",")
        _CommandText.Append("'" & _SupplierRefNo & "',")
        _CommandText.Append(_CompanyID & ",")
        _CommandText.Append(_ChartOfAccountID & ",")
        _CommandText.Append("'" & _CreationDate & "',")
        _CommandText.Append("'" & _ModificationDate & "',")
        _CommandText.Append(_CurrencyID & ",")
        _CommandText.Append(_TaxCategoryID & ",")
        _CommandText.Append("'" & _NIC & "',")
        _CommandText.Append("'" & _STN & "',")
        _CommandText.Append(_IsExemption & ",")
        _CommandText.Append("'" & _ExemptionFromDate & "',")
        _CommandText.Append("'" & _ExemptionToDate & "',")
        _CommandText.Append("'" & _SupplierType & "',")
        _CommandText.Append("'" & _SupplierBusinessTitle & "',")
        _CommandText.Append(_SupplierCityID & ",")
        _CommandText.Append(_SupplierCountryID & ",")
        _CommandText.Append("'" & _Description & "',")
        _CommandText.Append(_PaymentTermID & ",")
        _CommandText.Append("'" & _TaxPayerStatus & "',")
        _CommandText.Append(_Latitude & ",")
        _CommandText.Append(_Longitude)
        _CommandText.Append(")")

        Return _CommandText.ToString
    End Function

    Private Function GetCommandUpdate()
        Dim _CommandText As New StringBuilder

        _CommandText.Append("UPDATE ")
        _CommandText.Append(Table_Name)
        _CommandText.Append(" SET ")

        _CommandText.Append("SupplierID=", _SupplierID & ",")
        _CommandText.Append("SupplierTitle='", _SupplierTitle & "',")
        _CommandText.Append("SupplierCategoryID=", _SupplierCategoryID & ",")
        _CommandText.Append("TownID=", _TownID & ",")
        _CommandText.Append("ContactPerson='", _ContactPerson & "',")
        _CommandText.Append("Designation='", _Designation & "',")
        _CommandText.Append("Address='", _Address & "',")
        _CommandText.Append("Email='", _Email & "',")
        _CommandText.Append("ContactNumber='", _ContactNumber & "',")
        _CommandText.Append("FaxNumber='", _FaxNumber & "',")
        _CommandText.Append("NTNNumber='", _NTNNumber & "',")
        _CommandText.Append("CreditDays=", _CreditDays & ",")
        _CommandText.Append("AccountCode='", _AccountCode & "',")
        _CommandText.Append("Remarks='", _Remarks & "',")
        _CommandText.Append("Active=", _Active & ",")
        _CommandText.Append("Commission=", _Commission & ",")
        _CommandText.Append("Commission=", _OpeningBalance & ",")
        _CommandText.Append("SupplierRefNo='", _SupplierRefNo & "',")
        _CommandText.Append("CompanyID=", _CompanyID & ",")
        _CommandText.Append("ChartOfAccountID=", _ChartOfAccountID & ",")
        _CommandText.Append("CreationDate='", _CreationDate & "',")
        _CommandText.Append("ModificationDate='", _ModificationDate & "',")
        _CommandText.Append("CurrencyID=", _CurrencyID & ",")
        _CommandText.Append("TaxCategoryID=", _TaxCategoryID & ",")
        _CommandText.Append("NIC='", _NIC & "',")
        _CommandText.Append("STN='", _STN & "',")
        _CommandText.Append("IsExemption=", _IsExemption & ",")
        _CommandText.Append("ExemptionFromDate='", _ExemptionFromDate & "',")
        _CommandText.Append("ExemptionToDate='", _ExemptionToDate & "',")
        _CommandText.Append("SupplierType='", _SupplierType & "',")
        _CommandText.Append("SupplierBusinessTitle='", _SupplierBusinessTitle & "',")
        _CommandText.Append("SupplierCityID=", _SupplierCityID & ",")
        _CommandText.Append("SupplierCountryID=", _SupplierCountryID & ",")
        _CommandText.Append("Description='", _Description & "',")
        _CommandText.Append("PaymentTermID=", _PaymentTermID & ",")
        _CommandText.Append("TaxPayerStatus='", _TaxPayerStatus & "',")
        _CommandText.Append("Latitude=", _Latitude & ",")
        _CommandText.Append("Longitude=", _Longitude)
        _CommandText.Append(" WHERE " & "SupplierID=" & _ChartOfAccountID)

        Return _CommandText.ToString
    End Function

End Module

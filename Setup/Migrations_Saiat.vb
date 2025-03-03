Imports System.Data
Imports System.Data.SqlClient
Imports Connection_Class
Imports System.Text
Imports System.Windows
Imports System.Collections


Public Class frmMigrations_Amcorp

    Private ReadOnly FilePath As String = "E:\AMCORP\Migration\"
    Private ReadOnly FileName As String = "Migrations_AGJV_PVT.xlsx"
    Private ReadOnly ExcelFile As String = String.Concat(FilePath, FileName)




    Private ReadOnly TableNameCOAcat As String = "[dbo].[tblAccountCategory]"               ' Chart of Accounts Category
    Private ReadOnly TableNameCOA As String = "[dbo].[tblChartofAccount]"                   ' Chart of Accounts
    Private ReadOnly TableNameCOAUnits As String = "[dbo].[tblChartAccount_CompanyUnit]"    ' COA Branch Units
    Private ReadOnly TableNameItemCat As String = "[dbo].[tblCategory]"                     ' Products' Item Category
    Private ReadOnly TableNameItems As String = "[dbo].[tblItem]"                           ' List of Product Items
    Private ReadOnly TableNameItemsFlag As String = "[dbo].[tblItemFlag]"                   ' Items Flag
    Private ReadOnly TableNameItemsMapping As String = "[dbo].[tblItem_ChartofAccount]"     ' Items Mapping with COA
    Private ReadOnly TableNameCity As String = "[dbo].[tblCity]"                            ' List of Cities
    Private ReadOnly TableNameUOM As String = "[dbo].[tblUOM]"                              ' List of Cities
    Private ReadOnly TableNameSupplier As String = "[dbo].[tblSupplier]"                    ' List of Suppliers
    Private ReadOnly TableNameExpenses As String = "[dbo].[tblExpense]"                     ' List of WIP Expenses


    Private ReadOnly Sheet_COACat As String = "[COACat$]"                                   ' Category of Chart of Accounts Sheet
    Private ReadOnly Sheet_COA As String = "[COA$]"                                         ' Chart of Accounts
    Private ReadOnly Sheet_ItemCat As String = "[ItemCat$]"                                 ' Products / Items Category
    Private ReadOnly Sheet_Items As String = "[Items$]"                                     ' List of Products / Items 
    Private ReadOnly Sheet_City As String = "[City$]"                                       ' List of Cities
    Private ReadOnly Sheet_Suppliers As String = "[Suppliers$]"                             ' List of Suppliers
    Private ReadOnly Sheet_Expenses As String = "[Expenses$]"                               ' List of Expenses

    Private Table_COACat As DataTable
    Private Table_COA As DataTable
    Private Table_COAUnits As DataTable
    Private Table_City As DataTable
    Private Table_UOM As DataTable
    Private Table_Supplier As DataTable
    Private Table_Expenses As DataTable

    Private Table_ItemCat As DataTable
    Private Table_Items As DataTable
    Private Table_ItemsFlag As DataTable
    Private Table_ItemsMapping As DataTable

    Private SourceCOACat As DataTable
    Private SourceCOA As DataTable
    Private SourceItemCat As DataTable
    Private SourceItems As DataTable
    Private SourceCity As DataTable
    Private SourceUOM As DataTable
    Private SourceSupplier As DataTable
    Private SourceExpenses As DataTable

    Private LastLine As Integer
    Private MyUnits As Array                                 ' Add Branch in company chart of Accounts

    Private Property SourceCompanyID As Integer = 7          ' Select Amcor-Orient JV Company
    Private Property MyDataTable As DataTable
    Private Property MyPrimaryKeyName As String
    Private Property MyPrimaryKeyValue As Integer
    Private Property MyMessages As ArrayList = New ArrayList

    Private Sub Migrations_Amcorp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyRefresh()

    End Sub

    Private Sub MyRefresh()

        Table_COAUnits = Get_DataTable(TableNameCOAUnits, Connection_Amcorp)

        gridItemCoat.DataSource = SourceItemCat

        RecordsProcess.Visible = False

        lblMessages.Text = ExcelFile


    End Sub


    Private Sub FrmMigration_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub frmMigration_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MyRefresh()
    End Sub

    Private Sub btnMigration_Cat_Click(sender As Object, e As EventArgs) Handles btnMigrationCOACat.Click

        Dim _SourceTable As DataTable = SourceCOACat
        Dim _TableView As New DataView(Table_COACat)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0


        For Each _Row As DataRow In SourceCOACat.Rows
            MyPrimaryKeyName = "AccountCategoryID"
            MyPrimaryKeyValue = _Row("AccountCatID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("AccountCatID") = -1 Then
                Continue For
            End If

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("AccountCategoryID") = Convert.ToInt32(_Row("AccountcatID").ToString)
                _DataRow("AccountCategoryCode") = _Row("AccountcATCode").ToString
                _DataRow("AccountCategoryTitle") = _Row("AccountCatTitle")
                _DataRow("Remarks") = ""
                _DataRow("Active") = True
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("CreationDate") = Now
                _DataRow("ModificationDate") = Now
                _DataRow("AccountCategoryGroupID") = _Row("GroupCode")
                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("AccountCatTitle")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)

        Next

        lblMessages.Text = "Process Completed."
        RecordsProcess.Visible = False


    End Sub

    Private Sub btnMigration_Click(sender As Object, e As EventArgs) Handles btnMigrationCOA.Click

        Dim _SourceTable As DataTable = SourceCOA
        Dim _TableView As New DataView(Table_COA)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0

        For Each _Row As DataRow In SourceCOA.Rows

            If IsDBNull(_Row("ID")) Then
                Continue For
            End If

            MyPrimaryKeyName = "ChartOfAccountID"
            MyPrimaryKeyValue = _Row("ID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("ID") = -1 Then
                Continue For
            End If

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("ChartOfAccountID") = Convert.ToInt32(_Row("ID").ToString)
                _DataRow("AccountCode") = _Row("Code").ToString
                _DataRow("AccountTitle") = _Row("Title").ToString
                _DataRow("Type") = _Row("Type").ToString
                _DataRow("SetLevel") = _Row("Level").ToString
                _DataRow("ParentChartOfAccountID") = _Row("Parent").ToString
                _DataRow("IsClosableAccount") = 0
                _DataRow("AccountCategoryID") = _Row("COACat").ToString
                _DataRow("AccountNature") = _Row("Nature").ToString
                _DataRow("OpeningBalance") = 0
                _DataRow("CurrentBalance") = 0
                _DataRow("Remarks") = ""
                _DataRow("Active") = True
                _DataRow("OldCode") = ""
                _DataRow("IsTaxApplied") = 0
                _DataRow("TaxDeductionID") = -1
                _DataRow("TaxExmpDate") = "2001-01-01"
                _DataRow("isChequePrintingRequired") = 0
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("CurrencyID") = -1
                _DataRow("CreationDate") = Now
                _DataRow("ModificationDate") = Now
                _DataRow("MobileNo") = ""
                _DataRow("IsBalanceSheet") = _Row("BSheet")
                _DataRow("IsPNL") = If(_Row("BSheet") = 0, 1, 0)
                _DataRow("FifiCode") = ""
                _DataRow("OldTitle") = ""
                _DataRow("IsFundTransfer") = 0
                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("Title")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)
        Next

        lblMessages.Text = "COA Process Completed."
        RecordsProcess.Visible = False

    End Sub

    Private Sub btnMigrationItemCat_Click(sender As Object, e As EventArgs) Handles btnMigrationItemCat.Click

        Dim _SourceTable As DataTable = SourceItemCat
        Dim _TableView As New DataView(Table_ItemCat)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0

        For Each _Row As DataRow In SourceItemCat.Rows
            MyPrimaryKeyName = "CategoryID"
            MyPrimaryKeyValue = _Row("ID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("ID") = -1 Then
                Continue For
            End If

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("CategoryID") = _Row("ID")
                _DataRow("Categorytitle") = _Row("Title")
                _DataRow("Active") = True
                _DataRow("AccountCode") = _Row("COAID")
                _DataRow("Percentage") = 0
                _DataRow("Discount") = 0
                _DataRow("CategoryRefNo") = _Row("Code")
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("TranType") = ""
                _DataRow("DepreciationPercentage") = 0
                _DataRow("ScrapPercentage") = 0
                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("Title")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)
        Next

        lblMessages.Text = "Process Completed."
        RecordsProcess.Visible = False


    End Sub

    Private Sub btnMigrationItems_Click(sender As Object, e As EventArgs) Handles btnMigrationItems.Click

        lblMessages.Text = "Items Data Loading......."

        Dim _SourceTable As DataTable = SourceItems
        Dim _TableView As New DataView(Table_Items)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0


        lblMessages.Text = "Items Data Loaded"

        For Each _Row As DataRow In SourceItems.Rows

            If _Row("ID") = 0 Or _Row("ID") Is Nothing Then
                Exit For
            End If

            MyPrimaryKeyName = "ItemID"
            MyPrimaryKeyValue = _Row("ID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("ID") = -1 Then
                Continue For
            End If

            If _Row("Edit") = 0 Then
                Continue For
            End If

            If _Row("Title2").ToString.Length > 0 Then
                _Row("Title") = _Row("Title2")
            End If


            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("ItemID") = _Row("ID")  'Convert.ToInt32(_Row(_DataRow("ID".ToString)
                _DataRow("Itemtitle") = _Row("Title")
                _DataRow("Active") = _Row("Active")
                _DataRow("CategoryID") = _Row("Cat")
                _DataRow("ClassID") = _Row("Class")
                _DataRow("UOMID") = _Row("UOM")
                _DataRow("ItemRefNo") = _Row("REFNo")
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("GroupID") = 3
                _DataRow("Unit") = ""
                _DataRow("PartNumber") = ""
                _DataRow("Location") = ""
                _DataRow("Make") = ""
                _DataRow("MinLevel") = 0
                _DataRow("MaxLevel") = 0
                _DataRow("RedAlertLevel") = 0
                _DataRow("ReOrderLevel") = 0
                _DataRow("ReOrderQty") = 0
                _DataRow("LeadTime") = 0
                _DataRow("PurchaseRate") = 0
                _DataRow("TradeRate") = 0
                _DataRow("DITPurchaseRate") = 0
                _DataRow("DITTradeRate") = 0
                _DataRow("Weight") = 1
                _DataRow("OldItemID") = ""
                _DataRow("AverageRate") = 0
                _DataRow("AverageRateExST") = 0
                _DataRow("Discount") = 0
                _DataRow("Bonus") = 0
                _DataRow("ISTaxable") = "Y"
                _DataRow("ISInstitutional") = "0"
                _DataRow("WtPerPcs") = 0
                _DataRow("PcsPerPkt") = 0
                _DataRow("PktWt") = 0
                _DataRow("UnitPerCtn") = 0
                _DataRow("CtnWt") = 0
                _DataRow("SalesCode") = ""
                _DataRow("SalesReturnCode") = ""
                _DataRow("UnitID") = -1
                _DataRow("WeightageUnit") = ""
                _DataRow("CatalogNo") = ""
                _DataRow("ItemPic") = ""
                _DataRow("ISType") = "C"
                _DataRow("ISProcurement") = "0"
                _DataRow("ISManufacturing") = "0"
                _DataRow("PreferedSupplierID") = -1
                _DataRow("PurchaseRateType") = "M"
                _DataRow("CurrencyID") = -1
                _DataRow("ConversionRate") = 0
                _DataRow("ItemType") = "I"
                _DataRow("MaterialType") = "R"
                _DataRow("IsInspected") = 0
                _DataRow("IsExcise") = 0
                _DataRow("ItemDescription") = ""
                _DataRow("STRate") = 0
                _DataRow("SEDRate") = 0
                _DataRow("MultipleBatch") = 0
                _DataRow("BatchLevel2") = 0
                _DataRow("BatchLevel3") = 0
                _DataRow("ValuationProcess") = "A"
                _DataRow("FixedRate") = 0
                _DataRow("SupplierID") = 2264
                _DataRow("PackagingID") = 3
                _DataRow("TypeID") = 15
                _DataRow("TaxCategoryID") = 78
                _DataRow("PurchaseUnit") = 0
                _DataRow("SalesUnit") = 0
                _DataRow("IsLock") = True
                _DataRow("ItemOrder") = -1
                _DataRow("DamageLeakageRateValue") = 0
                _DataRow("DamageLeakageRateType") = "F"
                _DataRow("DamageDentedRateValue") = 0
                _DataRow("DamageDentedRateType") = "P"
                _DataRow("DivisionID") = -1
                _DataRow("PrimaryItemID") = 0
                _DataRow("QuantityType") = "Both"
                _DataRow("DecimalPlaceCount") = 0
                _DataRow("CategoryRefNo") = ""
                _DataRow("ClassRefNo") = ""
                _DataRow("GroupRefNo") = ""
                _DataRow("UnitRefNo") = ""
                _DataRow("TaxCategoryRefNo") = ""
                _DataRow("SupplierRefNo") = ""
                _DataRow("DepreciationPercentage") = 0
                _DataRow("ScrapValue") = 0
                _DataRow("TranType") = ""
                _DataRow("ProductShortName") = ""
                _DataRow("SchemeTitle") = "12+1"
                _DataRow("DepreciationMethod") = ""
                _DataRow("ExpiryAge") = 0
                _DataRow("ExpiryAgeType") = "Year"
                _DataRow("ItemBarCode") = _Row("REFNo")
                _DataRow("DiscountRateType") = "Percentage"
                _DataRow("CommissionRateType") = "Percentage"
                _DataRow("CommissionRate") = 0
                _DataRow("ManualRate") = 0
                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("Title")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)

            lblMessages.Text = SaveItemFlag(MyPrimaryKeyValue) & " " & _Row("Title")
            MyMessages.Add(lblMessages.Text)
            lblMessages.Refresh()

            lblMessages.Text = SaveItemmMapping(MyPrimaryKeyValue, _Row("ItemCOA")) & " " & _Row("Title")
            MyMessages.Add(lblMessages.Text)
            lblMessages.Refresh()

        Next

        lblMessages.Text = "Process Completed."
        RecordsProcess.Visible = False

    End Sub

    Private Sub btnMigrationSupplier_Click(sender As Object, e As EventArgs) Handles btnMigrationSupplier.Click

        Dim _SourceTable As DataTable = SourceSupplier
        Dim _TableView As New DataView(Table_Supplier)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0

        For Each _Row As DataRow In _SourceTable.Rows

            MyPrimaryKeyName = "SupplierID"
            MyPrimaryKeyValue = _Row("SupplierID") '_Row("SupplierID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("SupplierID") = -1 Then
                Continue For
            End If

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("SupplierID") = _Row("SupplierID")
                _DataRow("SupplierTitle") = _Row("SupplierTitle")
                _DataRow("SupplierCategoryID") = _Row("SupplierCategoryID")
                _DataRow("TownID") = -1
                _DataRow("ContactPerson") = _Row("ContactPerson")
                _DataRow("Designation") = ""
                _DataRow("Address") = _Row("Address")
                _DataRow("Email") = _Row("Email")
                _DataRow("ContactNumber") = _Row("ContactNumber")
                _DataRow("FaxNumber") = ""
                _DataRow("NTNNumber") = _Row("NTNNumber")
                _DataRow("CreditDays") = 30
                _DataRow("AccountCode") = ""
                _DataRow("Remarks") = _Row("Remarks")
                _DataRow("Active") = 1
                _DataRow("Commission") = 0
                _DataRow("OpeningBalance") = 0
                _DataRow("SupplierRefNo") = _Row("SupplierRefNo")
                _DataRow("CompanyID") = _Row("CompanyID")
                _DataRow("ChartOfAccountID") = 1005
                _DataRow("CreationDate") = DateTime.Now
                _DataRow("ModificationDate") = DateTime.Now
                _DataRow("CurrencyID") = -1
                _DataRow("TaxCategoryID") = 78
                _DataRow("NIC") = _Row("NIC")
                _DataRow("STN") = _Row("STN")
                _DataRow("IsExemption") = 0
                _DataRow("ExemptionToDate") = _Row("ExemptionToDate")
                _DataRow("ExemptionFromDate") = _Row("ExemptionFromDate")
                _DataRow("ExemptionToDate") = _Row("ExemptionToDate")
                _DataRow("SupplierType") = "-1"
                _DataRow("SupplierBusinessTitle") = _Row("SupplierBusinessTitle")
                _DataRow("SupplierCityID") = _Row("SupplierCityID")
                _DataRow("SupplierCountryID") = 1
                _DataRow("Description") = ""
                _DataRow("PaymentTermID") = 0
                _DataRow("TaxPayerStatus") = "No"
                _DataRow("Latitude") = 0.00
                _DataRow("Longitude") = 0.00
                _Result = Save(_DataRow)

            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("SupplierTitle")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)
        Next

        lblMessages.Text = "Process Completed."
        RecordsProcess.Visible = False


    End Sub

    Private Sub btnMigrateCity_Click(sender As Object, e As EventArgs) Handles btnMigrateCity.Click
        Dim _SourceTable As DataTable = SourceCity
        Dim _TableView As New DataView(Table_City)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0

        For Each _Row As DataRow In _SourceTable.Rows

            MyPrimaryKeyName = "CityID"
            MyPrimaryKeyValue = _Row("ID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _TableView.Count = 0 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("CityID") = _Row("ID")
                _DataRow("CityTitle") = _Row("Title")
                _DataRow("CountryID") = 1
                _DataRow("Remarks") = ""
                _DataRow("Active") = 1
                _DataRow("UserID") = -1
                _DataRow("CityRefNo") = _Row("RefNo")
                _DataRow("CompanyID") = _Row("Company")
                _Result = Save(_DataRow)

            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("Title")
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)

        Next

        lblMessages.Text = "Process Completed."
        RecordsProcess.Visible = False


    End Sub

    Public Function Save(ByVal _DataRow As DataRow) As String

        Dim _TableView As New DataView(_DataRow.Table)
        Dim _Command As New SqlCommand()
        Dim _Result As String = ""
        Dim _IsError As Boolean = False
        Dim _Message As String = ""

        _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)

        Select Case _TableView.Count
            Case 0
                _Command = Connection_Class.SQLInsert(_DataRow, Connection_Amcorp)
                _Message = " Recorda(s) Inserted."
            Case 1
                _Command = Connection_Class.SQLUpdate(_DataRow, MyPrimaryKeyName, Connection_Amcorp)
                _Message = " Recorda(s) Updated."
            Case > 1
                _IsError = True
                _Message = " Error Found."
        End Select

        If _IsError = False Then
            _Result = _Command.ExecuteNonQuery.ToString & _Message
        End If

        Return _Result
    End Function

    Public Function SaveItemFlag(PKValue As Integer)
        Dim _TableView As New DataView(Table_ItemsFlag)
        Dim _ItemFlags() As String = {"NonInventory", "Purchase"}
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        For i = 0 To _ItemFlags.Length - 1

            _TableView.RowFilter = String.Concat("ItemID= ", PKValue.ToString, " And [FlagName] ='", _ItemFlags(i), "'")

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("ItemID") = PKValue
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("FlagName") = _ItemFlags(i)
                _Result = Save(_DataRow)
            End If

        Next

        Return _Result
    End Function

    Public Function SaveItemmMapping(PKValue As Integer, COA As Integer)
        Dim _TableView As New DataView(Table_ItemsMapping)
        Dim _DataRow As DataRow
        Dim _Result As String = ""


        _TableView.RowFilter = String.Concat("[ItemID]=", PKValue.ToString, " AND [AccountPostingTranType]='Purchase Invoice'")

        If _TableView.Count <= 1 Then
            _DataRow = _TableView.Table.NewRow

            _DataRow("AccountPostingTranType") = "Purchase Invoice"
            _DataRow("ItemID") = PKValue
            _DataRow("ChartOfAccountID") = COA
            _DataRow("CompanyID") = SourceCompanyID
            _DataRow("DestinationCategoryID") = -1
            _DataRow("AllocationSetupID") = -1
            _DataRow("AccountCode") = ""

            _Result = Save(_DataRow)

        End If

        Return _Result



    End Function

    Public Function SaveCOAUnits(PKvalue As Integer)
        Dim _TableView As New DataView(Table_COAUnits)
        Dim _COAUnits() As Integer = {22, 23}
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        For i = 0 To _COAUnits.Length - 1

            _TableView.RowFilter = String.Concat("[ChartofAccountID]=", PKvalue, " AND [CompanyUnitID]=", _COAUnits(i))
            MyMessages.Add(_TableView.RowFilter)

            If _TableView.Count = 0 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("ChartOfAccountID") = PKvalue
                _DataRow("CompanyID") = SourceCompanyID
                _DataRow("CompanyUnitID") = _COAUnits(i)
                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

        Next
        Return _Result

    End Function

    Private Sub btnLoadCity_Click(sender As Object, e As EventArgs) Handles btnLoadCity.Click

        Table_City = Get_DataTable(TableNameCity, Connection_Amcorp)
        SourceCity = ExcelToTable(ExcelFile, Sheet_City)
        gridCity.DataSource = SourceCity

    End Sub

    Private Sub btnLoadUOM_Click(sender As Object, e As EventArgs) Handles btnLoadUOM.Click
        Table_UOM = Get_DataTable(TableNameUOM, Connection_Amcorp)
    End Sub

    Private Sub btnLoadSupplier_Click(sender As Object, e As EventArgs) Handles btnLoadSupplier.Click
        Table_Supplier = Get_DataTable(TableNameSupplier, Connection_Amcorp)
        SourceSupplier = ExcelToTable(ExcelFile, Sheet_Suppliers)
        gridSupplier.DataSource = SourceSupplier
    End Sub

    Private Sub btnData_COA_CAT_Click(sender As Object, e As EventArgs) Handles btnData_COA_CAT.Click
        Table_COACat = Get_DataTable(TableNameCOAcat, Connection_Amcorp)
        SourceCOACat = ExcelToTable(ExcelFile, Sheet_COACat)
        gridCOACat.DataSource = SourceCOACat
    End Sub

    Private Sub btnData_COA_Click(sender As Object, e As EventArgs) Handles btnData_COA.Click
        Table_COA = Get_DataTable(TableNameCOA, Connection_Amcorp)
        SourceCOA = ExcelToTable(ExcelFile, Sheet_COA)
        gridCOA.DataSource = SourceCOA
    End Sub

    Private Sub btnData_Item_CAT_Click(sender As Object, e As EventArgs) Handles btnData_Item_CAT.Click
        Table_ItemCat = Get_DataTable(TableNameItemCat, Connection_Amcorp)
        SourceItemCat = ExcelToTable(ExcelFile, Sheet_ItemCat)
        gridItemCoat.DataSource = SourceItemCat

    End Sub

    Private Sub btnData_Items_Click(sender As Object, e As EventArgs) Handles btnData_Items.Click
        Table_Items = Get_DataTable(TableNameItems, Connection_Amcorp)
        Table_ItemsFlag = Get_DataTable(TableNameItemsFlag, Connection_Amcorp)
        Table_ItemsMapping = Get_DataTable(TableNameItemsMapping, Connection_Amcorp)
        SourceItems = ExcelToTable(ExcelFile, Sheet_Items)

        If SourceItems Is Nothing Then
            MsgBox("Items (Products) did not load.")
            Stop
        End If


        gridItems.DataSource = SourceItems


    End Sub


#Region "Expenses"

    Private Sub btnData_Expense_Click(sender As Object, e As EventArgs) Handles btnData_Expense.Click
        Table_Expenses = Get_DataTable(TableNameExpenses, Connection_Amcorp)
        SourceExpenses = ExcelToTable(ExcelFile, Sheet_Expenses)
        gridExpenses.DataSource = SourceExpenses
    End Sub


    Private Sub btnMigrate_Expense_Click(sender As Object, e As EventArgs) Handles btnMigrate_Expense.Click
        Dim _SourceTable As DataTable = SourceExpenses
        Dim _TableView As New DataView(Table_Expenses)
        Dim _DataRow As DataRow
        Dim _Result As String = ""

        RecordsProcess.Visible = True
        RecordsProcess.Maximum = _SourceTable.Rows.Count
        RecordsProcess.Value = 0

        For Each _Row As DataRow In SourceExpenses.Rows
            MyPrimaryKeyName = "ExpenseID"
            MyPrimaryKeyValue = _Row("ID")

            _TableView.RowFilter = String.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue)
            MyMessages.Add(_TableView.RowFilter)

            If _Row("ID") = -1 Then
                Continue For
            End If

            If _TableView.Count <= 1 Then
                _DataRow = _TableView.Table.NewRow
                _DataRow("ExpenseID") = Convert.ToInt32(_Row("ID").ToString)
                _DataRow("ExpenseRefNo") = _Row("RefNo").ToString
                _DataRow("ExpenseTitle") = _Row("Title").ToString
                _DataRow("CompanyID") = _Row("CompanyID").ToString
                _DataRow("ExpenseTypeID") = _Row("ExpenseTypeID").ToString
                _DataRow("ExpenseType") = _Row("ExpenseType").ToString
                _DataRow("Active") = True
                _DataRow("ChartOfAccountID") = Convert.ToInt32(_Row("ChartOfAccountID").ToString)

                _Result = Save(_DataRow)
            Else
                _Result = "Not Save "
            End If

            lblMessages.Text = _Result & " " & _Row("Title")
            lblMessages.Refresh()
            RecordsProcess.Value += 1
            MyMessages.Add(lblMessages.Text)
        Next
        lblMessages.Text = "Expenses (WIP) Process Completed."
        RecordsProcess.Visible = False
    End Sub

#End Region

#Region "COA Company Unit"

    Private Sub COA_Units(_Array As Array)

        Dim _DataView As DataView = Table_COAUnits.DefaultView
        Dim _Command As New SqlCommand("", Connection_Amcorp)
        _Command.Parameters.AddWithValue("@COA", 0)
        _Command.Parameters.AddWithValue("@Unit", 0)
        _Command.Parameters.AddWithValue("@Company", SourceCompanyID)


        For Each _Row As DataRow In Table_COA.Rows

            If _Row("CompanyID") <> SourceCompanyID Then
                Continue For
            End If

            For Each _Unit As Integer In _Array

                _DataView.RowFilter = "ChartofAccountID=" & _Row("ChartofAccountID").ToString & " AND CompanyUnitID=" & _Unit.ToString

                Dim _NewRow As DataRow

                If _DataView.Count = 0 Then

                    _Command.CommandText = "INSERT INTO [Bizztrax_Amcorp].[dbo].[tblChartAccount_CompanyUnit] VALUES (@COA, @Unit, @Company)"
                    _Command.Parameters("@COA").Value = _Row("ChartofAccountID")
                    _Command.Parameters("@Unit").Value = _Unit
                    _Command.Parameters("@Company").Value = SourceCompanyID
                    _Command.ExecuteNonQuery()

                    lblMessages.Text = "Chart of Account ID " & _Row("ChartofAccountID") & " Unit " & _Unit
                End If
            Next
        Next


    End Sub

    Private Sub btnBranches_Click(sender As Object, e As EventArgs) Handles btnBranches.Click

        If SourceCompanyID = 7 Then
            MyUnits = {27, 28}
            COA_Units(MyUnits)
        End If



    End Sub





#End Region




End Class
Imports System.Data
Imports System.Windows.Forms
Imports Connection_Class
Public Class frmSupplier

    Dim TableName_Company As String = "[Bizztrax_Amcorp].[dbo].[tblCompany]"
    Dim TableName_Supplier As String = "[Bizztrax_Amcorp].[dbo].[tblSupplier]"
    Dim TableName_City As String = "[Bizztrax_Amcorp].[dbo].[tblCity]"

    Dim TableCompany As DataTable
    Dim TableSupplier As DataTable
    Dim TableCity As DataTable
    Dim TableRefresh As Boolean = True

    Dim ViewSupplier As New DataView
    Dim ViewSupplierList As New DataView
    Dim ViewCity As New DataView
    Dim SQLCommandClass As New SQLCommandParameters

    Property MyPKColumn As String = "SupplierID"
    Property MyCompanyID As Integer = 1                ' Default Company is Amcorp

    Private Sub frmSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ViewSupplier.Table = TableSupplier
        ViewSupplier.RowFilter = "CompanyID=" & MyCompanyID.ToString & " AND " & MyPKColumn & "=" & GetID.ToString
        MyRefresh()

    End Sub

    Private Sub MyRefresh()

        If TableRefresh Then
            TableCompany = Connection_Class.Get_DataTable(TableName_Company, Connection_Amcorp)
            TableSupplier = Connection_Class.Get_DataTable(TableName_Supplier, Connection_Amcorp)
            TableCity = Connection_Class.Get_DataTable(TableName_City, Connection_Amcorp)
            TableRefresh = False
        End If

        ViewSupplierList.Table = TableSupplier
        ViewSupplierList.RowFilter = "CompanyID=" & MyCompanyID.ToString

        cboxSupplier.DataSource = ViewSupplierList
        cboxSupplier.DisplayMember = "SupplierTitle"
        cboxSupplier.ValueMember = "SupplierID"

        ViewSupplier.Table = TableSupplier
        If GetID() > 0 Then
            ViewSupplier.RowFilter = "CompanyID=" & MyCompanyID.ToString & " AND " & MyPKColumn & "=" & GetID().ToString
        End If

        '---------------------------------------------------------------------------------------------------------------------

        cBoxCompany.DataSource = TableCompany
        cBoxCompany.DisplayMember = "CompanyTitle"
        cBoxCompany.ValueMember = "CompanyID"


        ViewCity.Table = TableCity
        ViewCity.Sort = "CityTitle"
        cboxCity.DataSource = ViewCity
        cboxCity.DisplayMember = "CityTitle"
        cboxCity.ValueMember = "CityID"
        ViewCity.RowFilter = "CompanyID=" & MyCompanyID.ToString

        SQLCommandClass.SQLConnection = Connection_Amcorp()
        SQLCommandClass.SQLTable = TableSupplier
        SQLCommandClass.SQLTableName = "tblSupplier"
        SQLCommandClass.PKeyColumn = "SupplierID"
        SQLCommandClass.SQLRow = Get_Row()


        Set_Data()

    End Sub

    Private Sub Set_Data()

        Dim _Row = SQLCommandClass.SQLRow

        If SQLCommandClass.SQLRow IsNot Nothing Then

            txtID.Text = _Row("SupplierID").ToString
            txtTitle.Text = _Row("SupplierTitle").ToString
            txtContactPerson.Text = _Row("ContactPerson").ToString
            txtContactNumber.Text = _Row("ContactNumber").ToString
            txtEmail.Text = _Row("Email").ToString
            txtNTN.Text = _Row("NTNNumber").ToString
            txtRef.Text = _Row("SupplierRefNo").ToString
            txtAddress.Text = _Row("Address").ToString
            txtCNIC.Text = _Row("NIC").ToString
            txtSTN.Text = _Row("STN").ToString
            txtBusinessName.Text = _Row("SupplierBusinessTitle").ToString
            txtDescription.Text = _Row("Remarks").ToString
            chkExamted.Checked = If(IsDBNull(_Row("IsExemption")), False, _Row("IsExemption"))
            dtExamptionFrom.Value = If(IsDBNull(_Row("ExemptionFromDate")), dtExamptionFrom.MinDate, _Row("ExemptionFromDate"))
            dtExamptionTo.Value = If(IsDBNull(_Row("ExemptionToDate")), dtExamptionFrom.MinDate, _Row("ExemptionToDate"))
            cboxCity.SelectedValue = Convert_TextBox(_Row("SupplierCityID"))
            cBoxStatus.SelectedIndex = Convert_TextBox(_Row("SupplierType"))

        Else
            txtID.Text = ""
            txtTitle.Text = ""
            txtContactPerson.Text = ""
            txtContactNumber.Text = ""
            txtEmail.Text = ""
            txtNTN.Text = ""
            txtRef.Text = ""
            txtAddress.Text = ""
            txtCNIC.Text = ""
            txtSTN.Text = ""
            txtBusinessName.Text = ""
            txtDescription.Text = ""
            chkExamted.Checked = False
            dtExamptionFrom.Value = dtExamptionFrom.MinDate
            dtExamptionTo.Value = dtExamptionFrom.MinDate
            cboxCity.SelectedValue = 0
            cBoxStatus.SelectedIndex = 0
        End If

    End Sub

    Private Sub Get_Data()

        SQLCommandClass.SQLRow("SupplierID") = Convert_TextBox(txtID.Text)
        SQLCommandClass.SQLRow("SupplierTitle") = txtTitle.Text.Trim
        SQLCommandClass.SQLRow("ContactPerson") = txtContactPerson.Text.Trim
        SQLCommandClass.SQLRow("ContactNumber") = txtContactNumber.Text.Trim
        SQLCommandClass.SQLRow("Email") = txtEmail.Text.Trim
        SQLCommandClass.SQLRow("NTNNumber") = txtNTN.Text.Trim
        SQLCommandClass.SQLRow("SupplierRefNo") = txtRef.Text.Trim
        SQLCommandClass.SQLRow("SupplierType") = cBoxStatus.SelectedIndex            ' IND, AOP, COMpany
        SQLCommandClass.SQLRow("Address") = txtAddress.Text.Trim
        SQLCommandClass.SQLRow("NIC") = txtCNIC.Text.Trim
        SQLCommandClass.SQLRow("STN") = txtSTN.Text.Trim
        SQLCommandClass.SQLRow("SupplierBusinessTitle") = txtBusinessName.Text.Trim
        SQLCommandClass.SQLRow("Remarks") = txtDescription.Text.Trim
        SQLCommandClass.SQLRow("IsExemption") = chkExamted.Checked
        SQLCommandClass.SQLRow("ExemptionFromDate") = dtExamptionFrom.Value
        SQLCommandClass.SQLRow("ExemptionToDate") = dtExamptionTo.Value
        SQLCommandClass.SQLRow("SupplierCityID") = If(IsNothing(cboxCity.SelectedValue), 0, cboxCity.SelectedItem.Row("CityID"))

    End Sub

    Private Function Get_Row() As DataRow

        ViewSupplier.RowFilter = "CompanyID=" & MyCompanyID.ToString & " AND " & MyPKColumn & "=" & GetID().ToString

        Select Case ViewSupplier.Count
            Case Nothing
                Return TableSupplier.NewRow
            Case 0
                Return TableSupplier.NewRow
            Case = 1
                Return ViewSupplier.Item(0).Row
            Case > 1
                MsgBox("Multiple Records found. Total Records are " & ViewSupplier.Count.ToString, MsgBoxStyle.Critical, "Error......")
                Return TableSupplier.NewRow
            Case Else
                Return TableSupplier.NewRow
        End Select

    End Function

    Private Function GetID() As Integer
        Dim _ID As Integer
        Try
            _ID = Convert.ToInt32(txtID.Text)
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim _ID As Integer = GetID()
        _ID += 1
        txtID.Text = _ID.ToString
        MyRefresh()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Dim _ID As Integer = GetID()
        _ID -= 1

        If _ID < 0 Then
            _ID = 0
        End If

        txtID.Text = _ID.ToString
        MyRefresh()

    End Sub

    Private Sub cboxSupplier_DropDownClosed(sender As Object, e As EventArgs) Handles cboxSupplier.DropDownClosed


        txtID.Text = cboxSupplier.SelectedItem.Row.item("SupplierID")
        MyRefresh()


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Get_Data()                          ' Get / Fil Row from Text Box etc.

        Dim _Message As String
        Dim _HasError As Boolean = False
        Dim _SQLCommand As String = ""
        Dim _Row As DataRow = SQLCommandClass.SQLRow


        ' if Validate your record assign _HasError is false 

        If Not _HasError Then
            If _Row(MyPKColumn) = -1 Then
                _SQLCommand = "Insert"
            End If

            If _Row(MyPKColumn) > 0 Then
                'Apply Update Command   
                ViewSupplier.RowFilter = "CompanyID=" & MyCompanyID.ToString & " AND " & MyPKColumn & "=" & _Row(MyPKColumn)

                Select Case ViewSupplier.Count                                    ' Validate the update record is whether exist?
                    Case 0
                        _SQLCommand = _Row(MyPKColumn) & " is not exist."
                    Case 1
                        _SQLCommand = "Update"
                    Case > 1
                        _SQLCommand = "Error.... More than one redord found. Total Records are " & ViewSupplier.Count.ToString
                End Select
            End If
        End If

        Select Case _SQLCommand
            Case "Insert"
                Dim _MaxID As Integer = TableSupplier.Compute("MAX(" & MyPKColumn & ")", "")
                _Row(MyPKColumn) = IIf(IsNothing(_MaxID), 1, _MaxID + 1)             ' Get Row ID Maximum value for New Record.
                _Row("SupplierRefNo") = Format(SQLCommandClass.SQLRow(MyPKColumn), "00000")
                SQLCommandClass.Execute_SQLCommand(SQLCommandClass.InsertCommand)     ' Insert Record into Data Table 
                _Message = "Record has been saved."
                MyRefresh()
                ViewSupplier.RowFilter = "CompanyID=" & MyCompanyID.ToString & " AND " & "SupplierID=" & _MaxID + 1
                SQLCommandClass.SQLRow = ViewSupplier.Item(0).Row
                Set_Data()

            Case "Update"
                Try
                    SQLCommandClass.Execute_SQLCommand(SQLCommandClass.UpdateCommand)
                    _Message = "Record has been Updated."
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case Else
                _Message = "Record not updated."
        End Select

        MsgBox(_Message)                 ' Show Error Message if any.

        btnDelete.Enabled = True
        btnNew.Enabled = True

    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        SQLCommandClass.SQLRow = Nothing
        Set_Data()                              ' Show TextBox and others blanks
        MyRefresh()                             ' TextBox, Date, Fills from DataRow
        'SQLCommandClass.SQLRow = TableSupplier.NewRow
        SQLCommandClass.SQLRow(SQLCommandClass.PKeyColumn) = -1

        txtID.Text = SQLCommandClass.SQLRow(MyPKColumn)
        txtTitle.Select()
        btnDelete.Enabled = False
        btnNew.Enabled = False

        SQLCommandClass.SQLRow("SupplierCategoryID") = 1
        SQLCommandClass.SQLRow("TownID") = -1
        SQLCommandClass.SQLRow("Designation") = ""
        SQLCommandClass.SQLRow("Description") = ""
        SQLCommandClass.SQLRow("FaxNumber") = ""
        SQLCommandClass.SQLRow("CreditDays") = 30
        SQLCommandClass.SQLRow("AccountCode") = 0
        SQLCommandClass.SQLRow("Active") = True
        SQLCommandClass.SQLRow("Commission") = 0
        SQLCommandClass.SQLRow("OpeningBalance") = 0
        SQLCommandClass.SQLRow("CompanyID") = 1
        SQLCommandClass.SQLRow("ChartofAccountID") = 246
        SQLCommandClass.SQLRow("CreationDate") = Now
        SQLCommandClass.SQLRow("ModificationDate") = Now
        SQLCommandClass.SQLRow("SupplierType") = "-1"
        SQLCommandClass.SQLRow("SupplierCountryID") = -1
        SQLCommandClass.SQLRow("TaxCategoryID") = 1
        SQLCommandClass.SQLRow("TaxPayerStatus") = ""
        SQLCommandClass.SQLRow("CurrencyID") = -1
        SQLCommandClass.SQLRow("PaymentTermID") = -1
        SQLCommandClass.SQLRow("Latitude") = 0
        SQLCommandClass.SQLRow("Longitude") = 0


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Label7_DoubleClick(sender As Object, e As EventArgs) Handles Label7.DoubleClick
        txtBusinessName.Text = txtTitle.Text
    End Sub

    Private Sub cBoxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxCompany.DropDownClosed
        MyCompanyID = cBoxCompany.SelectedValue
        MyRefresh()
    End Sub

    Private Sub lblSupplier_Click(sender As Object, e As EventArgs) Handles lblSupplier.Click
        TableRefresh = True
        MyRefresh()
        lblMessage.Text = "Data Tables have been refreshed"
    End Sub
End Class
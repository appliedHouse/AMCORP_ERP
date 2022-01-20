Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text


Public Class frmPayment_Allocation

    Dim Table_Payments As DataTable
    Dim Table_Supplier As DataTable
    Dim Table_Company As DataTable
    Dim Table_Allocation As DataTable
    Dim Temp_Allocation As DataTable
    Dim Table_SupplierAll As DataTable

    Dim View_Payments As New DataView
    Dim View_Supplier As New DataView
    Dim View_Company As New DataView
    Dim View_Allocation As New DataView

    Property PaymentID As Integer
    Property CompanyID As Integer
    Property SupplierID As Integer
    Dim IsInilized As Boolean = False
    Dim IsGridSet As Boolean = False

#Region "Events"

    Private Sub Payment_Allocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PaymentID = 0
        CompanyID = 1
        SupplierID = 0


        Table_Payments = Connection_Class.Get_DataTable("[tblPaymentHead]", Connection_Amcorp)
        Table_SupplierAll = Connection_Class.Get_DataTable("[tblSupplier]", Connection_Amcorp)
        Table_Company = Connection_Class.Get_DataTable("[tblCompany]", Connection_Amcorp)
        Table_Allocation = Connection_Class.Get_DataTable("[tblProjectAllocation]", Connection_Amcorp)
        Table_Supplier = GetTable_Supplier(CompanyID)

        cBoxCompany.SelectedValue = CompanyID

        View_Payments.Table = Table_Payments
        View_Supplier.Table = Table_Supplier
        View_Company.Table = Table_Company
        View_Allocation.Table = Table_Allocation

        MyRefresh()

    End Sub

    Private Sub cBoxSupplier_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxSupplier.DropDownClosed
        If IsInilized Then
            UpdatePayments()
        End If
    End Sub

    Private Sub Grid_Payments_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_Payments.CellEnter

        If Grid_Payments.CurrentRow.Cells.Item("TranID").Value IsNot Nothing Then
            PaymentID = Grid_Payments.CurrentRow.Cells.Item("TranID").Value
            Data_Filter()
        End If




    End Sub

    Private Sub Grid_Allocation_DoubleClick(sender As Object, e As EventArgs) Handles Grid_Allocation.DoubleClick
        Dim _Grid As DataGridView = sender
        Dim _GRow As DataGridViewRow = _Grid.CurrentRow

        MsgBox(_GRow.Cells("TranDtlID").ToString)






    End Sub


#End Region

    Private Sub MyRefresh()

        cBoxCompany.DataSource = Table_Company
        cBoxCompany.DisplayMember = "CompanyTitle"
        cBoxCompany.ValueMember = "CompanyID"

        cBoxSupplier.DataSource = Table_Supplier
        cBoxSupplier.DisplayMember = "SupplierTitle"
        cBoxSupplier.ValueMember = "SupplierID"


        If CompanyID = Nothing Then
            CompanyID = 0
        End If

        If PaymentID = Nothing Then
            PaymentID = 0
        End If

        Data_Filter()
        IsInilized = True

    End Sub

    Private Sub UpdatePayments()

        CompanyID = cBoxCompany.SelectedValue
        SupplierID = cBoxSupplier.SelectedValue
        PaymentID = GetPaymentID()

        Data_Filter()
        Grid_Payments.Refresh()
        Grid_Allocation.Refresh()
        P1.Select()

    End Sub

    Private Sub Data_Filter()

        View_Payments.RowFilter = String.Concat("CompanyID=", CompanyID, " AND SupplierID=", SupplierID)
        If View_Payments.Count > 0 Then
            Grid_Payments.DataSource = View_Payments
            SetGrid_Payment()
        Else
            Grid_Payments.DataSource = ""
        End If

        View_Allocation.RowFilter = String.Concat("TranType='Payment' AND RefTrandtlID=", PaymentID)

        If View_Allocation.Count > 0 Then
            Grid_Allocation.DataSource = View_Allocation
            SetGrid_Allocation()
            IsGridSet = True
        Else
            Grid_Allocation.DataSource = ""
        End If


    End Sub

    Private Sub SetGrid_Payment()

        If IsGridSet Then
            Return
        End If



        'For i = 0 To Table_Payments.Columns.Count - 1
        '    Grid_Payments.Columns(i).Visible = False
        'Next



        For _Counter = 1 To Grid_Payments.Columns.Count - 1
            Grid_Payments.Columns(_Counter).Visible = False
        Next

        Grid_Payments.Columns.Item("TranID").Visible = True
        Grid_Payments.Columns.Item("TransactionID").Visible = True
        Grid_Payments.Columns.Item("TransactionDate").Visible = True
        Grid_Payments.Columns.Item("ChequeNo").Visible = True
        Grid_Payments.Columns.Item("GSTAmount").Visible = True
        Grid_Payments.Columns.Item("NetAmount").Visible = True
        Grid_Payments.Columns.Item("AccountVoucherNo").Visible = True

    End Sub

    Private Sub SetGrid_Allocation()

        If IsGridSet Then
            Return
        End If

        For _Counter = 1 To Grid_Allocation.Columns.Count - 1
            Grid_Allocation.Columns(_Counter).Visible = False
        Next

        Grid_Allocation.Columns.Item("TranID").Visible = True
        Grid_Allocation.Columns.Item("RefTranID").Visible = True
        Grid_Allocation.Columns.Item("RefAmount").Visible = True
        Grid_Allocation.Columns.Item("TranType").Visible = True
        Grid_Allocation.Columns.Item("Amount").Visible = True
        Grid_Allocation.Columns.Item("ProjectID").Visible = True


    End Sub

    Private Function GetPaymentID() As Integer
        Dim _ID As Integer

        If View_Payments.Count > 0 Then
            If Grid_Payments.Rows.Count > 0 Then
                _ID = Grid_Payments.CurrentRow.Cells.Item("TranID").Value
            Else
                _ID = 0
            End If
        Else
            _ID = 0
        End If

        Return _ID
    End Function

    Private Sub cBoxSupplier_DropDown(sender As Object, e As EventArgs) Handles cBoxSupplier.DropDown
        IsGridSet = False
    End Sub

#Region "Update"



    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Table_Update As DataTable = View_Allocation.ToTable()
        Dim SQLUpDate As New SqlCommand
        Dim SQLInsert As New SqlCommand
        Dim PrimaryKey As String = "TranDtlID"
        Dim _Total As Integer = Table_Update.Compute("SUM(Amount)", String.Empty)
        Dim NewPrimaryKey As Integer = 0


        If _Total = Table_Update.Rows(0).Item("RefAmount") Then

            For Each _Row As DataRow In Table_Update.Rows

                Dim TranDtl_ID As Integer = _Row(PrimaryKey)
                Dim _View As DataView = New DataView(Table_Allocation)

                _View.RowFilter = String.Concat(PrimaryKey, "=", _Row(PrimaryKey))

                If _View.Count = 1 Then                         ' Project Amount found in Allocation table.
                    SQLUpDate = Connection_Class.General.SQLUpdate(_Row, PrimaryKey, Connection_Bizztrax)

                    MsgBox(SQLUpDate.CommandText)

                ElseIf _View.Count = 0 Then                     ' Row not Found in Allocation Table, Create new one

                    If _Row(PrimaryKey) = -1 Then

                        SQLInsert = Connection_Class.General.SQLInsert(_Row, Connection_Bizztrax)
                        MsgBox(SQLInsert.CommandText)


                    End If
                End If

            Next
        Else
            lblMessage.Text = "Amount of Payment is not equal to Total Allocation Amount"
            MsgBox(lblMessage.Text)
        End If




    End Sub

#End Region

#Region "New Row"

    Private Function GetNewRow(GridPaymentRow As DataGridViewRow) As DataRowView
        Dim NewRow As DataRowView = View_Allocation.AddNew
        Dim MaxTranID As Integer = Table_Allocation.Compute("MAX(TranID)", String.Empty) + 1
        Dim MaxTranDtlID As Integer = Table_Allocation.Compute("MAX(TranDtlID)", String.Empty) + 1

        Dim _DataRowView As DataRowView = GridPaymentRow.DataBoundItem
        Dim PaymentRow As DataRow = _DataRowView.Row

        NewRow("TranID") = GetTranID(GridPaymentRow)
        NewRow("TranDtlID") = PaymentRow("TranID")
        NewRow("TranDate") = PaymentRow("TranDate")
        NewRow("TransactionID") = "Auto"
        NewRow("TransactionDate") = PaymentRow("TransactionDate")
        NewRow("ProcessID") = -1
        NewRow("TranType") = "Payment"
        NewRow("RefTranID") = PaymentRow("TranID")
        NewRow("RefTranDtlID") = PaymentRow("TranID")
        NewRow("RefAmount") = PaymentRow("RefAmount")
        NewRow("Amount") = 0
        NewRow("Percentage") = 0
        NewRow("ProjectID") = 0
        NewRow("ChartofAccountID") = -1
        NewRow("CostCenterID") = PaymentRow("CostCenterID")
        NewRow("CompanyID") = PaymentRow("CompanyID")
        NewRow("CompanyUnitID") = PaymentRow("CompanyUnitID")
        NewRow("Status") = String.Empty
        NewRow("Remarks") = PaymentRow("Remarks")
        NewRow("Description") = String.Concat("CHQ # ", PaymentRow("ChequeNo"))
        NewRow("UserID") = PaymentRow("UserID")
        NewRow("RequesterID") = PaymentRow("RequesterID")
        NewRow("CreationDate") = Now
        NewRow("ModificationDate") = Now

        NewRow.EndEdit()

        Return NewRow
    End Function

    Private Function GetTranID(GridPaymentRow As DataGridViewRow) As Integer

        If View_Allocation.RowFilter.Length > 0 Then               ' View must be filtered 
            If View_Allocation.Count > 0 Then
                Return View_Allocation(0).Row()("TranID")
            Else
                Return Table_Allocation.Compute("MAX(TranlID)", String.Empty) + 1
            End If
        End If

        Return 0

    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim _DataRowview As DataRowView = GetNewRow(Grid_Payments.CurrentRow)
        Stop
    End Sub

#End Region

#Region "Row Add Grid Events"

    Private Sub Grid_Allocation_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid_Allocation.RowsAdded
        'MsgBox("Rows added")
    End Sub

    Private Sub Grid_Allocation_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles Grid_Allocation.UserAddedRow
        MsgBox("User Added Row")
    End Sub

    Private Sub Grid_Allocation_NewRowNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles Grid_Allocation.NewRowNeeded
        MsgBox("New Row Needed")
    End Sub

#End Region

#Region "Company Table"

    Private Sub cBoxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxCompany.DropDownClosed
        cBoxSupplier.DataSource = GetTable_Supplier(cBoxCompany.SelectedValue)
    End Sub


    Private Function GetTable_Supplier(_CompanyID As Integer) As DataTable

        Dim _DataView As New DataView(Table_SupplierAll)
        _DataView.RowFilter = String.Concat("CompanyID=", _CompanyID)
        Return _DataView.ToTable

    End Function


#End Region

#Region "Closed"

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Stop
        Close()
    End Sub








#End Region

End Class
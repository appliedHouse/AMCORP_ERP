Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Connection_Class


Public Class frmVouchers

    Public CompanyID As Long = 1
    Public IsInitialize As Boolean = False

    Public tb_Company As DataTable
    Public tb_Supplier As DataTable
    Public tb_TranHead As DataTable
    Public tb_TranDetail As DataTable

    Public vw_Supplier As DataView
    Public vw_TranHead As DataView
    Public vw_TranDetail As DataView

    Public tb_CompanyName As String = "[BizzTrax_Amcorp].[dbo].[tblCompany]"
    Public tb_SupplierName As String = "[BizzTrax_Amcorp].[dbo].[tblSupplier]"
    Public tb_TranHeadName As String = "[BizzTrax_Amcorp].[dbo].[tblTranHead]"
    Public tb_TranDetailName As String = "[BizzTrax_Amcorp].[dbo].[tblTranDetail]"

    Private Sub Vouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMessage.Text = "DataBase is being loaded."

        tb_Company = Get_DataTable(tb_CompanyName, Connection_Bizztrax)
        tb_Supplier = Get_DataTable(tb_SupplierName, Connection_Bizztrax)
        tb_TranHead = Get_DataTable(tb_TranHeadName, Connection_Bizztrax)
        tb_TranDetail = Get_DataTable(tb_TranDetailName, Connection_Bizztrax)

        vw_Supplier = tb_Supplier.AsDataView
        vw_TranHead = tb_TranHead.AsDataView
        vw_TranDetail = tb_TranDetail.AsDataView

        cBoxCompany.DataSource = tb_Company
        cBoxCompany.DisplayMember = "CompanyTitle"
        cBoxCompany.ValueMember = "CompanyID"
        cBoxCompany.SelectedValue = CompanyID

        lblMessage.Text = "DataGrid is being updated"

        Grid_Update()

        lblMessage.Text = "Load Done.."

        IsInitialize = True

    End Sub

    Private Sub txtVoucherNo_Leave(sender As Object, e As EventArgs) Handles txtVoucherNo.Leave
        lblMessage.Text = "Voucher is being Loaded."
        Grid_Update()

    End Sub

    Private Sub Grid_Update()

        If txtVoucherNo.Text.Length > 0 Then

            lblMessage.Text = "Voucher is being Loaded. Start....."

            vw_TranHead.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
            vw_TranHead.RowFilter += " AND TransactionID='" + txtVoucherNo.Text.Trim + "'"

            Dim VouID As Long

            If vw_TranHead.Count > 0 Then
                VouID = Long.Parse(vw_TranHead.Item(0).Row("TranID").ToString)
                vw_TranHead.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
                vw_TranHead.RowFilter += " AND TranID=" + VouID.ToString

                vw_TranDetail.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
                vw_TranDetail.RowFilter += " AND TranID=" + VouID.ToString

            Else
                vw_TranHead.RowFilter = "TranID=-2"                                                                              'Grid_Setup show nill record.
                vw_TranDetail.RowFilter = "TranID=-2"                                                                              'Grid_Setup show nill record.
            End If

            grid_Voucher.DataSource = vw_TranHead
            grid_Transaction.DataSource = vw_TranDetail

            Grid_Setup()

            lblMessage.Text = "Voucher Load ... Done"

        End If

    End Sub


    Private Sub Grid_Setup()
        Dim _Columns() As String
        Dim _DisableColumns() As String

        ' VOUCHER
        _Columns = {"TransactionID", "TransactionDate", "TotalDebit", "TotalCredit", "TotalBaseDebit", "TotalBaseCredit", "ProjectID", "Status", "TranType", "AccountPostingTranType"}
        _DisableColumns = {"TransactionID", "TransactionDate"}
        For Each _Column As DataGridViewColumn In grid_Voucher.Columns
            If _Columns.Contains(_Column.Name) Then
                grid_Voucher.Columns(_Column.Name).Visible = True
            Else
                grid_Voucher.Columns(_Column.Name).Visible = False
            End If
        Next

        grid_Voucher.Columns(_Columns(0)).Width = 200
        grid_Voucher.Columns(_Columns(2)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Voucher.Columns(_Columns(3)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Voucher.Columns(_Columns(4)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Voucher.Columns(_Columns(5)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grid_Voucher.Columns(_Columns(2)).DefaultCellStyle.Format = "###,###,###.##"
        grid_Voucher.Columns(_Columns(3)).DefaultCellStyle.Format = "###,###,###.##"
        grid_Voucher.Columns(_Columns(4)).DefaultCellStyle.Format = "###,###,###.##"
        grid_Voucher.Columns(_Columns(5)).DefaultCellStyle.Format = "###,###,###.##"

        For Each _DisableColumn As DataGridViewColumn In grid_Voucher.Columns
            If _DisableColumns.Contains(_DisableColumn.Name) Then
                grid_Voucher.Columns(_DisableColumn.Name).ReadOnly = True
            Else
                grid_Voucher.Columns(_DisableColumn.Name).ReadOnly = False
            End If
        Next

        _Columns = {"ChartofAccountID", "Description", "Debit", "Credit", "BaseDebit", "BaseCredit", "RefNo", "ChequeNo", "ProjectID"}
        For Each _Column As DataGridViewColumn In grid_Transaction.Columns
            If _Columns.Contains(_Column.Name) Then
                grid_Transaction.Columns(_Column.Name).Visible = True
            Else
                grid_Transaction.Columns(_Column.Name).Visible = False
            End If
        Next

        grid_Transaction.Columns(1).Width = 200

        grid_Transaction.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Transaction.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Transaction.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grid_Transaction.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grid_Transaction.Columns(2).DefaultCellStyle.Format = "###,###,###.##"
        grid_Transaction.Columns(3).DefaultCellStyle.Format = "###,###,###.##"
        grid_Transaction.Columns(4).DefaultCellStyle.Format = "###,###,###.##"
        grid_Transaction.Columns(5).DefaultCellStyle.Format = "###,###,###.##"


    End Sub

    Private Sub grid_Voucher_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grid_Voucher.CellLeave
        Dim _Sender As DataGridView = sender

        If _Sender.Rows.Count = 0 Or _Sender.CurrentRow.Cells("TranID").Value = Nothing Then
            Return
        End If

        Dim _CellName As String = _Sender.Columns(_Sender.CurrentCell.ColumnIndex).Name
        Dim _RowID As String = _Sender.CurrentRow.Cells("TranID").Value.ToString
        Dim _ValueEdited As Object
        Dim _ValueCurrent As Object

        _ValueEdited = _Sender.CurrentCell.GetEditedFormattedValue(_Sender.CurrentRow.Index, 2)
        _ValueCurrent = _Sender.CurrentCell.Value.ToString

        If Not _ValueCurrent.Equals(_ValueEdited) Then
            UpdateTranHead(_RowID, _CellName, _ValueEdited)                     ' 1. Update Row ID, 2, Data Column to update, 3. Value of Data colum change.
        End If
    End Sub

    Private Sub UpdateTranHead(_RowID As String, _CellName As String, _ValueEdited As Object)
        Dim CommandFilter As String = "TranID=" + _RowID
        Dim CommandText As String = "UPDATE " + tb_TranHeadName + " SET " + _CellName + "=" + _ValueEdited + " WHERE " + CommandFilter
        Dim Command As New SqlCommand(CommandText, Connection_Amcorp)
        Dim DataView As New DataView(tb_TranHead)

        DataView.RowFilter = CommandFilter
        If DataView.Count = 1 Then
            Dim _Records = 0
            Command.ExecuteNonQuery()
            lblMessage.Text = "Trans ID =" + _RowID + " Column=" + _CellName + "value =" + _ValueEdited + " UPDATED Record(s)" + _Records.ToString
        End If
    End Sub

    Private Sub grid_Transaction_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grid_Transaction.CellLeave
        Dim _Sender As DataGridView = sender

        If _Sender.Rows.Count = 0 Or _Sender.CurrentRow.Cells("TranDtlID").Value = Nothing Then
            Return
        End If

        Dim _CellName As String = _Sender.Columns(_Sender.CurrentCell.ColumnIndex).Name
        Dim _RowID As String = _Sender.CurrentRow.Cells("TranDtlID").Value.ToString
        Dim _ValueEdited As Object
        Dim _ValueCurrent As Object

        _ValueEdited = _Sender.CurrentCell.GetEditedFormattedValue(_Sender.CurrentRow.Index, 2)
        _ValueCurrent = _Sender.CurrentCell.Value.ToString

        If Not _ValueCurrent.Equals(_ValueEdited) Then
            UpdateTranDetail(_RowID, _CellName, _ValueEdited)                     ' 1. Update Row ID, 2, Data Column to update, 3. Value of Data colum change.
        End If

    End Sub

    Private Sub UpdateTranDetail(_RowID As String, _CellName As String, _ValueEdited As Object)
        Dim TextColumn() As String = {"Description"}
        Dim CommandFilter As String = "TranDtlID=" + _RowID

        If (TextColumn.Contains(_CellName)) Then
            _ValueEdited = "'" + _ValueEdited + "'"
        End If

        Dim CommandText As String = "UPDATE " + tb_TranDetailName + " SET " + _CellName + "=" + _ValueEdited + " WHERE " + CommandFilter
        Dim Command As New SqlCommand(CommandText, Connection_Amcorp)
        Dim DataView As New DataView(tb_TranDetail)

        DataView.RowFilter = CommandFilter
        If DataView.Count = 1 Then
            Dim _Records = 0
            Command.ExecuteNonQuery()
            lblMessage.Text = "Trans ID =" + _RowID + " Column=" + _CellName + "value =" + _ValueEdited + " UPDATED Record(s)" + _Records.ToString
        End If

    End Sub

    Private Sub cBoxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxCompany.SelectedIndexChanged
        If IsInitialize = True Then
            CompanyID = (Long.Parse(cBoxCompany.SelectedValue.ToString))
        End If
    End Sub


End Class
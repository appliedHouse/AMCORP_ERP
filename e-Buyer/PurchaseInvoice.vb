Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Connection_Class
Public Class frmPurchaseInvoice

    Public CompanyID As Long = 6
    Public IsInitialize As Boolean = False

    Public tb_Company As DataTable
    Public tb_PInvoice As DataTable
    Public tb_POrder As DataTable
    Public tb_Requistation As DataTable
    Public tb_Supplier As DataTable
    Public tb_Items As DataTable

    Public vw_PInvoice As DataView
    Public vw_POrder As DataView
    Public vw_Requistation As DataView
    Public vw_Supplier As DataView
    Public vw_Items As DataView

    Public tb_CompanyName As String = "[BizzTrax_Amcorp].[dbo].[tblCompany]"
    Public tb_PInvoiceName As String = "[BizzTrax_Amcorp].[dbo].[tblDetailPurchaseInvoice]"
    Public tb_POrderName As String = "[BizzTrax_Amcorp].[dbo].[tblDetailPO]"
    Public tb_RequistationName As String = "[BizzTrax_Amcorp].[dbo].[tblDetailPurchaseRequisition]"
    Public tb_SupplierName As String = "[BizzTrax_Amcorp].[dbo].[tblSupplier]"
    Public tb_ItemsName As String = "[BizzTrax_Amcorp].[dbo].[tblItem]"

    Private Sub frmPurchaseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tb_Company = Get_DataTable(tb_CompanyName, Connection_Bizztrax)
        tb_PInvoice = Get_DataTable(tb_PInvoiceName, Connection_Bizztrax)
        tb_POrder = Get_DataTable(tb_POrderName, Connection_Bizztrax)
        tb_Requistation = Get_DataTable(tb_RequistationName, Connection_Bizztrax)
        tb_Supplier = Get_DataTable(tb_SupplierName, Connection_Bizztrax)
        tb_Items = Get_DataTable(tb_ItemsName, Connection_Bizztrax)

        vw_PInvoice = New DataView(tb_PInvoice)
        vw_POrder = New DataView(tb_POrder)
        vw_Requistation = New DataView(tb_Requistation)
        vw_Supplier = New DataView(tb_Supplier)
        vw_Items = New DataView(tb_Items)

        cBoxCompany.DataSource = tb_Company
        cBoxCompany.DisplayMember = "CompanyTitle"
        cBoxCompany.ValueMember = "CompanyID"
        cBoxCompany.SelectedValue = CompanyID

        txtPInvoice.Text = "P-00393"

        Grid_Update()

        IsInitialize = True

    End Sub

    Private Sub cBoxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxCompany.SelectedIndexChanged
        If IsInitialize = True Then
            CompanyID = (Long.Parse(cBoxCompany.SelectedValue.ToString))
        End If
    End Sub

    Private Sub txtPInvoice_Leave(sender As Object, e As EventArgs) Handles txtPInvoice.Leave
        Grid_Update()
    End Sub

    Private Sub Grid_Update()


        If txtPInvoice.Text.Length > 0 Then
            vw_PInvoice.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
            vw_PInvoice.RowFilter += " AND TransactionID='" + txtPInvoice.Text.Trim + "'"

            If vw_PInvoice.Count > 0 Then
                Dim PO As Long = Long.Parse(vw_PInvoice.Item(0).Row("POID").ToString)
                vw_POrder.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
                vw_POrder.RowFilter += " AND TranID=" + PO.ToString
            Else
                vw_POrder.RowFilter = "TranID=-2"                                                                              'Grid_Setup show nill record.
            End If

            If vw_POrder.Count > 0 Then
                Dim Requesition As Long = vw_POrder.Item(0).Row("PRTranID")
                vw_Requistation.RowFilter = "CompanyID=" + CompanyID.ToString.Trim
                vw_Requistation.RowFilter += " AND TranID=" + Requesition.ToString.Trim
            Else
                vw_Requistation.RowFilter = "TranID=-2"                                                                    'Grid_Setup show nill record.
            End If

            grid_Requisation.DataSource = vw_Requistation
            grid_POrder.DataSource = vw_POrder
            grid_PInvoice.DataSource = vw_PInvoice

            Grid_Setup()                                                                                                                     ' Enable or disbale Columsn and fomats.

        End If
    End Sub

    Private Sub Grid_Setup()
        Dim _Columns() As String
        Dim _DisableColumns() As String


        'PURCHASE REQUISATION
        _Columns = {"TransactionID", "TransactionDate", "SupplierID", "ProjectID", "ItemID", "Quantity", "Rate", "GrossAmount", "GSTAmount", "NetAmount", "ItemDescription", "Status"}
        _DisableColumns = {"TransactionID", "GrossAmount", "GSTAmount", "NetAmount", "Status"}
        For Each _Column As DataGridViewColumn In grid_Requisation.Columns
            If _Columns.Contains(_Column.Name) Then
                grid_Requisation.Columns(_Column.Name).Visible = True
            Else
                grid_Requisation.Columns(_Column.Name).Visible = False
            End If
        Next

        For Each _DisableColumn As DataGridViewColumn In grid_Requisation.Columns
            If _DisableColumns.Contains(_DisableColumn.Name) Then
                grid_Requisation.Columns(_DisableColumn.Name).ReadOnly = True
            Else
                grid_Requisation.Columns(_DisableColumn.Name).ReadOnly = False
            End If
        Next

        'PURCHASE ORDER 
        _Columns = {"TransactionID", "TransactionDate", "SupplierID", "ProjectID", "ItemID", "Quantity", "Rate", "GrossAmount", "GSTAmount", "NetAmount", "ItemDescription", "Status"}
        _DisableColumns = {"TransactionID", "GrossAmount", "GSTAmount", "NetAmount", "Status"}
        For Each _Column As DataGridViewColumn In grid_POrder.Columns
            If _Columns.Contains(_Column.Name) Then
                grid_POrder.Columns(_Column.Name).Visible = True
            Else
                grid_POrder.Columns(_Column.Name).Visible = False
            End If
        Next

        For Each _DisableColumn As DataGridViewColumn In grid_POrder.Columns
            If _DisableColumns.Contains(_DisableColumn.Name) Then
                grid_POrder.Columns(_DisableColumn.Name).ReadOnly = True
            Else
                grid_POrder.Columns(_DisableColumn.Name).ReadOnly = False
            End If
        Next

        ' PURCHASE INVOCIES
        _Columns = {"TransactionID", "TransactionDate", "SupplierID", "ProjectID", "ItemID", "Quantity", "Rate", "GrossAmount", "GSTAmount", "NetAmount", "ItemDescription", "Status"}
        _DisableColumns = {"TransactionID", "Status"}
        '_DisableColumns = {"TransactionID", "GrossAmount", "GSTAmount", "NetAmount", "Status"}
        For Each _Column As DataGridViewColumn In grid_PInvoice.Columns
            If _Columns.Contains(_Column.Name) Then
                grid_PInvoice.Columns(_Column.Name).Visible = True
            Else
                grid_PInvoice.Columns(_Column.Name).Visible = False
            End If
        Next

        For Each _DisableColumn As DataGridViewColumn In grid_PInvoice.Columns
            If _DisableColumns.Contains(_DisableColumn.Name) Then
                grid_PInvoice.Columns(_DisableColumn.Name).ReadOnly = True
            Else
                grid_PInvoice.Columns(_DisableColumn.Name).ReadOnly = False
            End If
        Next

        grid_PInvoice.AllowUserToAddRows = False
        grid_POrder.AllowUserToAddRows = False
        grid_Requisation.AllowUserToAddRows = False

        grid_PInvoice.AllowUserToDeleteRows = False
        grid_POrder.AllowUserToDeleteRows = False
        grid_Requisation.AllowUserToDeleteRows = False

    End Sub

#Region "Purchase Invoice Grid Cell Move"

    Private Sub grid_PInvoice_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grid_PInvoice.CellLeave
        Dim _Sender As DataGridView = sender

        If _Sender.Rows.Count = 0 Or _Sender.CurrentRow.Cells("TranDtlID").Value = Nothing Then
            Return
        End If

        Dim _Cell As String = _Sender.Columns(_Sender.CurrentCell.ColumnIndex).Name
        Dim _RowID As String = _Sender.CurrentRow.Cells("TranDtlID").Value.ToString
        Dim _ValueEdited As Object
        Dim _ValueCurrent As Object

        _ValueEdited = _Sender.CurrentCell.GetEditedFormattedValue(_Sender.CurrentRow.Index, 2)
        _ValueCurrent = _Sender.CurrentCell.Value.ToString

        If Not _ValueCurrent.Equals(_ValueEdited) Then
            UpdatePInvoice(_RowID, _Cell, _ValueEdited)                     ' 1. Update Row ID, 2, Data Column to update, 3. Value of Data colum change.
        End If
    End Sub

    Private Sub UpdatePInvoice(_RowID As String, _CellName As String, _ValueEdited As Object)
        Dim TextColumns() As String = {"ItemDescription"}
        Dim CommandFilter As String = "TranDtlID=" + _RowID
        If TextColumns.Contains(_CellName) Then
            _ValueEdited = "'" + _ValueEdited + "'"
        End If
        Dim CommandText As String = "UPDATE " + tb_PInvoiceName + " SET " + _CellName + "=" + _ValueEdited + " WHERE " + CommandFilter
        Dim Command As New SqlCommand(CommandText, Connection_Amcorp)
        Dim DataView As New DataView(tb_PInvoice)

        DataView.RowFilter = CommandFilter
        If DataView.Count = 1 Then
            Dim _Records = 0
            Command.ExecuteNonQuery()
            lblMessage.Text = "Trans ID =" + _RowID + " Column=" + _CellName + "value =" + _ValueEdited + " UPDATED Record(s)" + _Records.ToString
        End If

    End Sub

#End Region

#Region "Purchase Order Grid Cell Move"

    Private Sub grid_POrder_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grid_POrder.CellLeave
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
            UpdatePOrder(_RowID, _CellName, _ValueEdited)                     ' 1. Update Row ID, 2, Data Column to update, 3. Value of Data colum change.
        End If

    End Sub

    Private Sub UpdatePOrder(_RowID As String, _CellName As String, _ValueEdited As Object)

        Dim CommandFilter As String = "TranDtlID=" + _RowID
        Dim CommandText As String = "UPDATE " + tb_POrderName + " SET " + _CellName + "=" + _ValueEdited + " WHERE " + CommandFilter
        Dim Command As New SqlCommand(CommandText, Connection_Amcorp)
        Dim DataView As New DataView(tb_POrder)

        DataView.RowFilter = CommandFilter
        If DataView.Count = 1 Then
            Dim _Records = 0
            Command.ExecuteNonQuery()
            lblMessage.Text = "Trans ID =" + _RowID + " Column=" + _CellName + "value =" + _ValueEdited + " UPDATED Record(s)" + _Records.ToString
        End If
    End Sub
#End Region

#Region "Requisation"
    Private Sub grid_Requisation_Leave(sender As Object, e As EventArgs) Handles grid_Requisation.Leave
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
            UpdateReguisation(_RowID, _CellName, _ValueEdited)                     ' 1. Update Row ID, 2, Data Column to update, 3. Value of Data colum change.
        End If
    End Sub

    Private Sub UpdateReguisation(_RowID As String, _CellName As String, _ValueEdited As Object)
        Dim CommandFilter As String = "TranDtlID=" + _RowID
        Dim CommandText As String = "UPDATE " + tb_POrderName + " SET " + _CellName + "=" + _ValueEdited + " WHERE " + CommandFilter
        Dim Command As New SqlCommand(CommandText, Connection_Amcorp)
        Dim DataView As New DataView(tb_Requistation)

        DataView.RowFilter = CommandFilter
        If DataView.Count = 1 Then
            Dim _Records = 0
            Command.ExecuteNonQuery()
            lblMessage.Text = "Trans ID =" + _RowID + " Column=" + _CellName + "value =" + _ValueEdited + " UPDATED Record(s)" + _Records.ToString
        End If



    End Sub

    Private Sub grid_Requisation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_Requisation.CellContentClick

    End Sub

#End Region



End Class
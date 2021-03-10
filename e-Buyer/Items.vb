Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text

Public Class frmItems

    Private Property ActiveCellValue As Boolean

    Dim Table_items As DataTable
    Dim Table_Company As DataTable
    Dim View_Items As New DataView
    Dim ItemTableFullName As String = "[Bizztrax_Amcorp].[dbo].[tblItem]"

    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyDatabases()
        MyRefresh()
    End Sub

    Private Sub MyDatabases()

        Table_items = Connection_Class.Get_DataTable("[Items with CategoryTitle]", Connection_Master)                  ' Item
        Table_Company = Connection_Class.Get_DataTable("tblCompany", Connection_Amcorp)             ' Compnay

    End Sub

    Private Sub MyRefresh()

        cboxCompany.DataSource = Table_Company
        cboxCompany.DisplayMember = "CompanyTitle"
        cboxCompany.ValueMember = "CompanyID"

        View_Items.Table = Table_items

        RefreshGrid()


    End Sub

    Private Sub RefreshGrid()
        grdItems.DataSource = View_Items
        grdItems.Columns(0).Width = 40
        grdItems.Columns(1).Width = 40
        grdItems.Columns(2).Width = 250
        grdItems.Columns(3).Width = 40
        grdItems.Columns(4).Width = 250
        grdItems.Columns(5).Width = 40
        grdItems.Columns(6).Width = 40
        grdItems.Columns(3).Visible = False
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        SetFilter()

    End Sub

    Private Sub cboxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cboxCompany.DropDownClosed
        SetFilter()

    End Sub

    Private Sub grdItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItems.CellClick

        lblMessage.Text = String.Concat(grdItems.Columns(e.ColumnIndex).Name, " Value is ", ActiveCellValue.ToString)

        Dim _Value As Boolean = ActiveCellValue
        Dim _Value1 As Integer
        Dim _ItemID As Integer = grdItems.CurrentRow.Cells("ItemID").Value

        If _Value Then
            _Value1 = 0
        Else
            _Value1 = 1
        End If

        Dim SQLCommand As New SqlCommand("", Connection_Bizztrax)
        SQLCommand.CommandText = "UPDATE " & ItemTableFullName & " SET Active =" & _Value1.ToString & " WHERE ItemID=" & _ItemID & ";"
        Dim _Result = SQLCommand.ExecuteNonQuery


    End Sub

    Private Sub grdItems_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdItems.CellEnter

        ActiveCellValue = grdItems.CurrentRow.Cells("Active").Value

    End Sub

    Private Sub ChkActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkActive.CheckedChanged
        SetFilter()
    End Sub

    Private Sub SetFilter()


        Dim FilterText As New StringBuilder

        FilterText.Clear()

        If cboxCompany.SelectedValue IsNot Nothing Then
            FilterText.Append("CompanyID=")
            FilterText.Append(cboxCompany.SelectedValue.ToString)

        End If

        If txtFilter.Text.Length > 0 Then
            FilterText.Append(" AND ")
            FilterText.Append("ItemTitle Like '%")
            FilterText.Append(txtFilter.Text.Trim)
            FilterText.Append("%'")
        End If

        If chkActive.Checked Then
            FilterText.Append(" AND ")
            FilterText.Append(" Active ")
        End If

        View_Items.RowFilter = FilterText.ToString
        lblTotalRows.Text = String.Concat(View_Items.Count.ToString, " Rows")


        lblMessage.Text = View_Items.RowFilter

    End Sub

    Private Sub LblCompany_Click(sender As Object, e As EventArgs) Handles lblCompany.DoubleClick

        Dim _CompanyID = cboxCompany.SelectedValue
        Dim _Filter = txtFilter.Text
        Dim _Active = chkActive.Checked
        Dim _CurrrentRow = grdItems.CurrentRow.Index

        MyDatabases()
        MyRefresh()

        cboxCompany.SelectedValue = _CompanyID
        txtFilter.Text = _Filter
        chkActive.Checked = _Active
        grdItems.FirstDisplayedScrollingRowIndex = _CurrrentRow

        SetFilter()

    End Sub
End Class
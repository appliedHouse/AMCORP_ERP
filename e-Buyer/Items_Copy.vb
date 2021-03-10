Imports System.Data


Public Class frmItemJV

    Dim Table_items As DataTable
    Dim Table_Company As DataTable
    Dim Table_Flags As DataTable
    Dim Table_FlagsSetup As DataTable
    Dim Table_Mapping As DataTable
    Dim Table_COA As DataTable

    Dim View_Items As New DataView
    Dim View_COA As New DataView
    Dim View_Flag As New DataView
    Dim View_Mapping As New DataView

    'Dim SQLCommandClass As New Connection_Class.SQLCommandParameters
    Dim MyCompanyID As Integer = 1              ' AMCORP ERP
    Dim CopyCompanyIS As Integer = 5             ' Amcorp-GAsco JV


    Private Sub Items_Copy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTables()
        MyRefresh()
    End Sub

    Private Sub GetTables()

        Table_items = Connection_Class.Get_DataTable("tblItem", Connection_Amcorp)                  ' Item
        Table_Company = Connection_Class.Get_DataTable("tblCompany", Connection_Amcorp)             ' Compnay
        Table_FlagsSetup = Connection_Class.Get_DataTable("tblItemFlagSetup", Connection_Amcorp)    ' Items Flag's List
        Table_Flags = Connection_Class.Get_DataTable("tblItemFlag", Connection_Amcorp)              ' Item's Flags
        Table_Mapping = Connection_Class.Get_DataTable("tblItem_ChartofAccount", Connection_Amcorp) ' Mapped to COA
        Table_COA = Connection_Class.Get_DataTable("tblChartofAccount", Connection_Amcorp)          ' Chart of Accounts

    End Sub

    Private Sub MyRefresh()

        View_Items.Table = Table_items
        View_Items.RowFilter = String.Concat("CompanyID = ", MyCompanyID.ToString)
        lstItemJV.DataSource = View_Items
        lstItemJV.DisplayMember = "ItemTitle"
        lblFilter.Text = View_Items.RowFilter.ToString

        cboxCompany.DataSource = Table_Company
        cboxCompany.DisplayMember = "CompanyTitle"
        cboxCompany.ValueMember = "CompanyID"

        View_COA.Table = Table_COA
        View_COA.RowFilter = String.Concat("CompanyID = ", MyCompanyID.ToString)
        View_COA.Sort = "AccountCode"
        lstCOA.DataSource = View_COA
        lstCOA.DisplayMember = "AccountTitle"
        lstCOA.ValueMember = "ChartofAccountID"

        lsfFlags.DataSource = View_Flag
        lsfFlags.DisplayMember = "FlagName"
        lsfFlags.ValueMember = "FlagName"

        View_Mapping.Table = Table_Mapping
        lstMappedCOA.DataSource = View_Mapping
        lstMappedCOA.DisplayMember = "AccountPostingTranType"
        lstMappedCOA.ValueMember = "ChartofAccountID"


    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        View_Items.RowFilter = String.Concat("ItemTitle like '%", txtFilter.Text.Trim, "%' AND CompanyID = ", cboxCompany.SelectedValue)
        lblFilter.Text = View_Items.RowFilter.ToString
    End Sub

    Private Sub cboxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cboxCompany.DropDownClosed
        View_Items.RowFilter = String.Concat("ItemTitle like '%", txtFilter.Text.Trim, "%' AND CompanyID = ", cboxCompany.SelectedValue)
        View_COA.RowFilter = String.Concat("CompanyID = ", cboxCompany.SelectedValue)

        lblFilter.Text = View_Items.RowFilter.ToString
        lblCOA_Filter.Text = View_COA.RowFilter.ToString
    End Sub

    Private Sub lstItemJV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItemJV.SelectedIndexChanged

        Dim SelectedItem As Integer

        If View_Items.Count = 0 Then
            SelectedItem = 0
        Else
            SelectedItem = lstItemJV.SelectedItem(0)
        End If

        View_Flag.Table = Table_Flags
        View_Flag.RowFilter = String.Concat("ItemID=", SelectedItem.ToString)

        lblFilter.Text = View_Flag.RowFilter

    End Sub

    'Private Sub ItemRowFilter()




    'End Sub

End Class
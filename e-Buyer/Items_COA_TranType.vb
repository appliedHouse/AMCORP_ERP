Imports System.Data
Imports Connection_Class
Imports System.Collections


Public Class frmItems_COA_TranType

    Private Property MyMessage As String = ""
    Private Property MyCompanyID As Integer = 5

    Dim MyTranType As String = "Purchase Invoice"

    Dim TableName_Company As String = "[Bizztrax_Amcorp].[dbo].[tblCompany]"
    Dim TableName_ItemCategory As String = "[master].[dbo].[Item_Category_COA]" '
    Dim TableName_ItemTran As String = "[Bizztrax_Amcorp].[dbo].[tblItem_ChartofAccount]"

    Dim Table_Company As DataTable
    Dim Table_ItemCategory As DataTable
    Dim Table_ItemTran As DataTable

    Dim TableView_ItemCategory As DataView
    Dim TableView_ItemTran As DataView

    Dim _ArrayList As New ArrayList()
    Dim RunOnce As Boolean = True

    Private Sub Items_COA_TranType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Myrefresh()
    End Sub

    Private Sub Myrefresh()
        If RunOnce Then
            Table_Company = Get_DataTable(TableName_Company, Connection_Amcorp)
            Table_ItemCategory = Get_DataTable(TableName_ItemCategory, Connection_Master)
            Table_ItemTran = Get_DataTable(TableName_ItemTran, Connection_Amcorp)

            TableView_ItemCategory = New DataView(Table_ItemCategory)
            TableView_ItemTran = New DataView(Table_ItemTran)

            cBoxCompany.DataSource = Table_Company
            cBoxCompany.DisplayMember = "CompanyTitle"
            cBoxCompany.ValueMember = "CompanyID"
            cBoxCompany.SelectedValue = MyCompanyID


            RunOnce = False
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Do_Items_Mapped()
    End Sub


    Public Sub Do_Items_Mapped()

        TableView_ItemCategory.RowFilter = String.Concat("CompanyId=", MyCompanyID.ToString)
        Dim _ItemID As Integer = 0
        Dim _Action As Integer = 0

        For Each _Row In TableView_ItemCategory.Table.Rows

            If _Row("CompanyID") <> 5 Then
                Continue For
            End If

            _ItemID = _Row("ItemID")

            TableView_ItemTran.RowFilter = String.Concat("CompanyID=", MyCompanyID.ToString, " AND AccountPostingTranType='", MyTranType, "' AND ItemID=", _ItemID.ToString)

            If TableView_ItemTran.Count = 1 Then
                If TableView_ItemTran.Item(0).Item("ChartofAccountID") = Convert.ToInt32(_Row("AccountCode")) Then
                    _Action = SQLAction.Updated         '"UPDATED"
                Else
                    _Action = SQLAction.Edit            '"EDIT"
                End If


            ElseIf TableView_ItemTran.Count = 0 Then
                _Action = SQLAction.Insert               ' "INSERT"


            Else
                _Action = SQLAction.Errors              '"ERROR"
            End If

            If _Action = SQLAction.Edit Or _Action = SQLAction.Insert Then
                Do_Action(_Row, _Action)

                txtItem.Text = _Row("ItemID").ToString
                txtTranType.Text = MyTranType.ToString
                txtCOA.Text = _Row("AccountCode").ToString



            End If



        Next

    End Sub

    Private Sub Do_Action(_DataRow As DataRow, _Action As Integer)

        If _DataRow("AccountCode") = "" Then
            Return
        End If


        Dim _SQLText As String = ""
        Dim _SQLCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(_SQLText, Connection_Amcorp)
        Dim _COA As Integer = Convert.ToInt32(_DataRow("AccountCode"))
        Dim _ItemID As Integer = _DataRow("ItemID")

        _SQLCommand.Parameters.AddWithValue("@TranType", MyTranType)
        _SQLCommand.Parameters.AddWithValue("@ItemID", _DataRow("ItemID"))
        _SQLCommand.Parameters.AddWithValue("@COA", _COA)
        _SQLCommand.Parameters.AddWithValue("@CompanyID", _DataRow("CompanyID"))
        _SQLCommand.Parameters.AddWithValue("@DestinationID", -1)
        _SQLCommand.Parameters.AddWithValue("@AllocationID", -1)
        _SQLCommand.Parameters.AddWithValue("@AccountCode", "")

        Dim _Where As String = String.Concat(" WHERE AccountPostingTranType='", MyTranType, "' AND ItemID=", _ItemID)

        Select Case _Action

            Case SQLAction.Edit
                _SQLText = "UPDATE " & TableName_ItemTran & " SET ChartofAccountID=@COA" & _Where

            Case SQLAction.Insert
                _SQLText = "Insert into " & TableName_ItemTran & " Values (@TranType, @ItemID, @COA, @CompanyID, @DestinationID, @AllocationID, @AccountCode);"
        End Select

        _SQLCommand.CommandText = _SQLText
        _SQLCommand.ExecuteNonQuery()
        lblMessage.Text = _SQLText


        'Stop

    End Sub

    Private Sub cBoxCompany_ValueMemberChanged(sender As Object, e As EventArgs) Handles cBoxCompany.DropDownClosed
        MyCompanyID = cBoxCompany.SelectedValue
        'Stop
    End Sub

    Private Enum SQLAction
        Updated
        Insert
        Edit
        Errors
    End Enum



End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Connection_Class




Public Class frmDuplicateUser

    Dim Table_Company As DataTable
    Dim Table_User As DataTable
    Dim Table_Role As DataTable
    Dim DefaultCompany As Integer = 1
    Dim IsRefreshed As Boolean = False

    Dim View_Company As New DataView
    Dim View_User As New DataView
    Dim View_DuplicateUser As New DataView
    Dim View_UserRole As New DataView
    Dim Counter As Integer = 0

    Dim MyTableName As String = ""
    Dim MyDataTable As DataTable
    Dim MyConnection As SqlConnection = Connection_Amcorp()
    Dim _Command As SqlCommand = New SqlCommand("", MyConnection)

    'Dim AppliedTable As APPLIED_TABLE.Applied_Table


    Private Sub frmDuplicateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh()


    End Sub

    Private Sub MyRefresh()

        If IsRefreshed = False Then
            Table_Company = Get_DataTable("[dbo].[tblCompany]", Connection_Amcorp)
            Table_User = Get_DataTable("[dbo].[tblUser]", Connection_Amcorp)
            Table_Role = Get_DataTable("[dbo].[ST_tblRole]", Connection_Amcorp)

            View_Company.Table = Table_Company
            View_User.Table = Table_User
            View_DuplicateUser.Table = Table_Company
            View_UserRole.Table = Table_Role

            View_User.Sort = "UserID"
            MyDataTable = Table_User




            IsRefreshed = True
        End If

        cboxCompany.DataSource = View_Company 'View_Company
        cboxCompany.DisplayMember = "CompanyTitle"
        cboxCompany.ValueMember = "CompanyID"

        cBoxUser.DataSource = View_User
        cBoxUser.DisplayMember = "UserFullName"
        cBoxUser.ValueMember = "UserID"

        cboxDuplicateUser.DataSource = View_DuplicateUser
        cboxDuplicateUser.DisplayMember = "CompanyTitle"
        cboxDuplicateUser.ValueMember = "CompanyID"

        View_User.RowFilter = GetFilterText()
        View_UserRole.RowFilter = GetRoleFilterText()

    End Sub


    Private Function GetFilterText() As String
        Dim _FilterText As String = ""
        If cboxCompany.SelectedValue IsNot Nothing Then
            _FilterText = String.Concat("CompanyID=", cboxCompany.SelectedValue)
        Else
            _FilterText = String.Concat("CompanyID=", DefaultCompany.ToString)
        End If

        Counter += 1
        lblMessage.Text = String.Concat(_FilterText, " Counter=", Counter.ToString)

        Return _FilterText
    End Function

    Private Function GetRoleFilterText() As String
        Dim _FilterText As String = ""
        If cboxDuplicateUser.SelectedValue IsNot Nothing Then
            _FilterText = String.Concat("CompanyID=", cboxDuplicateUser.SelectedValue)
        Else
            _FilterText = String.Concat("CompanyID=", DefaultCompany.ToString)
        End If

        Counter += 1
        lblMessage.Text = String.Concat(_FilterText, " Counter=", Counter.ToString)

        Return _FilterText
    End Function


    Private Sub brnCreate_Click(sender As Object, e As EventArgs) Handles brnCreate.Click

        Dim SourceCompany As Integer = cboxCompany.SelectedValue
        Dim TargetComapny As Integer = cboxDuplicateUser.SelectedValue
        Dim TargetUser As Integer = cBoxUser.SelectedValue
        Dim ExistingFilter As String = View_User.RowFilter
        Dim TableClass As APPLIED_TABLE.Applied_Table = New APPLIED_TABLE.Applied_Table(MyDataTable, Connection_Amcorp)
        Dim MyText As String() = TableClass.SQLInsert(TargetUser)
        Dim InsertCommand As SqlCommand = New SqlCommand(MyText(3), Connection_Amcorp)
        Dim MaxID As Integer = MyDataTable.Compute(String.Concat("Max(UserID)"), "")
        Dim RoleTitle As String
        Dim Result As Integer

        TableClass.PrimaryKey = "UserID"

        View_User.RowFilter = String.Concat(TableClass.PrimaryKey, "=", TargetUser.ToString)
        TableClass.MyDataRow = View_User.ToTable().Rows(0)

        TableClass.MyDataRow(TableClass.PrimaryKey) = MaxID + 1
        TableClass.MyDataRow("CompanyID") = TargetComapny
        TableClass.MyDataRow("CompanyUnitID") = 23                      ' company Unit ID 3 = DHA

        View_UserRole.RowFilter = String.Concat("RoleID=", TableClass.MyDataRow("RoleID"), " and CompanyId=", SourceCompany.ToString)
        RoleTitle = View_UserRole(0).Item("RoleTitle").ToString
        View_UserRole.RowFilter = String.Concat("RoleTitle='", RoleTitle, "' and CompanyId=", TargetComapny.ToString)

        If View_UserRole.Count = 1 Then
            TableClass.MyDataRow("RoleID") = Convert.ToInt32(View_UserRole(0).Item("RoleID").ToString)
        Else
            TableClass.MyDataRow("RoleID") = 68
        End If

        For Each _Column As DataColumn In TableClass.MyDataTable.Columns
            InsertCommand.Parameters.AddWithValue("@" & _Column.ColumnName, TableClass.MyDataRow(_Column.ColumnName))
        Next

        'If TableClass.IsValueExist("UserName", TableClass.MyDataRow("UserName")) Then
        'Result = 0
        'Else
        Result = InsertCommand.ExecuteNonQuery

        'End If

        lblMessage.Text = String.Concat(Result.ToString, " Record(s) effected.")

        MyDataTable = Get_DataTable("[dbo].[tblUser]", Connection_Amcorp)


        View_User.RowFilter = ExistingFilter

    End Sub

    Private Sub cboxCompany_DropDownClosed(sender As Object, e As EventArgs) Handles cboxCompany.DropDownClosed
        MyRefresh()
    End Sub

    Private Sub cboxUserRole_DropDownClosed(sender As Object, e As EventArgs)
        MyRefresh()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class
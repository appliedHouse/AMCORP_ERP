Imports System.Data
Imports Connection_Class


Public Class frmTest

    Dim MyDataTable As New DataTable
    Dim MyDataView As New DataView
    Dim MyDataRow As DataRow
    Dim SaveRowClass As New SQLCommandParameters

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Refresh_Form()

        cBoxList.DataSource = MyDataTable
        cBoxList.DisplayMember = "Title"
        cBoxList.ValueMember = SaveRowClass.PKeyColumn

    End Sub

    Private Sub FieldsEnable(_Value As Boolean)

        txtID.Enabled = _Value
        cBoxList.Enabled = _Value
        txtCode.Enabled = _Value
        txtTitle.Enabled = _Value
        txtSupplier.Enabled = _Value
        txtProject.Enabled = _Value
        txtRemarks.Enabled = _Value
        txtCOA.Enabled = _Value
        dtDOB.Enabled = _Value
        btnSave.Enabled = _Value
        btnDelete.Enabled = _Value

    End Sub

    Private Function GetID() As Integer
        Dim _ID As Integer
        Try
            _ID = Convert.ToInt32(txtID.Text)
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        MyDataRow = MyDataTable.NewRow
        MyDataRow("ID") = -1
        txtCode.Select()

        FieldsEnable(True)
        txtID.Enabled = False
        cBoxList.Enabled = False
        btnDelete.Enabled = False
        btnNew.Enabled = False
        TextboxFromRow()       ' TextBox, Date, Fills from DataRow

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim _Message As String = ""
        Dim _HasError As Boolean = False
        Dim _SQLCommand As String = ""

        TextBoxtoRow()

        If MyDataRow("COA") = -1 Then
            _Message = "Chart of Account Code is wrong."
        ElseIf MyDataRow("Supplier") = -1 Then
            _Message = "Supplier Code is not valid"
        ElseIf MyDataRow("Project") = -1 Then
            _Message = "Project Code is not valid"
        End If

        If _Message.Length > 0 Then                         ' If Error found. show Message
            MsgBox(_Message)
            _HasError = True                                ' Tag Error Found.
        End If

        If Not _HasError Then
            If MyDataRow("ID") = -1 Then
                _SQLCommand = "Insert"
            End If

            If MyDataRow("ID") > 0 Then
                'Apply Update Command   
                MyDataView.RowFilter = "ID=" & MyDataRow("ID")

                Select Case MyDataView.Count                                    ' Validate the update record is whether exist?
                    Case 0
                        _SQLCommand = MyDataRow("ID") & " is not exist."
                    Case 1
                        _SQLCommand = "Update"
                    Case > 1
                        _SQLCommand = "Error.... More than one redord found. Total Records are " & MyDataView.Count.ToString
                End Select
            End If
        End If

        Select Case _SQLCommand
            Case "Insert"
                Dim _MaxID As Integer = MyDataTable.Compute("MAX(ID)", "")
                MyDataRow("ID") = IIf(IsNothing(_MaxID), 1, _MaxID + 1)         ' Get Row ID Maximum value for New Record.
                SaveRowClass.SQLRow = MyDataRow
                SaveRowClass.Execute_SQLCommand(SaveRowClass.InsertCommand)     ' Insert Record into Data Table 
                _Message = "Record has been saved."
                Refresh_Form()
                MyDataView.RowFilter = "ID=" & _MaxID + 1
                MyDataRow = MyDataView.Item(0).Row
                TextboxFromRow()

            Case "Update"
                TextBoxtoRow()
                SaveRowClass.SQLRow = MyDataRow
                SaveRowClass.Execute_SQLCommand(SaveRowClass.UpdateCommand)
                _Message = "Record has been Updated."
                'MsgBox("Record has been Updated.")
                FieldsEnable(True)
            Case Else
                _Message = "Record not updated."

        End Select

        MsgBox(_Message)                 ' Show Error Message if any.

        txtID.Enabled = True
        cBoxList.Enabled = True
        btnDelete.Enabled = True
        btnNew.Enabled = True
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim _Message As String = ""
        Dim _HasError As Boolean = True

        MyDataView.RowFilter = "ID=" & MyDataRow("ID").ToString

        If MyDataView.Count = 1 Then
            _HasError = False
        End If

        If Not _HasError Then

            SaveRowClass.SQLRow = MyDataRow
            SaveRowClass.RecordID = GetID()
            SaveRowClass.Execute_SQLCommand(SaveRowClass.DeleteCommand)     'Delete the Record mached with DataRow
            MsgBox("Record has ben deleted.")
            Refresh_Form()
            MyDataRow = MyDataTable.Rows(0)

        End If
    End Sub

    Private Sub TextboxFromRow()
        Try
            txtID.Text = MyDataRow("ID").ToString
            txtCode.Text = MyDataRow("Code").ToString
            txtTitle.Text = MyDataRow("Title").ToString
            txtSupplier.Text = MyDataRow("Supplier").ToString
            txtProject.Text = MyDataRow("Project").ToString
            dtDOB.Value = IIf(IsDBNull(MyDataRow("DOB")), Now, MyDataRow("DOB"))
            txtCOA.Text = MyDataRow("COA").ToString
            txtRemarks.Text = MyDataRow("Remarks").ToString
        Catch ex As Exception
            txtID.Text = ""
            txtCode.Text = ""
            txtTitle.Text = ""
            txtSupplier.Text = ""
            txtProject.Text = ""
            dtDOB.Value = Now
            txtCOA.Text = ""
            txtRemarks.Text = ""
        End Try

    End Sub

    Private Sub TextBoxtoRow()
        MyDataRow("ID") = GetID()
        MyDataRow("Code") = txtCode.Text.Trim
        MyDataRow("Title") = txtTitle.Text.Trim
        MyDataRow("DOB") = dtDOB.Value
        MyDataRow("COA") = Convert_TextBox(txtCOA.Text)
        MyDataRow("Supplier") = Convert_TextBox(txtSupplier.Text)
        MyDataRow("Project") = Convert_TextBox(txtProject.Text)
        MyDataRow("Remarks") = txtRemarks.Text
    End Sub

    Private Sub Refresh_Form()

        Try
            MyDataTable = Get_DataTable("Test", Connection_Master())
            MyDataView.Table = MyDataTable
            SaveRowClass.SQLConnection = Connection_Master()
            SaveRowClass.SQLTable = MyDataTable
            SaveRowClass.SQLTableName = "[master].[dbo].[Test]"
            SaveRowClass.PKeyColumn = "ID"
            TextboxFromRow()
            cBoxList.DataSource = MyDataTable
            cBoxList.SelectedValue = MyDataRow("ID")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cBoxList_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxList.DropDownClosed

        MyDataView.RowFilter = "ID=" & cBoxList.SelectedValue
        Try
            MyDataRow = MyDataView.Item(0).Row
        Catch ex As Exception
            MyDataRow = MyDataTable.NewRow
            MyDataRow("ID") = -1
        End Try
        TextboxFromRow()

    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class
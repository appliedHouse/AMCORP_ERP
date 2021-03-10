Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Connection_Class


Public Class frmSupplier_Invoice_Adjuste
#Disable Warning CA3105 ' Do not declare visible instance fields
#Disable Warning CA2100 ' Do not declare visible instance fields
#Disable Warning CA2000 ' Dispose objects before losing scope
#Disable Warning CA1303 ' Do not pass literals as localized parameters
#Disable Warning CA1305
#Disable Warning CA1031

    Private Property MyCompanyID As Integer = 1
    Private Property MyGridPain As Boolean

    Dim OnceRun As Boolean = False
    Dim IsPaint As Boolean = False
    Dim Run_clear As Boolean = True
    Dim Run_FormatPayment As Boolean = True
    Dim Run_FormatInvoice As Boolean = True

    Dim Table_Company As DataTable
    Dim View_Company As New DataView

    Dim Table_Supplier As DataTable
    Dim View_Supplier As New DataView

    Dim Table_Payment_Head As DataTable
    Dim Table_Payment_Details As DataTable
    Dim View_Payment_Head As New DataView
    Dim View_Payment_Details As New DataView

    Dim Table_Invocies As DataTable
    Dim View_Invoices As New DataView

    Dim MySupplierID As Integer

    Dim Table_PaymentHead As String = "[Bizztrax_Amcorp].[dbo].[tblPaymentHead]"
    Dim Table_PaymentDetail As String = "[Bizztrax_Amcorp].[dbo].[tblPaymentDetail]"
    Dim Table_SupplierInvoice As String = "[Supplier Invoice Adjustment]"
    Dim Table_CompanyList As String = "[Bizztrax_Amcorp].[dbo].[tblCompany]"
    Dim Table_SupplierList As String = "[Bizztrax_Amcorp].[dbo].[tblSupplier]"
    Dim Table_HeadPurchaseInvoice As String = "[Bizztrax_Amcorp].[dbo].[tblHeadPurchaseInvoice]"
    Dim Table_CreditNotes As String = "[Bizztrax_Amcorp].[dbo].[tblCreditNote]"
    Dim Procedure_Invoices_CNote As String = "[master].[dbo].[Invoices_CNote]"
    Dim Procedure_Payments_DNote As String = "[master].[dbo].[Payments_DNote]"

    Private Sub Supplier_Invoice_Adjuste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyRefresh()            ' Initialize the form Data Environment and Form Objects.
    End Sub

    Private Sub MyRefresh()

        If Not OnceRun Then


            Table_Company = Get_DataTable(Table_CompanyList, Connection_Amcorp)      ' Get Table from Bizztrax_Amcorp
            View_Company.Table = Table_Company
            View_Company.Sort = "CompanyID"
            cBoxCompany.DataSource = View_Company
            cBoxCompany.DisplayMember = "CompanyTitle"
            cBoxCompany.ValueMember = "CompanyID"

            Table_Supplier = Get_DataTable(Table_SupplierList, Connection_Amcorp)      ' Get Table from Bizztrax_Amcorp
            View_Supplier.Table = Table_Supplier
            View_Supplier.Sort = "SupplierID"
            View_Supplier.RowFilter = "CompanyID=" & cBoxCompany.SelectedValue
            cBoxSuppliers.DataSource = View_Supplier
            cBoxSuppliers.DisplayMember = "SupplierTitle"
            cBoxSuppliers.ValueMember = "SupplierID"

            Table_Payment_Head = Get_DataTable(Table_PaymentHead, Connection_Amcorp)
            View_Payment_Head.Table = Table_Payment_Head

            Table_Invocies = Get_DataTable(Table_SupplierInvoice, Connection_Master)
            View_Invoices.Table = Table_Invocies

            OnceRun = True
        End If

    End Sub

    Private Function Get_Table_InvoicesCNote(_SupplierID, _CompanyID) As DataTable
        Dim _DataTable As DataTable
        Dim _ProcedureName As String = Procedure_Invoices_CNote
        Dim _SQLCommand As New SqlCommand(_ProcedureName, Connection_Master)

        _SQLCommand.Parameters.AddWithValue("@CompanyID", _CompanyID)
        _SQLCommand.Parameters.AddWithValue("@SupplierID", _SupplierID)

        _DataTable = Get_Procedure(_SQLCommand)

        Return _DataTable
    End Function

    Private Function Get_Table_PaymentsDNote(_SupplierID, _CompanyID) As DataTable
        Dim _DataTable As DataTable
        Dim _ProcedureName As String = Procedure_Payments_DNote
        Dim _SQLCommand As New SqlCommand(_ProcedureName, Connection_Master)

        _SQLCommand.Parameters.AddWithValue("@CompanyID", _CompanyID)
        _SQLCommand.Parameters.AddWithValue("@SupplierID", _SupplierID)

        _DataTable = Get_Procedure(_SQLCommand)

        Return _DataTable

    End Function

    Private Sub SETGridPayments(_SupplierID As Integer)

        Dim _DataTable As DataTable = Get_Table_PaymentsDNote(_SupplierID, MyCompanyID)
        View_Payment_Head.Table = _DataTable
        grdPayments.DataSource = View_Payment_Head

        lblPayments.Text = "Payments Total = " & _DataTable.Compute("SUM(BaseAmount)", "").ToString

        If Run_FormatPayment Then

            grdPayments.AllowUserToAddRows = False
            grdPayments.AllowUserToDeleteRows = False
            grdPayments.AllowUserToResizeColumns = False
            grdPayments.AllowUserToResizeRows = False
            grdPayments.AllowUserToOrderColumns = True
            grdPayments.RowHeadersVisible = False

            Dim EnableColumns As String() = {"TransactionID", "TransactionDate", "ChequeNo", "BaseAmount"}

            For _Column = 0 To grdPayments.Columns.GetColumnCount(DataGridViewElementStates.None) - 1
                grdPayments.Columns(_Column).Visible = False
            Next

            For Each _Column In EnableColumns
                If grdPayments.Columns.Contains(grdPayments.Columns(_Column)) Then
                    grdPayments.Columns(_Column).Visible = True
                End If
            Next


            grdPayments.Columns(EnableColumns(0)).HeaderText = "Tran ID"

            grdPayments.Columns(EnableColumns(1)).HeaderText = "Tran Date"
            grdPayments.Columns(EnableColumns(2)).HeaderText = "Cheque #"
            grdPayments.Columns(EnableColumns(3)).HeaderText = "Amount"

            grdPayments.Columns(EnableColumns(0)).Width = 80
            grdPayments.Columns(EnableColumns(1)).Width = 80
            grdPayments.Columns(EnableColumns(2)).Width = 80
            grdPayments.Columns(EnableColumns(3)).Width = 82

            grdPayments.Columns(EnableColumns(3)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdPayments.Columns(EnableColumns(3)).DefaultCellStyle.NullValue = "-"
            grdPayments.Columns(EnableColumns(3)).DefaultCellStyle.Format = "###,###,###"

            Run_FormatPayment = False

        End If
    End Sub

    Private Sub SETGridPurchaseInvoice(_SupplierID As Integer)

        Dim _DataTable As DataTable = Get_Table_InvoicesCNote(_SupplierID, MyCompanyID)
        View_Invoices.Table = _DataTable
        grdInvoices.DataSource = View_Invoices            ' View_Invoices
        lblInvoices.Text = "Invoices Total = " & _DataTable.Compute("SUM(NetAmount)", "").ToString


        If Run_FormatInvoice Then

            grdInvoices.AllowUserToAddRows = False
            grdInvoices.AllowUserToDeleteRows = False
            grdInvoices.AllowUserToResizeColumns = False
            grdInvoices.AllowUserToResizeRows = False
            grdInvoices.AllowUserToOrderColumns = True
            grdInvoices.RowHeadersVisible = False

            Dim EnableColumns As String() = {"TransactionID", "TransactionDate", "TaxInvoiceNo", "NetAmount", "RemainingAmount", "AccountVoucherNo"}

            For _Column = 0 To grdInvoices.Columns.GetColumnCount(DataGridViewElementStates.None) - 1
                grdInvoices.Columns(_Column).Visible = False
            Next

            For Each _Column In EnableColumns
                If grdInvoices.Columns.Contains(grdInvoices.Columns(_Column)) Then
                    grdInvoices.Columns(_Column).Visible = True
                End If
            Next

            grdInvoices.Columns(EnableColumns(0)).HeaderText = "Tran ID"
            grdInvoices.Columns(EnableColumns(1)).HeaderText = "Tran Date"
            grdInvoices.Columns(EnableColumns(2)).HeaderText = "Inv. No."
            grdInvoices.Columns(EnableColumns(3)).HeaderText = "Amount"
            grdInvoices.Columns(EnableColumns(4)).HeaderText = "Balance"
            grdInvoices.Columns(EnableColumns(5)).HeaderText = "Vou No"

            grdInvoices.Columns(EnableColumns(0)).Width = 70
            grdInvoices.Columns(EnableColumns(1)).Width = 90
            grdInvoices.Columns(EnableColumns(2)).Width = 100
            grdInvoices.Columns(EnableColumns(3)).Width = 80
            grdInvoices.Columns(EnableColumns(4)).Width = 80
            grdInvoices.Columns(EnableColumns(5)).Width = 100

            grdInvoices.Columns(EnableColumns(3)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdInvoices.Columns(EnableColumns(3)).DefaultCellStyle.NullValue = "-"
            grdInvoices.Columns(EnableColumns(3)).DefaultCellStyle.Format = "###,###,###"

            grdInvoices.Columns(EnableColumns(4)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdInvoices.Columns(EnableColumns(4)).DefaultCellStyle.NullValue = "-"
            grdInvoices.Columns(EnableColumns(4)).DefaultCellStyle.Format = "###,###,###"

            Run_FormatInvoice = False                'Disable this codes after run once.

        End If
    End Sub

    Private Sub cBoxSuppliers_Leave(sender As Object, e As EventArgs) Handles cBoxSuppliers.Leave
        MySupplierID = cBoxSuppliers.SelectedValue
        grdRefresh()
    End Sub

    Private Sub grdRefresh()
        IsPaint = True
        SETGridPayments(MySupplierID)
        SETGridPurchaseInvoice(MySupplierID)
        grdInvoices.Refresh()
        IsPaint = False
    End Sub

    Private Sub cBoxSuppliers_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxSuppliers.DropDownClosed
        cBoxSuppliers_Leave(sender, e)
    End Sub

    Private Sub grdInvoices_Paint(sender As Object, e As PaintEventArgs) Handles grdInvoices.Paint
        'Dim _Columns As String() = {"TransactionID", "TransactionDate", "TaxInvoiceNo", "NetAmount", "RemainingAmount", "AccountVoucherNo"}

        If IsPaint Then
            For Each _Row In grdInvoices.Rows

                If _Row.Cells("NetAmount").Value <> _Row.Cells("RemainingAmount").Value Then
                    _Row.DefaultCellStyle.BackColor = Color.Brown
                    _Row.DefaultCellStyle.ForeColor = Color.Bisque

                    If _Row.Cells("RemainingAmount").Value = 0 Then
                        _Row.DefaultCellStyle.BackColor = Color.SeaGreen
                        _Row.DefaultCellStyle.ForeColor = Color.Beige
                    End If
                Else
                    _Row.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If

    End Sub

    Private Sub ClearPayments(_SupplierID As Integer)

        'where TranID IN (SELECT TranID FROM tblPaymentHead WHERE supplierid = @Suppliercode)

        'MsgBox(_PaymentTranID.ToString)

        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)
        Dim _Result1 As Integer = 0
        Dim _Result2 As Integer = 0
        Dim _Result3 As Integer = 0
        Dim _Result4 As Integer = 0

        Dim _SQLText1 As String = String.Concat("DELETE ", Table_PaymentDetail _
                                               , " WHERE TranID IN (SELECT TranID FROM " _
                                               , Table_PaymentHead _
                                               , " WHERE SupplierID = " _
                                               , _SupplierID.ToString _
                                               , " AND CompanyID=", MyCompanyID.ToString _
                                               , ")")

        Dim _SQLText2 As String = String.Concat("DELETE ", Table_PaymentDetail _
                                               , " WHERE TranID IN (SELECT TranID FROM " _
                                               , Table_CreditNotes _
                                               , " WHERE SupplierID = " _
                                               , _SupplierID.ToString _
                                               , " AND CompanyID=", MyCompanyID.ToString _
                                               , ")")

        Dim _SQLText3 As String = String.Concat("UPDATE ", Table_HeadPurchaseInvoice _
                                                , " SET RemainingAmount = NetAmount WHERE SupplierID=" _
                                                , _SupplierID.ToString _
                                                , " AND RemainingAmount <> NetAmount " _
                                                , " AND CompanyID=", MyCompanyID.ToString)

        Dim _SQLText4 As String = String.Concat("UPDATE ", Table_CreditNotes _
                                                , " SET RemainingAmount = GrossAmount WHERE SupplierID=" _
                                                , _SupplierID.ToString _
                                                , " AND RemainingAmount <> GrossAmount " _
                                                , " AND CompanyID=", MyCompanyID.ToString)

        _SQLCommand.CommandText = _SQLText1
        _Result1 = _SQLCommand.ExecuteNonQuery

        _SQLCommand.CommandText = _SQLText2
        _Result2 = _SQLCommand.ExecuteNonQuery

        _SQLCommand.CommandText = _SQLText3
        _Result3 = _SQLCommand.ExecuteNonQuery

        _SQLCommand.CommandText = _SQLText4
        _Result4 = _SQLCommand.ExecuteNonQuery


        If _Result1 + _Result2 + _Result3 + _Result4 > 0 Then
            'MsgBox(_Result1.ToString & " Record(s) Deleted." & Chr(13) & (_Result2 + _Result3).ToString & "Record(s) Updated")
        Else
            'MsgBox("No record deleted and updated")
        End If

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If cBoxSuppliers.SelectedValue Is Nothing Then
            Return
        ElseIf cBoxSuppliers.SelectedValue = 0 Then
            Return
        End If

        Dim _SupplierID As Integer = cBoxSuppliers.SelectedValue

        Dim MsgResult As MsgBoxResult
        Dim MsgTest As String = String.Concat("Are you sure to delete Payments of Supplier ", Chr(13), cBoxSuppliers.Text)
        MsgResult = MsgBox(MsgTest, MsgBoxStyle.YesNo + MessageBoxIcon.Question, "DELETE")

        If MsgResult = MsgBoxResult.Yes Then
            MySupplierID = _SupplierID
            ClearPayments(MySupplierID)
            grdRefresh()
        Else
            MsgBox("No")
        End If

    End Sub

    Private Sub BtnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click

        Dim _SQLText As String() = {"", "", ""}
        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)
        Dim _TotalRec As Integer() = {0, 0, 0}

        _SQLText(0) = "DELETE [tblPaymentDetail] WHERE TranId > 0;"
        _SQLText(1) = "UPDATE [tblHeadPurchaseInvoice] SET RemainingAmount = NetAmount WHERE Remaining <> NetAmount;"
        _SQLText(2) = "UPDATE [tblCreditNote] SET RemainingAmount = GrossAmount WHERE RemainingAmount <> GrossAmount;"

        For i = 1 To 3
            _SQLCommand.CommandText = _SQLText(i)
            _TotalRec(i) = _SQLCommand.ExecuteNonQuery()
        Next

        MsgBox(
        _TotalRec(0) & " Records deleted in Payment Detail Table" + Chr(13) &
        _TotalRec(1) & " Updated in Purchase Invoice Table" + Chr(13) &
        _TotalRec(2) & " Updated in Credit Note Table", MsgBoxStyle.Information, "SQL Queries Result"
        )

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub BtnAdjustAll_Click(sender As Object, e As EventArgs) Handles btnAdjustAll.Click

        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)
        Dim _DV_Supplier As New DataView(Table_Supplier)
        Dim _DV_Payemnts As New DataView
        Dim _DV_Invoices As New DataView

        Dim _SupplierID As Integer = 0
        Dim _SupplierName As String = ""

        'Delete all Supplier Payment Detail
        _SQLCommand.CommandText = String.Concat("DELETE ", Table_PaymentDetail, "WHERE CompanyID=", MyCompanyID.ToString)   'Delete All records of Payment Details Table 
        _SQLCommand.ExecuteNonQuery()
        'END Delete all Supplier Payment Detail
        '===============================================
        'LOOP SUPPLIER TABLE

        _DV_Supplier.RowFilter = "CompanyID=" & MyCompanyID.ToString

        Dim i As Integer = 0

        pbarSupplierList.Visible = True
        pbarSupplierList.Minimum = 0
        pbarSupplierList.Maximum = _DV_Supplier.Count

        While i <= _DV_Supplier.Count - 1

            pbarSupplierList.Value = i

            _SupplierID = _DV_Supplier.Item(i).Item("SupplierID")
            _SupplierName = _DV_Supplier.Item(i).Item("SupplierTitle")

            cBoxSuppliers.SelectedValue = _SupplierID
            cBoxSuppliers.Text = _SupplierName

            '   LOOP Grid Payments & D Note
            _DV_Payemnts.Table = Get_Table_PaymentsDNote(_SupplierID, MyCompanyID)              ' Get Payment of the selected Supplier in Table View.
            _DV_Invoices.Table = Get_Table_InvoicesCNote(_SupplierID, MyCompanyID)

            grdPayments.DataSource = _DV_Payemnts
            grdInvoices.DataSource = _DV_Invoices

            pbarTransactions.Visible = True
            pbarTransactions.Minimum = 0
            pbarTransactions.Maximum = _DV_Payemnts.Count



            Me.Refresh()

            If _DV_Invoices.Count = 0 Then
                i += 1
                Continue While
            End If


            If _DV_Payemnts.Count = 0 Then
                i += 1
                Continue While
            End If

            Dim j As Integer = 0
            Dim _TranID As Integer
            Dim _TransactionID As String
            Dim _Amount As Integer


            ClearPayments(_SupplierID)                      ' Clear / Reset All the payment in Credit Nottes and Purchase Invoice Table.


            While j <= _DV_Payemnts.Count - 1

                _TranID = _DV_Payemnts.Item(j).Item("TranID")
                _TransactionID = _DV_Payemnts.Item(j).Item("TransactionID")
                _Amount = _DV_Payemnts.Item(j).Item("BaseAmount")

                AdjustPayments(_SupplierID, _TranID, _TransactionID, _Amount)           'Adjust Payments Of Supplier
                'grdRefresh()

                pbarTransactions.Value = j

                j += 1




            End While
            '   END LOOP Grid Payments & D Note

            i += 1

        End While


    End Sub

    Private Sub BtnAdjustSupplier_Click(sender As Object, e As EventArgs) Handles btnAdjustSupplier.Click


        Dim _SupplierId = cBoxSuppliers.SelectedValue

        AdjustSupplier(_SupplierId)


    End Sub

    Private Sub BtnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click

        If grdPayments.CurrentCell Is Nothing Then

            If grdPayments.Rows.Count > 0 Then
                Return
                grdPayments.Rows(0).Selected = True
            Else
                lblMessage.Text = "Retuen due to Payment row not selected."
                Return
            End If

        End If

        Dim _SupplierID As Integer = grdPayments.CurrentRow.Cells("SupplierID").Value
        Dim _TransactionID As String = grdPayments.CurrentRow.Cells("TransactionID").Value
        Dim _TranID As Integer = grdPayments.CurrentRow.Cells("TranID").Value
        Dim _Amount As Integer = grdPayments.CurrentRow.Cells("BaseAmount").Value
        Dim _PaymentID As Integer = -1
        Dim _DNote As Integer = -1


        lblMessage.Text = "Payment is being executed now ......"

        AdjustPayments(_SupplierID, _TranID, _TransactionID, _Amount)
        grdRefresh()

        lblMessage.Text = "END - Executed Payment Adjustment."

    End Sub

    Private Sub AdjustPayments(_SupplierID As Integer, _TranID As Integer, _TransactionID As String, _Amount As Integer)

        ' Adjust Payment of Supplier (Main Codes)


        lblMessage.Text = "Executing Adjust Payment"

        Dim _SQLCommand As New SqlCommand("", Connection_Amcorp)
        Dim _DataView_Invoices As New DataView(Get_Table_InvoicesCNote(_SupplierID, MyCompanyID))
        Dim _LastEntry As Boolean = False
        Dim _VouNo As String = ""
        Dim _AdjustedAmount As Integer = 0
        Dim _TransactionAmount As Integer = 0
        Dim _PaymentSumAmount As Integer = 0
        Dim _Result As Integer = 0
        Dim _FirstEntry As Boolean = False

        Dim _PITranID As Integer = -1
        Dim _CnoteTranID As Integer = -1

        _SQLCommand.Parameters.Add("@TranID", SqlDbType.Int)
        _SQLCommand.Parameters.Add("@Amount", SqlDbType.Int)
        _DataView_Invoices.RowFilter = "RemainingAmount > 0"


        For Each _grdRow In _DataView_Invoices

            lblMessage.Text = "Payments are being adjusted... " & _grdRow("TransactionID")

            Table_Payment_Details = Get_DataTable(Table_PaymentDetail, Connection_Bizztrax)

            If _TransactionID.ToString.Substring(0, 3) = "SDN" Then
                If Not IsDBNull(Table_Payment_Details.Compute("SUM(Amount)", "TranID=" & _TranID)) Then
                    _PaymentSumAmount = Table_Payment_Details.Compute("SUM(Amount)", "TranID=" & _TranID)
                End If

                If _PaymentSumAmount = _Amount Then
                    Continue For                        ' If Payment already has been charged in payment detail table then continue
                End If

            End If

            _VouNo = _grdRow("TransactionID")


            If (_AdjustedAmount + _grdRow("RemainingAmount")) > _Amount Then
                _TransactionAmount = (_Amount - _AdjustedAmount)
                _AdjustedAmount = _AdjustedAmount + _TransactionAmount
                _LastEntry = True


            ElseIf (_AdjustedAmount + _grdRow("RemainingAmount")) = _AdjustedAmount Then
                _TransactionAmount = _grdRow("RemainingAmount")
                _AdjustedAmount = _AdjustedAmount + _TransactionAmount
                _LastEntry = True
            Else
                _TransactionAmount = _grdRow("RemainingAmount")
                _AdjustedAmount = _AdjustedAmount + _TransactionAmount
                _LastEntry = False
            End If


            If _VouNo.ToString.Substring(0, 3) = "SCN" Then                   ' Credit note

                _CnoteTranID = _grdRow("TranID")
                _SQLCommand.Parameters("@Amount").Value = _TransactionAmount
                _SQLCommand.Parameters("@TranID").Value = _grdRow("TranID")
                _SQLCommand.CommandText = "UPDATE " & Table_CreditNotes & " SET RemainingAmount = (RemainingAmount - @Amount) WHERE TranID=@TranID; " '& _grdRow("TranID").ToString
                _Result = _SQLCommand.ExecuteNonQuery()

                'MsgBox("Credit Note " & _VouNo)
            Else

                _PITranID = _grdRow("TranID")
                _SQLCommand.Parameters("@Amount").Value = _TransactionAmount
                _SQLCommand.Parameters("@TranID").Value = _grdRow("TranID")
                _SQLCommand.CommandText = "UPDATE " & Table_HeadPurchaseInvoice & " SET RemainingAmount = (RemainingAmount - @Amount) WHERE TranID=@TranID; " '& _grdRow("TranID").ToString
                _Result = _SQLCommand.ExecuteNonQuery()

                'MsgBox("Purchase Invoice " & _VouNo)
            End If

            Dim _SQLText As New StringBuilder
            Dim _PaymentAmount As Integer = 0
            Dim _MaxDetailTran As Integer = 0

            '----------------------------------------------------------------------------- Get Maximum Detail Tran ID
            If IsDBNull(Table_Payment_Details.Compute("MAX(TranDtlID)", "")) Then
                _MaxDetailTran = 1
            Else
                _MaxDetailTran = Table_Payment_Details.Compute("MAX(TranDtlID)", "") + 1
            End If
            '---------------------------------------------------------------------------------------------------------

            _SQLText.Append("INSERT INTO ")
            _SQLText.Append(Table_PaymentDetail)
            _SQLText.Append(" (")
            _SQLText.Append("TranDtlID,")
            _SQLText.Append("TranID,")
            _SQLText.Append("PurchaseInvoiceTranID,")
            _SQLText.Append("CreditNoteTranId,")
            _SQLText.Append("InvoiceNo,")
            _SQLText.Append("CompanyUnitID,")
            _SQLText.Append("Amount,")
            _SQLText.Append("CompanyID,")
            _SQLText.Append("HeadTranID,")
            _SQLText.Append("CurrencyID,")
            _SQLText.Append("BaseCurrencyID,")
            _SQLText.Append("ROE,")
            _SQLText.Append("BaseAmount,")
            _SQLText.Append("AdjustmentType)")

            _SQLText.Append(" VALUES ")

            _SQLText.Append("(")
            _SQLText.Append(_MaxDetailTran.ToString & ",")
            _SQLText.Append(_TranID.ToString & ",")
            _SQLText.Append(_PITranID.ToString & ",")
            _SQLText.Append(_CnoteTranID.ToString & ",")
            _SQLText.Append("' ',")
            _SQLText.Append("1,")
            _SQLText.Append(_TransactionAmount.ToString & ",")
            _SQLText.Append("1,")
            _SQLText.Append(_TranID.ToString & ",")
            _SQLText.Append("1,")
            _SQLText.Append("1,")
            _SQLText.Append("1,")
            _SQLText.Append(_TransactionAmount.ToString & ",")
            _SQLText.Append("'Payment')")

            _SQLCommand.CommandText = _SQLText.ToString
            _SQLCommand.ExecuteNonQuery()

            If _LastEntry Or _TransactionAmount = _Amount Then
                Exit For
            End If

        Next

    End Sub

    Private Sub AdjustSupplier(_SupplierID As Integer)

        Dim _DV_Payemnts As New DataView
        Dim _DV_Invoices As New DataView

        Dim _SupplierName As String = cBoxSuppliers.Text

        _DV_Payemnts.Table = Get_Table_PaymentsDNote(_SupplierID, MyCompanyID)    '(_SQLCommand_Payments)              ' Get Payment of the selected Supplier in Table View.
        _DV_Invoices.Table = Get_Table_InvoicesCNote(_SupplierID, MyCompanyID)     '(_SQLCommand_Invoices)              ' Get Invocies and Credit Notes of the selected supplier in the table view

        grdPayments.DataSource = _DV_Payemnts
        grdInvoices.DataSource = _DV_Invoices
        Me.Refresh()

        If _DV_Invoices.Count = 0 Then
            Return
        End If

        If _DV_Payemnts.Count = 0 Then
            Return
        End If

        Dim j As Integer = 0
        Dim _TranID As Integer
        Dim _TransactionID As String
        Dim _Amount As Integer

        If Run_clear Then
            ClearPayments(_SupplierID)                      ' Clear / Reset All the payment in Credit Nottes and Purchase Invoice Table.
        End If

        pbarTransactions.Visible = True
        pbarTransactions.Minimum = 0
        pbarTransactions.Maximum = _DV_Payemnts.Count

        While j <= _DV_Payemnts.Count - 1

            _TranID = _DV_Payemnts.Item(j).Item("TranID")
            _TransactionID = _DV_Payemnts.Item(j).Item("TransactionID")
            _Amount = _DV_Payemnts.Item(j).Item("BaseAmount")

            AdjustPayments(_SupplierID, _TranID, _TransactionID, _Amount)
            grdRefresh()

            lblMessage.Text = _TransactionID
            pbarTransactions.Value = j
            j += 1

        End While

        pbarTransactions.Visible = False

    End Sub

    Private Sub CBoxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxCompany.SelectedIndexChanged

        Try
            MyCompanyID = cBoxCompany.SelectedValue
        Catch ex As Exception
            MyCompanyID = 0
        End Try


        View_Supplier.RowFilter = "CompanyID=" & MyCompanyID.ToString

    End Sub



#Enable Warning CA3105 ' Do not declare visible instance fields
#Enable Warning CA2100 ' Do not declare visible instance fields
#Enable Warning CA2000 ' Dispose objects before losing scope
#Enable Warning CA1303 ' Do not pass literals as localized parameters
#Enable Warning CA1305
#Enable Warning CA1031


End Class
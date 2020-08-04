Imports System.Data

Public Class START

#Disable Warning CA2000 ' Dispose objects before losing scope

    Private Sub START_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _Result As String = Connection_Class.CreateSetup.InstanceStart(My.Settings.SetupDBInstance)
        lblMessage.Text = _Result
    End Sub

    Private Sub mnuCreateSetupDB_Click(sender As Object, e As EventArgs) Handles mnuCreateSetupDB.Click

        Dim SetupClass As New Connection_Class.CreateSetup(DB_Defaults)
        SetupClass.CreateSetupDB(DB_Defaults)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub mnuGetPWHash_Click(sender As Object, e As EventArgs) Handles mnuGetPWHash.Click


        Dim ShowForm As New frmGetPWHash

        ShowForm.Show()

    End Sub

    Private Sub mnuDatabase_Test_Click(sender As Object, e As EventArgs) Handles mnuDatabase_Test.Click

        Dim _form As New frmTest_Connection
        _form.Show()

    End Sub

    Private Sub AddDBConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDBConnectionToolStripMenuItem.Click

        Add_Connection()

    End Sub

    Private Sub mnuSupplierLedger_Click(sender As Object, e As EventArgs) Handles mnuSupplierLedger.Click
        Dim ShowForm As New frmSupplier_Ledger
        ShowForm.Show()
    End Sub

    Private Sub mnuConnectionDataRecord_Click(sender As Object, e As EventArgs) Handles mnuConnectionDataRecord.Click

        Dim Showform As New Connection_Class.frmConnection_Record(DB_Defaults)
        Showform.Show()


    End Sub

    Private Sub SupplierListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSupplierRecord.Click
        Dim ShowForm As New frmSupplier
        ShowForm.Show()
    End Sub

    Private Sub TestFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestFormToolStripMenuItem.Click
        Dim ShowForm As New frmTest
        ShowForm.Show()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        Dim ShowForm As New frmGeneralLedger
        ShowForm.Show()
    End Sub


    Private Sub MnuSupplierInvAdj_Click(sender As Object, e As EventArgs) Handles mnuSupplierInvAdj.Click
        Dim ShowForm As New frmSupplier_Invoice_Adjuste
        ShowForm.Show()
    End Sub

    Private Sub MnuItemJV_Click(sender As Object, e As EventArgs) Handles mnuItemJV.Click
        Dim ShowForm As New frmItemJV
        ShowForm.Show()
    End Sub

    Private Sub MnuItemList_Click(sender As Object, e As EventArgs) Handles mnuItemList.Click
        Dim ShowForm As New frmItems
        ShowForm.Show()
    End Sub

    Private Sub MnuTest_Click(sender As Object, e As EventArgs) Handles mnuTest.Click
        Copy_COA_JV_ACC()
    End Sub

    Private Sub MnuCopySupplierJV_Click(sender As Object, e As EventArgs) Handles mnuCopySupplierJV.Click
        Copy_SupplierJV()
    End Sub

    Private Sub MnuSupplierAging_Click(sender As Object, e As EventArgs) Handles mnuSupplierAging.Click
        Dim ShowForm As New frmSupplierAging
        ShowForm.Show()
    End Sub

    Private Sub MnuJoinSupplierLedger_Click(sender As Object, e As EventArgs) Handles mnuJoinSupplierLedger.Click
        Dim ShowForm As New frmJoinLedgers
        ShowForm.Show()
    End Sub

    Private Sub MnuItems_COA_Trans_Click(sender As Object, e As EventArgs) Handles mnuItems_COA_Trans.Click
        Dim ShowForm As New frmItems_COA_TranType
        ShowForm.Show()
    End Sub

    Private Sub mnuDeplicateUser_Click(sender As Object, e As EventArgs) Handles mnuDeplicateUser.Click
        Dim ShowForm As New frmDuplicateUser
        ShowForm.Show()
    End Sub

    Private Sub mnuMigration_AO_Click(sender As Object, e As EventArgs) Handles mnuMigration_AO.Click
        Dim ShowForm As New frmMigration_COA
        ShowForm.Show()
    End Sub

    Private Sub mnuAllocation_Click(sender As Object, e As EventArgs) Handles mnuAllocation.Click
        Dim ShowForm As New frmPayment_Allocation
        ShowForm.Show()
    End Sub

    Private Sub mnuMigrationAmcorp_Click(sender As Object, e As EventArgs) Handles mnuMigrationAmcorp.Click
        Dim ShowForm As New frmMigrations_Amcorp
        ShowForm.Show()
    End Sub

    Private Sub mnuProjectReport_Click(sender As Object, e As EventArgs) Handles mnuProjectReport.Click
        Dim ShowForm As New frmProject_Expense_Report
        ShowForm.Show()
    End Sub

    Private Sub mnuUpdateExpenses_Click(sender As Object, e As EventArgs) Handles mnuUpdateExpenses.Click
        Dim ShowForm As New frmCostExpenses
        ShowForm.Show()
    End Sub

#Enable Warning CA2000 ' Dispose objects before losing scope

End Class
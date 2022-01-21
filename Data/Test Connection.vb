Imports System.Data.SqlClient
Public Class frmTest_Connection

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnConnection_Master_Click(sender As Object, e As EventArgs) Handles btnConnection_Master.Click
        Dim ConnectionMaster As SqlConnection
        'ConnectionMaster = Connection_Class.AppliedConnection(DB.Master, DB_Defaults)
        ConnectionMaster = Connection_Master()
        MsgBox("Status Master | " & ConnectionMaster.State.ToString)

    End Sub

    Private Sub btnConnection_Bizztrax_Click(sender As Object, e As EventArgs) Handles btnConnection_Bizztrax.Click
        Dim ConnectionMaster As SqlConnection
        ConnectionMaster = Connection_Bizztrax()
        MsgBox("Status BizzTrax| " & ConnectionMaster.State.ToString)
    End Sub

    Private Sub btnConnection_BizztraxAmcorp_Click(sender As Object, e As EventArgs) Handles btnConnection_BizztraxAmcorp.Click
        Dim ConnectionMaster As SqlConnection
        ConnectionMaster = Connection_Amcorp()
        MsgBox("Status BizzTrax_Amcorp | " & ConnectionMaster.State.ToString)
    End Sub


End Class
Imports System.Windows.Forms
Public Class frmGetPWHash

    Dim PasswordChar As Char = My.Settings.PWChar

    Private Sub chkPWView_CheckedChanged(sender As Object, e As EventArgs) Handles chkPWView.CheckedChanged

        If chkPWView.Checked Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = PasswordChar
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPWHash.Text = Connection_Class.PW.EncryptPassword(sender.Text, My.Settings.PWWrapper)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles txtCopy.Click
        Clipboard.SetText(txtPWHash.Text)
        MsgBox("Password Hash texct has been clipboard.")
    End Sub
End Class
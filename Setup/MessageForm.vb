Imports System.Collections

Public Class frmMessageForm


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(MyMessages As ArrayList)

        ' This call is required by the designer.
        InitializeComponent()

        txtMessages.Text = MyMessages.ToString

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class
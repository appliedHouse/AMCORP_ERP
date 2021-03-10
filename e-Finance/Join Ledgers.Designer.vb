<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJoinLedgers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cBoxSupplierJoin = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnJoinLedger = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cBoxSupplierJoin
        '
        Me.cBoxSupplierJoin.FormattingEnabled = True
        Me.cBoxSupplierJoin.Location = New System.Drawing.Point(12, 28)
        Me.cBoxSupplierJoin.Name = "cBoxSupplierJoin"
        Me.cBoxSupplierJoin.Size = New System.Drawing.Size(432, 21)
        Me.cBoxSupplierJoin.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Join Suppliers Ledger"
        '
        'btnJoinLedger
        '
        Me.btnJoinLedger.Location = New System.Drawing.Point(15, 74)
        Me.btnJoinLedger.Name = "btnJoinLedger"
        Me.btnJoinLedger.Size = New System.Drawing.Size(125, 23)
        Me.btnJoinLedger.TabIndex = 2
        Me.btnJoinLedger.Text = "Join Ledgers"
        Me.btnJoinLedger.UseVisualStyleBackColor = True
        '
        'frmJoinLedgers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 199)
        Me.Controls.Add(Me.btnJoinLedger)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cBoxSupplierJoin)
        Me.Name = "frmJoinLedgers"
        Me.Text = "Join_Ledgers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cBoxSupplierJoin As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnJoinLedger As Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetPWHash
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
        Me.lblPW = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtPWHash = New System.Windows.Forms.TextBox()
        Me.ChkPWPolicy = New System.Windows.Forms.CheckBox()
        Me.chkPWView = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtCopy = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPW
        '
        Me.lblPW.AutoSize = True
        Me.lblPW.Location = New System.Drawing.Point(12, 22)
        Me.lblPW.Name = "lblPW"
        Me.lblPW.Size = New System.Drawing.Size(53, 13)
        Me.lblPW.TabIndex = 0
        Me.lblPW.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password Hash"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(102, 19)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtPassword.Size = New System.Drawing.Size(320, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtPWHash
        '
        Me.txtPWHash.Location = New System.Drawing.Point(102, 56)
        Me.txtPWHash.Name = "txtPWHash"
        Me.txtPWHash.Size = New System.Drawing.Size(359, 20)
        Me.txtPWHash.TabIndex = 3
        '
        'ChkPWPolicy
        '
        Me.ChkPWPolicy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPWPolicy.AutoSize = True
        Me.ChkPWPolicy.Enabled = False
        Me.ChkPWPolicy.Location = New System.Drawing.Point(12, 100)
        Me.ChkPWPolicy.Name = "ChkPWPolicy"
        Me.ChkPWPolicy.Size = New System.Drawing.Size(143, 17)
        Me.ChkPWPolicy.TabIndex = 4
        Me.ChkPWPolicy.Text = "Enforce Password Policy"
        Me.ChkPWPolicy.UseVisualStyleBackColor = True
        '
        'chkPWView
        '
        Me.chkPWView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPWView.AutoSize = True
        Me.chkPWView.Location = New System.Drawing.Point(442, 22)
        Me.chkPWView.Name = "chkPWView"
        Me.chkPWView.Size = New System.Drawing.Size(98, 17)
        Me.chkPWView.TabIndex = 5
        Me.chkPWView.Text = "View Password"
        Me.chkPWView.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(465, 94)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtCopy
        '
        Me.txtCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopy.Location = New System.Drawing.Point(465, 56)
        Me.txtCopy.Name = "txtCopy"
        Me.txtCopy.Size = New System.Drawing.Size(75, 23)
        Me.txtCopy.TabIndex = 7
        Me.txtCopy.Text = "Copy"
        Me.txtCopy.UseVisualStyleBackColor = True
        '
        'frmGetPWHash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 132)
        Me.Controls.Add(Me.txtCopy)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.chkPWView)
        Me.Controls.Add(Me.ChkPWPolicy)
        Me.Controls.Add(Me.txtPWHash)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPW)
        Me.Name = "frmGetPWHash"
        Me.Text = "Password_Hash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPW As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtPassword As Windows.Forms.TextBox
    Friend WithEvents txtPWHash As Windows.Forms.TextBox
    Friend WithEvents ChkPWPolicy As Windows.Forms.CheckBox
    Friend WithEvents chkPWView As Windows.Forms.CheckBox
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents txtCopy As Windows.Forms.Button
End Class

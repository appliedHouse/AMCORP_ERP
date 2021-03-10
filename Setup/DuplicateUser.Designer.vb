<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDuplicateUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboxCompany = New System.Windows.Forms.ComboBox()
        Me.cBoxUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboxDuplicateUser = New System.Windows.Forms.ComboBox()
        Me.brnCreate = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboxCompany
        '
        Me.cboxCompany.FormattingEnabled = True
        Me.cboxCompany.Location = New System.Drawing.Point(109, 30)
        Me.cboxCompany.Name = "cboxCompany"
        Me.cboxCompany.Size = New System.Drawing.Size(306, 21)
        Me.cboxCompany.TabIndex = 0
        '
        'cBoxUser
        '
        Me.cBoxUser.FormattingEnabled = True
        Me.cBoxUser.Location = New System.Drawing.Point(109, 57)
        Me.cBoxUser.Name = "cBoxUser"
        Me.cBoxUser.Size = New System.Drawing.Size(306, 21)
        Me.cBoxUser.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Company"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "User"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Create User in Company"
        '
        'cboxDuplicateUser
        '
        Me.cboxDuplicateUser.FormattingEnabled = True
        Me.cboxDuplicateUser.Location = New System.Drawing.Point(146, 138)
        Me.cboxDuplicateUser.Name = "cboxDuplicateUser"
        Me.cboxDuplicateUser.Size = New System.Drawing.Size(269, 21)
        Me.cboxDuplicateUser.TabIndex = 5
        '
        'brnCreate
        '
        Me.brnCreate.Location = New System.Drawing.Point(340, 232)
        Me.brnCreate.Name = "brnCreate"
        Me.brnCreate.Size = New System.Drawing.Size(75, 23)
        Me.brnCreate.TabIndex = 6
        Me.brnCreate.Text = "Create User"
        Me.brnCreate.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(340, 263)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(19, 273)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(55, 13)
        Me.lblMessage.TabIndex = 8
        Me.lblMessage.Text = "Messages"
        '
        'frmDuplicateUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 298)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.brnCreate)
        Me.Controls.Add(Me.cboxDuplicateUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cBoxUser)
        Me.Controls.Add(Me.cboxCompany)
        Me.Name = "frmDuplicateUser"
        Me.Text = "Duplicate User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboxCompany As Windows.Forms.ComboBox
    Friend WithEvents cBoxUser As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cboxDuplicateUser As Windows.Forms.ComboBox
    Friend WithEvents brnCreate As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents lblMessage As Windows.Forms.Label
End Class

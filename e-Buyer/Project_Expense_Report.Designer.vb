<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProject_Expense_Report
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.proBar = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "F I L E"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(57, 30)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(602, 20)
        Me.txtFile.TabIndex = 1
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(665, 28)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(33, 23)
        Me.btnFile.TabIndex = 2
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(542, 72)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 3
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(623, 72)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E X I T"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'proBar
        '
        Me.proBar.Location = New System.Drawing.Point(13, 110)
        Me.proBar.Name = "proBar"
        Me.proBar.Size = New System.Drawing.Size(685, 23)
        Me.proBar.TabIndex = 5
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(13, 91)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(39, 13)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Label2"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(57, 57)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(405, 20)
        Me.txtFileName.TabIndex = 7
        '
        'frmProject_Expense_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 148)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.proBar)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmProject_Expense_Report"
        Me.Text = "Project Expense Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtFile As Windows.Forms.TextBox
    Friend WithEvents btnFile As Windows.Forms.Button
    Friend WithEvents btnProceed As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents proBar As Windows.Forms.ProgressBar
    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents txtFileName As Windows.Forms.TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostExpenses
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
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.proBar = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_Thar = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(6, 16)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(39, 13)
        Me.lblMessage.TabIndex = 13
        Me.lblMessage.Text = "Label2"
        '
        'proBar
        '
        Me.proBar.Location = New System.Drawing.Point(25, 156)
        Me.proBar.Name = "proBar"
        Me.proBar.Size = New System.Drawing.Size(685, 23)
        Me.proBar.TabIndex = 12
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(635, 83)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "E X I T"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(554, 83)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(75, 23)
        Me.btnProceed.TabIndex = 10
        Me.btnProceed.Text = "PROCEED"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(677, 43)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(33, 23)
        Me.btnFile.TabIndex = 9
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(69, 45)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(602, 20)
        Me.txtFile.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "F I L E"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(187, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(358, 24)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "PROJECT COST REPORT UPDATER"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(470, 83)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 15
        Me.btnView.Text = "VIEW"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 38)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MESSAGE"
        '
        'rb_Thar
        '
        Me.rb_Thar.AutoSize = True
        Me.rb_Thar.Location = New System.Drawing.Point(176, 83)
        Me.rb_Thar.Name = "rb_Thar"
        Me.rb_Thar.Size = New System.Drawing.Size(67, 17)
        Me.rb_Thar.TabIndex = 17
        Me.rb_Thar.TabStop = True
        Me.rb_Thar.Text = "Thar OM"
        Me.rb_Thar.UseVisualStyleBackColor = True
        '
        'frmCostExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 187)
        Me.Controls.Add(Me.rb_Thar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.proBar)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCostExpenses"
        Me.Text = "Project_Cost_Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents proBar As Windows.Forms.ProgressBar
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnProceed As Windows.Forms.Button
    Friend WithEvents btnFile As Windows.Forms.Button
    Friend WithEvents txtFile As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnView As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rb_Thar As Windows.Forms.RadioButton
End Class

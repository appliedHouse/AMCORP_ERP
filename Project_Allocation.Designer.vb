<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Project_Allocation
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
        Me.cBoxProjects = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cBoxProjects
        '
        Me.cBoxProjects.FormattingEnabled = True
        Me.cBoxProjects.Location = New System.Drawing.Point(53, 13)
        Me.cBoxProjects.Name = "cBoxProjects"
        Me.cBoxProjects.Size = New System.Drawing.Size(537, 21)
        Me.cBoxProjects.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(53, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(122, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(515, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(7, 16)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(40, 13)
        Me.lblProject.TabIndex = 3
        Me.lblProject.Text = "Project"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(4, 43)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(43, 13)
        Me.lblAmount.TabIndex = 4
        Me.lblAmount.Text = "Amount"
        '
        'Project_Allocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 231)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.lblProject)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cBoxProjects)
        Me.Name = "Project_Allocation"
        Me.Text = "Project_Allocation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cBoxProjects As Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents lblProject As Windows.Forms.Label
    Friend WithEvents lblAmount As Windows.Forms.Label
End Class

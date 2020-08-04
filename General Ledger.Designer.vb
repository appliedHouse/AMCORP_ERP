<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralLedger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneralLedger))
        Me.cboxCOA = New System.Windows.Forms.ComboBox()
        Me.cboxProject = New System.Windows.Forms.ComboBox()
        Me.chkAllProjects = New System.Windows.Forms.CheckBox()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboxCOA
        '
        Me.cboxCOA.FormattingEnabled = True
        Me.cboxCOA.Location = New System.Drawing.Point(102, 50)
        Me.cboxCOA.Name = "cboxCOA"
        Me.cboxCOA.Size = New System.Drawing.Size(362, 21)
        Me.cboxCOA.TabIndex = 0
        '
        'cboxProject
        '
        Me.cboxProject.FormattingEnabled = True
        Me.cboxProject.Location = New System.Drawing.Point(102, 77)
        Me.cboxProject.Name = "cboxProject"
        Me.cboxProject.Size = New System.Drawing.Size(362, 21)
        Me.cboxProject.TabIndex = 1
        '
        'chkAllProjects
        '
        Me.chkAllProjects.AutoSize = True
        Me.chkAllProjects.Location = New System.Drawing.Point(102, 104)
        Me.chkAllProjects.Name = "chkAllProjects"
        Me.chkAllProjects.Size = New System.Drawing.Size(81, 17)
        Me.chkAllProjects.TabIndex = 2
        Me.chkAllProjects.Text = "CheckBox1"
        Me.chkAllProjects.UseVisualStyleBackColor = True
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(102, 146)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(107, 20)
        Me.dtFrom.TabIndex = 3
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(265, 146)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(107, 20)
        Me.dtTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ledger Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Project"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "All Project"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Report From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(224, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "To"
        '
        'btnPreview
        '
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.Location = New System.Drawing.Point(327, 240)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(30, 30)
        Me.btnPreview.TabIndex = 10
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(363, 240)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(30, 30)
        Me.btnPrint.TabIndex = 11
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(434, 240)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(30, 30)
        Me.btnExit.TabIndex = 12
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Company"
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(102, 21)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(362, 21)
        Me.cBoxCompany.TabIndex = 14
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(16, 257)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Message"
        '
        'frmGeneralLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 282)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.chkAllProjects)
        Me.Controls.Add(Me.cboxProject)
        Me.Controls.Add(Me.cboxCOA)
        Me.Name = "frmGeneralLedger"
        Me.Text = "General Ledger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboxCOA As Windows.Forms.ComboBox
    Friend WithEvents cboxProject As Windows.Forms.ComboBox
    Friend WithEvents chkAllProjects As Windows.Forms.CheckBox
    Friend WithEvents dtFrom As Windows.Forms.DateTimePicker
    Friend WithEvents dtTo As Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btnPreview As Windows.Forms.Button
    Friend WithEvents btnPrint As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
    Friend WithEvents lblMessage As Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplier_Ledger
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboxSupplier = New System.Windows.Forms.ComboBox()
        Me.cboxProject = New System.Windows.Forms.ComboBox()
        Me.chkAllProject = New System.Windows.Forms.CheckBox()
        Me.dtReportFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtReportTo = New System.Windows.Forms.DateTimePicker()
        Me.btnLedgerSupplier = New System.Windows.Forms.Button()
        Me.btnLedgerProject = New System.Windows.Forms.Button()
        Me.btnSummary = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MyMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MyProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.gboxERP_DB = New System.Windows.Forms.GroupBox()
        Me.chkZeroBalance = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1.SuspendLayout()
        Me.gboxERP_DB.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Supplier"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(129, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Project"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(129, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Report From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(322, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Report To"
        '
        'cboxSupplier
        '
        Me.cboxSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboxSupplier.FormattingEnabled = True
        Me.cboxSupplier.Location = New System.Drawing.Point(204, 42)
        Me.cboxSupplier.Name = "cboxSupplier"
        Me.cboxSupplier.Size = New System.Drawing.Size(384, 21)
        Me.cboxSupplier.TabIndex = 4
        '
        'cboxProject
        '
        Me.cboxProject.Enabled = False
        Me.cboxProject.FormattingEnabled = True
        Me.cboxProject.Location = New System.Drawing.Point(204, 69)
        Me.cboxProject.Name = "cboxProject"
        Me.cboxProject.Size = New System.Drawing.Size(300, 21)
        Me.cboxProject.TabIndex = 5
        '
        'chkAllProject
        '
        Me.chkAllProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAllProject.AutoSize = True
        Me.chkAllProject.Checked = True
        Me.chkAllProject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllProject.Location = New System.Drawing.Point(510, 73)
        Me.chkAllProject.Name = "chkAllProject"
        Me.chkAllProject.Size = New System.Drawing.Size(78, 17)
        Me.chkAllProject.TabIndex = 6
        Me.chkAllProject.Text = "All Projects"
        Me.chkAllProject.UseVisualStyleBackColor = True
        '
        'dtReportFrom
        '
        Me.dtReportFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtReportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtReportFrom.Location = New System.Drawing.Point(204, 106)
        Me.dtReportFrom.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtReportFrom.MinDate = New Date(2017, 6, 30, 0, 0, 0, 0)
        Me.dtReportFrom.Name = "dtReportFrom"
        Me.dtReportFrom.Size = New System.Drawing.Size(106, 20)
        Me.dtReportFrom.TabIndex = 7
        Me.dtReportFrom.Value = New Date(2017, 6, 30, 0, 0, 0, 0)
        '
        'dtReportTo
        '
        Me.dtReportTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtReportTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtReportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtReportTo.Location = New System.Drawing.Point(398, 106)
        Me.dtReportTo.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.dtReportTo.MinDate = New Date(2017, 6, 30, 0, 0, 0, 0)
        Me.dtReportTo.Name = "dtReportTo"
        Me.dtReportTo.Size = New System.Drawing.Size(106, 20)
        Me.dtReportTo.TabIndex = 8
        Me.dtReportTo.Value = New Date(2020, 6, 30, 0, 0, 0, 0)
        '
        'btnLedgerSupplier
        '
        Me.btnLedgerSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLedgerSupplier.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLedgerSupplier.Location = New System.Drawing.Point(204, 180)
        Me.btnLedgerSupplier.Name = "btnLedgerSupplier"
        Me.btnLedgerSupplier.Size = New System.Drawing.Size(91, 23)
        Me.btnLedgerSupplier.TabIndex = 9
        Me.btnLedgerSupplier.Text = "Ledger"
        Me.btnLedgerSupplier.UseVisualStyleBackColor = True
        '
        'btnLedgerProject
        '
        Me.btnLedgerProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLedgerProject.Location = New System.Drawing.Point(303, 180)
        Me.btnLedgerProject.Name = "btnLedgerProject"
        Me.btnLedgerProject.Size = New System.Drawing.Size(91, 23)
        Me.btnLedgerProject.TabIndex = 10
        Me.btnLedgerProject.Text = "Project Ledger"
        Me.btnLedgerProject.UseVisualStyleBackColor = True
        '
        'btnSummary
        '
        Me.btnSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSummary.Location = New System.Drawing.Point(400, 180)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(91, 23)
        Me.btnSummary.TabIndex = 11
        Me.btnSummary.Text = "Summary"
        Me.btnSummary.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(497, 180)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MyMessage, Me.MyProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 219)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(602, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MyMessage
        '
        Me.MyMessage.Name = "MyMessage"
        Me.MyMessage.Size = New System.Drawing.Size(53, 17)
        Me.MyMessage.Text = "Message"
        '
        'MyProgressBar
        '
        Me.MyProgressBar.Name = "MyProgressBar"
        Me.MyProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(9, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(88, 17)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.Text = "< 01-07-2017"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(9, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(72, 17)
        Me.RadioButton2.TabIndex = 15
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "New ERP"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'gboxERP_DB
        '
        Me.gboxERP_DB.Controls.Add(Me.RadioButton1)
        Me.gboxERP_DB.Controls.Add(Me.RadioButton2)
        Me.gboxERP_DB.Location = New System.Drawing.Point(12, 13)
        Me.gboxERP_DB.Name = "gboxERP_DB"
        Me.gboxERP_DB.Size = New System.Drawing.Size(109, 64)
        Me.gboxERP_DB.TabIndex = 16
        Me.gboxERP_DB.TabStop = False
        Me.gboxERP_DB.Text = "ERP System"
        '
        'chkZeroBalance
        '
        Me.chkZeroBalance.AutoSize = True
        Me.chkZeroBalance.Checked = True
        Me.chkZeroBalance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkZeroBalance.Location = New System.Drawing.Point(204, 146)
        Me.chkZeroBalance.Name = "chkZeroBalance"
        Me.chkZeroBalance.Size = New System.Drawing.Size(125, 17)
        Me.chkZeroBalance.TabIndex = 17
        Me.chkZeroBalance.Text = "Show Zero Balances"
        Me.chkZeroBalance.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Company"
        '
        'cBoxCompany
        '
        Me.cBoxCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(204, 13)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(384, 21)
        Me.cBoxCompany.TabIndex = 19
        '
        'frmSupplier_Ledger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 241)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkZeroBalance)
        Me.Controls.Add(Me.gboxERP_DB)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSummary)
        Me.Controls.Add(Me.btnLedgerProject)
        Me.Controls.Add(Me.btnLedgerSupplier)
        Me.Controls.Add(Me.dtReportTo)
        Me.Controls.Add(Me.dtReportFrom)
        Me.Controls.Add(Me.chkAllProject)
        Me.Controls.Add(Me.cboxProject)
        Me.Controls.Add(Me.cboxSupplier)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSupplier_Ledger"
        Me.Text = "Supplier_Ledger"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gboxERP_DB.ResumeLayout(False)
        Me.gboxERP_DB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cboxSupplier As Windows.Forms.ComboBox
    Friend WithEvents cboxProject As Windows.Forms.ComboBox
    Friend WithEvents chkAllProject As Windows.Forms.CheckBox
    Friend WithEvents dtReportFrom As Windows.Forms.DateTimePicker
    Friend WithEvents dtReportTo As Windows.Forms.DateTimePicker
    Friend WithEvents btnLedgerSupplier As Windows.Forms.Button
    Friend WithEvents btnLedgerProject As Windows.Forms.Button
    Friend WithEvents btnSummary As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents MyMessage As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MyProgressBar As Windows.Forms.ToolStripProgressBar
    Friend WithEvents RadioButton1 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As Windows.Forms.RadioButton
    Friend WithEvents gboxERP_DB As Windows.Forms.GroupBox
    Friend WithEvents chkZeroBalance As Windows.Forms.CheckBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
End Class

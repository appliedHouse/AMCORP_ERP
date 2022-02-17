<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVouchers
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grid_Voucher = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grid_Transaction = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grid_Voucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grid_Transaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 57)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(775, 365)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grid_Voucher)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(767, 339)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "VOUCHER"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grid_Voucher
        '
        Me.grid_Voucher.AllowDrop = True
        Me.grid_Voucher.AllowUserToAddRows = False
        Me.grid_Voucher.AllowUserToDeleteRows = False
        Me.grid_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Voucher.Location = New System.Drawing.Point(6, 6)
        Me.grid_Voucher.Name = "grid_Voucher"
        Me.grid_Voucher.Size = New System.Drawing.Size(754, 327)
        Me.grid_Voucher.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grid_Transaction)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(767, 339)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TRANSACTION"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grid_Transaction
        '
        Me.grid_Transaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Transaction.Location = New System.Drawing.Point(6, 6)
        Me.grid_Transaction.Name = "grid_Transaction"
        Me.grid_Transaction.Size = New System.Drawing.Size(755, 327)
        Me.grid_Transaction.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Company"
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(71, 24)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(388, 21)
        Me.cBoxCompany.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(476, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Voucher No"
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Location = New System.Drawing.Point(549, 24)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(100, 20)
        Me.txtVoucherNo.TabIndex = 4
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(17, 425)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = "Message"
        '
        'frmVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmVouchers"
        Me.Text = "Voucher"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grid_Voucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grid_Transaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents grid_Voucher As Windows.Forms.DataGridView
    Friend WithEvents grid_Transaction As Windows.Forms.DataGridView
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtVoucherNo As Windows.Forms.TextBox
    Friend WithEvents lblMessage As Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplier_Invoice_Adjuste
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
        Me.cBoxSuppliers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdPayments = New System.Windows.Forms.DataGridView()
        Me.grdInvoices = New System.Windows.Forms.DataGridView()
        Me.lblPayments = New System.Windows.Forms.Label()
        Me.lblInvoices = New System.Windows.Forms.Label()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAdjustAll = New System.Windows.Forms.Button()
        Me.btnAdjust = New System.Windows.Forms.Button()
        Me.Pages = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Page2 = New System.Windows.Forms.TabPage()
        Me.grdPaymentDetail = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAdjustSupplier = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pbarTransactions = New System.Windows.Forms.ProgressBar()
        Me.pbarSupplierList = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        CType(Me.grdPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pages.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Page2.SuspendLayout()
        CType(Me.grdPaymentDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cBoxSuppliers
        '
        Me.cBoxSuppliers.FormattingEnabled = True
        Me.cBoxSuppliers.Location = New System.Drawing.Point(73, 36)
        Me.cBoxSuppliers.Name = "cBoxSuppliers"
        Me.cBoxSuppliers.Size = New System.Drawing.Size(306, 21)
        Me.cBoxSuppliers.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Supplier"
        '
        'grdPayments
        '
        Me.grdPayments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPayments.Location = New System.Drawing.Point(9, 26)
        Me.grdPayments.Name = "grdPayments"
        Me.grdPayments.Size = New System.Drawing.Size(404, 412)
        Me.grdPayments.TabIndex = 2
        '
        'grdInvoices
        '
        Me.grdInvoices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInvoices.Location = New System.Drawing.Point(419, 26)
        Me.grdInvoices.Name = "grdInvoices"
        Me.grdInvoices.Size = New System.Drawing.Size(657, 412)
        Me.grdInvoices.TabIndex = 3
        '
        'lblPayments
        '
        Me.lblPayments.AutoSize = True
        Me.lblPayments.Location = New System.Drawing.Point(6, 10)
        Me.lblPayments.Name = "lblPayments"
        Me.lblPayments.Size = New System.Drawing.Size(53, 13)
        Me.lblPayments.TabIndex = 4
        Me.lblPayments.Text = "Payments"
        '
        'lblInvoices
        '
        Me.lblInvoices.AutoSize = True
        Me.lblInvoices.Location = New System.Drawing.Point(416, 10)
        Me.lblInvoices.Name = "lblInvoices"
        Me.lblInvoices.Size = New System.Drawing.Size(47, 13)
        Me.lblInvoices.TabIndex = 5
        Me.lblInvoices.Text = "Invoices"
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(87, 20)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(75, 23)
        Me.btnClearAll.TabIndex = 2
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(6, 20)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(982, 564)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAdjustAll
        '
        Me.btnAdjustAll.Location = New System.Drawing.Point(330, 19)
        Me.btnAdjustAll.Name = "btnAdjustAll"
        Me.btnAdjustAll.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjustAll.TabIndex = 5
        Me.btnAdjustAll.Text = "A L L "
        Me.btnAdjustAll.UseVisualStyleBackColor = True
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(168, 20)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjust.TabIndex = 3
        Me.btnAdjust.Text = "Payment"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'Pages
        '
        Me.Pages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pages.Controls.Add(Me.TabPage1)
        Me.Pages.Controls.Add(Me.Page2)
        Me.Pages.Location = New System.Drawing.Point(16, 65)
        Me.Pages.Name = "Pages"
        Me.Pages.SelectedIndex = 0
        Me.Pages.Size = New System.Drawing.Size(1045, 470)
        Me.Pages.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdPayments)
        Me.TabPage1.Controls.Add(Me.grdInvoices)
        Me.TabPage1.Controls.Add(Me.lblPayments)
        Me.TabPage1.Controls.Add(Me.lblInvoices)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1037, 444)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Page1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.grdPaymentDetail)
        Me.Page2.Location = New System.Drawing.Point(4, 22)
        Me.Page2.Name = "Page2"
        Me.Page2.Padding = New System.Windows.Forms.Padding(3)
        Me.Page2.Size = New System.Drawing.Size(926, 420)
        Me.Page2.TabIndex = 1
        Me.Page2.Text = "TabPage2"
        Me.Page2.UseVisualStyleBackColor = True
        '
        'grdPaymentDetail
        '
        Me.grdPaymentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPaymentDetail.Location = New System.Drawing.Point(6, 6)
        Me.grdPaymentDetail.Name = "grdPaymentDetail"
        Me.grdPaymentDetail.Size = New System.Drawing.Size(914, 257)
        Me.grdPaymentDetail.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAdjustSupplier)
        Me.GroupBox1.Controls.Add(Me.btnAdjustAll)
        Me.GroupBox1.Controls.Add(Me.btnAdjust)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnClearAll)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 539)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Invoice / Payment Adjustments"
        '
        'btnAdjustSupplier
        '
        Me.btnAdjustSupplier.Location = New System.Drawing.Point(249, 20)
        Me.btnAdjustSupplier.Name = "btnAdjustSupplier"
        Me.btnAdjustSupplier.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjustSupplier.TabIndex = 4
        Me.btnAdjustSupplier.Text = "Supplier"
        Me.btnAdjustSupplier.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(436, 558)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(55, 13)
        Me.lblMessage.TabIndex = 14
        Me.lblMessage.Text = "Messages"
        '
        'pbarTransactions
        '
        Me.pbarTransactions.Location = New System.Drawing.Point(385, 36)
        Me.pbarTransactions.Name = "pbarTransactions"
        Me.pbarTransactions.Size = New System.Drawing.Size(561, 23)
        Me.pbarTransactions.TabIndex = 15
        Me.pbarTransactions.Visible = False
        '
        'pbarSupplierList
        '
        Me.pbarSupplierList.Location = New System.Drawing.Point(385, 8)
        Me.pbarSupplierList.Name = "pbarSupplierList"
        Me.pbarSupplierList.Size = New System.Drawing.Size(561, 23)
        Me.pbarSupplierList.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbarSupplierList.TabIndex = 16
        Me.pbarSupplierList.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Company"
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(73, 8)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(306, 21)
        Me.cBoxCompany.TabIndex = 1
        '
        'frmSupplier_Invoice_Adjuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 593)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.pbarSupplierList)
        Me.Controls.Add(Me.pbarTransactions)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Pages)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cBoxSuppliers)
        Me.Name = "frmSupplier_Invoice_Adjuste"
        Me.Text = "Supplier_Invoice_Adjuste"
        CType(Me.grdPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pages.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Page2.ResumeLayout(False)
        CType(Me.grdPaymentDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cBoxSuppliers As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents grdPayments As Windows.Forms.DataGridView
    Friend WithEvents grdInvoices As Windows.Forms.DataGridView
    Friend WithEvents lblPayments As Windows.Forms.Label
    Friend WithEvents lblInvoices As Windows.Forms.Label
    Friend WithEvents btnClearAll As Windows.Forms.Button
    Friend WithEvents btnClear As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnAdjustAll As Windows.Forms.Button
    Friend WithEvents btnAdjust As Windows.Forms.Button
    Friend WithEvents Pages As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents Page2 As Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents grdPaymentDetail As Windows.Forms.DataGridView
    Friend WithEvents pbarTransactions As Windows.Forms.ProgressBar
    Friend WithEvents pbarSupplierList As Windows.Forms.ProgressBar
    Friend WithEvents btnAdjustSupplier As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseInvoice
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
        Me.Pages = New System.Windows.Forms.TabControl()
        Me.Page1 = New System.Windows.Forms.TabPage()
        Me.grid_Requisation = New System.Windows.Forms.DataGridView()
        Me.Page2 = New System.Windows.Forms.TabPage()
        Me.grid_POrder = New System.Windows.Forms.DataGridView()
        Me.Page3 = New System.Windows.Forms.TabPage()
        Me.grid_PInvoice = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPInvoice = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Pages.SuspendLayout()
        Me.Page1.SuspendLayout()
        CType(Me.grid_Requisation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page2.SuspendLayout()
        CType(Me.grid_POrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page3.SuspendLayout()
        CType(Me.grid_PInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pages
        '
        Me.Pages.Controls.Add(Me.Page1)
        Me.Pages.Controls.Add(Me.Page2)
        Me.Pages.Controls.Add(Me.Page3)
        Me.Pages.Location = New System.Drawing.Point(12, 53)
        Me.Pages.Name = "Pages"
        Me.Pages.SelectedIndex = 0
        Me.Pages.Size = New System.Drawing.Size(776, 385)
        Me.Pages.TabIndex = 0
        '
        'Page1
        '
        Me.Page1.Controls.Add(Me.grid_Requisation)
        Me.Page1.Location = New System.Drawing.Point(4, 22)
        Me.Page1.Name = "Page1"
        Me.Page1.Padding = New System.Windows.Forms.Padding(3)
        Me.Page1.Size = New System.Drawing.Size(768, 359)
        Me.Page1.TabIndex = 0
        Me.Page1.Text = "Requisation"
        Me.Page1.UseVisualStyleBackColor = True
        '
        'grid_Requisation
        '
        Me.grid_Requisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Requisation.Location = New System.Drawing.Point(6, 6)
        Me.grid_Requisation.Name = "grid_Requisation"
        Me.grid_Requisation.Size = New System.Drawing.Size(756, 347)
        Me.grid_Requisation.TabIndex = 0
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.grid_POrder)
        Me.Page2.Location = New System.Drawing.Point(4, 22)
        Me.Page2.Name = "Page2"
        Me.Page2.Padding = New System.Windows.Forms.Padding(3)
        Me.Page2.Size = New System.Drawing.Size(768, 359)
        Me.Page2.TabIndex = 1
        Me.Page2.Text = "Purchase Order"
        Me.Page2.UseVisualStyleBackColor = True
        '
        'grid_POrder
        '
        Me.grid_POrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_POrder.Location = New System.Drawing.Point(6, 6)
        Me.grid_POrder.Name = "grid_POrder"
        Me.grid_POrder.Size = New System.Drawing.Size(756, 347)
        Me.grid_POrder.TabIndex = 0
        '
        'Page3
        '
        Me.Page3.Controls.Add(Me.grid_PInvoice)
        Me.Page3.Location = New System.Drawing.Point(4, 22)
        Me.Page3.Name = "Page3"
        Me.Page3.Size = New System.Drawing.Size(768, 359)
        Me.Page3.TabIndex = 2
        Me.Page3.Text = "Purchase Invoice"
        Me.Page3.UseVisualStyleBackColor = True
        '
        'grid_PInvoice
        '
        Me.grid_PInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_PInvoice.Location = New System.Drawing.Point(6, 6)
        Me.grid_PInvoice.Name = "grid_PInvoice"
        Me.grid_PInvoice.Size = New System.Drawing.Size(756, 347)
        Me.grid_PInvoice.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Company"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(379, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Purchase Invoices"
        '
        'txtPInvoice
        '
        Me.txtPInvoice.Location = New System.Drawing.Point(480, 12)
        Me.txtPInvoice.Name = "txtPInvoice"
        Me.txtPInvoice.Size = New System.Drawing.Size(100, 20)
        Me.txtPInvoice.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(709, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(73, 12)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(300, 21)
        Me.cBoxCompany.TabIndex = 6
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(19, 445)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 7
        Me.lblMessage.Text = "Message"
        '
        'frmPurchaseInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 470)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPInvoice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pages)
        Me.Name = "frmPurchaseInvoice"
        Me.Text = "Purchase Invoice"
        Me.Pages.ResumeLayout(False)
        Me.Page1.ResumeLayout(False)
        CType(Me.grid_Requisation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page2.ResumeLayout(False)
        CType(Me.grid_POrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page3.ResumeLayout(False)
        CType(Me.grid_PInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pages As Windows.Forms.TabControl
    Friend WithEvents Page1 As Windows.Forms.TabPage
    Friend WithEvents grid_Requisation As Windows.Forms.DataGridView
    Friend WithEvents Page2 As Windows.Forms.TabPage
    Friend WithEvents grid_POrder As Windows.Forms.DataGridView
    Friend WithEvents Page3 As Windows.Forms.TabPage
    Friend WithEvents grid_PInvoice As Windows.Forms.DataGridView
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtPInvoice As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
    Friend WithEvents lblMessage As Windows.Forms.Label
End Class

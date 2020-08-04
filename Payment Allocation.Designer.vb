<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment_Allocation
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
        Me.P1 = New System.Windows.Forms.TabPage()
        Me.Grid_Payments = New System.Windows.Forms.DataGridView()
        Me.P2 = New System.Windows.Forms.TabPage()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Grid_Allocation = New System.Windows.Forms.DataGridView()
        Me.cBoxSupplier = New System.Windows.Forms.ComboBox()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Pages.SuspendLayout()
        Me.P1.SuspendLayout()
        CType(Me.Grid_Payments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P2.SuspendLayout()
        CType(Me.Grid_Allocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pages
        '
        Me.Pages.Controls.Add(Me.P1)
        Me.Pages.Controls.Add(Me.P2)
        Me.Pages.Location = New System.Drawing.Point(12, 39)
        Me.Pages.Name = "Pages"
        Me.Pages.SelectedIndex = 0
        Me.Pages.Size = New System.Drawing.Size(776, 372)
        Me.Pages.TabIndex = 3
        '
        'P1
        '
        Me.P1.Controls.Add(Me.Grid_Payments)
        Me.P1.Location = New System.Drawing.Point(4, 22)
        Me.P1.Name = "P1"
        Me.P1.Padding = New System.Windows.Forms.Padding(3)
        Me.P1.Size = New System.Drawing.Size(768, 346)
        Me.P1.TabIndex = 0
        Me.P1.Text = "Payments"
        Me.P1.UseVisualStyleBackColor = True
        '
        'Grid_Payments
        '
        Me.Grid_Payments.AllowUserToAddRows = False
        Me.Grid_Payments.AllowUserToDeleteRows = False
        Me.Grid_Payments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Payments.Location = New System.Drawing.Point(6, 6)
        Me.Grid_Payments.Name = "Grid_Payments"
        Me.Grid_Payments.Size = New System.Drawing.Size(756, 334)
        Me.Grid_Payments.TabIndex = 0
        '
        'P2
        '
        Me.P2.Controls.Add(Me.btnUpdate)
        Me.P2.Controls.Add(Me.btnNew)
        Me.P2.Controls.Add(Me.Grid_Allocation)
        Me.P2.Location = New System.Drawing.Point(4, 22)
        Me.P2.Name = "P2"
        Me.P2.Padding = New System.Windows.Forms.Padding(3)
        Me.P2.Size = New System.Drawing.Size(768, 346)
        Me.P2.TabIndex = 1
        Me.P2.Text = "Allocations"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(392, 320)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(370, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "U P D A T E"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(6, 320)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(370, 23)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "N E W     A L L O C A T I O N  (ADD)"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'Grid_Allocation
        '
        Me.Grid_Allocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Allocation.Location = New System.Drawing.Point(6, 6)
        Me.Grid_Allocation.Name = "Grid_Allocation"
        Me.Grid_Allocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_Allocation.Size = New System.Drawing.Size(756, 312)
        Me.Grid_Allocation.TabIndex = 0
        '
        'cBoxSupplier
        '
        Me.cBoxSupplier.FormattingEnabled = True
        Me.cBoxSupplier.Location = New System.Drawing.Point(240, 12)
        Me.cBoxSupplier.Name = "cBoxSupplier"
        Me.cBoxSupplier.Size = New System.Drawing.Size(548, 21)
        Me.cBoxSupplier.TabIndex = 2
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(16, 12)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(218, 21)
        Me.cBoxCompany.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(709, 417)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E X I T"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(13, 422)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Message"
        '
        'frmPayment_Allocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.cBoxSupplier)
        Me.Controls.Add(Me.Pages)
        Me.Name = "frmPayment_Allocation"
        Me.Text = "Payment_Allocation"
        Me.Pages.ResumeLayout(False)
        Me.P1.ResumeLayout(False)
        CType(Me.Grid_Payments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P2.ResumeLayout(False)
        CType(Me.Grid_Allocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pages As Windows.Forms.TabControl
    Friend WithEvents P1 As Windows.Forms.TabPage
    Friend WithEvents P2 As Windows.Forms.TabPage
    Friend WithEvents cBoxSupplier As Windows.Forms.ComboBox
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents Grid_Payments As Windows.Forms.DataGridView
    Friend WithEvents Grid_Allocation As Windows.Forms.DataGridView
    Friend WithEvents btnNew As Windows.Forms.Button
    Friend WithEvents btnUpdate As Windows.Forms.Button
End Class

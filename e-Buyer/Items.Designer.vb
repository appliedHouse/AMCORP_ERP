<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItems
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
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.cboxCompany = New System.Windows.Forms.ComboBox()
        Me.grdItems = New System.Windows.Forms.DataGridView()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.lblTotalRows = New System.Windows.Forms.Label()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(13, 16)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(51, 13)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = "Company"
        '
        'cboxCompany
        '
        Me.cboxCompany.FormattingEnabled = True
        Me.cboxCompany.Location = New System.Drawing.Point(70, 13)
        Me.cboxCompany.Name = "cboxCompany"
        Me.cboxCompany.Size = New System.Drawing.Size(271, 21)
        Me.cboxCompany.TabIndex = 1
        '
        'grdItems
        '
        Me.grdItems.AllowUserToAddRows = False
        Me.grdItems.AllowUserToDeleteRows = False
        Me.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItems.Location = New System.Drawing.Point(16, 47)
        Me.grdItems.Name = "grdItems"
        Me.grdItems.Size = New System.Drawing.Size(772, 378)
        Me.grdItems.TabIndex = 2
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(382, 13)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(296, 20)
        Me.txtFilter.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Filter"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(13, 430)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = "Message"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(685, 16)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(80, 17)
        Me.chkActive.TabIndex = 6
        Me.chkActive.Text = "Active Only"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'lblTotalRows
        '
        Me.lblTotalRows.AutoSize = True
        Me.lblTotalRows.Location = New System.Drawing.Point(714, 430)
        Me.lblTotalRows.Name = "lblTotalRows"
        Me.lblTotalRows.Size = New System.Drawing.Size(74, 13)
        Me.lblTotalRows.TabIndex = 7
        Me.lblTotalRows.Text = "Total Records"
        Me.lblTotalRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblTotalRows)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.grdItems)
        Me.Controls.Add(Me.cboxCompany)
        Me.Controls.Add(Me.lblCompany)
        Me.Name = "frmItems"
        Me.Text = "Items"
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCompany As Windows.Forms.Label
    Friend WithEvents cboxCompany As Windows.Forms.ComboBox
    Friend WithEvents grdItems As Windows.Forms.DataGridView
    Friend WithEvents txtFilter As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents chkActive As Windows.Forms.CheckBox
    Friend WithEvents lblTotalRows As Windows.Forms.Label
End Class

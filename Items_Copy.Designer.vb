<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemJV
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
        Me.lstItemJV = New System.Windows.Forms.ListBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.cboxCompany = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstMappedCOA = New System.Windows.Forms.ListBox()
        Me.lstCOA = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCOA_Filter = New System.Windows.Forms.Label()
        Me.lsfFlags = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstItemJV
        '
        Me.lstItemJV.FormattingEnabled = True
        Me.lstItemJV.Location = New System.Drawing.Point(12, 65)
        Me.lstItemJV.Name = "lstItemJV"
        Me.lstItemJV.Size = New System.Drawing.Size(433, 381)
        Me.lstItemJV.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(47, 39)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(398, 20)
        Me.txtFilter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filter"
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Location = New System.Drawing.Point(9, 452)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(39, 13)
        Me.lblFilter.TabIndex = 3
        Me.lblFilter.Text = "Label2"
        '
        'cboxCompany
        '
        Me.cboxCompany.FormattingEnabled = True
        Me.cboxCompany.Location = New System.Drawing.Point(69, 12)
        Me.cboxCompany.Name = "cboxCompany"
        Me.cboxCompany.Size = New System.Drawing.Size(376, 21)
        Me.cboxCompany.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Company"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(452, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Item Flag"
        '
        'lstMappedCOA
        '
        Me.lstMappedCOA.FormattingEnabled = True
        Me.lstMappedCOA.Location = New System.Drawing.Point(451, 165)
        Me.lstMappedCOA.Name = "lstMappedCOA"
        Me.lstMappedCOA.Size = New System.Drawing.Size(336, 121)
        Me.lstMappedCOA.TabIndex = 8
        '
        'lstCOA
        '
        Me.lstCOA.FormattingEnabled = True
        Me.lstCOA.Location = New System.Drawing.Point(451, 325)
        Me.lstCOA.Name = "lstCOA"
        Me.lstCOA.Size = New System.Drawing.Size(336, 121)
        Me.lstCOA.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(451, 306)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Chart of Accounts"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(452, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Mapped Accounts"
        '
        'lblCOA_Filter
        '
        Me.lblCOA_Filter.AutoSize = True
        Me.lblCOA_Filter.Location = New System.Drawing.Point(451, 452)
        Me.lblCOA_Filter.Name = "lblCOA_Filter"
        Me.lblCOA_Filter.Size = New System.Drawing.Size(39, 13)
        Me.lblCOA_Filter.TabIndex = 12
        Me.lblCOA_Filter.Text = "Label6"
        '
        'lsfFlags
        '
        Me.lsfFlags.FormattingEnabled = True
        Me.lsfFlags.Location = New System.Drawing.Point(454, 39)
        Me.lsfFlags.Name = "lsfFlags"
        Me.lsfFlags.Size = New System.Drawing.Size(333, 108)
        Me.lsfFlags.TabIndex = 13
        '
        'frmItemJV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 474)
        Me.Controls.Add(Me.lsfFlags)
        Me.Controls.Add(Me.lblCOA_Filter)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstCOA)
        Me.Controls.Add(Me.lstMappedCOA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboxCompany)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lstItemJV)
        Me.Name = "frmItemJV"
        Me.Text = "Items_Copy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstItemJV As Windows.Forms.ListBox
    Friend WithEvents txtFilter As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblFilter As Windows.Forms.Label
    Friend WithEvents cboxCompany As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lstMappedCOA As Windows.Forms.ListBox
    Friend WithEvents lstCOA As Windows.Forms.ListBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lblCOA_Filter As Windows.Forms.Label
    Friend WithEvents lsfFlags As Windows.Forms.ListBox
End Class

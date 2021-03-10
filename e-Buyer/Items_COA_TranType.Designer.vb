<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItems_COA_TranType
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
        Me.lblItem = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCOA = New System.Windows.Forms.TextBox()
        Me.txtTranType = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company"
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Location = New System.Drawing.Point(12, 94)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(27, 13)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "‪Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "COA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tran Type"
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(74, 91)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(364, 20)
        Me.txtItem.TabIndex = 5
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(74, 34)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(364, 21)
        Me.cBoxCompany.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 179)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCOA
        '
        Me.txtCOA.Location = New System.Drawing.Point(74, 117)
        Me.txtCOA.Name = "txtCOA"
        Me.txtCOA.Size = New System.Drawing.Size(364, 20)
        Me.txtCOA.TabIndex = 8
        '
        'txtTranType
        '
        Me.txtTranType.Location = New System.Drawing.Point(74, 143)
        Me.txtTranType.Name = "txtTranType"
        Me.txtTranType.Size = New System.Drawing.Size(364, 20)
        Me.txtTranType.TabIndex = 9
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(12, 232)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 10
        Me.lblMessage.Text = "Message"
        '
        'frmItems_COA_TranType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 254)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtTranType)
        Me.Controls.Add(Me.txtCOA)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmItems_COA_TranType"
        Me.Text = "Items_COA_TranType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblItem As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtItem As Windows.Forms.TextBox
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents txtCOA As Windows.Forms.TextBox
    Friend WithEvents txtTranType As Windows.Forms.TextBox
    Friend WithEvents lblMessage As Windows.Forms.Label
End Class

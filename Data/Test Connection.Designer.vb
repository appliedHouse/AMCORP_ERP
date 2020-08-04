<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest_Connection
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
        Me.btnConnection_Master = New System.Windows.Forms.Button()
        Me.btnConnection_Bizztrax = New System.Windows.Forms.Button()
        Me.btnConnection_BizztraxAmcorp = New System.Windows.Forms.Button()
        Me.lblMaster = New System.Windows.Forms.Label()
        Me.lblBizztrax = New System.Windows.Forms.Label()
        Me.lblAmcorp = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConnection_Master
        '
        Me.btnConnection_Master.Location = New System.Drawing.Point(12, 20)
        Me.btnConnection_Master.Name = "btnConnection_Master"
        Me.btnConnection_Master.Size = New System.Drawing.Size(134, 23)
        Me.btnConnection_Master.TabIndex = 0
        Me.btnConnection_Master.Text = "Master"
        Me.btnConnection_Master.UseVisualStyleBackColor = True
        '
        'btnConnection_Bizztrax
        '
        Me.btnConnection_Bizztrax.Location = New System.Drawing.Point(12, 49)
        Me.btnConnection_Bizztrax.Name = "btnConnection_Bizztrax"
        Me.btnConnection_Bizztrax.Size = New System.Drawing.Size(134, 23)
        Me.btnConnection_Bizztrax.TabIndex = 1
        Me.btnConnection_Bizztrax.Text = "Bizztrax"
        Me.btnConnection_Bizztrax.UseVisualStyleBackColor = True
        '
        'btnConnection_BizztraxAmcorp
        '
        Me.btnConnection_BizztraxAmcorp.Location = New System.Drawing.Point(12, 78)
        Me.btnConnection_BizztraxAmcorp.Name = "btnConnection_BizztraxAmcorp"
        Me.btnConnection_BizztraxAmcorp.Size = New System.Drawing.Size(134, 23)
        Me.btnConnection_BizztraxAmcorp.TabIndex = 2
        Me.btnConnection_BizztraxAmcorp.Text = "Bizztrax_Amcorp"
        Me.btnConnection_BizztraxAmcorp.UseVisualStyleBackColor = True
        '
        'lblMaster
        '
        Me.lblMaster.AutoSize = True
        Me.lblMaster.Location = New System.Drawing.Point(153, 25)
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.Size = New System.Drawing.Size(39, 13)
        Me.lblMaster.TabIndex = 3
        Me.lblMaster.Text = "Master"
        '
        'lblBizztrax
        '
        Me.lblBizztrax.AutoSize = True
        Me.lblBizztrax.Location = New System.Drawing.Point(153, 54)
        Me.lblBizztrax.Name = "lblBizztrax"
        Me.lblBizztrax.Size = New System.Drawing.Size(43, 13)
        Me.lblBizztrax.TabIndex = 4
        Me.lblBizztrax.Text = "Bizztrax"
        '
        'lblAmcorp
        '
        Me.lblAmcorp.AutoSize = True
        Me.lblAmcorp.Location = New System.Drawing.Point(153, 83)
        Me.lblAmcorp.Name = "lblAmcorp"
        Me.lblAmcorp.Size = New System.Drawing.Size(85, 13)
        Me.lblAmcorp.TabIndex = 5
        Me.lblAmcorp.Text = "Bizztrax_Amcorp"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(221, 107)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(54, 23)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmTest_Connection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 142)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblAmcorp)
        Me.Controls.Add(Me.lblBizztrax)
        Me.Controls.Add(Me.lblMaster)
        Me.Controls.Add(Me.btnConnection_BizztraxAmcorp)
        Me.Controls.Add(Me.btnConnection_Bizztrax)
        Me.Controls.Add(Me.btnConnection_Master)
        Me.Name = "frmTest_Connection"
        Me.Text = "Test_Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConnection_Master As Windows.Forms.Button
    Friend WithEvents btnConnection_Bizztrax As Windows.Forms.Button
    Friend WithEvents btnConnection_BizztraxAmcorp As Windows.Forms.Button
    Friend WithEvents lblMaster As Windows.Forms.Label
    Friend WithEvents lblBizztrax As Windows.Forms.Label
    Friend WithEvents lblAmcorp As Windows.Forms.Label
    Friend WithEvents btnExit As Windows.Forms.Button
End Class

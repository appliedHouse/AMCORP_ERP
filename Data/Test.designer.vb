<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.txtProject = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cBoxList = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtCOA = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Title"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Project"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Remarks"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(74, 64)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 12
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(74, 90)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 13
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(74, 116)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(292, 20)
        Me.txtTitle.TabIndex = 15
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(74, 142)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplier.TabIndex = 16
        '
        'txtProject
        '
        Me.txtProject.Location = New System.Drawing.Point(74, 168)
        Me.txtProject.Name = "txtProject"
        Me.txtProject.Size = New System.Drawing.Size(100, 20)
        Me.txtProject.TabIndex = 17
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(74, 194)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(292, 89)
        Me.txtRemarks.TabIndex = 18
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(74, 289)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 23)
        Me.btnNew.TabIndex = 31
        Me.btnNew.Text = "NEW"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(151, 289)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(228, 289)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.TabIndex = 33
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(305, 289)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(60, 23)
        Me.btnExit.TabIndex = 34
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cBoxList
        '
        Me.cBoxList.FormattingEnabled = True
        Me.cBoxList.Location = New System.Drawing.Point(74, 13)
        Me.cBoxList.Name = "cBoxList"
        Me.cBoxList.Size = New System.Drawing.Size(292, 21)
        Me.cBoxList.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "List"
        '
        'dtDOB
        '
        Me.dtDOB.CustomFormat = "dd-MMM-yyyy"
        Me.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDOB.Location = New System.Drawing.Point(193, 64)
        Me.dtDOB.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.Size = New System.Drawing.Size(95, 20)
        Me.dtDOB.TabIndex = 14
        Me.dtDOB.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'txtCOA
        '
        Me.txtCOA.Location = New System.Drawing.Point(193, 90)
        Me.txtCOA.Name = "txtCOA"
        Me.txtCOA.Size = New System.Drawing.Size(100, 20)
        Me.txtCOA.TabIndex = 35
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 324)
        Me.Controls.Add(Me.txtCOA)
        Me.Controls.Add(Me.dtDOB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cBoxList)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtProject)
        Me.Controls.Add(Me.txtSupplier)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTest"
        Me.Text = "Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtID As Windows.Forms.TextBox
    Friend WithEvents txtCode As Windows.Forms.TextBox
    Friend WithEvents txtTitle As Windows.Forms.TextBox
    Friend WithEvents txtSupplier As Windows.Forms.TextBox
    Friend WithEvents txtProject As Windows.Forms.TextBox
    Friend WithEvents txtRemarks As Windows.Forms.TextBox
    Friend WithEvents btnNew As Windows.Forms.Button
    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents btnDelete As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents cBoxList As Windows.Forms.ComboBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents dtDOB As Windows.Forms.DateTimePicker
    Friend WithEvents txtCOA As Windows.Forms.TextBox
End Class

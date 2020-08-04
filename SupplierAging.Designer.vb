Imports System.Runtime.InteropServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSupplierAging
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                xlWorkBook.Save()
                xlWorkBook.Close()
                xlApp.Quit()

                Marshal.ReleaseComObject(xlWorkBook)
                Marshal.ReleaseComObject(xlWorkSheet)
                Marshal.ReleaseComObject(xlApp)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
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
        Me.txtAge1 = New System.Windows.Forms.TextBox()
        Me.txtAge2 = New System.Windows.Forms.TextBox()
        Me.txtAge3 = New System.Windows.Forms.TextBox()
        Me.txtAge4 = New System.Windows.Forms.TextBox()
        Me.txtAge5 = New System.Windows.Forms.TextBox()
        Me.txtAge6 = New System.Windows.Forms.TextBox()
        Me.txtAge7 = New System.Windows.Forms.TextBox()
        Me.txtAge8 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnFileSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAge1
        '
        Me.txtAge1.Location = New System.Drawing.Point(8, 19)
        Me.txtAge1.Name = "txtAge1"
        Me.txtAge1.Size = New System.Drawing.Size(75, 20)
        Me.txtAge1.TabIndex = 1
        '
        'txtAge2
        '
        Me.txtAge2.Location = New System.Drawing.Point(89, 19)
        Me.txtAge2.Name = "txtAge2"
        Me.txtAge2.Size = New System.Drawing.Size(75, 20)
        Me.txtAge2.TabIndex = 2
        '
        'txtAge3
        '
        Me.txtAge3.Location = New System.Drawing.Point(170, 19)
        Me.txtAge3.Name = "txtAge3"
        Me.txtAge3.Size = New System.Drawing.Size(75, 20)
        Me.txtAge3.TabIndex = 3
        '
        'txtAge4
        '
        Me.txtAge4.Location = New System.Drawing.Point(251, 19)
        Me.txtAge4.Name = "txtAge4"
        Me.txtAge4.Size = New System.Drawing.Size(75, 20)
        Me.txtAge4.TabIndex = 4
        '
        'txtAge5
        '
        Me.txtAge5.Location = New System.Drawing.Point(332, 19)
        Me.txtAge5.Name = "txtAge5"
        Me.txtAge5.Size = New System.Drawing.Size(75, 20)
        Me.txtAge5.TabIndex = 5
        '
        'txtAge6
        '
        Me.txtAge6.Location = New System.Drawing.Point(413, 19)
        Me.txtAge6.Name = "txtAge6"
        Me.txtAge6.Size = New System.Drawing.Size(75, 20)
        Me.txtAge6.TabIndex = 6
        '
        'txtAge7
        '
        Me.txtAge7.Location = New System.Drawing.Point(494, 19)
        Me.txtAge7.Name = "txtAge7"
        Me.txtAge7.Size = New System.Drawing.Size(75, 20)
        Me.txtAge7.TabIndex = 7
        '
        'txtAge8
        '
        Me.txtAge8.Location = New System.Drawing.Point(575, 19)
        Me.txtAge8.Name = "txtAge8"
        Me.txtAge8.Size = New System.Drawing.Size(75, 20)
        Me.txtAge8.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAge8)
        Me.GroupBox1.Controls.Add(Me.txtAge1)
        Me.GroupBox1.Controls.Add(Me.txtAge7)
        Me.GroupBox1.Controls.Add(Me.txtAge2)
        Me.GroupBox1.Controls.Add(Me.txtAge6)
        Me.GroupBox1.Controls.Add(Me.txtAge3)
        Me.GroupBox1.Controls.Add(Me.txtAge5)
        Me.GroupBox1.Controls.Add(Me.txtAge4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 51)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aging Scale"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(587, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Preview"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Location = New System.Drawing.Point(101, 78)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(449, 20)
        Me.txtFileLocation.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "File Location"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(587, 117)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnFileSearch
        '
        Me.btnFileSearch.Location = New System.Drawing.Point(557, 78)
        Me.btnFileSearch.Name = "btnFileSearch"
        Me.btnFileSearch.Size = New System.Drawing.Size(24, 23)
        Me.btnFileSearch.TabIndex = 14
        Me.btnFileSearch.Text = "..."
        Me.btnFileSearch.UseVisualStyleBackColor = True
        '
        'frmSupplierAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 152)
        Me.Controls.Add(Me.btnFileSearch)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFileLocation)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSupplierAging"
        Me.Text = "SupplierAging"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAge1 As Windows.Forms.TextBox
    Friend WithEvents txtAge2 As Windows.Forms.TextBox
    Friend WithEvents txtAge3 As Windows.Forms.TextBox
    Friend WithEvents txtAge4 As Windows.Forms.TextBox
    Friend WithEvents txtAge5 As Windows.Forms.TextBox
    Friend WithEvents txtAge6 As Windows.Forms.TextBox
    Friend WithEvents txtAge7 As Windows.Forms.TextBox
    Friend WithEvents txtAge8 As Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents txtFileLocation As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnFileSearch As Windows.Forms.Button
End Class

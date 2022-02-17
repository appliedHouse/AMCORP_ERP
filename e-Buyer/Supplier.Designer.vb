<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplier
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.txtNTN = New System.Windows.Forms.TextBox()
        Me.txtCNIC = New System.Windows.Forms.TextBox()
        Me.txtSTN = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtBusinessName = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.chkExamted = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtExamptionFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtExamptionTo = New System.Windows.Forms.DateTimePicker()
        Me.cboxSupplier = New System.Windows.Forms.ComboBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.cboxCity = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cBoxStatus = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cBoxCompany = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ref No."
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "NTN No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "CNIC"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "STN"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(271, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Business Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(271, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Title / Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "City"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 268)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Remarks"
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(92, 49)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(167, 20)
        Me.txtID.TabIndex = 10
        '
        'txtRef
        '
        Me.txtRef.Enabled = False
        Me.txtRef.Location = New System.Drawing.Point(92, 72)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(167, 20)
        Me.txtRef.TabIndex = 11
        '
        'txtNTN
        '
        Me.txtNTN.Location = New System.Drawing.Point(92, 105)
        Me.txtNTN.Name = "txtNTN"
        Me.txtNTN.Size = New System.Drawing.Size(167, 20)
        Me.txtNTN.TabIndex = 12
        '
        'txtCNIC
        '
        Me.txtCNIC.Location = New System.Drawing.Point(92, 131)
        Me.txtCNIC.Name = "txtCNIC"
        Me.txtCNIC.Size = New System.Drawing.Size(167, 20)
        Me.txtCNIC.TabIndex = 13
        '
        'txtSTN
        '
        Me.txtSTN.Location = New System.Drawing.Point(92, 157)
        Me.txtSTN.Name = "txtSTN"
        Me.txtSTN.Size = New System.Drawing.Size(167, 20)
        Me.txtSTN.TabIndex = 14
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.Location = New System.Drawing.Point(92, 231)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(696, 20)
        Me.txtAddress.TabIndex = 21
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(92, 257)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(618, 166)
        Me.txtDescription.TabIndex = 22
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(361, 49)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(427, 20)
        Me.txtTitle.TabIndex = 16
        '
        'txtBusinessName
        '
        Me.txtBusinessName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusinessName.Location = New System.Drawing.Point(361, 75)
        Me.txtBusinessName.Name = "txtBusinessName"
        Me.txtBusinessName.Size = New System.Drawing.Size(427, 20)
        Me.txtBusinessName.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(716, 313)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(716, 342)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(716, 371)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 27
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(716, 400)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 99
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(13, 429)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(50, 13)
        Me.lblMessage.TabIndex = 24
        Me.lblMessage.Text = "Message"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(739, 9)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(48, 23)
        Me.btnNext.TabIndex = 23
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(685, 9)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(48, 23)
        Me.btnBack.TabIndex = 24
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'chkExamted
        '
        Me.chkExamted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExamted.AutoSize = True
        Me.chkExamted.Location = New System.Drawing.Point(361, 108)
        Me.chkExamted.Name = "chkExamted"
        Me.chkExamted.Size = New System.Drawing.Size(94, 17)
        Me.chkExamted.TabIndex = 18
        Me.chkExamted.Text = "Tax Exampted"
        Me.chkExamted.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(461, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "From"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(632, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "To"
        '
        'dtExamptionFrom
        '
        Me.dtExamptionFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtExamptionFrom.Checked = False
        Me.dtExamptionFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtExamptionFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtExamptionFrom.Location = New System.Drawing.Point(497, 105)
        Me.dtExamptionFrom.Name = "dtExamptionFrom"
        Me.dtExamptionFrom.Size = New System.Drawing.Size(129, 20)
        Me.dtExamptionFrom.TabIndex = 19
        '
        'dtExamptionTo
        '
        Me.dtExamptionTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtExamptionTo.Checked = False
        Me.dtExamptionTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtExamptionTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtExamptionTo.Location = New System.Drawing.Point(658, 105)
        Me.dtExamptionTo.Name = "dtExamptionTo"
        Me.dtExamptionTo.Size = New System.Drawing.Size(129, 20)
        Me.dtExamptionTo.TabIndex = 20
        '
        'cboxSupplier
        '
        Me.cboxSupplier.FormattingEnabled = True
        Me.cboxSupplier.Location = New System.Drawing.Point(361, 9)
        Me.cboxSupplier.Name = "cboxSupplier"
        Me.cboxSupplier.Size = New System.Drawing.Size(318, 21)
        Me.cboxSupplier.Sorted = True
        Me.cboxSupplier.TabIndex = 1
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(274, 14)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
        Me.lblSupplier.TabIndex = 33
        Me.lblSupplier.Text = "Supplier"
        '
        'cboxCity
        '
        Me.cboxCity.FormattingEnabled = True
        Me.cboxCity.Location = New System.Drawing.Point(92, 186)
        Me.cboxCity.Name = "cboxCity"
        Me.cboxCity.Size = New System.Drawing.Size(167, 21)
        Me.cboxCity.TabIndex = 100
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(274, 134)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Contact Person"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Location = New System.Drawing.Point(361, 131)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(265, 20)
        Me.txtContactPerson.TabIndex = 102
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(274, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(361, 185)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(265, 20)
        Me.txtEmail.TabIndex = 104
        '
        'txtContactNumber
        '
        Me.txtContactNumber.Location = New System.Drawing.Point(361, 157)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Size = New System.Drawing.Size(265, 20)
        Me.txtContactNumber.TabIndex = 106
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(274, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "Contact Number"
        '
        'cBoxStatus
        '
        Me.cBoxStatus.FormattingEnabled = True
        Me.cBoxStatus.Items.AddRange(New Object() {"Select.....", "INDIVIDUAL", "AOP", "COMPANY"})
        Me.cBoxStatus.Location = New System.Drawing.Point(645, 185)
        Me.cBoxStatus.Name = "cBoxStatus"
        Me.cBoxStatus.Size = New System.Drawing.Size(142, 21)
        Me.cBoxStatus.TabIndex = 107
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Company"
        '
        'cBoxCompany
        '
        Me.cBoxCompany.FormattingEnabled = True
        Me.cBoxCompany.Location = New System.Drawing.Point(92, 12)
        Me.cBoxCompany.Name = "cBoxCompany"
        Me.cBoxCompany.Size = New System.Drawing.Size(167, 21)
        Me.cBoxCompany.TabIndex = 109
        '
        'frmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 449)
        Me.Controls.Add(Me.cBoxCompany)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cBoxStatus)
        Me.Controls.Add(Me.txtContactNumber)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtContactPerson)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboxCity)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.cboxSupplier)
        Me.Controls.Add(Me.dtExamptionTo)
        Me.Controls.Add(Me.dtExamptionFrom)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkExamted)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtBusinessName)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtSTN)
        Me.Controls.Add(Me.txtCNIC)
        Me.Controls.Add(Me.txtNTN)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSupplier"
        Me.Text = "Supplier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txtID As Windows.Forms.TextBox
    Friend WithEvents txtRef As Windows.Forms.TextBox
    Friend WithEvents txtNTN As Windows.Forms.TextBox
    Friend WithEvents txtCNIC As Windows.Forms.TextBox
    Friend WithEvents txtSTN As Windows.Forms.TextBox
    Friend WithEvents txtAddress As Windows.Forms.TextBox
    Friend WithEvents txtDescription As Windows.Forms.TextBox
    Friend WithEvents txtTitle As Windows.Forms.TextBox
    Friend WithEvents txtBusinessName As Windows.Forms.TextBox
    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents btnDelete As Windows.Forms.Button
    Friend WithEvents btnNew As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents lblMessage As Windows.Forms.Label
    Friend WithEvents btnNext As Windows.Forms.Button
    Friend WithEvents btnBack As Windows.Forms.Button
    Friend WithEvents chkExamted As Windows.Forms.CheckBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents dtExamptionFrom As Windows.Forms.DateTimePicker
    Friend WithEvents dtExamptionTo As Windows.Forms.DateTimePicker
    Friend WithEvents cboxSupplier As Windows.Forms.ComboBox
    Friend WithEvents lblSupplier As Windows.Forms.Label
    Friend WithEvents cboxCity As Windows.Forms.ComboBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents txtContactPerson As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents txtEmail As Windows.Forms.TextBox
    Friend WithEvents txtContactNumber As Windows.Forms.TextBox
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents cBoxStatus As Windows.Forms.ComboBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents cBoxCompany As Windows.Forms.ComboBox
End Class

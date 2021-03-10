<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMigration_COA
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
        Me.gridCOACat = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabCATCat = New System.Windows.Forms.TabPage()
        Me.btnData_COA_CAT = New System.Windows.Forms.Button()
        Me.btnMigrationCOACat = New System.Windows.Forms.Button()
        Me.TabCOA = New System.Windows.Forms.TabPage()
        Me.btnData_COA = New System.Windows.Forms.Button()
        Me.btnMigrationCOA = New System.Windows.Forms.Button()
        Me.gridCOA = New System.Windows.Forms.DataGridView()
        Me.TabItemCat = New System.Windows.Forms.TabPage()
        Me.btnData_Item_CAT = New System.Windows.Forms.Button()
        Me.btnMigrationItemCat = New System.Windows.Forms.Button()
        Me.gridItemCoat = New System.Windows.Forms.DataGridView()
        Me.TabItems = New System.Windows.Forms.TabPage()
        Me.btnData_Items = New System.Windows.Forms.Button()
        Me.btnMigrationItems = New System.Windows.Forms.Button()
        Me.gridItems = New System.Windows.Forms.DataGridView()
        Me.TabSupplier = New System.Windows.Forms.TabPage()
        Me.btnLoadSupplier = New System.Windows.Forms.Button()
        Me.btnMigrationSupplier = New System.Windows.Forms.Button()
        Me.gridSupplier = New System.Windows.Forms.DataGridView()
        Me.TabCity = New System.Windows.Forms.TabPage()
        Me.btnLoadCity = New System.Windows.Forms.Button()
        Me.btnMigrateCity = New System.Windows.Forms.Button()
        Me.gridCity = New System.Windows.Forms.DataGridView()
        Me.TabUOM = New System.Windows.Forms.TabPage()
        Me.btnLoadUOM = New System.Windows.Forms.Button()
        Me.btnMigrationUOM = New System.Windows.Forms.Button()
        Me.gridUOM = New System.Windows.Forms.DataGridView()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.RecordsProcess = New System.Windows.Forms.ProgressBar()
        CType(Me.gridCOACat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabCATCat.SuspendLayout()
        Me.TabCOA.SuspendLayout()
        CType(Me.gridCOA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabItemCat.SuspendLayout()
        CType(Me.gridItemCoat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabItems.SuspendLayout()
        CType(Me.gridItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSupplier.SuspendLayout()
        CType(Me.gridSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCity.SuspendLayout()
        CType(Me.gridCity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabUOM.SuspendLayout()
        CType(Me.gridUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridCOACat
        '
        Me.gridCOACat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridCOACat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCOACat.Location = New System.Drawing.Point(7, 7)
        Me.gridCOACat.Name = "gridCOACat"
        Me.gridCOACat.Size = New System.Drawing.Size(717, 333)
        Me.gridCOACat.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabCATCat)
        Me.TabControl1.Controls.Add(Me.TabCOA)
        Me.TabControl1.Controls.Add(Me.TabItemCat)
        Me.TabControl1.Controls.Add(Me.TabItems)
        Me.TabControl1.Controls.Add(Me.TabSupplier)
        Me.TabControl1.Controls.Add(Me.TabCity)
        Me.TabControl1.Controls.Add(Me.TabUOM)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(737, 400)
        Me.TabControl1.TabIndex = 1
        '
        'TabCATCat
        '
        Me.TabCATCat.Controls.Add(Me.btnData_COA_CAT)
        Me.TabCATCat.Controls.Add(Me.btnMigrationCOACat)
        Me.TabCATCat.Controls.Add(Me.gridCOACat)
        Me.TabCATCat.Location = New System.Drawing.Point(4, 22)
        Me.TabCATCat.Name = "TabCATCat"
        Me.TabCATCat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCATCat.Size = New System.Drawing.Size(729, 374)
        Me.TabCATCat.TabIndex = 0
        Me.TabCATCat.Text = "COA Category"
        Me.TabCATCat.UseVisualStyleBackColor = True
        '
        'btnData_COA_CAT
        '
        Me.btnData_COA_CAT.Location = New System.Drawing.Point(480, 345)
        Me.btnData_COA_CAT.Name = "btnData_COA_CAT"
        Me.btnData_COA_CAT.Size = New System.Drawing.Size(113, 23)
        Me.btnData_COA_CAT.TabIndex = 2
        Me.btnData_COA_CAT.Text = "Load Data"
        Me.btnData_COA_CAT.UseVisualStyleBackColor = True
        '
        'btnMigrationCOACat
        '
        Me.btnMigrationCOACat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMigrationCOACat.Location = New System.Drawing.Point(599, 345)
        Me.btnMigrationCOACat.Name = "btnMigrationCOACat"
        Me.btnMigrationCOACat.Size = New System.Drawing.Size(122, 23)
        Me.btnMigrationCOACat.TabIndex = 1
        Me.btnMigrationCOACat.Text = "Migrate Records"
        Me.btnMigrationCOACat.UseVisualStyleBackColor = True
        '
        'TabCOA
        '
        Me.TabCOA.Controls.Add(Me.btnData_COA)
        Me.TabCOA.Controls.Add(Me.btnMigrationCOA)
        Me.TabCOA.Controls.Add(Me.gridCOA)
        Me.TabCOA.Location = New System.Drawing.Point(4, 22)
        Me.TabCOA.Name = "TabCOA"
        Me.TabCOA.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCOA.Size = New System.Drawing.Size(729, 374)
        Me.TabCOA.TabIndex = 1
        Me.TabCOA.Text = "COA"
        Me.TabCOA.UseVisualStyleBackColor = True
        '
        'btnData_COA
        '
        Me.btnData_COA.Location = New System.Drawing.Point(496, 345)
        Me.btnData_COA.Name = "btnData_COA"
        Me.btnData_COA.Size = New System.Drawing.Size(103, 23)
        Me.btnData_COA.TabIndex = 3
        Me.btnData_COA.Text = "Load Data"
        Me.btnData_COA.UseVisualStyleBackColor = True
        '
        'btnMigrationCOA
        '
        Me.btnMigrationCOA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMigrationCOA.Location = New System.Drawing.Point(605, 345)
        Me.btnMigrationCOA.Name = "btnMigrationCOA"
        Me.btnMigrationCOA.Size = New System.Drawing.Size(118, 23)
        Me.btnMigrationCOA.TabIndex = 1
        Me.btnMigrationCOA.Text = "Migrate Records"
        Me.btnMigrationCOA.UseVisualStyleBackColor = True
        '
        'gridCOA
        '
        Me.gridCOA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridCOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCOA.Location = New System.Drawing.Point(7, 7)
        Me.gridCOA.Name = "gridCOA"
        Me.gridCOA.Size = New System.Drawing.Size(716, 330)
        Me.gridCOA.TabIndex = 0
        '
        'TabItemCat
        '
        Me.TabItemCat.Controls.Add(Me.btnData_Item_CAT)
        Me.TabItemCat.Controls.Add(Me.btnMigrationItemCat)
        Me.TabItemCat.Controls.Add(Me.gridItemCoat)
        Me.TabItemCat.Location = New System.Drawing.Point(4, 22)
        Me.TabItemCat.Name = "TabItemCat"
        Me.TabItemCat.Size = New System.Drawing.Size(729, 374)
        Me.TabItemCat.TabIndex = 2
        Me.TabItemCat.Text = "Item Cat"
        Me.TabItemCat.UseVisualStyleBackColor = True
        '
        'btnData_Item_CAT
        '
        Me.btnData_Item_CAT.Location = New System.Drawing.Point(501, 344)
        Me.btnData_Item_CAT.Name = "btnData_Item_CAT"
        Me.btnData_Item_CAT.Size = New System.Drawing.Size(106, 23)
        Me.btnData_Item_CAT.TabIndex = 2
        Me.btnData_Item_CAT.Text = "Load Data"
        Me.btnData_Item_CAT.UseVisualStyleBackColor = True
        '
        'btnMigrationItemCat
        '
        Me.btnMigrationItemCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMigrationItemCat.Location = New System.Drawing.Point(613, 344)
        Me.btnMigrationItemCat.Name = "btnMigrationItemCat"
        Me.btnMigrationItemCat.Size = New System.Drawing.Size(113, 23)
        Me.btnMigrationItemCat.TabIndex = 1
        Me.btnMigrationItemCat.Text = "Migrate Records"
        Me.btnMigrationItemCat.UseVisualStyleBackColor = True
        '
        'gridItemCoat
        '
        Me.gridItemCoat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridItemCoat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridItemCoat.Location = New System.Drawing.Point(7, 7)
        Me.gridItemCoat.Name = "gridItemCoat"
        Me.gridItemCoat.Size = New System.Drawing.Size(717, 333)
        Me.gridItemCoat.TabIndex = 0
        '
        'TabItems
        '
        Me.TabItems.Controls.Add(Me.btnData_Items)
        Me.TabItems.Controls.Add(Me.btnMigrationItems)
        Me.TabItems.Controls.Add(Me.gridItems)
        Me.TabItems.Location = New System.Drawing.Point(4, 22)
        Me.TabItems.Name = "TabItems"
        Me.TabItems.Size = New System.Drawing.Size(729, 374)
        Me.TabItems.TabIndex = 4
        Me.TabItems.Text = "Items"
        Me.TabItems.UseVisualStyleBackColor = True
        '
        'btnData_Items
        '
        Me.btnData_Items.Location = New System.Drawing.Point(496, 346)
        Me.btnData_Items.Name = "btnData_Items"
        Me.btnData_Items.Size = New System.Drawing.Size(111, 23)
        Me.btnData_Items.TabIndex = 3
        Me.btnData_Items.Text = "Load Data"
        Me.btnData_Items.UseVisualStyleBackColor = True
        '
        'btnMigrationItems
        '
        Me.btnMigrationItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMigrationItems.Location = New System.Drawing.Point(613, 346)
        Me.btnMigrationItems.Name = "btnMigrationItems"
        Me.btnMigrationItems.Size = New System.Drawing.Size(113, 23)
        Me.btnMigrationItems.TabIndex = 2
        Me.btnMigrationItems.Text = "Migrate Records"
        Me.btnMigrationItems.UseVisualStyleBackColor = True
        '
        'gridItems
        '
        Me.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridItems.Location = New System.Drawing.Point(7, 7)
        Me.gridItems.Name = "gridItems"
        Me.gridItems.Size = New System.Drawing.Size(717, 333)
        Me.gridItems.TabIndex = 0
        '
        'TabSupplier
        '
        Me.TabSupplier.Controls.Add(Me.btnLoadSupplier)
        Me.TabSupplier.Controls.Add(Me.btnMigrationSupplier)
        Me.TabSupplier.Controls.Add(Me.gridSupplier)
        Me.TabSupplier.Location = New System.Drawing.Point(4, 22)
        Me.TabSupplier.Name = "TabSupplier"
        Me.TabSupplier.Size = New System.Drawing.Size(729, 374)
        Me.TabSupplier.TabIndex = 3
        Me.TabSupplier.Text = "Supplier"
        Me.TabSupplier.UseVisualStyleBackColor = True
        '
        'btnLoadSupplier
        '
        Me.btnLoadSupplier.Location = New System.Drawing.Point(485, 346)
        Me.btnLoadSupplier.Name = "btnLoadSupplier"
        Me.btnLoadSupplier.Size = New System.Drawing.Size(122, 23)
        Me.btnLoadSupplier.TabIndex = 4
        Me.btnLoadSupplier.Text = "Load Data"
        Me.btnLoadSupplier.UseVisualStyleBackColor = True
        '
        'btnMigrationSupplier
        '
        Me.btnMigrationSupplier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMigrationSupplier.Location = New System.Drawing.Point(613, 346)
        Me.btnMigrationSupplier.Name = "btnMigrationSupplier"
        Me.btnMigrationSupplier.Size = New System.Drawing.Size(113, 23)
        Me.btnMigrationSupplier.TabIndex = 3
        Me.btnMigrationSupplier.Text = "Migrate Records"
        Me.btnMigrationSupplier.UseVisualStyleBackColor = True
        '
        'gridSupplier
        '
        Me.gridSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSupplier.Location = New System.Drawing.Point(7, 7)
        Me.gridSupplier.Name = "gridSupplier"
        Me.gridSupplier.Size = New System.Drawing.Size(717, 333)
        Me.gridSupplier.TabIndex = 0
        '
        'TabCity
        '
        Me.TabCity.Controls.Add(Me.btnLoadCity)
        Me.TabCity.Controls.Add(Me.btnMigrateCity)
        Me.TabCity.Controls.Add(Me.gridCity)
        Me.TabCity.Location = New System.Drawing.Point(4, 22)
        Me.TabCity.Name = "TabCity"
        Me.TabCity.Size = New System.Drawing.Size(729, 374)
        Me.TabCity.TabIndex = 6
        Me.TabCity.Text = "City( All)"
        Me.TabCity.UseVisualStyleBackColor = True
        '
        'btnLoadCity
        '
        Me.btnLoadCity.Location = New System.Drawing.Point(462, 345)
        Me.btnLoadCity.Name = "btnLoadCity"
        Me.btnLoadCity.Size = New System.Drawing.Size(122, 23)
        Me.btnLoadCity.TabIndex = 2
        Me.btnLoadCity.Text = "Load Data"
        Me.btnLoadCity.UseVisualStyleBackColor = True
        '
        'btnMigrateCity
        '
        Me.btnMigrateCity.Location = New System.Drawing.Point(599, 345)
        Me.btnMigrateCity.Name = "btnMigrateCity"
        Me.btnMigrateCity.Size = New System.Drawing.Size(122, 23)
        Me.btnMigrateCity.TabIndex = 1
        Me.btnMigrateCity.Text = "Migrate City"
        Me.btnMigrateCity.UseVisualStyleBackColor = True
        '
        'gridCity
        '
        Me.gridCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCity.Location = New System.Drawing.Point(7, 7)
        Me.gridCity.Name = "gridCity"
        Me.gridCity.Size = New System.Drawing.Size(716, 330)
        Me.gridCity.TabIndex = 0
        '
        'TabUOM
        '
        Me.TabUOM.Controls.Add(Me.btnLoadUOM)
        Me.TabUOM.Controls.Add(Me.btnMigrationUOM)
        Me.TabUOM.Controls.Add(Me.gridUOM)
        Me.TabUOM.Location = New System.Drawing.Point(4, 22)
        Me.TabUOM.Name = "TabUOM"
        Me.TabUOM.Size = New System.Drawing.Size(729, 374)
        Me.TabUOM.TabIndex = 7
        Me.TabUOM.Text = "UOM"
        Me.TabUOM.UseVisualStyleBackColor = True
        '
        'btnLoadUOM
        '
        Me.btnLoadUOM.Location = New System.Drawing.Point(462, 343)
        Me.btnLoadUOM.Name = "btnLoadUOM"
        Me.btnLoadUOM.Size = New System.Drawing.Size(122, 23)
        Me.btnLoadUOM.TabIndex = 4
        Me.btnLoadUOM.Text = "Load Data"
        Me.btnLoadUOM.UseVisualStyleBackColor = True
        '
        'btnMigrationUOM
        '
        Me.btnMigrationUOM.Location = New System.Drawing.Point(599, 343)
        Me.btnMigrationUOM.Name = "btnMigrationUOM"
        Me.btnMigrationUOM.Size = New System.Drawing.Size(122, 23)
        Me.btnMigrationUOM.TabIndex = 3
        Me.btnMigrationUOM.Text = "Migrate City"
        Me.btnMigrationUOM.UseVisualStyleBackColor = True
        '
        'gridUOM
        '
        Me.gridUOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridUOM.Location = New System.Drawing.Point(7, 7)
        Me.gridUOM.Name = "gridUOM"
        Me.gridUOM.Size = New System.Drawing.Size(716, 330)
        Me.gridUOM.TabIndex = 0
        '
        'lblMessages
        '
        Me.lblMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessages.AutoSize = True
        Me.lblMessages.Location = New System.Drawing.Point(22, 419)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(55, 13)
        Me.lblMessages.TabIndex = 2
        Me.lblMessages.Text = "Messages"
        '
        'RecordsProcess
        '
        Me.RecordsProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RecordsProcess.Location = New System.Drawing.Point(428, 416)
        Me.RecordsProcess.Name = "RecordsProcess"
        Me.RecordsProcess.Size = New System.Drawing.Size(317, 23)
        Me.RecordsProcess.TabIndex = 3
        '
        'frmMigration_COA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 445)
        Me.Controls.Add(Me.RecordsProcess)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMigration_COA"
        Me.Text = "Migration_COA"
        CType(Me.gridCOACat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabCATCat.ResumeLayout(False)
        Me.TabCOA.ResumeLayout(False)
        CType(Me.gridCOA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabItemCat.ResumeLayout(False)
        CType(Me.gridItemCoat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabItems.ResumeLayout(False)
        CType(Me.gridItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSupplier.ResumeLayout(False)
        CType(Me.gridSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCity.ResumeLayout(False)
        CType(Me.gridCity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabUOM.ResumeLayout(False)
        CType(Me.gridUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gridCOACat As Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabCATCat As Windows.Forms.TabPage
    Friend WithEvents TabCOA As Windows.Forms.TabPage
    Friend WithEvents btnMigrationCOACat As Windows.Forms.Button
    Friend WithEvents btnMigrationCOA As Windows.Forms.Button
    Friend WithEvents gridCOA As Windows.Forms.DataGridView
    Friend WithEvents lblMessages As Windows.Forms.Label
    Friend WithEvents RecordsProcess As Windows.Forms.ProgressBar
    Friend WithEvents TabItemCat As Windows.Forms.TabPage
    Friend WithEvents gridItemCoat As Windows.Forms.DataGridView
    Friend WithEvents btnMigrationItemCat As Windows.Forms.Button
    Friend WithEvents TabSupplier As Windows.Forms.TabPage
    Friend WithEvents TabItems As Windows.Forms.TabPage
    Friend WithEvents btnMigrationItems As Windows.Forms.Button
    Friend WithEvents gridItems As Windows.Forms.DataGridView
    Friend WithEvents btnMigrationSupplier As Windows.Forms.Button
    Friend WithEvents gridSupplier As Windows.Forms.DataGridView
    Friend WithEvents TabCity As Windows.Forms.TabPage
    Friend WithEvents gridCity As Windows.Forms.DataGridView
    Friend WithEvents TabUOM As Windows.Forms.TabPage
    Friend WithEvents gridUOM As Windows.Forms.DataGridView
    Friend WithEvents btnLoadCity As Windows.Forms.Button
    Friend WithEvents btnMigrateCity As Windows.Forms.Button
    Friend WithEvents btnLoadUOM As Windows.Forms.Button
    Friend WithEvents btnMigrationUOM As Windows.Forms.Button
    Friend WithEvents btnLoadSupplier As Windows.Forms.Button
    Friend WithEvents btnData_COA_CAT As Windows.Forms.Button
    Friend WithEvents btnData_COA As Windows.Forms.Button
    Friend WithEvents btnData_Item_CAT As Windows.Forms.Button
    Friend WithEvents btnData_Items As Windows.Forms.Button
End Class

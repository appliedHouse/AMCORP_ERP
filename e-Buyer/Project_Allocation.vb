Imports System.Data

Public Class Project_Allocation

    Dim Table_Project As DataTable
    Private Property MyProjectID As Integer = 0

    Private Sub Project_Allocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Table_Project = Connection_Class.Get_DataTable("[tblProject]", Connection_Amcorp)

        cBoxProjects.DataSource = Table_Project
        cBoxProjects.DisplayMember = "ProjectTitle"
        cBoxProjects.ValueMember = "ProjectID"

        cBoxProjects.SelectedValue = MyProjectID

    End Sub


End Class
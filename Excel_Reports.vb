Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Imports Connection_Class
Imports System.Drawing


Module Excel_Reports

    Public Sub Excel_Supplier_Ledger(_DataTable As DataTable, _Reports As Report_Parameters)
        '  Project wise Supplier Ledger 

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim _ColumnFormat As String = _Reports.AmountFormat
        Dim _Balance As Integer = 0


        Dim _HasError As Boolean = False
        Dim _ErrorExecption As New Exception

        'xlApp.Visible = True

        Try
            xlWorkBook = xlApp.Workbooks.Add
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            Dim ReportView As New DataView
            ReportView.Table = _DataTable
            ReportView.Sort = _Reports.ReportSort

            'SET HEADER SECTION OF THE REPORT
            With xlWorkSheet
                '~~> Directly type the values that we want

                ' REPORT HEADER ..........................................................................................................

                .Range("A1").Value = _Reports.CompanyName
                .Range("A1").Font.Size = 18
                .Range("A1").Font.Bold = True
                .Range("A1").Font.Color = Drawing.Color.Navy

                .Range("A2").Value = _Reports.ReportHeading
                .Range("A2").Font.Size = 14
                .Range("A2").Font.Bold = True
                .Range("A2").Font.Color = Drawing.Color.SteelBlue

                .Range("A3").Value = "Supplier Project Ledger From " & _Reports.FormatDate(_Reports.DateFrom) & " To " & _Reports.FormatDate(_Reports.DateTo)
                .Range("A3").Font.Size = 12
                .Range("A3").Font.Bold = True
                .Range("A3").Font.Color = Drawing.Color.Purple

                .Range("A4").Value = "Supplier : " & _Reports.SupplierID1 & " -> "
                .Range("C4").Value = Get_Title(_Reports.SupplierID1, "SupplierID", "SupplierTitle", "tblSupplier", Connection_Amcorp).ToUpper
                .Range("A4:C4").Font.Size = 12S
                .Range("A4:C4").Font.Bold = True
                .Range("A4:C4").Font.Color = Drawing.Color.Black

                .Range("A6").Value = "SR No."
                .Range("B6").Value = "Code"
                .Range("C6").Value = "Date"
                .Range("D6").Value = "Voucher No"
                .Range("E6").Value = "Ref No"
                .Range("F6").Value = "Ref Date"
                .Range("G6").Value = "Tran Type"
                .Range("H6").Value = "PRJ"
                .Range("I6").Value = "Debit"
                .Range("J6").Value = "Credit"
                .Range("K6").Value = "Balance"
                .Range("L6").Value = "Tax"
                .Range("M6").Value = "Particulars / Remarks"

                .Range("A6").ColumnWidth = 5.5
                .Range("B6").ColumnWidth = 13.5
                .Range("C6").ColumnWidth = 13
                .Range("D6").ColumnWidth = 13
                .Range("E6").ColumnWidth = 13
                .Range("F6").ColumnWidth = 12.5
                .Range("G6").ColumnWidth = 10
                .Range("H6").ColumnWidth = 5.5
                .Range("I6").ColumnWidth = 13
                .Range("J6").ColumnWidth = 13
                .Range("K6").ColumnWidth = 13
                .Range("L6").ColumnWidth = 13
                .Range("M6").ColumnWidth = 60

                .Range("B6").HorizontalAlignment = Windows.Forms.HorizontalAlignment.Center

                .Range("A6:M6").Font.Color = Drawing.Color.Purple
                .Range("A6:M6").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range("A6:M6").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                ' END .......REPORT HEADER .....................................................................................
            End With

            'SET ROWS OF THE REPORT

            Dim CellNo As Integer = 7
            Dim CellStart As Integer = 7
            Dim _SrNo As Integer = 1

            Dim Report_Project As Integer = 0
            Dim cReport_Total As String = ""
            Dim cReport_DR As String = ""
            Dim cReport_CR As String = ""
            Dim cReport_Tax As String = ""
            Dim Project_Balance As Integer = 0

            Dim Project_Cell_First As Integer = CellNo
            Dim Project_Cell_Last As Integer = CellNo
            Dim Start As Boolean = True
            Dim FilterRangeFrom As String = "A" & CellNo - 1
            Dim FilterRangeTo As String = ""

            For Each _Row As DataRowView In ReportView
                'SET HEADING OF PROJECT

                _Row("Tax Amount") = Math.Round(_Row("Tax Amount"), 0)

                Report_Project = _Row("Project ID")
                _Balance = _Balance + (_Row("Debit") - _Row("Credit"))

                xlWorkSheet.Range("A" & CellNo).Value = _SrNo
                xlWorkSheet.Range("B" & CellNo).Value = _Row("Vou No").Trim
                xlWorkSheet.Range("C" & CellNo).Value = _Row("Vou Date")
                xlWorkSheet.Range("D" & CellNo).Value = _Row("Vou Ref").Trim
                xlWorkSheet.Range("E" & CellNo).Value = _Row("Ref ID").Trim
                xlWorkSheet.Range("F" & CellNo).Value = _Row("Ref Date")
                xlWorkSheet.Range("G" & CellNo).Value = _Row("Vou Type").Trim
                xlWorkSheet.Range("H" & CellNo).Value = _Row("Project ID")
                xlWorkSheet.Range("I" & CellNo).Value = _Row("Debit")
                xlWorkSheet.Range("J" & CellNo).Value = _Row("Credit")
                xlWorkSheet.Range("K" & CellNo).Value = _Balance                        ' Calculated Balance    
                xlWorkSheet.Range("L" & CellNo).Value = _Row("Tax Amount")
                xlWorkSheet.Range("M" & CellNo).Value = _Row("Remarks").trim
                xlWorkSheet.Range("C" & CellNo).NumberFormat = "dd-MMM-yyyy"
                xlWorkSheet.Range("F" & CellNo).NumberFormat = "dd-MMM-yyyy"
                xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).NumberFormat = _ColumnFormat
                xlWorkSheet.Range("A" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
                _SrNo += 1
                CellNo += 1

            Next

            Project_Cell_Last = CellNo
            CellNo += 1

            xlWorkSheet.Range("G" & CellNo).Value = "TOTAL"
            xlWorkSheet.Range("I" & CellNo).Value = "=SUM(I" & Project_Cell_First & ":I" & Project_Cell_Last & ")"
            xlWorkSheet.Range("J" & CellNo).Value = "=SUM(J" & Project_Cell_First & ":J" & Project_Cell_Last & ")"
            xlWorkSheet.Range("L" & CellNo).Value = "=SUM(L" & Project_Cell_First & ":L" & Project_Cell_Last & ")"
            xlWorkSheet.Range("K" & CellNo).Value = "=I" & CellNo & "-J" & CellNo

            If xlWorkSheet.Range("K" & CellNo).Value < 0 Then
                xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Red
            Else
                xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Blue
            End If

            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            cReport_DR = cReport_DR & "+I" & CellNo
            cReport_CR = cReport_CR & "+J" & CellNo
            cReport_Total = cReport_Total & "+K" & CellNo
            cReport_Tax = cReport_Tax & "+L" & CellNo

            CellNo += 2
            FilterRangeTo = "M" & CellNo
            '.... REPORT BOTTOM ...... REPORT TOTAL

            xlWorkSheet.Range("G" & CellNo).Value = "TOTAL"
            xlWorkSheet.Range("I" & CellNo).Value = "=" & cReport_DR
            xlWorkSheet.Range("J" & CellNo).Value = "=" & cReport_CR
            xlWorkSheet.Range("K" & CellNo).Value = "=" & cReport_Total
            xlWorkSheet.Range("L" & CellNo).Value = "=" & cReport_Tax

            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Font.Color = Drawing.Color.DarkBlue
            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).NumberFormat = _ColumnFormat

            CellNo += 2

            xlWorkSheet.PageSetup.PrintArea = "A1:" & "L" & CellNo
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            xlWorkSheet.PageSetup.CenterHorizontally = True
            xlWorkSheet.PageSetup.Zoom = False
            xlWorkSheet.PageSetup.FitToPagesTall = 1
            xlWorkSheet.PageSetup.FitToPagesWide = 1
            xlWorkSheet.Range(FilterRangeFrom & ":" & FilterRangeTo).AutoFilter(Field:=1)

        Catch ex As Exception
            _HasError = True
            _ErrorExecption = ex
        End Try

        If _HasError Then
            MsgBox(_ErrorExecption.Message)

        Else
            xlApp.WindowState = Excel.XlWindowState.xlMaximized         'FormWindowState.Maximized
            xlApp.Visible = True
        End If
    End Sub
    Public Sub Excel_Supplier_Project_Ledger(_DataTable As DataTable, _Reports As Report_Parameters)
        '  Project wise Supplier Ledger 

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim _ColumnFormat As String = _Reports.AmountFormat
        Dim _Balance As Integer = 0
        Dim TotalFrom As Integer    ' Project Total Calculate from here...

        Dim _HasError As Boolean = False
        Dim _ErrorExecption As New Exception

        'xlApp.DisplayAlerts = False
        'xlApp.Visible = False

        Try

            xlWorkBook = xlApp.Workbooks.Add
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            Dim ReportView As New DataView
            ReportView.Table = _DataTable
            ReportView.Sort = _Reports.ReportSort

            'SET HEADER SECTION OF THE REPORT
            With xlWorkSheet
                '~~> Directly type the values that we want

                ' REPORT HEADER ..........................................................................................................

                .Range("A1").Value = _Reports.CompanyName
                .Range("A1").Font.Size = 18
                .Range("A1").Font.Bold = True
                .Range("A1").Font.Color = Drawing.Color.Navy

                .Range("A2").Value = _Reports.ReportHeading
                .Range("A2").Font.Size = 14
                .Range("A2").Font.Bold = True
                .Range("A2").Font.Color = Drawing.Color.SteelBlue

                .Range("A3").Value = "Supplier Project Ledger From " & _Reports.FormatDate(_Reports.DateFrom) & " To " & _Reports.FormatDate(_Reports.DateTo)
                .Range("A3").Font.Size = 12
                .Range("A3").Font.Bold = True
                .Range("A3").Font.Color = Drawing.Color.Purple

                .Range("A4").Value = "Supplier : " & _Reports.SupplierID1 & " -> "
                .Range("C4").Value = Get_Title(_Reports.SupplierID1, "SupplierID", "SupplierTitle", "tblSupplier", Connection_Amcorp).ToUpper
                .Range("A4:C4").Font.Size = 12S
                .Range("A4:C4").Font.Bold = True
                .Range("A4:C4").Font.Color = Drawing.Color.Black

                .Range("A6").Value = "SR No."
                .Range("B6").Value = "Code"
                .Range("C6").Value = "Date"
                .Range("D6").Value = "Voucher No"
                .Range("E6").Value = "Ref No"
                .Range("F6").Value = "Ref Date"
                .Range("G6").Value = "Tran Type"
                .Range("H6").Value = "PRJ"
                .Range("I6").Value = "Debit"
                .Range("J6").Value = "Credit"
                .Range("K6").Value = "Balance"
                .Range("L6").Value = "Tax"
                .Range("M6").Value = "Particulars / Remarks"

                .Range("A6").ColumnWidth = 5.5
                .Range("B6").ColumnWidth = 13.5
                .Range("C6").ColumnWidth = 13
                .Range("D6").ColumnWidth = 13
                .Range("E6").ColumnWidth = 13
                .Range("F6").ColumnWidth = 12.5
                .Range("G6").ColumnWidth = 10
                .Range("H6").ColumnWidth = 5.5
                .Range("I6").ColumnWidth = 13
                .Range("J6").ColumnWidth = 13
                .Range("K6").ColumnWidth = 13
                .Range("L6").ColumnWidth = 13
                .Range("M6").ColumnWidth = 60

                .Range("B6").HorizontalAlignment = Windows.Forms.HorizontalAlignment.Center

                .Range("A6:M6").Font.Color = Drawing.Color.Purple
                .Range("A6:M6").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range("A6:M6").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                ' END .......REPORT HEADER .....................................................................................
            End With

            'SET ROWS OF THE REPORT

            Dim CellNo As Integer = 7
            Dim CellStart As Integer = 7
            Dim _SrNo As Integer = 1

            Dim Report_Project As Integer = 0
            Dim cReport_Total As String = ""
            Dim cReport_DR As String = ""
            Dim cReport_CR As String = ""
            Dim cReport_Tax As String = ""
            Dim Project_Balance As Integer = 0

            Dim Project_Cell_First As Integer = CellNo
            Dim Project_Cell_Last As Integer = CellNo
            Dim Start As Boolean = True
            Dim Project_LastRow As Integer
            Dim Print_Project_Heading As Boolean
            Dim FilterRangeFrom As String = "A" & CellNo - 1
            Dim FilterRangeTo As String = ""

            For Each _Row As DataRowView In ReportView
                'SET HEADING OF PROJECT

                _Row("Tax Amount") = Math.Round(_Row("Tax Amount"), 0)

                Report_Project = _Row("Project ID")

                If Start Then                               ' Run this code only one time
                    Project_LastRow = Report_Project
                    Print_Project_Heading = True
                    CellNo += 1
                    _Balance = 0
                    TotalFrom = CellNo
                    _SrNo = 1
                    Start = False
                Else

                    If Report_Project <> Project_LastRow Then
                        Print_Project_Heading = True
                        Project_Cell_Last = CellNo
                        CellNo += 1

                        ' SHOW TOTAL OF PROJECT 

                        xlWorkSheet.Range("G" & CellNo).Value = "TOTAL"
                        xlWorkSheet.Range("I" & CellNo).Value = "=SUM(I" & Project_Cell_First & ":I" & Project_Cell_Last & ")"
                        xlWorkSheet.Range("J" & CellNo).Value = "=SUM(J" & Project_Cell_First & ":J" & Project_Cell_Last & ")"
                        xlWorkSheet.Range("L" & CellNo).Value = "=SUM(L" & Project_Cell_First & ":L" & Project_Cell_Last & ")"

                        xlWorkSheet.Range("K" & CellNo).Value = "=I" & CellNo & "-J" & CellNo

                        xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).NumberFormat = _ColumnFormat

                        If xlWorkSheet.Range("K" & CellNo).Value < 0 Then
                            xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Red
                        Else
                            xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Blue
                        End If



                        xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous


                        cReport_DR = cReport_DR & "+I" & CellNo
                        cReport_CR = cReport_CR & "+J" & CellNo
                        cReport_Total = cReport_Total & "+K" & CellNo
                        cReport_Tax = cReport_Tax & "+L" & CellNo

                        CellNo += 1

                    Else

                        Print_Project_Heading = False
                        Project_Cell_Last = CellNo

                    End If

                End If

                If Print_Project_Heading Then

                    xlWorkSheet.Range("A" & CellNo).Value = "'" & Get_Title(_Row("Project ID"), "ProjectID", "ProjectRefNo", "tblProject", Connection_Amcorp)
                    xlWorkSheet.Range("B" & CellNo).Value = "'" & Get_Title(_Row("Project ID"), "ProjectID", "ProjectTitle", "tblProject", Connection_Amcorp)

                    xlWorkSheet.Range("A" & CellNo & ":B" & CellNo).Font.Color = Drawing.Color.Firebrick
                    xlWorkSheet.Range("A" & CellNo & ":B" & CellNo).Font.Bold = True
                    xlWorkSheet.Range("A" & CellNo & ":B" & CellNo).Font.Underline = True

                    CellNo += 1
                    Project_Cell_First = CellNo
                    Project_Cell_Last = CellNo
                    Project_LastRow = _Row("Project ID")
                    Project_Balance = 0

                End If

                Project_Balance = Project_Balance + _Row("Debit") - _Row("Credit")

                xlWorkSheet.Range("A" & CellNo).Value = _SrNo
                xlWorkSheet.Range("B" & CellNo).Value = _Row("Vou No").Trim
                xlWorkSheet.Range("C" & CellNo).Value = _Row("Vou Date")
                xlWorkSheet.Range("D" & CellNo).Value = _Row("Vou Ref").Trim
                xlWorkSheet.Range("E" & CellNo).Value = _Row("Ref ID").Trim
                xlWorkSheet.Range("F" & CellNo).Value = _Row("Ref Date")
                xlWorkSheet.Range("G" & CellNo).Value = _Row("Vou Type").Trim
                xlWorkSheet.Range("H" & CellNo).Value = _Row("Project ID")
                xlWorkSheet.Range("I" & CellNo).Value = _Row("Debit")
                xlWorkSheet.Range("J" & CellNo).Value = _Row("Credit")
                xlWorkSheet.Range("K" & CellNo).Value = "=K" & CellNo - 1 & "+I" & CellNo & "-J" & CellNo
                xlWorkSheet.Range("L" & CellNo).Value = _Row("Tax Amount")
                xlWorkSheet.Range("M" & CellNo).Value = _Row("Remarks").trim
                xlWorkSheet.Range("C" & CellNo).NumberFormat = "dd-MMM-yyyy"
                xlWorkSheet.Range("F" & CellNo).NumberFormat = "dd-MMM-yyyy"
                xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).NumberFormat = _ColumnFormat
                xlWorkSheet.Range("A" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
                _SrNo += 1
                CellNo += 1

            Next

            Project_Cell_Last = CellNo
            CellNo += 1

            xlWorkSheet.Range("G" & CellNo).Value = "TOTAL"
            xlWorkSheet.Range("I" & CellNo).Value = "=SUM(I" & Project_Cell_First & ":I" & Project_Cell_Last & ")"
            xlWorkSheet.Range("J" & CellNo).Value = "=SUM(J" & Project_Cell_First & ":J" & Project_Cell_Last & ")"
            xlWorkSheet.Range("L" & CellNo).Value = "=SUM(L" & Project_Cell_First & ":L" & Project_Cell_Last & ")"
            xlWorkSheet.Range("K" & CellNo).Value = "=I" & CellNo & "-J" & CellNo

            If xlWorkSheet.Range("K" & CellNo).Value < 0 Then
                xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Red
            Else
                xlWorkSheet.Range("K" & CellNo).Font.Color = Drawing.Color.Blue
            End If

            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            cReport_DR = cReport_DR & "+I" & CellNo
            cReport_CR = cReport_CR & "+J" & CellNo
            cReport_Total = cReport_Total & "+K" & CellNo
            cReport_Tax = cReport_Tax & "+L" & CellNo

            CellNo += 2
            FilterRangeTo = "M" & CellNo
            '.... REPORT BOTTOM ...... REPORT TOTAL

            xlWorkSheet.Range("G" & CellNo).Value = "TOTAL"
            xlWorkSheet.Range("I" & CellNo).Value = "=" & cReport_DR
            xlWorkSheet.Range("J" & CellNo).Value = "=" & cReport_CR
            xlWorkSheet.Range("K" & CellNo).Value = "=" & cReport_Total
            xlWorkSheet.Range("L" & CellNo).Value = "=" & cReport_Tax

            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            xlWorkSheet.Range("G" & CellNo & ":L" & CellNo).Font.Color = Drawing.Color.DarkBlue
            xlWorkSheet.Range("I" & CellNo & ":L" & CellNo).NumberFormat = _ColumnFormat

            CellNo += 2

            xlWorkSheet.PageSetup.PrintArea = "A1:" & "L" & CellNo
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            xlWorkSheet.PageSetup.CenterHorizontally = True
            xlWorkSheet.PageSetup.Zoom = False
            xlWorkSheet.PageSetup.FitToPagesTall = 1
            xlWorkSheet.PageSetup.FitToPagesWide = 1
            xlWorkSheet.Range(FilterRangeFrom & ":" & FilterRangeTo).AutoFilter(Field:=1)

        Catch ex As Exception
            _HasError = True
            _ErrorExecption = ex
        End Try

        If _HasError Then
            MsgBox(_ErrorExecption.Message)

        Else
            xlApp.WindowState = Excel.XlWindowState.xlMaximized         'FormWindowState.Maximized
            xlApp.Visible = True
        End If
    End Sub
    Public Sub Excel_Supplier_Project_TB(_DataTable As DataTable, _Report As Report_Parameters)

        'Dim _DataTable As DataTable = _TableReport2                     ' Select Supplier TB Table
        'Dim SupplierID As Integer = _DataTable.Rows(0).Item("Supplier")
        'Dim SupplierTitle As String = _DataTable.Rows(0).Item("SupplierTitle")
        'Dim ProjectID As Integer = _DataTable.Rows(0).Item("Project")
        'Dim ProjectTitle As String = _DataTable.Rows(0).Item("ProjectTitle")

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        'ADD EXCEL WORKBOOK

        xlWorkBook = xlApp.Workbooks.Add
        xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        xlWorkSheet = xlWorkBook.ActiveSheet                        ' Activate the Sheet1

        With xlWorkSheet
            ' REPORT HEADER ...............................................................................

            .Range("A1").Value = _Report.CompanyName
            .Range("A1").Font.Size = 18
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Color = Color.Blue

            .Range("A2").Value = _Report.ReportHeading
            .Range("A2").Font.Size = 14
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Color = Color.RosyBrown

            .Range("A3").Value = "Supplier Project Outstanding as on " & _Report.FormatDate(_Report.DateTo)
            .Range("A3").Font.Size = 12
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Color = Color.Black

            .Range("A4").Value = "Supplier : " & _DataTable.Rows(0).Item("Supplier Title")
            .Range("A4").Font.Size = 12
            .Range("A4").Font.Bold = True
            .Range("A4").Font.Color = Color.RoyalBlue

            .Range("A6").Value = "SR No."
            .Range("B6").Value = "Code"
            .Range("C6").Value = "Project Title"
            .Range("D6").Value = "Debit"
            .Range("E6").Value = "Credit"
            .Range("F6").Value = "Balance"
            .Range("G6").Value = "GST"
            .Range("H6").Value = "Tax"


            .Range("A6").ColumnWidth = 5
            .Range("B6").ColumnWidth = 6
            .Range("C6").ColumnWidth = 50
            .Range("D6").ColumnWidth = 13
            .Range("E6").ColumnWidth = 13
            .Range("F6").ColumnWidth = 13
            .Range("G6").ColumnWidth = 13
            .Range("H6").ColumnWidth = 13

            .Range("A6:H6").Font.Color = Color.Purple
            .Range("A6:H6").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("A6:H6").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        End With

        'SET ROWS OF THE REPORT
        Dim CellFirst As Integer = 7
        Dim CellLast As Integer = CellFirst
        Dim CellNo As Integer = CellFirst
        Dim Records As Integer = 0
        Dim _Balance As Integer = 0

        Dim _SrNo As Integer = 1

        For Each _Row As DataRow In _DataTable.Rows

            If _Report.ShowZeros Then
                If _Row("Balance") = 0 Then
                    Continue For
                End If
            End If

            _Balance = _Row("Debit") - _Row("Credit")

            xlWorkSheet.Range("A" & CellNo).Value = _SrNo
            xlWorkSheet.Range("B" & CellNo).Value = _Row("Project")
            xlWorkSheet.Range("C" & CellNo).Value = _Row("Project Title")
            xlWorkSheet.Range("D" & CellNo).Value = _Row("Debit")
            xlWorkSheet.Range("E" & CellNo).Value = _Row("Credit")
            xlWorkSheet.Range("F" & CellNo).Value = _Balance
            xlWorkSheet.Range("G" & CellNo).Value = _Row("GST Amount")
            xlWorkSheet.Range("H" & CellNo).Value = _Row("Tax Amount")

            _SrNo += 1
            CellNo += 1
            CellLast = CellNo
            Records += 1
        Next

        If Records = 0 Then
            xlWorkSheet.Range("C" & CellNo).Value = "No Record Found."
            CellNo += 1
            CellLast = CellNo
        End If

        CellNo += 1
        CellLast = CellNo
        Records += 1

        xlWorkSheet.Range("C" & CellFirst & ":H" & CellLast).NumberFormat = _Report.AmountFormat
        xlWorkSheet.Range("C" & CellLast & ":H" & CellLast).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        xlWorkSheet.Range("C" & CellLast & ":H" & CellLast).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        xlWorkSheet.Range("C" & CellLast).Value = "TOTAL"
        xlWorkSheet.Range("D" & CellLast).Value = "=SUBTOTAL(9, D" & CellFirst & ":D" & CellLast - 1 & ")"
        xlWorkSheet.Range("E" & CellLast).Value = "=SUBTOTAL(9, E" & CellFirst & ":E" & CellLast - 1 & ")"
        xlWorkSheet.Range("F" & CellLast).Value = "=SUBTOTAL(9, F" & CellFirst & ":F" & CellLast - 1 & ")"
        xlWorkSheet.Range("G" & CellLast).Value = "=SUBTOTAL(9, G" & CellFirst & ":G" & CellLast - 1 & ")"
        xlWorkSheet.Range("H" & CellLast).Value = "=SUBTOTAL(9, H" & CellFirst & ":H" & CellLast - 1 & ")"


        '---------------------- Page Setup and Preview

        CellNo += 1
        CellLast = CellNo

        xlWorkSheet.PageSetup.PrintArea = "A1:" & "H" & CellLast
        xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
        xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
        xlWorkSheet.PageSetup.CenterHorizontally = True
        xlWorkSheet.PageSetup.Zoom = False
        xlWorkSheet.PageSetup.FitToPagesTall = 1
        xlWorkSheet.PageSetup.FitToPagesWide = 1

        xlApp.WindowState = Excel.XlWindowState.xlMaximized        'FormWindowState.Maximized
        xlApp.Visible = True

    End Sub

    Friend Sub Excel_General_Ledger(_Datatable As DataTable, _Reports As Report_Parameters)

        '  Project wise Supplier Ledger 

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim _ColumnFormat As String = _Reports.AmountFormat
        Dim _Balance As Integer = 0

        Dim _HasError As Boolean = False
        Dim _ErrorExecption As New Exception

        'xlApp.Visible = True

        Try
            xlWorkBook = xlApp.Workbooks.Add
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            Dim ReportView As New DataView
            ReportView.Table = _Datatable
            ReportView.Sort = _Reports.ReportSort

            'SET HEADER SECTION OF THE REPORT
            With xlWorkSheet
                '~~> Directly type the values that we want

                ' REPORT HEADER ..........................................................................................................

                .Range("A1").Value = _Reports.CompanyName
                .Range("A1").Font.Size = 18
                .Range("A1").Font.Bold = True
                .Range("A1").Font.Color = Drawing.Color.Navy

                .Range("A2").Value = _Reports.ReportHeading
                .Range("A2").Font.Size = 14
                .Range("A2").Font.Bold = True
                .Range("A2").Font.Color = Drawing.Color.SteelBlue

                .Range("A3").Value = "General Ledger From " & _Reports.FormatDate(_Reports.DateFrom) & " To " & _Reports.FormatDate(_Reports.DateTo)
                .Range("A3").Font.Size = 12
                .Range("A3").Font.Bold = True
                .Range("A3").Font.Color = Drawing.Color.Purple

                .Range("A4").Value = "Ledger : " & _Reports.COAID1 & " -> "
                .Range("C4").Value = Get_Title(_Reports.COAID1, "ChartofAccountID", "AccountTitle", "tblChartofaccount", Connection_Amcorp).ToUpper
                .Range("A4:C4").Font.Size = 12S
                .Range("A4:C4").Font.Bold = True
                .Range("A4:C4").Font.Color = Drawing.Color.Black

                .Range("A6").Value = "SR No."
                .Range("B6").Value = "Vou Date"
                .Range("C6").Value = "Vou No"
                .Range("D6").Value = "Description"
                .Range("E6").Value = "Debit"
                .Range("F6").Value = "Credit"
                .Range("G6").Value = "Balance"
                .Range("H6").Value = "PRJ"


                .Range("A6").ColumnWidth = 5.5
                .Range("B6").ColumnWidth = 12
                .Range("C6").ColumnWidth = 15
                .Range("D6").ColumnWidth = 75
                .Range("E6").ColumnWidth = 13
                .Range("F6").ColumnWidth = 13
                .Range("G6").ColumnWidth = 13
                .Range("H6").ColumnWidth = 6

                .Range("B6").HorizontalAlignment = Windows.Forms.HorizontalAlignment.Center

                .Range("A6:H6").Font.Color = Drawing.Color.Purple
                .Range("A6:H6").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range("A6:H6").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                ' END .......REPORT HEADER .....................................................................................
            End With

            'SET ROWS OF THE REPORT

            Dim CellNo As Integer = 7
            Dim CellStart As Integer = 7
            Dim _SrNo As Integer = 1

            Dim Report_Project As Integer = 0

            Dim Project_Cell_First As Integer = CellNo
            Dim Project_Cell_Last As Integer = CellNo
            Dim FilterRangeFrom As String = "A" & CellNo - 1
            Dim FilterRangeTo As String = "H"

            For Each _Row As DataRowView In ReportView
                'SET HEADING OF PROJECT

                Report_Project = _Row("Project ID")
                _Balance = _Balance + (_Row("Amount"))

                xlWorkSheet.Range("A" & CellNo).Value = _SrNo
                xlWorkSheet.Range("B" & CellNo).Value = _Row("Vou Date")
                xlWorkSheet.Range("C" & CellNo).Value = _Row("Vou No").Trim
                xlWorkSheet.Range("D" & CellNo).Value = _Row("Remarks").Trim
                xlWorkSheet.Range("E" & CellNo).Value = _Row("Debit")
                xlWorkSheet.Range("F" & CellNo).Value = _Row("Credit")
                xlWorkSheet.Range("G" & CellNo).Value = _Balance                        ' Calculated Balance    
                xlWorkSheet.Range("H" & CellNo).Value = _Row("Project ID")
                xlWorkSheet.Range("E" & CellNo & ":G" & CellNo).NumberFormat = _ColumnFormat
                xlWorkSheet.Range("A" & CellNo & ":H" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
                _SrNo += 1
                CellNo += 1

            Next

            Project_Cell_Last = CellNo
            CellNo += 1

            xlWorkSheet.Range("D" & CellNo).Value = "TOTAL"
            xlWorkSheet.Range("E" & CellNo).Value = "=SUM(E" & Project_Cell_First & ":E" & Project_Cell_Last & ")"
            xlWorkSheet.Range("F" & CellNo).Value = "=SUM(F" & Project_Cell_First & ":F" & Project_Cell_Last & ")"
            xlWorkSheet.Range("G" & CellNo).Value = "=SUM(G" & Project_Cell_First & ":G" & Project_Cell_Last & ")"

            xlWorkSheet.Range("D" & CellNo & ":G" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("D" & CellNo & ":G" & CellNo).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            CellNo += 2

            FilterRangeTo = "H" & CellNo

            xlWorkSheet.PageSetup.PrintArea = "A1:" & "G" & CellNo
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            xlWorkSheet.PageSetup.CenterHorizontally = True
            xlWorkSheet.PageSetup.Zoom = False
            xlWorkSheet.PageSetup.FitToPagesTall = 1
            xlWorkSheet.PageSetup.FitToPagesWide = 1
            xlWorkSheet.Range(FilterRangeFrom & ":" & FilterRangeTo).AutoFilter(Field:=1)

        Catch ex As Exception
            _HasError = True
            _ErrorExecption = ex
        End Try

        If _HasError Then
            MsgBox(_ErrorExecption.Message)

        Else
            xlApp.WindowState = Excel.XlWindowState.xlMaximized         'FormWindowState.Maximized
            xlApp.Visible = True
        End If

    End Sub

End Module

Imports System.IO
Imports System.Windows.Forms

Module ERP_Connections

    '02-04-2019
    ' It Supplies the Amcorp ERP SQL connection 

    Public Function Connection_Master() As SqlConnection
        Return Connection_Establish("192.168.0.5", "Master")
    End Function

    Public Function Connection_Bizztrax() As SqlConnection
        Return Connection_Establish("192.168.0.5", "Bizztrax")
    End Function


    Public Function Connection_Amcorp() As SqlConnection
        Return Connection_Establish("192.168.0.5", "Bizztrax_Amcorp")
    End Function


    Public Function Connection_Establish(_DB_Name As String, _Catlog As String) As SqlConnection
        ' 29-June-2021
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False

        Dim ConnString = "Data Source=" + _DB_Name + ";Initial Catalog=" + _Catlog + " ;User ID=sa;Password=efrosoft97;"
        Dim _SQLConnection = New SqlConnection(ConnString)

        Try
            _SQLConnection = New SqlConnection(ConnString)
            _SQLConnection.Open()
        Catch ex As Exception
            MessageBox.Show("Error(1001): Connection of Database is not being establised.")
        End Try

        Return _SQLConnection

    End Function



End Module

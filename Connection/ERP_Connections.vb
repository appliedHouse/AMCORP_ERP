Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports ERROR_CLASS
Module ERP_Connections

    '02-04-2019
    ' It Supplies the Amcorp ERP SQL connection 


    Public Function MessageShow(_ID As Integer) As Boolean

        Dim ErrorClass As ErrorMsgControl = New ErrorMsgControl()

        ErrorClass.msgID.Text = _ID.ToString()
        ErrorClass.msgText.Text = "Error Message"
        ErrorClass.msgSource.Text = "Error source"


        ErrorClass.Show()

        Return True

    End Function



    Public Function Connection_Master() As SqlConnection
        'Dim ConnString = "Data Source=AMCORPDB;Initial Catalog=master;User ID=sa;Password=efrosoft97;"
        'Dim _SQLConnection = New SqlConnection(ConnString)
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False
        '_SQLConnection.Open()
        'Return _SQLConnection
        'Return Connection_Class.AppliedConnection(DB.Master, DB_Defaults)

        Return Connection_Establish("192.168.0.5", "Master")
    End Function

    Public Function Connection_Bizztrax() As SqlConnection
        'Dim ConnString = "Data Source=AMCORPDB;Initial Catalog=Bizztrax;User ID=sa;Password=efrosoft97;"
        'Dim _SQLConnection = New SqlConnection(ConnString)
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False
        '_SQLConnection.Open()

        'Return _SQLConnection


        'Return Connection_Class.AppliedConnection(DB.BizzTrax, DB_Defaults)

        Return Connection_Establish("192.168.0.5", "Bizztrax")


    End Function


    Public Function Connection_Amcorp() As SqlConnection

        'Dim ConnStringIP = "Data Source=AMCORPDB;Initial Catalog=Bizztrax_Amcorp;User ID=sa;Password=efrosoft97;"
        'Dim ConnString = "Data Source=192.168.0.5;Initial Catalog=Bizztrax_Amcorp;User ID=sa;Password=efrosoft97;"
        'Dim _SQLConnection = New SqlConnection(ConnString)

        'Try
        '    _SQLConnection = New SqlConnection(ConnString)
        '    _SQLConnection.Open()
        'Catch ex As Exception
        '    Try
        '        _SQLConnection = New SqlConnection(ConnStringIP)
        '        _SQLConnection.Open()
        '    Catch ex1 As Exception
        '        MessageShow(1001)
        '    End Try
        'Finally

        '    MessageBox.Show("Connection has been established.")


        'End Try

        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False

        'Return _SQLConnection

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

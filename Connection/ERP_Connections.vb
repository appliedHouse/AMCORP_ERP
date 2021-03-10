Imports System.Data.SqlClient
Module ERP_Connections

    '02-04-2019
    ' It Supplies the Amcorp ERP SQL connection 

    Public Function Connection_Master() As SqlConnection
        Dim ConnString = "Data Source=AMCORPDB;Initial Catalog=master;User ID=sa;Password=efrosoft97;"
        Dim _SQLConnection = New SqlConnection(ConnString)
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False
        _SQLConnection.Open()

        Return _SQLConnection

        'Return Connection_Class.AppliedConnection(DB.Master, DB_Defaults)
    End Function

    Public Function Connection_Bizztrax() As SqlConnection
        Dim ConnString = "Data Source=AMCORPDB;Initial Catalog=Bizztrax;User ID=sa;Password=efrosoft97;"
        Dim _SQLConnection = New SqlConnection(ConnString)
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False
        _SQLConnection.Open()

        Return _SQLConnection


        'Return Connection_Class.AppliedConnection(DB.BizzTrax, DB_Defaults)
    End Function


    Public Function Connection_Amcorp() As SqlConnection

        Dim ConnString = "Data Source=AMCORPDB;Initial Catalog=Bizztrax_Amcorp;User ID=sa;Password=efrosoft97;"
        Dim _SQLConnection = New SqlConnection(ConnString)
        'Provider = SQLOLEDB.1;;Persist Security Info=True;Use Procedure For Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=ACCOUNTS-PC;Use Encryption For Data=False;Tag With column collation When possible=False
        _SQLConnection.Open()
        Return _SQLConnection
    End Function


    Public Function Connection_Amcorp1() As SqlConnection

        Dim _SQLConnection = New SqlConnection
        Try
            _SQLConnection = Connection_Class.AppliedConnection(DB.Amcorp, DB_Defaults)
        Catch ex As Exception
            _SQLConnection = Nothing

        End Try

        Return _SQLConnection
    End Function

End Module

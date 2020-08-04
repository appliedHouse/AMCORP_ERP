Imports System.Data.SqlClient
Module ERP_Connections

    '02-04-2019
    ' It Supplies the Amcorp ERP SQL connection 

    Public Function Connection_Master() As SqlConnection
        Return Connection_Class.AppliedConnection(DB.Master, DB_Defaults)
    End Function

    Public Function Connection_Bizztrax() As SqlConnection
        Return Connection_Class.AppliedConnection(DB.BizzTrax, DB_Defaults)
    End Function

    Public Function Connection_Amcorp() As SqlConnection


        Dim _SQLConnection = New SqlConnection
        Try
            _SQLConnection = Connection_Class.AppliedConnection(DB.Amcorp, DB_Defaults)
        Catch ex As Exception
            _SQLConnection = Nothing

        End Try

        Return _SQLConnection
    End Function
End Module

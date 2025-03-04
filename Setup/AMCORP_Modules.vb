Imports Connection_Class

Module AMCORP_Modules

#Disable Warning CA1031 ' Do not declare visible instance fields
#Disable Warning CA1305 ' Do not declare visible instance fields

    Public ReadOnly Property DB_Defaults As Default_Values
        Get
            Dim _DB_Defaults As New Default_Values

            _DB_Defaults.SQLInstance = My.Settings.Default.SetupDBInstance
            _DB_Defaults.DBEngine = My.Settings.Default.SetupDBEngine
            _DB_Defaults.DBPath = My.Settings.Default.SetupDBPath
            _DB_Defaults.DBLogin = My.Settings.Default.SetupDBLogin
            _DB_Defaults.DBPWHash = My.Settings.Default.SetupDBPWHash
            _DB_Defaults.DBPWWrapper = My.Settings.Default.PWWrapper

            Return _DB_Defaults
        End Get


    End Property
    Public Sub Add_Connection()

        Dim _Defaults As Default_Values

        _Defaults = DB_Defaults

        MsgBox(_Defaults.SetupConnection.State.ToString)

        Dim _SetupRecord As New SetupRecord(DB_Defaults)
        Dim _DataRecord As New DataRecord

        '-------------------------------------------------- Record 1

        _DataRecord.ID = 1
        _DataRecord.Code = "1"
        _DataRecord.Title = "AMCORP ERP Bizztrax"

        _DataRecord.Data_Source = "AMCORPDB"
        _DataRecord.User_ID = "sa"
        _DataRecord.Initial_Catalog = "BizzTrax"
        _DataRecord.Password = PW.EncryptPassword("efrosoft97", DB_Defaults.DBPWWrapper)

        _SetupRecord.MyDataRecord = _DataRecord
        _SetupRecord.SaveRecord()

        '-------------------------------------------------- Record 2

        _DataRecord.ID = 2
        _DataRecord.Code = "2"
        _DataRecord.Title = "AMCORP ERP Bizztrax"

        _DataRecord.Data_Source = "AMCORPDB"
        _DataRecord.User_ID = "sa"
        _DataRecord.Initial_Catalog = "BizzTrax_Amcorp"
        _DataRecord.Password = PW.EncryptPassword("efrosoft97", DB_Defaults.DBPWWrapper)

        _SetupRecord.MyDataRecord = _DataRecord
        _SetupRecord.SaveRecord()

        '-------------------------------------------------- Record 2

        _DataRecord.ID = 3
        _DataRecord.Code = "3"
        _DataRecord.Title = "AMCORP ERP Bizztrax"

        _DataRecord.Data_Source = "AMCORPDB"
        _DataRecord.User_ID = "sa"
        _DataRecord.Initial_Catalog = "master"
        _DataRecord.Password = PW.EncryptPassword("efrosoft97", DB_Defaults.DBPWWrapper)

        _SetupRecord.MyDataRecord = _DataRecord
        _SetupRecord.SaveRecord()

    End Sub

    Public Function Convert_TextBox(_String As Object) As Integer
        Dim _Integer As Integer

        If IsNumeric(_String) Then
            Return _String
        End If

        If _String Is Nothing Then
            Return 0
        End If

        If IsDBNull(_String) Then
            Return 0
        End If

        If _String.Length = 0 Then
            Return 0
        End If
        Try
            _Integer = Convert.ToInt32(_String)
        Catch ex As Exception
            Return -1
        End Try

        Return _Integer

    End Function

    Public Enum DB
        Master = 3
        BizzTrax = 1
        Amcorp = 2
    End Enum

    Public Enum Table
        Supplier = 101
        StockItems = 102
        Projects = 103
        Ledger_General = 104
        Supplier_Ledger = 105
        Supplier_Outstanding = 106
    End Enum





End Module

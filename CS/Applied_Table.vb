Public Function SQLInsert(ByVal _ID As Integer) As String()
    Dim _string = New String(4) {}
    Dim _CommandString = New StringBuilder
    _CommandString.Append("INSERT INTO ")
    _CommandString.Append(MyTableName)
    _CommandString.Append(" ( ")

    For Each _Column As DataColumn In MyDataTable.Columns
        Dim _ColumnName As String = _Column.ColumnName
        Dim _LastColumn As String = MyDataTable.Columns(MyDataTable.Columns.Count - 1).ColumnName
        _CommandString.Append(String.Concat("[", _Column.ColumnName, "]"))

        If _ColumnName IsNot _LastColumn Then
            _CommandString.Append(",")
        Else
            _CommandString.Append(") ")
        End If
    Next

    _CommandString.Remove(_CommandString.ToString.Trim.Length - 1, 1)
    _CommandString.Append(") VALUES (")

    For Each _Column As DataColumn In MyDataTable.Columns
        Dim _ColumnName As String = _Column.ColumnName
        Dim _LastColumn As String = MyDataTable.Columns(MyDataTable.Columns.Count - 1).ColumnName
        _CommandString.Append(String.Concat("@", _Column.ColumnName.Replace(" ", "")))

        If _ColumnName IsNot _LastColumn Then
            _CommandString.Append(",")
        Else
            _CommandString.Append(") ")
        End If
    Next

    Dim _result = 1
    _string(0) = MyTableName
    _string(1) = Convert.ToString(MyConnection.State)
    _string(2) = String.Concat("SQL Query hit ", Convert.ToString(_result), " record(s).")
    _Command.CommandText = _CommandString.ToString
    Return _string
End Function
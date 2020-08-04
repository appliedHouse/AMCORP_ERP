using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace APPLIED_TABLE
{
    public class Applied_Table
    {
        public const string ClassName = "Applied Table Class";
        public const string ClassVersion = "1.0.100";
        public const string ClassRemarks = "Class provide the Table's fuctions i.e. SQL Insert, Update, Delete Command. Get Tabel Row, Rows, Columms Value";
        //===========================================================================================================================================

        public string MyMessage = "Applied Table Class";
        private string[] SkipColumns = { "ID", "Created" };

        public SqlConnection MyConnection;
        private SqlCommand _Command;
        private SqlDataAdapter _Adapter;
        private DataSet _DataSet;
        private bool IsConnection;

        public DataTable MyDataTable;
        public DataView MyTableView = new DataView();
        public DataRow MyDataRow;
        public string MyTableName;

        public Applied_Table(DataTable _DataTable, SqlConnection _Connection)
        {
            MyConnection = _Connection;
            _Command = _Connection.CreateCommand();

            MyDataTable = _DataTable;
            MyTableView.Table = MyDataTable;
            MyTableName = MyDataTable.TableName;

            if (MyDataTable.Rows.Count > 0) { MyDataRow = MyDataTable.Rows[0]; } else { MyDataRow = MyDataTable.NewRow(); }
            SET_SQLParameters();     // Create SQL Command Parameter
        }

        //------------------------------------------------------------------ SQL Commands    
        public string[] SQLInsert(int _ID)
        {
            string[] _string = new string[5];
            StringBuilder _CommandString = new StringBuilder();


            _CommandString.Append("INSERT INTO ");
            _CommandString.Append(MyTableName);
            _CommandString.Append(" ( ");

            foreach (DataColumn _Column in MyDataTable.Columns)
            {
                string _ColumnName = _Column.ColumnName;
                string _LastColumn = MyDataTable.Columns[MyDataTable.Columns.Count-1].ColumnName;
                
                _CommandString.Append(string.Concat("[", _Column.ColumnName, "]"));

                if (_ColumnName != _LastColumn)
                {
                    _CommandString.Append(",");
                }
                else
                {
                    _CommandString.Append(") ");
                }
                
            }

            _CommandString.Remove(_CommandString.ToString().Trim().Length - 1, 1); //   ' Remove Last Comma Character
            _CommandString.Append(") VALUES (");

            foreach (DataColumn _Column in MyDataTable.Columns)
            {
                string _ColumnName = _Column.ColumnName;
                string _LastColumn = MyDataTable.Columns[MyDataTable.Columns.Count-1].ColumnName;

                    _CommandString.Append(string.Concat("@", _Column.ColumnName.Replace(" ", "")));

                    if (_ColumnName != _LastColumn)
                    {
                        _CommandString.Append(",");
                    }
                    else
                    {
                        _CommandString.Append(") ");
                    }
            }

            int _result = 1;   //_Command.ExecuteNonQuery();

            _string[0] = MyTableName;
            _string[1] = Convert.ToString(MyConnection.State);
            _string[2] = string.Concat("SQL Query hit ", Convert.ToString(_result), " record(s).");

            _Command.CommandText = _CommandString.ToString();
            
            return _string;
        }
        public string[] SQLUpdate(int ID)
        {
            string[] _string = new string[5];
            StringBuilder _CommandString = new StringBuilder();

            _string[0] = "SQL Update Command....";

            _CommandString.Append(string.Concat("UPDATE ", MyTableName, " SET "));


            foreach (DataColumn _Column in MyDataTable.Columns)
            {
                string _ColumnName = _Column.ColumnName;
                string _LastColumn = MyDataTable.Columns[MyDataTable.Columns.Count - 1].ColumnName;

                if(SkipColumns.Contains(_ColumnName)) {continue;}
                else
                { 
                    _CommandString.Append(string.Concat("[", _Column.ColumnName, "]"));
                    _CommandString.Append("=");
                    _CommandString.Append(string.Concat("@", _Column.ColumnName.Replace(" ","")));


                    if (_ColumnName != _LastColumn)
                    {
                        _CommandString.Append(",");
                    }
                    else
                    {
                        _CommandString.Append(" WHERE ID = @ID");
                    }
                }
            }

            _Command.CommandText = _CommandString.ToString();

            _string[1] = _CommandString.ToString();
            _string[2] = "Insert Command done";

            return _string ;
        }
        public string[] SQLDelete(int _ID)
        {
            string[] _string = new string[5];
            _string[0] = "SQL Delete Command.";
            _Command.CommandText = string.Concat("DELETE FROM ", MyTableName, " SET ID=@id) WHERE ID = @ID;;");
            _string[1] = _Command.CommandText;
            _string[2] = "Insert Command done";
            return _string;
        }
        public string[] SQLDelete(int _ID, string _Where)
        {
            string[] _string = new string[5];
            _string[0] = "SQL Delete Command.";
            _Command.CommandText = string.Concat("DELETE FROM ", MyTableName, " ", _Where);
            _string[1] = _Command.CommandText;
            _string[2] = "Insert Command done";
            return _string;
        }

        //===================================================================

        public string SET_SQLParameters()
        {
            foreach (DataColumn _Columns in MyDataTable.Columns)
            {
                _Command.Parameters.Add(string.Concat("@", _Columns.ColumnName.Replace(" ", "")),  GetDBType(_Columns.DataType));
            }
            return "";
        }


        //==================== Copy from <https://stackoverflow.com/questions/1574867/convert-datacolumn-datatype-to-sqldbtype>
        private SqlDbType GetDBType(System.Type theType)
        {
            //Convert Column Type to DB Type.
            System.Data.SqlClient.SqlParameter p1;
            System.ComponentModel.TypeConverter tc;
            p1 = new System.Data.SqlClient.SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
            {
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            else
            {
                //Try brute force
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception)
                {
                    //Do Nothing; will return NVarChar as default
                }
            }
            return p1.SqlDbType;
        }

        public bool IsConnectionOpen()
        {
            bool _Result = false;
            try
            {
                MyConnection.Open();
                _Result = true;
            }
            catch (Exception ex)
            {
                _Result = false;
                MyMessage = ex.Message;
            }
            return _Result;
        }

        public string[] Save(DataRow _DataRow)
        {
            string[] _string = new string[5];
            _string[0] = "INSERT  / UPDATE A RECORD IN TABLE";

            foreach(DataColumn _Column in _DataRow.Table.Columns)
            {
                if(_Column==null)
                {
                    continue;
                }
                  
                _Command.Parameters["@" + _Column.ColumnName.Replace(" ", "")].Value = _DataRow[_Column.ColumnName];
            }

            MyTableView.RowFilter = "ID=" + _DataRow["ID"].ToString();
            if (MyTableView.Count == 0)
            {
                SQLInsert((int)_DataRow["ID"]);
                _string[1] = "Insert Command will execute.";
            }
            else
            {
                SQLUpdate((int)_DataRow["ID"]);
                _string[2] = "Update Command will execute.";
            }

            if(_string[0]=="Stop")
            {
                MyMessage = "SQL Command is going to executve.";
            }

            _string[3] = _Command.ExecuteNonQuery().ToString() + "Record(s) effected.";
            return _string;
        }

    }
}

using System;
using System.Data;


    public sealed class SafeDataReader : IDataReader
    {
        private readonly IDataReader _dr;

        // To detect redundant calls
        private bool _disposedValue;

        public SafeDataReader(IDataReader dr)
        {
            _dr = dr;
        }

        public void Close()
        {
            _dr.Close();
        }

        public int Depth
        {
            get { return _dr.Depth; }
        }

        public DataTable GetSchemaTable()
        {
            return _dr.GetSchemaTable();
        }

        public bool IsClosed
        {
            get { return _dr.IsClosed; }
        }

        public bool NextResult()
        {
            return _dr.NextResult();
        }

        public bool Read()
        {
            return _dr.Read();
        }

        public int RecordsAffected
        {
            get { return _dr.RecordsAffected; }
        }

        public int FieldCount
        {
            get { return _dr.FieldCount; }
        }

        public bool GetBoolean(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return false;
            }
            return _dr.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could be Byte.MinValue
            }
            return _dr.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could be Long.MinValue
            }
            return _dr.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return char.MinValue;
            }
            return _dr.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
            }
            return _dr.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return _dr.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return _dr.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return DateTime.MinValue;
            }
            return _dr.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Decimal.MinValue
            }
            return _dr.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Double.MinValue
            }
            return _dr.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return _dr.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Single.MinValue
            }
            return _dr.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return Guid.Empty;
            }
            return _dr.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Short.MinValue
            }
            return _dr.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Int32.MinValue
            }
            return _dr.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return 0;
                //Could use Long.MinValue
            }
            return _dr.GetInt64(i);
        }

        public string GetName(int i)
        {
            return _dr.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return _dr.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            if (_dr.IsDBNull(i))
            {
                return string.Empty;
            }
            return _dr.GetString(i);
        }

        public object GetValue(int i)
        {
            return _dr.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return _dr.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return _dr.IsDBNull(i);
        }

        public object this[int i]
        {
            get
            {
                if (_dr.IsDBNull(i))
                {
                    return null;
                }
                return _dr[i];
            }
        }

        public object this[string name]
        {
            get
            {
                if (_dr.IsDBNull(_dr.GetOrdinal(name)))
                {
                    return null;
                }
                return _dr[name];
            }
        }

        #region " IDisposable Support "

        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        // IDisposable
        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: free other state (managed objects).
                }
                // TODO: free your own state (unmanaged objects).
                // TODO: set large fields to null.
            }
            _disposedValue = true;
        }

        #region " Custom methods"

        public DateTime? GetNullableDateTime(string name)
        {
            if (ReferenceEquals(_dr[name], DBNull.Value))
            {
                return null;
            }
            return Convert.ToDateTime(_dr[name]);
        }

        public decimal? GetNullableDecimal(string name)
        {
            if (ReferenceEquals(_dr[name], DBNull.Value))
            {
                return null;
            }
            return Convert.ToDecimal(_dr[name]);
        }

        public int? GetNullableInt32(string name)
        {
            if (ReferenceEquals(_dr[name], DBNull.Value))
            {
                return null;
            }
            return Convert.ToInt32(_dr[name]);
        }

        public bool? GetNullableBoolean(string name)
        {
            if (ReferenceEquals(_dr[name], DBNull.Value))
            {
                return null;
            }
            return Convert.ToBoolean(_dr[name]);
        }

        public Guid GetGuid(string name)
        {
            return GetGuid(_dr.GetOrdinal(name));
        }

        public DateTime GetDateTime(string name)
        {
            return GetDateTime(_dr.GetOrdinal(name));
        }

        public decimal GetDecimal(string name)
        {
            return GetDecimal(_dr.GetOrdinal(name));
        }

        public short GetInt16(string name)
        {
            return GetInt16(_dr.GetOrdinal(name));
        }

        public int GetInt32(string name)
        {
            return GetInt32(_dr.GetOrdinal(name));
        }

        public long GetInt64(string name)
        {
            return GetInt64(_dr.GetOrdinal(name));
        }

        public bool GetBoolean(string name)
        {
            return GetBoolean(_dr.GetOrdinal(name));
        }

        public string GetString(string name)
        {
            return GetString(_dr.GetOrdinal(name));
        }

        #endregion
    }

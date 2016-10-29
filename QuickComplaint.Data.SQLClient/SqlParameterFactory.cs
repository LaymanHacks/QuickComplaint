using System;
using System.Data;
using System.Data.SqlClient;

public class SqlParameterFactory
{
    public static SqlParameter CreateInputParameter(string paramName, SqlDbType dbType, object objValue)
    {
        var param = new SqlParameter(paramName, dbType);

        if (objValue == null)
        {
            param.IsNullable = true;
            param.Value = DBNull.Value;
        }
        else
        {
            param.Value = objValue;
        }

        return param;
    }
}
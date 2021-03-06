//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System.Data;
using System.Data.SqlClient;
using QuickComplaint.Data.DbCommandProvider;

namespace QuickComplaint.Data.SqlDbCommandProvider
{
    public class SqlDbComplaintTypeCommandProvider : IDbComplaintTypeCommandProvider
    {
        public SqlDbComplaintTypeCommandProvider()
        {
            ComplaintTypeDbConnectionHolder = new DbConnectionHolder(DbConnectionName);
        }

        public string DbConnectionName => "QuickComplaintConnection";

        public DbConnectionHolder ComplaintTypeDbConnectionHolder { get; }

        /// <summary>
        ///     Selects one or more records from the ComplaintType table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataDbCommand()
        {
            var command = new SqlCommand("ComplaintType_Select");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Updates one or more records from the ComplaintType table
        /// </summary>
        /// <param name="name" />
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetUpdateDbCommand(string name, int id)
        {
            var command = new SqlCommand("ComplaintType_Update");
            command.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(name))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.NVarChar, name));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.NVarChar, null));
            }
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Deletes one or more records from the ComplaintType table
        /// </summary>
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetDeleteDbCommand(int id)
        {
            var command = new SqlCommand("ComplaintType_Delete");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Inserts a record into the ComplaintType table on the database.
        /// </summary>
        /// <param name="name" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetInsertDbCommand(string name)
        {
            var command = new SqlCommand("ComplaintType_Insert");
            command.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(name))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.NVarChar, name));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.NVarChar, null));
            }
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataPageable returns a IDataReader populated with a subset of data from ComplaintType
        /// </summary>
        /// <param name="sortExpression" />
        /// <param name="page" />
        /// <param name="pageSize" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataPageableDbCommand(string sortExpression, int page, int pageSize)
        {
            var command = new SqlCommand("ComplaintType_GetDataPageable");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar,
                sortExpression));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize));
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetRowCount returns the row count for ComplaintType
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetRowCountDbCommand()
        {
            var command = new SqlCommand("ComplaintType_GetRowCount");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function  GetDataById returns a IDataReader for ComplaintType
        /// </summary>
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByIdDbCommand(int id)
        {
            var command = new SqlCommand("ComplaintType_GetDataById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintTypeDbConnectionHolder.Connection;
            return command;
        }
    }
}
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
    public class SqlDbComplaintCommandProvider : IDbComplaintCommandProvider
    {
        public SqlDbComplaintCommandProvider()
        {
            ComplaintDbConnectionHolder = new DbConnectionHolder(DbConnectionName);
        }

        public string DbConnectionName => "QuickComplaintConnection";

        public DbConnectionHolder ComplaintDbConnectionHolder { get; }

        /// <summary>
        ///     Selects one or more records from the Complaint table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataDbCommand()
        {
            var command = new SqlCommand("Complaint_Select");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Updates one or more records from the Complaint table
        /// </summary>
        /// <param name="complaintTypeId" />
        /// <param name="description" />
        /// <param name="locationDetails" />
        /// <param name="reportingPartyId" />
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetUpdateDbCommand(int complaintTypeId, string description, string locationDetails,
            int reportingPartyId, int id)
        {
            var command = new SqlCommand("Complaint_Update");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ComplaintTypeId", SqlDbType.Int,
                complaintTypeId));
            if (!string.IsNullOrEmpty(description))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Description", SqlDbType.NVarChar,
                    description));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Description", SqlDbType.NVarChar, null));
            }
            if (!string.IsNullOrEmpty(locationDetails))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@LocationDetails", SqlDbType.NVarChar,
                    locationDetails));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@LocationDetails", SqlDbType.NVarChar,
                    null));
            }
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ReportingPartyId", SqlDbType.Int,
                reportingPartyId));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Deletes one or more records from the Complaint table
        /// </summary>
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetDeleteDbCommand(int id)
        {
            var command = new SqlCommand("Complaint_Delete");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Inserts a record into the Complaint table on the database.
        /// </summary>
        /// <param name="complaintTypeId" />
        /// <param name="description" />
        /// <param name="locationDetails" />
        /// <param name="reportingPartyId" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetInsertDbCommand(int complaintTypeId, string description, string locationDetails,
            int reportingPartyId)
        {
            var command = new SqlCommand("Complaint_Insert");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ComplaintTypeId", SqlDbType.Int,
                complaintTypeId));
            if (!string.IsNullOrEmpty(description))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Description", SqlDbType.NVarChar,
                    description));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Description", SqlDbType.NVarChar, null));
            }
            if (!string.IsNullOrEmpty(locationDetails))
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@LocationDetails", SqlDbType.NVarChar,
                    locationDetails));
            }
            else
            {
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@LocationDetails", SqlDbType.NVarChar,
                    null));
            }
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ReportingPartyId", SqlDbType.Int,
                reportingPartyId));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataPageable returns a IDataReader populated with a subset of data from Complaint
        /// </summary>
        /// <param name="sortExpression" />
        /// <param name="page" />
        /// <param name="pageSize" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataPageableDbCommand(string sortExpression, int page, int pageSize)
        {
            var command = new SqlCommand("Complaint_GetDataPageable");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar,
                sortExpression));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetRowCountDbCommand()
        {
            var command = new SqlCommand("Complaint_GetRowCount");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function  GetDataById returns a IDataReader for Complaint
        /// </summary>
        /// <param name="id" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByIdDbCommand(int id)
        {
            var command = new SqlCommand("Complaint_GetDataById");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.Int, id));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataByComplaintTypeId returns a IDataReader for Complaint
        /// </summary>
        /// <param name="complaintTypeId" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByComplaintTypeIdDbCommand(int complaintTypeId)
        {
            var command = new SqlCommand("Complaint_GetDataByComplaintTypeId");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ComplaintTypeId", SqlDbType.Int,
                complaintTypeId));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataBy GetDataByComplaintTypeIdPageable returns a IDataReader populated with a subset of data from
        ///     Complaint
        /// </summary>
        /// <param name="complaintTypeId" />
        /// <param name="sortExpression" />
        /// <param name="page" />
        /// <param name="pageSize" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByComplaintTypeIdPageableDbCommand(int complaintTypeId, string sortExpression,
            int page, int pageSize)
        {
            var command = new SqlCommand("Complaint_GetDataByComplaintTypeIdPageable");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ComplaintTypeId", SqlDbType.Int,
                complaintTypeId));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar,
                sortExpression));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <param name="complaintTypeId" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByComplaintTypeIdRowCountDbCommand(int complaintTypeId)
        {
            var command = new SqlCommand("Complaint_GetDataByComplaintTypeIdRowCount");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ComplaintTypeId", SqlDbType.Int,
                complaintTypeId));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataByReportingPartyId returns a IDataReader for Complaint
        /// </summary>
        /// <param name="reportingPartyId" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByReportingPartyIdDbCommand(int reportingPartyId)
        {
            var command = new SqlCommand("Complaint_GetDataByReportingPartyId");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ReportingPartyId", SqlDbType.Int,
                reportingPartyId));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetDataBy GetDataByReportingPartyIdPageable returns a IDataReader populated with a subset of data from
        ///     Complaint
        /// </summary>
        /// <param name="reportingPartyId" />
        /// <param name="sortExpression" />
        /// <param name="page" />
        /// <param name="pageSize" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByReportingPartyIdPageableDbCommand(int reportingPartyId, string sortExpression,
            int page, int pageSize)
        {
            var command = new SqlCommand("Complaint_GetDataByReportingPartyIdPageable");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ReportingPartyId", SqlDbType.Int,
                reportingPartyId));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.VarChar,
                sortExpression));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page));
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }

        /// <summary>
        ///     Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <param name="reportingPartyId" />
        /// <returns></returns>
        /// <remarks></remarks>
        public IDbCommand GetGetDataByReportingPartyIdRowCountDbCommand(int reportingPartyId)
        {
            var command = new SqlCommand("Complaint_GetDataByReportingPartyIdRowCount");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ReportingPartyId", SqlDbType.Int,
                reportingPartyId));
            command.Connection = (SqlConnection) ComplaintDbConnectionHolder.Connection;
            return command;
        }
    }
}
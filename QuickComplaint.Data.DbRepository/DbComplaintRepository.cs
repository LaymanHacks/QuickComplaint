//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using QuickComplaint.Data;
using QuickComplaint.Domain.Entities;
using QuickComplaint.Data.DbCommandProvider;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using Data;


namespace QuickComplaint.Data.Repository
{
    [DataObject(true)]
    public class DbComplaintRepository : IComplaintRepository, IDisposable
    {

        private readonly IDbComplaintCommandProvider _dbComplaintCommandProvider;
        private DbConnectionHolder _dbConnHolder;

        public DbComplaintRepository(IDbComplaintCommandProvider dbComplaintCommandProvider)
        {
            _dbComplaintCommandProvider = dbComplaintCommandProvider;
            _dbConnHolder = _dbComplaintCommandProvider.ComplaintDbConnectionHolder;
        }

        /// <summary>
        /// Selects one or more records from the Complaint table 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ICollection<Complaint> GetData()
        {
            var command = _dbComplaintCommandProvider.GetGetDataDbCommand();
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Updates one or more records from the Complaint table 
        /// </summary>
        /// <param name="complaintTypeId"></param>
        /// <param name="description"></param>
        /// <param name="locationDetails"></param>
        /// <param name="reportingPartyId"></param>
        /// <param name="id"></param>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(Int32 complaintTypeId, string description, string locationDetails, Int32 reportingPartyId, Int32 id)
        {
            var command = _dbComplaintCommandProvider.GetUpdateDbCommand(complaintTypeId, description, locationDetails, reportingPartyId, id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            command.ExecuteNonQuery();
            _dbConnHolder.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Update(Complaint complaint)
        {
            Update((Int32)complaint.ComplaintTypeId, complaint.Description, complaint.LocationDetails, (Int32)complaint.ReportingPartyId, (Int32)complaint.Id);
        }

        /// <summary>
        /// Deletes one or more records from the Complaint table 
        /// </summary>
        /// <param name="id"></param>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void Delete(Int32 id)
        {
            var command = _dbComplaintCommandProvider.GetDeleteDbCommand(id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            command.ExecuteNonQuery();
            _dbConnHolder.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Delete(Complaint complaint)
        {
            Delete((Int32)complaint.Id);
        }

        /// <summary>
        /// Inserts an entity of Complaint into the database.
        /// </summary>
        /// <param name="complaintTypeId"></param>
        /// <param name="description"></param>
        /// <param name="locationDetails"></param>
        /// <param name="reportingPartyId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Int32 Insert(Int32 complaintTypeId, string description, string locationDetails, Int32 reportingPartyId)
        {
            var command = _dbComplaintCommandProvider.GetInsertDbCommand(complaintTypeId, description, locationDetails, reportingPartyId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public Int32 Insert(Complaint complaint)
        {
            return Insert((Int32)complaint.ComplaintTypeId, complaint.Description, complaint.LocationDetails, (Int32)complaint.ReportingPartyId);
        }

        /// <summary>
        /// Function GetDataPageable returns a IDataReader populated with a subset of data from Complaint
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<Complaint> GetDataPageable(string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbComplaintCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetRowCount();
            var pagedResults = new PagedResult<Complaint>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetRowCount()
        {
            var command = _dbComplaintCommandProvider.GetGetRowCountDbCommand();
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        /// <summary>
        /// Function  GetDataById returns a IDataReader for Complaint
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<Complaint> GetDataById(Int32 id)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByIdDbCommand(id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataByComplaintTypeId returns a IDataReader for Complaint
        /// </summary>
        /// <param name="complaintTypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<Complaint> GetDataByComplaintTypeId(Int32 complaintTypeId)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByComplaintTypeIdDbCommand(complaintTypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataBy GetDataByComplaintTypeIdPageable returns a IDataReader populated with a subset of data from Complaint
        /// </summary>
        /// <param name="complaintTypeId"></param>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<Complaint> GetDataByComplaintTypeIdPageable(Int32 complaintTypeId, string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByComplaintTypeIdPageableDbCommand(complaintTypeId, sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetDataByComplaintTypeIdRowCount(complaintTypeId);
            var pagedResults = new PagedResult<Complaint>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <param name="complaintTypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetDataByComplaintTypeIdRowCount(Int32 complaintTypeId)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByComplaintTypeIdRowCountDbCommand(complaintTypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        /// <summary>
        /// Function GetDataByReportingPartyId returns a IDataReader for Complaint
        /// </summary>
        /// <param name="reportingPartyId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<Complaint> GetDataByReportingPartyId(Int32 reportingPartyId)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByReportingPartyIdDbCommand(reportingPartyId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataBy GetDataByReportingPartyIdPageable returns a IDataReader populated with a subset of data from Complaint
        /// </summary>
        /// <param name="reportingPartyId"></param>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<Complaint> GetDataByReportingPartyIdPageable(Int32 reportingPartyId, string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByReportingPartyIdPageableDbCommand(reportingPartyId, sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<Complaint>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new Complaint(reader.GetInt32("Id"), reader.GetInt32("ComplaintTypeId"), reader.GetString("Description"), reader.GetString("LocationDetails"), reader.GetInt32("ReportingPartyId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetDataByReportingPartyIdRowCount(reportingPartyId);
            var pagedResults = new PagedResult<Complaint>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for Complaint
        /// </summary>
        /// <param name="reportingPartyId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetDataByReportingPartyIdRowCount(Int32 reportingPartyId)
        {
            var command = _dbComplaintCommandProvider.GetGetDataByReportingPartyIdRowCountDbCommand(reportingPartyId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        #region "IDisposable Support"
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    switch (_dbConnHolder.Connection.State)
                    {
                        case ConnectionState.Open:
                            _dbConnHolder.Close();
                            break;
                    }
                    _dbConnHolder = null;
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
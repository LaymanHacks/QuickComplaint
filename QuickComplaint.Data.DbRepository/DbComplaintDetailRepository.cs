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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using QuickComplaint.Data.DbCommandProvider;
using QuickComplaint.Data.Entities;

namespace QuickComplaint.Data.Repository
{
    [DataObject(true)]
    public class DbComplaintDetailRepository : IComplaintDetailRepository, IDisposable
    {
        private readonly IDbComplaintDetailCommandProvider _dbComplaintDetailCommandProvider;
        private DbConnectionHolder _dbConnHolder;

        public DbComplaintDetailRepository(IDbComplaintDetailCommandProvider dbComplaintDetailCommandProvider)
        {
            _dbComplaintDetailCommandProvider = dbComplaintDetailCommandProvider;
            _dbConnHolder = _dbComplaintDetailCommandProvider.ComplaintDetailDbConnectionHolder;
        }

        /// <summary>
        ///     Selects one or more records from the ComplaintDetails table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ICollection<ComplaintDetail> GetData()
        {
            var command = _dbComplaintDetailCommandProvider.GetGetDataDbCommand();
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ComplaintDetail>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ComplaintDetail(reader.GetInt32("Id"), reader.GetString("Name"),
                    reader.GetString("Description"), reader.GetString("LocationDetails"),
                    reader.GetString("ReportingParty"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;
        }

        /// <summary>
        ///     Function GetDataPageable returns a IDataReader populated with a subset of data from ComplaintDetails
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<ComplaintDetail> GetDataPageable(string sortExpression, int page, int pageSize)
        {
            var command = _dbComplaintDetailCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ComplaintDetail>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ComplaintDetail(reader.GetInt32("Id"), reader.GetString("Name"),
                    reader.GetString("Description"), reader.GetString("LocationDetails"),
                    reader.GetString("ReportingParty"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetRowCount();
            var pagedResults = new PagedResult<ComplaintDetail>(page, pageSize, totalCount, entList);
            return pagedResults;
        }

        /// <summary>
        ///     Function GetRowCount returns the row count for ComplaintDetails
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int GetRowCount()
        {
            var command = _dbComplaintDetailCommandProvider.GetGetRowCountDbCommand();
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
            if (!disposedValue)
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
            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
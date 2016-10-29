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
    public class DbReportingPartyRepository : IReportingPartyRepository, IDisposable
    {

        private readonly IDbReportingPartyCommandProvider _dbReportingPartyCommandProvider;
        private DbConnectionHolder _dbConnHolder;

        public DbReportingPartyRepository(IDbReportingPartyCommandProvider dbReportingPartyCommandProvider)
        {
            _dbReportingPartyCommandProvider = dbReportingPartyCommandProvider;
            _dbConnHolder = _dbReportingPartyCommandProvider.ReportingPartyDbConnectionHolder;
        }

        /// <summary>
        /// Selects one or more records from the ReportingParty table 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ICollection<ReportingParty> GetData()
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataDbCommand();
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Updates one or more records from the ReportingParty table 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phone1"></param>
        /// <param name="phone1TypeId"></param>
        /// <param name="phone2"></param>
        /// <param name="phone2TypeId"></param>
        /// <param name="id"></param>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(string name, string email, string phone1, Int32?  phone1TypeId, string phone2, Int32?  phone2TypeId, Int32 id)
        {
            var command = _dbReportingPartyCommandProvider.GetUpdateDbCommand(name, email, phone1, phone1TypeId, phone2, phone2TypeId, id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            command.ExecuteNonQuery();
            _dbConnHolder.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Update(ReportingParty reportingParty)
        {
            Update((string)reportingParty.Name, reportingParty.Email, reportingParty.Phone1, reportingParty.Phone1TypeId, reportingParty.Phone2, reportingParty.Phone2TypeId, (Int32)reportingParty.Id);
        }

        /// <summary>
        /// Deletes one or more records from the ReportingParty table 
        /// </summary>
        /// <param name="id"></param>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void Delete(Int32 id)
        {
            var command = _dbReportingPartyCommandProvider.GetDeleteDbCommand(id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            command.ExecuteNonQuery();
            _dbConnHolder.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Delete(ReportingParty reportingParty)
        {
            Delete((Int32)reportingParty.Id);
        }

        /// <summary>
        /// Inserts an entity of ReportingParty into the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phone1"></param>
        /// <param name="phone1TypeId"></param>
        /// <param name="phone2"></param>
        /// <param name="phone2TypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public Int32 Insert(string name, string email, string phone1, Int32?  phone1TypeId, string phone2, Int32?  phone2TypeId)
        {
            var command = _dbReportingPartyCommandProvider.GetInsertDbCommand(name, email, phone1, phone1TypeId, phone2, phone2TypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public Int32 Insert(ReportingParty reportingParty)
        {
            return Insert((string)reportingParty.Name, reportingParty.Email, reportingParty.Phone1, reportingParty.Phone1TypeId, reportingParty.Phone2, reportingParty.Phone2TypeId);
        }

        /// <summary>
        /// Function GetDataPageable returns a IDataReader populated with a subset of data from ReportingParty
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<ReportingParty> GetDataPageable(string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetRowCount();
            var pagedResults = new PagedResult<ReportingParty>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for ReportingParty
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetRowCount()
        {
            var command = _dbReportingPartyCommandProvider.GetGetRowCountDbCommand();
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        /// <summary>
        /// Function  GetDataById returns a IDataReader for ReportingParty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<ReportingParty> GetDataById(Int32 id)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByIdDbCommand(id);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataByPhone1TypeId returns a IDataReader for ReportingParty
        /// </summary>
        /// <param name="phone1TypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<ReportingParty> GetDataByPhone1TypeId(Int32 phone1TypeId)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone1TypeIdDbCommand(phone1TypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataBy GetDataByPhone1TypeIdPageable returns a IDataReader populated with a subset of data from ReportingParty
        /// </summary>
        /// <param name="phone1TypeId"></param>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<ReportingParty> GetDataByPhone1TypeIdPageable(Int32 phone1TypeId, string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone1TypeIdPageableDbCommand(phone1TypeId, sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetDataByPhone1TypeIdRowCount(phone1TypeId);
            var pagedResults = new PagedResult<ReportingParty>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for ReportingParty
        /// </summary>
        /// <param name="phone1TypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetDataByPhone1TypeIdRowCount(Int32 phone1TypeId)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone1TypeIdRowCountDbCommand(phone1TypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var returnValue = Convert.ToInt32(command.ExecuteScalar());
            _dbConnHolder.Close();
            return returnValue;

        }

        /// <summary>
        /// Function GetDataByPhone2TypeId returns a IDataReader for ReportingParty
        /// </summary>
        /// <param name="phone2TypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ICollection<ReportingParty> GetDataByPhone2TypeId(Int32 phone2TypeId)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone2TypeIdDbCommand(phone2TypeId);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            return entList;

        }

        /// <summary>
        /// Function GetDataBy GetDataByPhone2TypeIdPageable returns a IDataReader populated with a subset of data from ReportingParty
        /// </summary>
        /// <param name="phone2TypeId"></param>
        /// <param name="sortExpression"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PagedResult<ReportingParty> GetDataByPhone2TypeIdPageable(Int32 phone2TypeId, string sortExpression, Int32 page, Int32 pageSize)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone2TypeIdPageableDbCommand(phone2TypeId, sortExpression, page, pageSize);
            command.Connection = _dbConnHolder.Connection;
            _dbConnHolder.Open();
            var entList = new Collection<ReportingParty>();
            var reader = new SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection));
            while (reader.Read())
            {
                var tempEntity = new ReportingParty(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("Email"), reader.GetString("Phone1"), reader.GetNullableInt32("Phone1TypeId"), reader.GetString("Phone2"), reader.GetNullableInt32("Phone2TypeId"));
                entList.Add(tempEntity);
            }
            reader.Close();
            var totalCount = GetDataByPhone2TypeIdRowCount(phone2TypeId);
            var pagedResults = new PagedResult<ReportingParty>(page, pageSize, totalCount, entList);
            return pagedResults;

        }

        /// <summary>
        /// Function GetRowCount returns the row count for ReportingParty
        /// </summary>
        /// <param name="phone2TypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetDataByPhone2TypeIdRowCount(Int32 phone2TypeId)
        {
            var command = _dbReportingPartyCommandProvider.GetGetDataByPhone2TypeIdRowCountDbCommand(phone2TypeId);
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
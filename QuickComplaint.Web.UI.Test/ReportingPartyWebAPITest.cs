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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuickComplaint.Data.Repository;
using QuickComplaint.Domain.Entities;
using QuickComplaint.Web.UI.Controllers.Api;

namespace QuickComplaint.Web.UI.Test.Controllers.Api
{
    [TestClass()]
    public class ReportingPartyApiControllerTests
    {
        
        private Mock<IReportingPartyRepository> _repository;

        private List<ReportingParty> _repositoryList = new List<ReportingParty>
        {
        //TODO Initialize test data
            new ReportingParty()
        };

        private ReportingPartyApiController _target;
        
        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IReportingPartyRepository>();
            _target = new ReportingPartyApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/ReportingParties") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }
   
                [TestMethod()]
        public void GetDataTest() 
        {
            _repository
                 .Setup(it => it.GetData())
                     .Returns(_repositoryList);
                
            var result = _target.GetData().ToList();
             Assert.AreEqual(_repositoryList.ToList().Count, result.Count);
        }

        [TestMethod()]
        public void Update_Should_Update_A_ReportingParty() 
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Int32?>(), It.IsAny<String>(), It.IsAny<Int32?>(), It.IsAny<Int32>()))
                 .Callback<String, String, String, Int32?, String, Int32?, Int32>((name, email, phone1, phone1TypeId, phone2, phone2TypeId, id) => 
            { 
                 var tReportingParty = _repositoryList.Find(x => x.Id==id);
                 tReportingParty.Name = name; 
                 tReportingParty.Email = email; 
                 tReportingParty.Phone1 = phone1; 
                 tReportingParty.Phone1TypeId = phone1TypeId; 
                 tReportingParty.Phone2 = phone2; 
                 tReportingParty.Phone2TypeId = phone2TypeId; 
            });
            var tempReportingParty = _repositoryList.Find(x => x.Id==id);
            var testReportingParty = new ReportingParty {
                 Id = tempReportingParty.Id, 
                 Name = tempReportingParty.Name, 
                 Email = tempReportingParty.Email, 
                 Phone1 = tempReportingParty.Phone1, 
                 Phone1TypeId = tempReportingParty.Phone1TypeId, 
                 Phone2 = tempReportingParty.Phone2, 
                 Phone2TypeId = tempReportingParty.Phone2TypeId};
            
            //TODO change something on testReportingParty
            //testReportingParty.oldValue = newValue; 
            _target.Update(testReportingParty);
            //Assert.AreEqual(newValue, _repositoryList.Find(x => x.Id==1).oldValue);
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void Delete_Should_Delete_A_ReportingParty() 
        {
            _repository
                 .Setup(it => it.Delete(It.IsAny<Int32>()))  
                 .Callback<Int32>((id) => 
                 { 
                      var i = _repositoryList.FindIndex(q => q.Id==id);
                      _repositoryList.RemoveAt(i);
                 });
            var iniCount = _repositoryList.Count();
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void Insert_Should_Insert_A_ReportingParty() 
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Int32?>(), It.IsAny<String>(), It.IsAny<Int32?>()))
                 .Returns<String, String, String, Int32?, String, Int32?>((name, email, phone1, phone1TypeId, phone2, phone2TypeId) => 
            { 
                 _repositoryList.Add(new  ReportingParty (name, email, phone1, phone1TypeId, phone2, phone2TypeId));
            });
            
            //TODO insert values 
            _target.Insert(new ReportingParty (name, email, phone1, phone1TypeId, phone2, phone2TypeId));
            //Assert.AreEqual(11, _repositoryList.Count());
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataPageableTest()
        {
            PagedResult<ReportingParty> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Id));
                              break;
                          case  "Name":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Name));
                              break;
                          case  "Email":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Email));
                              break;
                          case  "Phone1":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1));
                              break;
                          case  "Phone1TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1TypeId));
                              break;
                          case  "Phone2":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2));
                              break;
                          case  "Phone2TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2TypeId));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetDataByIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataById(It.IsAny<Int32>()))
                     .Returns<Int32>((id) => 
                 { 
                      return _repositoryList.Where(x => x.Id==id).ToList();
                 });
                
            var result = _target.GetDataById(idValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.Id==idValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByPhone1TypeIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByPhone1TypeId(It.IsAny<Int32>()))
                     .Returns<Int32>((phone1TypeId) => 
                 { 
                      return _repositoryList.Where(x => x.Phone1TypeId==phone1TypeId).ToList();
                 });
                
            var result = _target.GetDataByPhone1TypeId(phone1TypeIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.Phone1TypeId==phone1TypeIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByPhone1TypeIdPageableTest()
        {
            PagedResult<ReportingParty> expectedResult;

            _repository
                 .Setup(it => it.GetDataByPhone1TypeIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((phone1TypeId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList.Where(x => x.Phone1TypeId==phone1TypeId);
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Id));
                              break;
                          case  "Name":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Name));
                              break;
                          case  "Email":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Email));
                              break;
                          case  "Phone1":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1));
                              break;
                          case  "Phone1TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1TypeId));
                              break;
                          case  "Phone2":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2));
                              break;
                          case  "Phone2TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2TypeId));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByPhone1TypeIdRowCount(phone1TypeId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByPhone1TypeIdPageable(Phone1TypeIdValue, "Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.Phone1TypeId==phone1TypeId).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.Phone1TypeId==phone1TypeId).OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetDataByPhone2TypeIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByPhone2TypeId(It.IsAny<Int32>()))
                     .Returns<Int32>((phone2TypeId) => 
                 { 
                      return _repositoryList.Where(x => x.Phone2TypeId==phone2TypeId).ToList();
                 });
                
            var result = _target.GetDataByPhone2TypeId(phone2TypeIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.Phone2TypeId==phone2TypeIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByPhone2TypeIdPageableTest()
        {
            PagedResult<ReportingParty> expectedResult;

            _repository
                 .Setup(it => it.GetDataByPhone2TypeIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((phone2TypeId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList.Where(x => x.Phone2TypeId==phone2TypeId);
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Id));
                              break;
                          case  "Name":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Name));
                              break;
                          case  "Email":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Email));
                              break;
                          case  "Phone1":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1));
                              break;
                          case  "Phone1TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone1TypeId));
                              break;
                          case  "Phone2":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2));
                              break;
                          case  "Phone2TypeId":
                              query = new List<ReportingParty>(query.OrderBy(q => q.Phone2TypeId));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByPhone2TypeIdRowCount(phone2TypeId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByPhone2TypeIdPageable(Phone2TypeIdValue, "Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.Phone2TypeId==phone2TypeId).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.Phone2TypeId==phone2TypeId).OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }


    }
}
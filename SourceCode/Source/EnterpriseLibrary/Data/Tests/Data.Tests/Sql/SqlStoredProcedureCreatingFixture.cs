﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Microsoft.Practices.EnterpriseLibrary.Data.Sql.Tests
{
    [TestClass]
    public class SqlStoredProcedureCreatingFixture : StoredProcedureCreationBase
    {
        [TestInitialize]
        public void SetUp()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory(TestConfigurationSource.CreateConfigurationSource());
            db = factory.CreateDefault();
            CompleteSetup(db);
        }
        [TestCleanup]
        public void TearDown()
        {
            Cleanup();
        }
        protected override void CreateStoredProcedure()
        {
            string storedProcedureCreation = "CREATE procedure [TestProc] " +
                                             "(@vCount int output, @vCustomerId varchar(15)) AS " +
                                             "set @vCount = (select count(*) from Orders where CustomerId = @vCustomerId)";
            DbCommand command = db.GetSqlStringCommand(storedProcedureCreation);
            db.ExecuteNonQuery(command);
        }
        protected override void DeleteStoredProcedure()
        {
            string storedProcedureDeletion = "Drop procedure TestProc";
            DbCommand command = db.GetSqlStringCommand(storedProcedureDeletion);
            db.ExecuteNonQuery(command);
        }
        [TestMethod]
        public void CanGetOutputValueFromStoredProcedure()
        {
            baseFixture.CanGetOutputValueFromStoredProcedure();
        }
        [TestMethod]
        public void CanGetOutputValueFromStoredProcedureWithCachedParameters()
        {
            baseFixture.CanGetOutputValueFromStoredProcedureWithCachedParameters();
        }
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ArgumentExceptionWhenThereAreTooFewParameters()
        {
            baseFixture.ArgumentExceptionWhenThereAreTooFewParameters();
        }
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ArgumentExceptionWhenThereAreTooManyParameters()
        {
            baseFixture.ArgumentExceptionWhenThereAreTooFewParameters();
        }
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionThrownWhenReadingParametersFromCacheWithTooFewParameterValues()
        {
            baseFixture.ExceptionThrownWhenReadingParametersFromCacheWithTooFewParameterValues();
        }
    }
}

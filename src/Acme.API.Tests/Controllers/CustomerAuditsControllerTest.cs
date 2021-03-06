﻿using System;
using System.Linq;
using System.Web.Http;
using Acme.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.API.Controllers;

namespace Acme.API.Tests.Controllers
{
    [TestClass]
    public class CustomerAuditsControllerTest
    {
        [TestMethod]
        public void Given_Get_call_When_repos_and_data_are_valid_return_data()
        {
            // Arrange
            var mockCustomerAuditRepo = Mocks.GetMockCustomerAuditRepo().Object;
            var mockGenderRepo = Mocks.GetMockGenderRepo().Object;
            var mockCategoryRepo = Mocks.GetMockCategoryRepo().Object;
            var mockCountryRepo = Mocks.GetMockCountryRepo().Object;

            var controller = new CustomerAuditsController(
                mockCustomerAuditRepo,
                mockGenderRepo,
                mockCategoryRepo,
                mockCountryRepo);

            var expectedCount = 3;

            // Act
            var result = controller.Get();

            // Assert
            Assert.AreEqual(expectedCount, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void Given_Get_call_When_repos_and_data_are_valid_except_for_empty_country_repo_then_expect_exception()
        {
            // Arrange
            var mockCustomerAuditRepo = Mocks.GetMockCustomerAuditRepo().Object;
            var mockGenderRepo = Mocks.GetMockGenderRepo().Object;
            var mockCategoryRepo = Mocks.GetMockCategoryRepo().Object;
            var mockEmptyCountryRepo = Mocks.GetMockEmptyCountryRepo().Object;

            var controller = new CustomerAuditsController(
                mockCustomerAuditRepo,
                mockGenderRepo,
                mockCategoryRepo,
                mockEmptyCountryRepo);

            // Act
            controller.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_customerauditrepo_argumentnullexception_should_be_thrown()
        {
            new CustomerAuditsController(
                null, 
                new GenderRepository(), 
                new CategoryRepository(), 
                new CountryRepository());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_genderrepo_argumentnullexception_should_be_thrown()
        {
            new CustomerAuditsController(
                new CustomerAuditRepository(), 
                null, 
                new CategoryRepository(), 
                new CountryRepository());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_categoryrepo_argumentnullexception_should_be_thrown()
        {
            new CustomerAuditsController(
                new CustomerAuditRepository(), 
                new GenderRepository(), 
                null, 
                new CountryRepository());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_countryrepo_argumentnullexception_should_be_thrown()
        {
            new CustomerAuditsController(
                new CustomerAuditRepository(), 
                new GenderRepository(), 
                new CategoryRepository(), 
                null);
        }
    }
}

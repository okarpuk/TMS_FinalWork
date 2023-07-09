using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWork.Models;
using FinalWork.Utilites.Helpers;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NLog;

namespace FinalWork.Tests.API
{
    public class RunApiTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Run validRunRequest = TestDataHelper.GetRunRequest("GetValidRunRequest.json");
        public ResultRun validRunExpectedResponse = TestDataHelper.GetRunResponse("GetValidRunResponse.json");

        public Run createValidRunExpectedResponse = TestDataHelper.AddTestRun("CreateValidRun.json");

        [Test]
        public void TEST_3_GetValidRun()
        {
            var actualValidRun = _runService.GetRun(validRunRequest.Id);
            _logger.Info("Actual Valid Run: " + actualValidRun);
            _logger.Info("Expected Valid Run: " + validRunExpectedResponse);

            Assert.Multiple(() =>
            {
                Assert.That(actualValidRun.Result.Name, Is.EqualTo(validRunExpectedResponse.Result.Name));
                Assert.That(actualValidRun.Result.Project_Id, Is.EqualTo(validRunExpectedResponse.Result.Project_Id));
            });
        }

        [Test]
        public void TEST_4_AddValidRun()
        {
            var actualValidRun = _runService.AddRun(createValidRunExpectedResponse);
            _logger.Info("Actual Valid Run: " + actualValidRun);
            _logger.Info("Expected Valid Run: " + createValidRunExpectedResponse);

            Assert.That(actualValidRun.StatusCode.ToString(), Is.EqualTo("Created"));
        }
    }
}

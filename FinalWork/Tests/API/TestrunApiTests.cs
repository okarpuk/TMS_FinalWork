using FinalWork.Models;
using FinalWork.Utilites.Helpers;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NLog;

namespace FinalWork.Tests.API
{
    public class TestrunApiTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Run validRunRequest = TestDataHelper.GetRunRequest("GetValidRunRequest.json");
        public ResultRun validRunExpectedResponse = TestDataHelper.GetRunResponse("GetValidRunResponse.json");

        public Run createValidRunExpectedResponse = TestDataHelper.AddTestRun("CreateValidRun.json");

        [Test(Description = "This test gets valid test run via API")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("GetValidTestRun")]
        [AllureIssue("TestmoIssue_3")]
        [AllureTms("TesmoTestCase_3")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
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

        [Test(Description = "This test creates valid test run via API")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("AddValidTestRun")]
        [AllureIssue("TestmoIssue_4")]
        [AllureTms("TesmoTestCase_4")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void TEST_4_AddValidRun()
        {
            var actualValidRun = _runService.AddRun(createValidRunExpectedResponse);
            _logger.Info("Actual Valid Run: " + actualValidRun);
            _logger.Info("Expected Valid Run: " + createValidRunExpectedResponse);

            Assert.That(actualValidRun.StatusCode.ToString(), Is.EqualTo("Created"));
        }
    }
}

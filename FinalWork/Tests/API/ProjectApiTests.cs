using Newtonsoft.Json.Linq;
using FinalWork.Models;
using FinalWork.Utilites.Helpers;
using RestSharp;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NLog;

namespace FinalWork.Tests.API
{
    public class ProjectApiTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Project validProjectRequest = TestDataHelper.GetProjectRequest("GetValidProjectRequest.json");
        public ResultProject validProjectExpectedResponse = TestDataHelper.GetProjectResponse("GetValidProjectResponse.json");

        public Project invalidProjectRequest = TestDataHelper.GetProjectRequest("GetInvalidProjectRequest.json");
        public Project invalidProjectExpectedResponse = TestDataHelper.GetInvalidProjectResponse("GetInvalidProjectResponse.json");

        [Test]
        public void TEST_1_GetValidProject()
        {
            var actualValidProject = _projectService.GetProject(validProjectRequest.Id);
            _logger.Info("Actual Valid Project: " + actualValidProject);
            _logger.Info("Expected Valid Project: " + validProjectExpectedResponse);

            Assert.Multiple(() =>
            {
                Assert.That(actualValidProject.Result.Id, Is.EqualTo(validProjectExpectedResponse.Result.Id));
                Assert.That(actualValidProject.Result.Name, Is.EqualTo(validProjectExpectedResponse.Result.Name));
                Assert.That(actualValidProject.Result.Note, Is.EqualTo(validProjectExpectedResponse.Result.Note));
            });
        }

        [Test]
        public void TEST_2_GetInvalidProject()
        {
            var invalidActualProject = _projectService.GetInvalidProject(invalidProjectExpectedResponse.Id);
            _logger.Info("Actual Invalid Project: " + invalidActualProject);
            _logger.Info("Expected Invalid Project: " + invalidProjectExpectedResponse);

            Assert.That(invalidActualProject.Message, Is.EqualTo(invalidProjectExpectedResponse.Message));
        }
    }
}

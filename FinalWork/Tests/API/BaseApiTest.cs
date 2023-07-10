using FinalWork.Clients;
using FinalWork.Services;
using NUnit.Allure.Core;

namespace FinalWork.Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected ProjectService _projectService;
        protected RunService _runService;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
            _runService = new RunService(_apiClient);
        }
    }
}

using RestSharp;
using FinalWork.Clients;
using FinalWork.Models;
using FinalWork.Utilites.Configuration;

namespace FinalWork.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(ApiClient apiClient) : base(apiClient)
        {
        }

        public ResultProject GetProject(int id)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", id);

            return _apiClient.Execute<ResultProject>(request);
        }

        public Project GetInvalidProject(int id)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", id);

            return _apiClient.Execute<Project>(request);
        }
    }
}

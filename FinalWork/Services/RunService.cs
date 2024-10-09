using RestSharp;
using FinalWork.Clients;
using FinalWork.Models;
using FinalWork.Utilites.Configuration;

namespace FinalWork.Services
{
    public class RunService : BaseService
    {
        public RunService(ApiClient apiClient) : base(apiClient)
        {
        }

        public ResultRun GetRun(int id)
        {
            var request = new RestRequest(Endpoints.GET_RUN)
                .AddUrlSegment("run_id", id);

            return _apiClient.Execute<ResultRun>(request); ;
        }

        public RestResponse AddRun(Run run)
        {
            var request = new RestRequest(Endpoints.ADD_RUN, Method.Post)
                .AddUrlSegment("project_id", run.Project_Id)
                .AddHeader("Content-Type", "application/json")
                .AddBody(run);

            return _apiClient.Execute(request);
        }
    }
}

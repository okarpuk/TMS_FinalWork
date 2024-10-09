using FinalWork.Models;

namespace FinalWork.Utilites.Helpers
{
    public class TestDataHelper
    {
        public static Project GetProjectRequest(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Project>();
        }

        public static ResultProject GetProjectResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<ResultProject>();
        }

        public static Project GetInvalidProjectResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Project>();
        }

        public static Run GetRunRequest(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Run>();
        }

        public static ResultRun GetRunResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<ResultRun>();
        }

        public static Run AddTestRun(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Run>();
        }
    }
}
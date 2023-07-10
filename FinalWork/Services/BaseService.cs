using FinalWork.Clients;

namespace FinalWork.Services
{
    public class BaseService
    {
        protected ApiClient _apiClient;

        public BaseService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}

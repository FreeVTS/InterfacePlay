using System.Net;

namespace InterfacePlay
{
    public class RestClient : IRestClient
    {
        public void AddRestRequest(RestRequest restRequest)
        {
            MakeRealCallWithRestServer(restRequest);
        }

        public event OnRestServerResponded RestServerResponded;

        private void MakeRealCallWithRestServer(RestRequest restRequest)
        {
            var status = MakeRequest(restRequest);
            SendStatusToCaller(status);
        }

        private void SendStatusToCaller(HttpStatusCode status)
        {
            var restEvent = new RestEvent()
            {
                HttpStatusCode = status,
                RestClientName = "RestClient"
            };
            RestServerResponded?.Invoke(this, restEvent);
        }

        private HttpStatusCode MakeRequest(RestRequest restRequest) => HttpStatusCode.OK;
    }
}

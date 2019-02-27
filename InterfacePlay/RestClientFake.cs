using System.Net;

namespace InterfacePlay
{
    public class RestClientFake : IRestClient
    {
        public void AddRestRequest(RestRequest restRequest)
        {
            MakeFakeCallWithRestServer(restRequest);
        }

        public event OnRestServerResponded RestServerResponded;

        private void MakeFakeCallWithRestServer(RestRequest restRequest)
        {
            var status = MakeRequest(restRequest);
            SendStatusToCaller(status);
        }

        private void SendStatusToCaller(HttpStatusCode status)
        {
            var restEvent = new RestEvent()
            {
                HttpStatusCode = status,
                RestClientName = "RestClientFake"
            };
            RestServerResponded?.Invoke(this, restEvent);
        }

        private HttpStatusCode MakeRequest(RestRequest restRequest) => HttpStatusCode.OK;
    }
}

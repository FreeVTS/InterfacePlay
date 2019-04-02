using System.Net;

namespace InterfacePlay
{
    public class ConsumerDependencyInjection
    {
        private const string request = "http://127.0.0.1/queryThat?option=this";

        private IRestClient restClient;
        private ParameterSet _parameterSet;

        public ConsumerDependencyInjection(ParameterSet parameterSet, IRestClient restClient)
        {
            _parameterSet = parameterSet;
            InitializeComponent(restClient);
        }

        public void SendRequest()
        {
            var restRequest = new RestRequest()
            {
                Request = request
            };
            restClient.AddRestRequest(restRequest);
        }

        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.BadRequest;

        public string RestClientName { get; set; }

        private void InitializeComponent(IRestClient restClient)
        {

            restClient.RestServerResponded += (sender, restEvent) =>
            {
                HttpStatusCode = restEvent.HttpStatusCode;
                RestClientName = restEvent.RestClientName;
            };
        }
    }
}

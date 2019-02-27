using System.Net;

namespace InterfacePlay
{
    public class ConsumerAvecFactory
    {
        private const string request = "http://127.0.0.1/queryThat?option=this";

        private IRestClient restClient;
        private ParameterSet _parameterSet;

        public ConsumerAvecFactory(ParameterSet parameterSet)
        {
            _parameterSet = parameterSet;
            InitializeComponent();
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

        private void InitializeComponent()
        {
            restClient = RestClientFactory.CreateRestClient(_parameterSet.RestClientType);

            restClient.RestServerResponded += delegate (object sender, RestEvent restEvent)
            {
                HttpStatusCode = restEvent.HttpStatusCode;
                RestClientName = restEvent.RestClientName;
            };
        }
    }

    public class ParameterSet
    {
        public RestClientType RestClientType { get; set; }
    }
}

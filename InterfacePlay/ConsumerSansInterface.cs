using System.Net;

namespace InterfacePlay
{
    public class ConsumerSansInterface
    {
        private const string request = "http://127.0.0.1/queryThat?option=this";

        private RestClient restClient = new RestClient();

        public ConsumerSansInterface()
        {
            InitializeComponent();
            SendRequest();
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
            restClient.RestServerResponded += (sender, restEvent) =>
            {
                HttpStatusCode = restEvent.HttpStatusCode;
                RestClientName = restEvent.RestClientName;
            };
        }
    }
}

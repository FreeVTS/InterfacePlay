using System.Net;

namespace InterfacePlay
{
    public class ConsumerAvecInterface
    {
        private const string request = "http://127.0.0.1/queryThat?option=this";

        private IRestClient restClient = new RestClient();

        public ConsumerAvecInterface()
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
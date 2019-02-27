namespace InterfacePlay
{
    public enum RestClientType { Real, Fake };

    public static class RestClientFactory
    {
        public static IRestClient CreateRestClient(RestClientType restClientType)
        {
            IRestClient restClient = new RestClientFake();
            switch (restClientType)
            {
                case RestClientType.Real:
                    restClient = new RestClient();
                    break;
            }
            return restClient;
        }
    }
}

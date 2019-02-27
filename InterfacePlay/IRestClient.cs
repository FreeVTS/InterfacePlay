namespace InterfacePlay
{
    public interface IRestClient
    {
        event OnRestServerResponded RestServerResponded;

        void AddRestRequest(RestRequest restRequest);
    }
}
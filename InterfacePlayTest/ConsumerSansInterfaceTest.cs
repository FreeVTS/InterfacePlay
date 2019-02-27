using InterfacePlay;
using System.Net;
using Xunit;

namespace InterfacePlayTest
{
    public class ConsumerSansInterfaceTest
    {
        [Fact]
        public void ConsumerSansInterface_UseRealClient()
        {
            //Arrange
            var consumer = new ConsumerSansInterface();
            const string restClientName = "RestClient";

            //Act
            consumer.SendRequest();

            //Assert
            Assert.Equal(HttpStatusCode.OK, consumer.HttpStatusCode);
            Assert.Equal(restClientName, consumer.RestClientName);
        }
    }
}

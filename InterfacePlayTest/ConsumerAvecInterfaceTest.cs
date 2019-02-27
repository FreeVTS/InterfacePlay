using InterfacePlay;
using System.Net;
using Xunit;

namespace InterfacePlayTest
{
    public class ConsumerAvecInterfaceTest
    {
        [Fact]
        public void ConsumerAvecInterface_UseFakeClient()
        {
            //Arrange
            ParameterSet parameterSet = new ParameterSet()
            {
                RestClientType = RestClientType.Fake
            };
            var consumer = new ConsumerAvecFactory(parameterSet);
            const string restClientName = "RestClientFake";

            //Act
            consumer.SendRequest();

            //Assert
            Assert.Equal(HttpStatusCode.OK, consumer.HttpStatusCode);
            Assert.Equal(restClientName, consumer.RestClientName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePlay
{
    public class InterfacePlay
    {
        public InterfacePlay()
        {
            InjectDependency();
        }

        private void InjectDependency()
        {
            var parameterSet = new ParameterSet();
            var restClient = new RestClientFake();
            var consumerDepInjected = new ConsumerDependencyInjection(parameterSet, restClient);
        }
    }
}

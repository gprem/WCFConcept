using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proplanner.ServiceModel
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    namespace ProxyWrapperTesting
    {
        public class ProxyWrapper<T> where T : ICommunicationObject
        {
            public T ProxyInterface { get; private set; }

            public ProxyWrapper(T proxyInterface)
            {
                this.ProxyInterface = proxyInterface;
            }

            public void Execute(Action<T> action)
            {
                T proxy = ProxyInterface;

                action(proxy);

                proxy.Close();
            }

            public TResult Execute<TResult>(Func<T, TResult> function)
            {
                T proxy = ProxyInterface;

                var result = function(proxy);

                proxy.Close();

                return result;
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProLINK.Data.Entity;
using Proplanner;
using System.ServiceModel;

namespace ProLINK.Data
{
    [ServiceContract]
    public interface IProcess : IWCFServiceBase
    {
        [OperationContract]
        Routing GetRouting(string id);

        [OperationContract]
        int GetRoutingCount(string plantID, string routingType);

        [OperationContract]
        void SaveRouting(Routing r);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proplanner.ServiceModel;
using ProLINK.Data;
using ProLINK.Data.Entity;
using System.ComponentModel.Composition;

namespace Proplanner.WCF.ClientProxy
{
    [Export(typeof(IProcess))]
    public class ProcessClientProxy : UserClientBase<IProcess>, IProcess
    {
        public Routing GetRouting(string id)
        {
            return Channel.GetRouting(id);
        }

        public int GetRoutingCount(string plantID, string routingType)
        {
            return Channel.GetRoutingCount(plantID, routingType);
        }

        public void SaveRouting(Routing r)
        {
            Channel.SaveRouting(r);
        }
    }
}

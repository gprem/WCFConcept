using ProLINK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProLINK.Data.Entity;

namespace Proplanner.WCF
{
    [ProplannerServiceBehaviorAttribute]
    public class ProcessService : ServiceBase, IProcess
    {
        public Routing GetRouting(string id)
        {
            //return ExecuteFaultHandledOperation(() =>
            //{
            //    throw new ArgumentException("Routing ID is invalid: " + this.LoginName);

            //    return new Routing { ID = id, Description = "Sample Routing" };
            //});

            throw new ArgumentException("Routing ID is invalid: ");
        }

        public int GetRoutingCount(string plantID, string routingType)
        {
            return 10;
        }

        public void SaveRouting(Routing r)
        {
            throw new NotImplementedException();
        }
    }
}

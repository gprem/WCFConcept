using ProLINK.Data;
using Proplanner.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Type> services = new List<Type> { typeof(ProcessService) };
            List<ServiceHost> hostList = new List<ServiceHost>();
            
            foreach (var serviceType in services)
            {
                ServiceHost host = new ServiceHost(serviceType);
                host.Open();

                hostList.Add(host);
            }

            Console.WriteLine("Service Host Started. Press any key to close...");

            Console.ReadKey();

            foreach (ServiceHost host in hostList)
            {
                host.Close();                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using Serilog;

namespace Proplanner.WCF
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProplannerServiceBehaviorAttribute : Attribute, IErrorHandler, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                channelDispatcher.ErrorHandlers.Add(this);
            }
        }

        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            Log.Error(error, string.Concat("Error occured in service: ", error.Message));

            FaultException faultException = new FaultException(error.Message);
            fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
           
        }
    }
}

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Proplanner.WCF
{
    public class ServiceBase
    {
        protected internal string LoginName { get; private set; }

        public ServiceBase()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                try
                {
                    LoginName = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("String", "System");
                    if (LoginName.IndexOf(@"\") > -1)
                        LoginName = string.Empty;
                }
                catch
                {
                    LoginName = string.Empty;
                }
            }

            Log.Logger = new LoggerConfiguration().WriteTo.RollingFile(".\\logs\\log-{Date}.txt").CreateLogger();
            Log.Information("Initializing the service: " + this.GetType().Name);
            
            //if (!string.IsNullOrWhiteSpace(_LoginName))
            //    _AuthorizationAccount = LoadAuthorizationValidationAccount(_LoginName);
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            //catch (AuthorizationValidationException ex)
            //{
            //    throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            //}
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}

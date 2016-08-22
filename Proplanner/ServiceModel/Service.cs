using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Proplanner.ServiceModel
{
    public static class Service<T> where T : IWCFServiceBase
    {
        public static void Execute(Action<T> codeToExecute)
        {
            T proxy = MEFLoader.GetContainer().GetExportedValueOrDefault<T>();

            try
            {
                codeToExecute.Invoke(proxy);
            }
            catch (FaultException<ExceptionDetail> fex)
            {
                throw fex.InnerException;
            }
            catch (FaultException ex)
            {
                //TODO: Log the exception
                throw new Exception(ex.Message);
            }
            finally
            {
                try
                {
                    IDisposable disposableClient = proxy as IDisposable;
                    if (disposableClient != null)
                        disposableClient.Dispose();
                }
                catch { }
            }
        }

        public static TResult Execute<TResult>(Func<T, TResult> function)
        {
            T proxy = MEFLoader.GetContainer().GetExportedValueOrDefault<T>();

            try
            {
                var result = function(proxy);
                return result;
            }
            catch (FaultException<ExceptionDetail> fex)
            {
                throw fex.InnerException;
            }
            catch (FaultException ex)
            {
                //TODO: Log the exception
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                try
                {
                    IDisposable disposableClient = proxy as IDisposable;
                    if (disposableClient != null)
                        disposableClient.Dispose();
                }
                catch { }
            }
        }
    }
}

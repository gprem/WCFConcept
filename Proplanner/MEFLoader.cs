using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Reflection;

namespace Proplanner
{
    public class MEFLoader
    {
        public static CompositionContainer GetContainer()
        {
            var rules = new RegistrationBuilder();
            rules.ForTypesDerivedFrom<IWCFServiceBase>()
                .Export()
                .SetCreationPolicy(CreationPolicy.NonShared);

            //Note: It has been assumed ALL ServiceClientProxy implementation will be located in this dll. 
            //      Change it to a more general Catalog like DirectoryCatalog if loading from multiple ones.
            AssemblyCatalog asyCatalog = new AssemblyCatalog(Assembly.LoadFrom("Proplanner.WCF.ClientProxy.dll"), rules);
            AggregateCatalog catalog = new AggregateCatalog(asyCatalog);

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }

    }
}

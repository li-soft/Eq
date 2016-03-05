using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Eq.StockDomain.Services;
using Eq.StockDomain.Models;

namespace Eq.StockDomain.Config
{
    public class ValuationDomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IValuationService>().ImplementedBy<ValuationService>());
            container.Register(Component.For<IValuationResult>().ImplementedBy<ValuationResult>());
        }
    }
}

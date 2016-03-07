using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Eq.StockDomain.Models.Valuation;
using Eq.StockDomain.Services.Implementation;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.StockDomain.Config
{
    /// <summary>
    /// Fund Domain IOC installer
    /// </summary>
    public class FundDomainInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Install all necessary services/types
        /// </summary>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IValuationService>().ImplementedBy<ValuationService>());
            container.Register(Component.For<IValuationResult>().ImplementedBy<ValuationResult>());
            container.Register(Component.For<IStockIdGenerator>().ImplementedBy<StockIdGenerator>());
            container.Register(Component.For<ITransactionService>().ImplementedBy<TransactionService>());

            container.Register(Component.For<IWallet>().Instance(new Wallet()).LifestyleSingleton());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleInjector;

using ThreeAmigos.Interfaces;
using ThreeAmigos.Data.Repository;
using ThreeAmigos.Integrations.Aggregator;
using ThreeAmigos.Integrations.BazzasBazaar;
using ThreeAmigos.Integrations.DavisonStore;
using ThreeAmigos.Integrations.Dispatcher;
using ThreeAmigos.Integrations.DodgyDealers;
using ThreeAmigos.Integrations.KhansMart;
using ThreeAmigos.Integrations.UnderCutters;
using ThreeAmigos.Services.Account;
using ThreeAmigos.Services.Store;
using ThreeAmigos.Services.Authentication;

namespace ThreeAmigos.IoC
{
    public static class DependencyRegistrar
    {
        public static void RegisterDependencies(Container container)
        {
            container.Register<IStoreRepository, StoreDataRepository>();
            container.Register<IStoreService, StoreService>();

            container.Register<IAccountRepository, AccountDataRepository>();
            container.Register<IAccountService, AccountService>();

            container.Register<IAuthenticationService, AuthenticationService>();

            // The store aggregator faces outwards towards the product supplier(s).
            container.Register<IStoreAggregator>(() => new StrategicStoreAggregator(
                new BestPriceStoreAggregationStrategy(), // Pull products based on best price.
                new BazzasBazaarAdapter("http://bazzasbazaar.azurewebsites.net/Store.svc"),
                new DavisonStoreAdapter("http://davisonstore.azurewebsites.net/"),
                //new DodgyDealersAdapter("http://dodgydealers.azurewebsites.net/"),
                new UnderCuttersAdapter("http://undercutters.azurewebsites.net/")));

            // The gift-wrapping supplier aggregator faces outward towards the gift-wrapping supplier(s).
            container.Register<IGiftWrappingSupplierAggregator>(() => new GiftWrappingSupplierAggregator(
                new KhansKwikiMartAdapter("http://khanskwikimart.azurewebsites.net/")));

            container.Register<IDispatcher, DispatcherWrapper>();

            container.Verify();
        }
    }
}

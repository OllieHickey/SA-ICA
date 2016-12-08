using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.BazzasBazzar
{
    /// <summary>
    /// An implementation of an adapter designed to work with the Bazza's Bazaar web service.
    /// </summary>
    public class BazzasBazaarAdapter : IStoreAdapter
    {
        private readonly StoreService.StoreClient _proxy;

        public Domain.Store.SupplierCode SupplierCode
        {
            get { return Domain.Store.SupplierCode.BazzasBazaar; }
        }

        /// <summary>
        /// Initializes a new instance of an adapter designed to work with the Bazza's Bazaar web service.
        /// </summary>
        public BazzasBazaarAdapter(string baseUrl)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                Name = "BasicHttpBinding_IStore"
            };
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            var endpointAddress = new EndpointAddress(baseUrl);
            _proxy = new StoreService.StoreClient(binding, endpointAddress);
        }

        private Domain.Store.Product ToDomainProduct(StoreService.Product product)
        {
            return new Domain.Store.Product
            {
                Brands = Enumerable.Empty<Domain.Store.Brand>(), // This integration doesn't use brands.
                Categories = new[]
                {
                    GetCategoryById(product.CategoryId)
                },
                Description = product.Description,
                Ean = product.Ean,
                Enabled = true,
                Name = product.Name,
                Prices = new[]
                {
                    new Domain.Store.Price
                    {
                        Amount = (decimal) product.PriceForOne,
                        Quantity = 1
                    },
                    new Domain.Store.Price
                    {
                        Amount = (decimal) product.PriceForTen,
                        Quantity = 10
                    }
                },
                ProviderId = product.Id,
                SupplierCode = Domain.Store.SupplierCode.BazzasBazaar
            };
        }

        private static Domain.Store.Category ToDomainCategory(StoreService.Category category)
        {
            return new Domain.Store.Category
            {
                Enabled = true,
                Name = category.Name,
                ProviderId = category.Id
            };
        }

        private Domain.Store.OrderLine ToDomainOrderLine(StoreService.Order order)
        {
            return new Domain.Store.OrderLine
            {
                SupplierCode = Domain.Store.SupplierCode.BazzasBazaar,
                Product = GetProductById(order.Id),
                OrderId = order.Id.ToString(),
                Quantity = order.Quantity
            };
        }

        public IEnumerable<Domain.Store.Product> GetAllProducts()
        {
            return _proxy.GetFilteredProducts(null, null, null, null).Select(ToDomainProduct);
        }

        public IEnumerable<Domain.Store.Product> SearchProducts(
            int? categoryId = null,
            string categoryName = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            // If we have a search by brand ID, just pass back an empty collection.
            if (brandId != null)
            {
                return Enumerable.Empty<Domain.Store.Product>();
            }

            return _proxy.GetFilteredProducts(categoryId, categoryName, (double?)minPrice, (double?)maxPrice)
                .Select(ToDomainProduct);
        }

        public Domain.Store.Product GetProductById(int id)
        {
            return ToDomainProduct(_proxy.GetProductById(id));
        }

        public IEnumerable<Domain.Store.Category> GetAllCategories()
        {
            return _proxy.GetAllCategories().Select(ToDomainCategory);
        }

        public Domain.Store.Category GetCategoryById(int id)
        {
            return ToDomainCategory(_proxy.GetCategoryById(id));
        }

        public IEnumerable<Domain.Store.Brand> GetAllBrands()
        {
            // This API doesn't use brands.
            return Enumerable.Empty<Domain.Store.Brand>();
        }

        public Domain.Store.Brand GetBrandById(int id)
        {
            // This API doesn't use brands.
            return null;
        }

        public Domain.Store.OrderLine PlaceOrder(int productId, int quantity, string accountName, string cardNumber)
        {
            return ToDomainOrderLine(_proxy.CreateOrder(accountName, cardNumber, productId, quantity));
        }

        public bool DeleteOrder(int id)
        {
            return _proxy.CancelOrderById(id);
        }

        public Domain.Store.OrderLine GetOrder(int id)
        {
            return ToDomainOrderLine(_proxy.GetOrderById(id));
        }
    }
}

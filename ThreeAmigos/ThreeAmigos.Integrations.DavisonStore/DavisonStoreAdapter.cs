using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.DavisonStore
{
    /// <summary>
    /// An implementation of an adapter designed to work with the Davison Store web service.
    /// </summary>
    public class DavisonStoreAdapter : IStoreAdapter
    {
        private readonly DavisonStoreProxy _proxy;

        public Domain.Store.SupplierCode SupplierCode
        {
            get { return Domain.Store.SupplierCode.DavisonStore; }
        }

        /// <summary>
        /// Initializes a new instance of an adapter designed to work with the Davison Store web service.
        /// </summary>
        public DavisonStoreAdapter(string baseUrl)
        {
            _proxy = new DavisonStoreProxy(baseUrl);
        }

        private Domain.Store.Product ToDomainProduct(Product product)
        {
            return new Domain.Store.Product
            {
                Brands = new[]
                {
                    GetBrandById(product.BrandId)
                },
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
                        Amount = product.Price,
                        Quantity = 1
                    }
                },
                ProviderId = product.Id,
                SupplierCode = Domain.Store.SupplierCode.DavisonStore
            };
        }

        private static Domain.Store.Category ToDomainCategory(Category category)
        {
            return new Domain.Store.Category
            {
                Enabled = true,
                Name = category.Name,
                ProviderId = category.Id
            };
        }

        private static Domain.Store.Brand ToDomainBrand(Brand brand)
        {
            return new Domain.Store.Brand
            {
                Enabled = true,
                Name = brand.Name,
                ProviderId = brand.Id
            };
        }

        private Domain.Store.OrderLine ToDomainOrderLine(Order order)
        {
            return new Domain.Store.OrderLine
            {
                SupplierCode = Domain.Store.SupplierCode.DavisonStore,
                Product = GetProductById(order.Id.GetValueOrDefault()),
                OrderId = order.Id.ToString(),
                Quantity = order.Quantity.GetValueOrDefault()
            };
        }

        public IEnumerable<Domain.Store.Product> GetAllProducts()
        {
            return _proxy.GetAllProducts().Select(ToDomainProduct);
        }

        public IEnumerable<Domain.Store.Product> SearchProducts(
            int? categoryId = null,
            string categoryName = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            return _proxy.SearchProducts(categoryId, categoryName, brandId, minPrice, maxPrice)
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
            return _proxy.GetAllBrands().Select(ToDomainBrand);
        }

        public Domain.Store.Brand GetBrandById(int id)
        {
            return ToDomainBrand(_proxy.GetBrandById(id));
        }

        public Domain.Store.OrderLine PlaceOrder(int productId, int quantity, string accountName, string cardNumber)
        {
            return ToDomainOrderLine(_proxy.PlaceOrder(productId, quantity, accountName, cardNumber));
        }

        public bool DeleteOrder(int id)
        {
            throw new System.NotImplementedException("This provider does not support order deletion.");
        }

        public Domain.Store.OrderLine GetOrder(int id)
        {
            throw new System.NotImplementedException("This provider does not support order retrieval.");
        }
    }
}

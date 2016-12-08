using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.Aggregator
{
    /// <summary>
    /// An implementation of a store adapter aggregator capable of querying multiple store adapters at once.
    /// </summary>
    public class StoreAggregator : IStoreAggregator
    {
        private readonly List<ISupplierError> _errors;

        /// <summary>
        /// Gets a set of store adapters aggregated by this instance.
        /// </summary>
        public IEnumerable<IStoreAdapter> Stores { get; private set; }

        /// <summary>
        /// Gets a collection of errors that occurred during the last operation on this aggregator.
        /// </summary>
        public IEnumerable<ISupplierError> Errors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Gets whether or not this aggregator experienced an error during its last operation.
        /// </summary>
        public bool HasErrors
        {
            get { return Errors.Any(); }
        }

        /// <summary>
        /// Initializes a new instance of a store adapter aggregator.
        /// </summary>
        /// <param name="stores">The store adapters to aggregate together.</param>
        public StoreAggregator(params IStoreAdapter[] stores)
        {
            _errors = new List<ISupplierError>();
            Stores = stores;
        }

        public virtual IEnumerable<Product> GetAllProducts()
        {
            _errors.Clear();
            return Stores.SelectMany(s =>
            {
                try
                {
                    return s.GetAllProducts();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, s.SupplierCode, "Method call to GetAllProducts failed."));
                    return Enumerable.Empty<Product>();
                }
            });
        }

        public virtual IEnumerable<Product> SearchProducts(
            int? categoryId = null,
            string categoryName = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            _errors.Clear();
            return Stores.SelectMany(s =>
            {
                try
                {
                    return s.SearchProducts(categoryId, categoryName, brandId, minPrice, maxPrice);
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, s.SupplierCode, "Method call to SearchProducts failed."));
                    return Enumerable.Empty<Product>();
                }
            });
        }

        public Product GetProductById(int id, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get product " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .GetProductById(id);
        }

        public virtual IEnumerable<Category> GetAllCategories()
        {
            _errors.Clear();
            return Stores.SelectMany(s =>
            {
                try
                {
                    return s.GetAllCategories();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, s.SupplierCode, "Method call to GetAllCategories failed."));
                    return Enumerable.Empty<Category>();
                }
            });
        }

        public Category GetCategoryById(int id, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get category " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .GetCategoryById(id);
        }

        public virtual IEnumerable<Brand> GetAllBrands()
        {
            _errors.Clear();
            return Stores.SelectMany(s =>
            {
                try
                {
                    return s.GetAllBrands();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, s.SupplierCode, "Method call to GetAllBrands failed."));
                    return Enumerable.Empty<Brand>();
                }
            });
        }

        public Brand GetBrandById(int id, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get brand " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .GetBrandById(id);
        }

        public OrderLine PlaceOrder(int productId, int quantity, string accountName, string cardNumber, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not place order " +
                    "because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .PlaceOrder(productId, quantity, accountName, cardNumber);
        }

        public bool DeleteOrder(int id, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not delete order " +
                    "because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .DeleteOrder(id);
        }

        public OrderLine GetOrder(int id, SupplierCode supplier)
        {
            if (Stores.All(s => s.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get order " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Stores.First(s => s.SupplierCode == supplier)
                .GetOrder(id);
        }

        public ApiHealthStatus GetHealthStatus(SupplierCode supplier)
        {
            // Send off 10 requests to see how many we get back.
            var store = Stores.First(s => s.SupplierCode == supplier);
            var success = 0;
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    store.GetAllProducts();
                    success++;
                }
                catch (Exception e)
                {
                    // Swallow exception.
                }
            }

            // Grade API health.
            if (success == 10)
            {
                return ApiHealthStatus.Good;
            }
            if (success > 5)
            {
                return ApiHealthStatus.Fair;
            }
            if (success > 0)
            {
                return ApiHealthStatus.Poor;
            }
            return ApiHealthStatus.Offline;
        }
    }
}
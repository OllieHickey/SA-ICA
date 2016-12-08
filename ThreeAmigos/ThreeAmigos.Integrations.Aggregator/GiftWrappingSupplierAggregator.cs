using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.Aggregator
{
    /// <summary>
    /// An implementation of a gift-wrapping supplier adapter aggregator capable of querying multiple gift-wrapping 
    /// supplier adapters at once.
    /// </summary>
    public class GiftWrappingSupplierAggregator : IGiftWrappingSupplierAggregator
    {
        private readonly List<ISupplierError> _errors;

        public IEnumerable<IGiftWrappingSupplierAdapter> Suppliers { get; private set; }

        public IEnumerable<ISupplierError> Errors
        {
            get { return _errors; }
        }

        public bool HasErrors
        {
            get { return Errors.Any(); }
        }

        /// <summary>
        /// Initializes a new instance of a gift-wrapping supplier adapter aggregator.
        /// </summary>
        /// <param name="stores">The gift-wrapping supplier adapters to aggregate together.</param>
        public GiftWrappingSupplierAggregator(params IGiftWrappingSupplierAdapter[] stores)
        {
            _errors = new List<ISupplierError>();
            Suppliers = stores;
        }

        public IEnumerable<GiftWrappingProduct> GetAllGiftWrappingProducts()
        {
            _errors.Clear();
            return Suppliers.SelectMany(p =>
            {
                try
                {
                    return p.GetAllGiftWrappingProducts();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, p.SupplierCode, "Method call to GetAllGiftWrappingProducts failed."));
                    return Enumerable.Empty<GiftWrappingProduct>();
                }
            });
        }

        public IEnumerable<GiftWrappingProduct> SearchGiftWrappingProducts(
            int? typeId = null,
            int? rangeId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minSize = null,
            decimal? maxSize = null)
        {
            _errors.Clear();
            return Suppliers.SelectMany(p =>
            {
                try
                {
                    return p.SearchGiftWrappingProducts(typeId, rangeId, minPrice, maxPrice, minSize, maxSize);
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, p.SupplierCode, "Method call to SearchGiftWrappingProducts failed."));
                    return Enumerable.Empty<GiftWrappingProduct>();
                }
            });
        }

        public GiftWrappingProduct GetGiftWrappingProductById(int id, SupplierCode supplier)
        {
            if (Suppliers.All(p => p.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get product " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Suppliers.First(p => p.SupplierCode == supplier)
                .GetGiftWrappingProductById(id);
        }

        public IEnumerable<GiftWrappingType> GetAllGiftWrappingTypes()
        {
            _errors.Clear();
            return Suppliers.SelectMany(p =>
            {
                try
                {
                    return p.GetAllGiftWrappingTypes();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, p.SupplierCode, "Method call to GetAllGiftWrappingTypes failed."));
                    return Enumerable.Empty<GiftWrappingType>();
                }
            });
        }

        public GiftWrappingType GetGiftWrappingTypeById(int id, SupplierCode supplier)
        {
            if (Suppliers.All(p => p.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get category " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Suppliers.First(p => p.SupplierCode == supplier)
                .GetGiftWrappingTypeById(id);
        }

        public IEnumerable<GiftWrappingRange> GetAllGiftWrappingRanges()
        {
            _errors.Clear();
            return Suppliers.SelectMany(p =>
            {
                try
                {
                    return p.GetAllGiftWrappingRanges();
                }
                catch (Exception ex)
                {
                    _errors.Add(new SupplierError(ex, p.SupplierCode, "Method call to GetAllGiftWrappingRanges failed."));
                    return Enumerable.Empty<GiftWrappingRange>();
                }
            });
        }

        public GiftWrappingRange GetGiftWrappingRangeById(int id, SupplierCode supplier)
        {
            if (Suppliers.All(p => p.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not get category " +
                    "by ID because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Suppliers.First(p => p.SupplierCode == supplier)
                .GetGiftWrappingRangeById(id);
        }

        public Order PlaceOrder(int productId, int quantity, string accountName, string cardNumber, SupplierCode supplier)
        {
            if (Suppliers.All(p => p.SupplierCode != supplier))
            {
                throw new NotSupportedException(string.Format("Could not place order " +
                    "because the supplier '{0}' was not found in the aggregator.", supplier));
            }
            return Suppliers.First(p => p.SupplierCode == supplier)
                .PlaceOrder(productId, quantity, accountName, cardNumber);
        }
    }
}
